using Microsoft.Extensions.Configuration;

namespace PaintingSellingBot.Configs
{
	public class ConfigApp
	{
		private static ConfigApp Instance;

		public IConfigurationRoot BotConfig { get; }

		public static ConfigApp GetInstance()
		{
			return Instance ??= new ConfigApp();
		}

		private ConfigApp()
		{
			BotConfig = new ConfigurationBuilder()
					 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					 .AddJsonFile("Configs/botconfig.json").Build();
		}

		public static T GetSettingsBot<T>()
		{
			var config = GetInstance().BotConfig;
			var section = config.GetSection(typeof(T).Name);
			return section.Get<T>();
		}
	}
}