namespace RestaurantApp
{
    public class Appsetting
    {
        public string SecretKey { get; set; }
        public string DB_PROTOCOL { get; set; }
        public string DB_HOST { get; set; }
        public string DB_PORT { get; set; }
        public string DB_SERVICE_NAME { get; set; }
        public string DB_USERID { get; set; }
        public string DB_PASSWORD { get; set; }
        public string LocalOriginURL { get; set; }
        public string UatOriginURL { get; set; }
        public string ProdOriginURL { get; set; }
        public string CSP_LocalOriginURL { get; set; }
    }
}
