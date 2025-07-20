using System.Globalization;
using ConfigurationLib.Models;
using ConfigurationLib.Providers;

namespace ConfigurationLib
{
    public class ConfigReader
    {
        private readonly string _applicationName;
        private readonly IConfigProvider _provider;
        private readonly int _refreshIntervalMs;
        private Dictionary<string, ConfigItem> _cache = new();
        private Timer _refreshTimer;

        public ConfigReader(string applicationName, IConfigProvider provider, int refreshIntervalMs)
        {
            _applicationName = applicationName;
            _provider = provider;
            _refreshIntervalMs = refreshIntervalMs;

            LoadValues(); 
            _refreshTimer = new Timer(_ => LoadValues(), null, refreshIntervalMs, refreshIntervalMs); 
        }

        private void LoadValues()
        {
            var items = _provider.LoadAll(_applicationName);           
            _cache = items.ToDictionary(x => x.Name, x => x);
        }

        public T GetValue<T>(string key)
        {
            var item = _cache.Values.FirstOrDefault(x => x.Name == key && x.IsActive);
            if (item is null || string.IsNullOrWhiteSpace(item.Value))
                return default;

            try
            {
                var targetType = typeof(T);

                if (targetType == typeof(bool))
                    return (T)(object)(item.Value.ToLower() == "true");

                if (targetType == typeof(int))
                    return (T)(object)int.Parse(item.Value);

                if (targetType == typeof(decimal))
                    return (T)(object)decimal.Parse(item.Value, CultureInfo.InvariantCulture);

                if (targetType == typeof(string))
                    return (T)(object)item.Value;

                return (T)Convert.ChangeType(item.Value, targetType);
            }
            catch
            {
                return default;
            }
        }

        public List<ConfigItem> GetAll(string applicationName)
        {
            return _cache.Values
                .Where(x => x.IsActive)
                .ToList();
        }
    }
}
