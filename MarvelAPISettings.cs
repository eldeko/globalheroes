namespace GlobalHeroes
{
    public class MarvelAPISettings
    {
        public Keys Keys { get; set; }
   
        public string BaseURL { get; set; }
    }

    public class Keys
    {
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
    }
}