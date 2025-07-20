using ConfigurationLib.Models;
using ConfigurationLib.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConfigDashboard.Pages
{
    public class IndexModel : PageModel
    {
        public List<ConfigItem> Configs { get; set; } = new();

        [BindProperty]
        public ConfigItem NewConfig { get; set; } = new();

        public void OnGet()
        {
            var provider = new MongoConfigProvider("mongodb://localhost:27017", "ConfigDB");
            Configs = provider.LoadAll("SERVICE-A");
        }

        public IActionResult OnPostAdd()
        {
            var provider = new MongoConfigProvider("mongodb://localhost:27017", "ConfigDB");
            provider.Add(NewConfig);
            return RedirectToPage(); 
        }

        public IActionResult OnPostDelete(string id)
        {
            var provider = new MongoConfigProvider("mongodb://localhost:27017", "ConfigDB");
            provider.Delete(id);
            return RedirectToPage();
        }
        [BindProperty]
        public ConfigItem EditedConfig { get; set; } = new();

        public IActionResult OnPostUpdate()
        {
            var provider = new MongoConfigProvider("mongodb://localhost:27017", "ConfigDB");
            provider.Update(EditedConfig);
            return RedirectToPage();
        }
    }

}
