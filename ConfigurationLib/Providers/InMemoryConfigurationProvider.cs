using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationLib.Models;

namespace ConfigurationLib.Providers
{
    public class InMemoryConfigurationProvider : IConfigProvider
    {
        private List<ConfigItem> _items = new()
        {
            new ConfigItem
            {
                Id = "1",
                Name = "SiteName",
                Type = "string",
                Value = "soty.io",
                IsActive = true,
                ApplicationName = "SERVICE-A"
            },
            new ConfigItem
            {
                Id = "2",
                Name = "MaxItemCount",
                Type = "int",
                Value = "50",
                IsActive = false,
                ApplicationName = "SERVICE-A"
            },
            new ConfigItem
            {
                Id = "3",
                Name = "IsBasketEnabled",
                Type = "bool",
                Value = "true",
                IsActive = true,
                ApplicationName = "SERVICE-B"
            }
        };

        public List<ConfigItem> LoadAll(string applicationName)
        {
            return _items
                .Where(x => x.ApplicationName == applicationName && x.IsActive)
                .ToList();
        }
        public void Add(ConfigItem item)
        {
            item.Id = Guid.NewGuid().ToString();
            _items.Add(item);
        }
        public void Update(ConfigItem item)
        {
            var existing = _items.FirstOrDefault(x => x.Id == item.Id);
            if (existing is not null)
            {
                existing.Name = item.Name;
                existing.Type = item.Type;
                existing.Value = item.Value;
                existing.IsActive = item.IsActive;
                existing.ApplicationName = item.ApplicationName;
            }
        }
        public void Delete(string id)
        {
            var itemToDelete = _items.FirstOrDefault(x => x.Id == id);
            if (itemToDelete is null)
                throw new KeyNotFoundException($"Id {id} ile eşleşen kayıt bulunamadı.");

            _items.Remove(itemToDelete);
        }
    }
}
