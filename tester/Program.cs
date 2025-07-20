using ConfigurationLib.Providers;
using ConfigurationLib;

Console.WriteLine("Hello, World!");
var provider = new MongoConfigProvider("mongodb://localhost:27017", "ConfigDB");
var reader = new ConfigReader("SERVICE-TEST", provider, 3000);

int maxCount = reader.GetValue<int>("MaxItemCount");
Console.WriteLine($"Max item count from MongoDB: {maxCount}");