namespace health_checks_and_alerting.Settings
{
    public class RabbitMqSetting
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string VHost { get; set; }
        public int Port { get; set; }

        public string ConnectionString => 
            $"amqp://{UserName}:{Password}@{HostName}:{Port}/{VHost}";

    }
}