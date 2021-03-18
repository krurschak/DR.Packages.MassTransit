using System;
using System.Linq;
using System.Reflection;

namespace DR.Packages.MassTransit
{
    [Serializable]
    public class RabbitMqOptions
    {
        public RabbitMqOptions()
        {
            ApplicationName = Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;
        }

        public RabbitMqOptions(string connectionString)
        {
            var parts = connectionString
                .Split(';')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x));

            foreach (var part in parts)
            {
                foreach (var property in GetType().GetProperties())
                {
                    if (part.StartsWith(property.Name))
                    {
                        if (property.Name == "Port")
                            property.SetValue(this, Convert.ToUInt16(part.Replace(property.Name + '=', string.Empty)));
                        else
                            property.SetValue(this, part.Replace(property.Name + '=', string.Empty));

                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(ApplicationName))
            {
                ApplicationName = Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;
            }
        }

        public string Host { get; set; } = "localhost";
        public ushort Port { get; set; } = 5672;
        public string VHost { get; set; } = "/";
        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string ApplicationName { get; set; } = string.Empty;
    }
}
