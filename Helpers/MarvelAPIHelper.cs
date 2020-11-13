using GlobalHeroes.Entities;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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

        public List<CharactersResponse> GetAllCharacters()
        {
            var charactersResponseList = new List<CharactersResponse>();

            var request = new RestRequest(baseURL+"characters");
            var firstResponse = Execute<CharactersResponse>(request);
            charactersResponseList.Add(firstResponse);

          //  var totalPages = (int.Parse(firstResponse.Data.Total)/100) + 1;

            //for (int i = 2; i < totalPages; i++)
            //{
            //    request = new RestRequest(baseURL + "characters");
            //    request.AddParameter("offset", i*100, ParameterType.QueryString);
            //    var currentResponse =  Execute<CharactersResponse>(request);
            //    charactersResponseList.Add(currentResponse);
            //}
            return charactersResponseList;
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            string ts = DateTime.Now.Ticks.ToString();

            request.AddParameter("ts", ts, ParameterType.QueryString);
            request.AddParameter("apikey", publicKey, ParameterType.QueryString);
            request.AddParameter("hash", GenerateHash(ts, privateKey, publicKey), ParameterType.QueryString);
            request.AddParameter("limit", 100, ParameterType.QueryString);
            var response = _client.Execute<T>(request);

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
    }
}
