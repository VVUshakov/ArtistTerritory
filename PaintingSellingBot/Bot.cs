﻿/*
#region [Создание/Миграция БД]

var optionsBuilder = new DbContextOptionsBuilder<PaintingSellingBot.Models.GalleryEntity.GalleryDbContext>();

// Здесь мы пытаемся получить строку подключения из конфигурации или другого источника
string connectionString = string.Empty;// = GetConnectionStringFromConfiguration();

if(!string.IsNullOrEmpty(connectionString))
{
	// Если строка подключения получена, используем ее для настройки контекста
	optionsBuilder.UseDatabase("SQLite");
}
else
{
	// Если строка подключения не получена, выводим сообщение об ошибке
	Console.WriteLine("Connection string not found.");
	return;
}

using(var context = new PaintingSellingBot.Models.GalleryEntity.GalleryDbContext(optionsBuilder.Options))
{
	context.Database.EnsureCreated();
}

#endregion
*/

#region [Запустить Бот]

/*
// Получить конфигурацию бота
PRTelegramBot.Configs.TelegramConfig telegramConfig
	= PaintingSellingBot.Configs.ConfigApp.GetSettings<PRTelegramBot.Configs.TelegramConfig>();

// Получить экземпляр бота из библиотеки PRTelegramBot
PRTelegramBot.Core.PRBot bot = new(telegramConfig);
*/

// Получить экземпляр бота из библиотеки PRTelegramBot
PRTelegramBot.Core.PRBot bot = new(PaintingSellingBot.Configs.ConfigApp.GetSettings<PRTelegramBot.Configs.TelegramConfig>());

// Инициализировать обработчики событий
HandlerInit(bot);

// Запустить бот
await bot.Start();

#endregion

/*
#region[ПРИМЕР ИСПОЛЬЗОВАНИЯ СЕРВИСОВ]
// Пример использования
public class Service1
{
	private readonly IConfigBuilder _config;

	public Service1(IConfigBuilder config)
	{
		_config = config;
	}

	public void DoSomething()
	{
		// Используем конфигурацию для сервиса 1
		var settings = _config.GetSettings<Service1Settings>();
		// ...
	}
}

public class Service2
{
	private readonly IConfigBuilder _config;

	public Service2(IConfigBuilder config)
	{
		_config = config;
	}

	public void DoSomethingElse()
	{
		// Используем конфигурацию для сервиса 2
		var settings = _config.GetSettings<Service2Settings>();
		// ...
	}
}

// Создание экземпляров сервисов с соответствующими конфигурациями
var service1Config = ConfigBuilderFactory.GetInstance<AppConfig>();
var service2Config = ConfigBuilderFactory.GetInstance<DbConfig>();

var service1 = new Service1(service1Config);
var service2 = new Service2(service2Config);

service1.DoSomething();
service2.DoSomethingElse();
#endregion
*/

#region [Держать консоль открытой]

//Команда для завершения приложения
const string EXIT_COMMAND = "exit";

// Уведомление о запуске программы 
Console.WriteLine("Программа запущена");
// Уведомление о команде закрытия программы 
Console.WriteLine($"Для закрытия программы напишите {EXIT_COMMAND}");

// Ожидание ввода команды
while(true)
{
	// Игнорировать регистр сравниваемых строк
	if(Console.ReadLine().Equals(EXIT_COMMAND, StringComparison.CurrentCultureIgnoreCase))
	{
		Environment.Exit(0);
	}
}

#endregion

#region [Подписать на события]

void HandlerInit(PRTelegramBot.Core.PRBot bot)
{
	if(bot.Handler != null)
	{
		// Подписаться на общие логи
		bot.OnLogCommon += Telegram_OnLogCommon;

		// Подписаться на логи ошибок
		bot.OnLogError += Telegram_OnLogError;

		//Обработка: обновление 
		bot.Handler.OnPreUpdate += Handler_OnUpdate;

		//Обработка: обновление кроме message и callback
		bot.Handler.OnPostMessageUpdate += Handler_OnWithoutMessageUpdate;

		//Обработка: не правильный тип сообщений
		bot.Handler.Router.OnWrongTypeMessage += PaintingSellingBot.Events.OnWrongTypeMessage;

		//Обработка: пользователь написал в чат start с deeplink
		bot.Handler.Router.OnUserStartWithArgs += PaintingSellingBot.Events.OnUserStartWithArgs;

		//Обработка: проверка привилегий
		bot.Handler.Router.OnCheckPrivilege += PaintingSellingBot.Events.OnCheckPrivilege;

		//Обработка не верного типа чата
		bot.Handler.Router.OnWrongTypeChat += PaintingSellingBot.Events.OnWrongTypeChat;

		//Обработка локаций
		bot.Handler.Router.OnLocationHandle += PaintingSellingBot.Events.OnLocationHandle;

		//Обработка контактных данных
		bot.Handler.Router.OnContactHandle += PaintingSellingBot.Events.OnContactHandle;

		//Обработка голосований
		bot.Handler.Router.OnPollHandle += PaintingSellingBot.Events.OnPollHandle;

		//Обработка WebApps
		bot.Handler.Router.OnWebAppsHandle += PaintingSellingBot.Events.OnWebAppsHandle;

		//Обработка, когда пользователю отказано в доступе
		bot.Handler.Router.OnAccessDenied += PaintingSellingBot.Events.OnAccessDenied;

		//Обработка сообщения с документом
		bot.Handler.Router.OnDocumentHandle += PaintingSellingBot.Events.OnDocumentHandle;

		//Обработка сообщения с аудио
		bot.Handler.Router.OnAudioHandle += PaintingSellingBot.Events.OnAudioHandle;

		//Обработка сообщения с видео
		bot.Handler.Router.OnVideoHandle += PaintingSellingBot.Events.OnVideoHandle;

		//Обработка сообщения с фото
		bot.Handler.Router.OnPhotoHandle += PaintingSellingBot.Events.OnPhotoHandle;

		//Обработка сообщения со стикером
		bot.Handler.Router.OnStickerHandle += PaintingSellingBot.Events.OnStickerHandle;

		//Обработка сообщения с голосовым сообщением
		bot.Handler.Router.OnVoiceHandle += PaintingSellingBot.Events.OnVoiceHandle;

		//Обработка сообщения с неизвестным типом
		bot.Handler.Router.OnUnknownHandle += PaintingSellingBot.Events.OnUnknownHandle;

		//Обработка сообщения с местоположением
		bot.Handler.Router.OnVenueHandle += PaintingSellingBot.Events.OnVenueHandle;

		//Обработка сообщения с игрой
		bot.Handler.Router.OnGameHandle += PaintingSellingBot.Events.OnGameHandle;

		//Обработка сообщения с видеозаметкой
		bot.Handler.Router.OnVideoNoteHandle += PaintingSellingBot.Events.OnVideoNoteHandle;

		//Обработка сообщения с игральной костью
		bot.Handler.Router.OnDiceHandle += PaintingSellingBot.Events.OnDiceHandle;

		//Обработка пропущенной  команды (отсутсвующей в подписках)
		bot.Handler.Router.OnMissingCommand += PaintingSellingBot.Events.OnMissingCommand;
	}
	/*
	tg.RegisterInlineCommand(AddCustomTHeader.TestAddCommand, async (botClient, update) =>
	{
		PRTelegramBot.Helpers.Message.Send(botClient, update, "Тест метода TestAddCommand");
	});

	tg.RegisterInlineCommand(AddCustomTHeader.TestAddCommandTwo, async (botClient, update) =>
	{
		PRTelegramBot.Helpers.Message.Send(botClient, update, "Тест метода TestAddCommandTwo");
	});
	*/
}

// Обработчик_Обновление 
async Task<PRTelegramBot.Models.Enums.ResultUpdate> Handler_OnUpdate(Telegram.Bot.ITelegramBotClient client, Telegram.Bot.Types.Update update)
	=> PRTelegramBot.Models.Enums.ResultUpdate.Continue;

// Обрабочик_Обновление (кроме message и callback)
async Task Handler_OnWithoutMessageUpdate(Telegram.Bot.ITelegramBotClient botclient, Telegram.Bot.Types.Update update)
{
	//Обработка обновление кроме message и callback
}

// Обработка общих ошибок
void Telegram_OnLogError(Exception ex, long? id = null)
{
	Console.ForegroundColor = ConsoleColor.Red;
	string errorMsg = $"{DateTime.Now}: {ex}";
	Console.WriteLine(errorMsg);
	Console.ResetColor();
}

// Обработка общих логов
void Telegram_OnLogCommon(string msg, Enum? eventType, ConsoleColor color = ConsoleColor.Blue)
{
	Console.ForegroundColor = color;
	string formatMsg = $"{DateTime.Now}: {msg}";
	Console.WriteLine(formatMsg);
	Console.ResetColor();
}

#endregion
