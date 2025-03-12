using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;

namespace WPFLearn.OrderFood.Helper
{
    public class Appsettings
    {
        private static IConfiguration _configuration;
        public Appsettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static T? Get<T>(string key)
        {
            return _configuration.GetSection(key).Get<T>();
        }
    }
}
