using Microsoft.Extensions.Configuration;

namespace PaintingSellingBot.Configs
{
	public class ConfigDb
	{
		private static string _configFileName = "dbconfig";

		private static ConfigDb? Instance;

		public IConfigurationRoot Config { get; }

		public static ConfigDb GetInstance() => Instance ??= new ConfigDb();

		private ConfigDb() => Config = new ConfigurationBuilder()
					 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					 .AddJsonFile($"Configs/{_configFileName}.json").Build();

		public static T GetSettingsDb<T>()
		{
			var config = GetInstance().Config;
			var section = config.GetSection(typeof(T).Name);
			return section.Get<T>();
		}
	}
}