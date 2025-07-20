using ConfigurationLib;
using ConfigurationLib.Models;
using ConfigurationLib.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ConfigReader _reader;
        private readonly IConfigProvider _provider = new MongoConfigProvider(
          "mongodb://localhost:27017",
          "ConfigDB"
        );

        public ConfigController()
        {
            
            var provider = new InMemoryConfigurationProvider();
            _reader = new ConfigReader("SERVICE-A", provider, 10000);
        }

        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            try
            {
                var value = _reader.GetValue<string>(key);
                return Ok(new { Key = key, Value = value });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpGet("all/{applicationName}")]
        public IActionResult GetAll(string applicationName)
        {
            var allItems = _reader.GetAll(applicationName);
            return Ok(allItems);
        }
        [HttpPost]
        public IActionResult Add([FromBody] ConfigItem item)
        {
            _provider.Add(item);
            return Ok(new { Message = "Kayıt başarıyla eklendi", item });
        }
        [HttpPut]
        public IActionResult Update([FromBody] ConfigItem item)
        {
            _provider.Update(item);
            return Ok(new { Message = "Kayıt başarıyla güncellendi", item });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _provider.Delete(id);
                return Ok(new { Message = $"Id {id} başarıyla silindi" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
