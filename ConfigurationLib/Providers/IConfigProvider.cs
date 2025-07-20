using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationLib.Models;

namespace ConfigurationLib.Providers
{
    public interface IConfigProvider
    {
        List<ConfigItem> LoadAll(string applicationName);
        void Add(ConfigItem item);
        void Update(ConfigItem item);
        void Delete(string id);
    }
}
