using GlobalHeroes.Entities;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHeroes.Helpers
{
    public class MarvelAPIHelper : IMarvelAPIHelper
    {
        private readonly IRestClient _client;
        private readonly string baseURL;
        private readonly string privateKey;
        private readonly string publicKey;

        public MarvelAPIHelper(IOptions<MarvelAPISettings> config)
        {
            baseURL = config.Value.BaseURL;
            privateKey = config.Value.Keys.PrivateKey;
            publicKey = config.Value.Keys.PublicKey;
            _client = new RestClient(baseURL);
        }
        
        public async Task<List<CharactersResponse>> GetAllCharacters()
        {
            int totalPages = GetTotalCountOfPages();
           
            var tasks = new List<Task<CharactersResponse>>();
            var returnList = new List<CharactersResponse>();

            for (int i = 0; i <= totalPages; i++)
            {
               var request = new RestRequest(baseURL + "characters");
                request.AddParameter("offset", i * 100, ParameterType.QueryString);

                var currentResponse = Task.Run(()=> Execute<RestRequest>(request));

                tasks.Add(currentResponse);
            }

             await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                returnList.Add(task.Result); 
            }

            return returnList;
        }

        private int GetTotalCountOfPages()
        {          
            var firstRequest = new RestRequest(baseURL + "characters");
            AddDefaultParameters(firstRequest);
            firstRequest.AddOrUpdateParameter("limit", 1, ParameterType.QueryString);
            var FirstTask =  _client.Execute<CharactersResponse>(firstRequest);

            return (int.Parse(FirstTask.Data.Data.Total) / 100) + 1;
        }

        private CharactersResponse Execute<T>(RestRequest request) where T : new()
        {
            string ts = DateTime.Now.Ticks.ToString();

            request.AddParameter("ts", ts, ParameterType.QueryString);
            request.AddParameter("apikey", publicKey, ParameterType.QueryString);
            request.AddParameter("hash", GenerateHash(ts, privateKey, publicKey), ParameterType.QueryString);
            request.AddParameter("limit", 100, ParameterType.QueryString);
            var response = _client.Execute<CharactersResponse>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var MarvelException = new Exception(message, response.ErrorException);
                throw MarvelException;
            }
            return response.Data;
        }

        private static string GenerateHash(string ts, string pvKey, string pbKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + pvKey + pbKey);
            var generator = MD5.Create();
            byte[] bytesHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }

        private RestRequest AddDefaultParameters(RestRequest request)
        {
            string ts = DateTime.Now.Ticks.ToString();

            request.AddParameter("ts", ts, ParameterType.QueryString);
            request.AddParameter("apikey", this.publicKey, ParameterType.QueryString);
            request.AddParameter("hash", GenerateHash(ts, privateKey, publicKey), ParameterType.QueryString);
            request.AddParameter("limit", 100, ParameterType.QueryString);
            return request;

        }
    }
}
