using System.Configuration;

namespace BrokerMVC
{
    public class AppSettingKeysVariables
    {
        public static string GoogleMapsKey => ConfigurationSettings.AppSettings[nameof(GoogleMapsKey)];
        public static string GoogleAuthenticationClientId => ConfigurationSettings.AppSettings[nameof(GoogleAuthenticationClientId)];
        public static string GoogleAuthenticationClientSecret => ConfigurationSettings.AppSettings[nameof(GoogleAuthenticationClientSecret)];
        public static string FacebookAuthenticationAppId => ConfigurationSettings.AppSettings[nameof(FacebookAuthenticationAppId)];
        public static string FacebookAuthenticationAppSecret => ConfigurationSettings.AppSettings[nameof(FacebookAuthenticationAppSecret)];
    }
}