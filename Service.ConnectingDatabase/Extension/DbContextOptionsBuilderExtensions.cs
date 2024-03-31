using Microsoft.EntityFrameworkCore;


namespace PaintingSellingBot.Extension
{
	// Метод расширения для выбора используемой базы данных
	public static class DbContextOptionsBuilderExtensions
	{
		public static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string providerName)
		{
			string connectionString = string.Empty;




			switch(providerName)
			{
				case "SqlServer":
					builder.UseSqlServer(connectionString);
					break;

				case "Sqlite":
					builder.UseSqlite(connectionString);
					break;

				// Добавьте сюда другие провайдеры по аналогии

				// Обработка неизвестного провайдера
				default: throw new ArgumentException($"Unknown provider: {providerName}");
			}

			return builder;
		}
	}
}
