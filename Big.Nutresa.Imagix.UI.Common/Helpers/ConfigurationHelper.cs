using System.Configuration;

namespace Big.Nutresa.Imagix.UI.Common.Helpers
{
    public class ConfigurationHelper
    {
        public static string  Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
