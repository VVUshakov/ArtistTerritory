using Microsoft.Extensions.Configuration;

namespace PaintingSellingBot.Configs
{
	// Интерфейс для получения настроек
	public interface IConfigBuilder
	{
		IConfigurationRoot Config { get; }
		T GetSettings<T>();
	}

	// Базовый класс для конфигурации
	public abstract class ConfigBuilderBase : IConfigBuilder
	{
		public IConfigurationRoot Config { get; private set; }

		protected ConfigBuilderBase(string configFileName)
		{
			Config = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile($"Configs/{configFileName}.json")
				.Build();
		}

		public virtual T GetSettings<T>()
		{
			var section = Config.GetSection(typeof(T).Name);
			return section.Get<T>();
		}
	}

	// Конкретный класс конфигурации для приложения
	public class AppConfig : ConfigBuilderBase
	{
		public AppConfig() : base("appconfig") { }
	}

	// Конкретный класс конфигурации для базы данных
	public class DbConfig : ConfigBuilderBase
	{
		public DbConfig() : base("dbconfig") { }
	}

	// Класс для создания экземпляров конфигураций
	public static class ConfigBuilderFactory
	{
		public static IConfigBuilder GetInstance<T>() where T : ConfigBuilderBase, new()
		{
			return new T();
		}
	}

}