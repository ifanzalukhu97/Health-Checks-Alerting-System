namespace health_checks_and_alerting.Settings
{
    public class RedisSetting
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Db { get; set; }
        
        public string ConnectionString => $"{Host}:{Port},defaultDatabase={Db}";

    }
}