using Microsoft.Extensions.Configuration;

namespace PaintingSellingBot.Configs
{
	public class ConfigApp
	{
		private static string _configFileName = "botconfig";

		private static ConfigApp? Instance;

		public IConfigurationRoot Config { get; }

		public static ConfigApp GetInstance() => Instance ??= new ConfigApp();

		private ConfigApp() => Config = new ConfigurationBuilder()
					 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					 .AddJsonFile($"Configs/{_configFileName}.json").Build();

		public static T GetSettings<T>()
		{
			var config = GetInstance().Config;
			var section = config.GetSection(typeof(T).Name);
			return section.Get<T>();
		}
	}
}