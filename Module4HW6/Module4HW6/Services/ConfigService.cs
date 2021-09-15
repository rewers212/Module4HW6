using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module4HW6.Configs;
using Newtonsoft.Json;

namespace Module4HW6
{
    public class ConfigService
    {
        private readonly string _filePath = "Config.json";
        private readonly ConnectionStringConfig _connectionStringConfig;

        public ConfigService()
        {
            _connectionStringConfig = GetConfig();
        }
        public string ConnectionString => _connectionStringConfig.ConnectionString;

        private ConnectionStringConfig GetConfig()
        {
            var configFile = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<ConnectionStringConfig>(configFile);
        }
    }
}
