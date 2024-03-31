#region [Запуск Бота]

// Получить конфигурацию бота
PRTelegramBot.Configs.TelegramConfig telegramConfig = PaintingSellingBot.Configs.ConfigApp.GetSettingsBot<PRTelegramBot.Configs.TelegramConfig>();
// Получить экземпляр бота из библиотеки PRTelegramBot
PRTelegramBot.Core.PRBot bot = new(telegramConfig);

// Подписаться на общие логи
bot.OnLogCommon += Telegram_OnLogCommon;
// Подписаться на логи ошибок
bot.OnLogError += Telegram_OnLogError;

// Запустить бот
await bot.Start();

// Инициализировать обработчики событий
HandlerInit(bot);

#endregion

// Подписать на события
void HandlerInit(PRTelegramBot.Core.PRBot tg)
{
	if(tg.Handler != null)
	{
		//Обработка: обновление 
		tg.Handler.OnPreUpdate += Handler_OnUpdate;

		//Обработка: обновление кроме message и callback
		tg.Handler.OnPostMessageUpdate += Handler_OnWithoutMessageUpdate;

		//Обработка: не правильный тип сообщений
		tg.Handler.Router.OnWrongTypeMessage += PaintingSellingBot.Events.OnWrongTypeMessage;

		//Обработка: пользователь написал в чат start с deeplink
		tg.Handler.Router.OnUserStartWithArgs += PaintingSellingBot.Events.OnUserStartWithArgs;

		//Обработка: проверка привилегий
		tg.Handler.Router.OnCheckPrivilege += PaintingSellingBot.Events.OnCheckPrivilege;		
		
		//Обработка не верного типа чата
		tg.Handler.Router.OnWrongTypeChat += PaintingSellingBot.Events.OnWrongTypeChat;

		//Обработка локаций
		tg.Handler.Router.OnLocationHandle += PaintingSellingBot.Events.OnLocationHandle;

		//Обработка контактных данных
		tg.Handler.Router.OnContactHandle += PaintingSellingBot.Events.OnContactHandle;

		//Обработка голосований
		tg.Handler.Router.OnPollHandle += PaintingSellingBot.Events.OnPollHandle;

		//Обработка WebApps
		tg.Handler.Router.OnWebAppsHandle += PaintingSellingBot.Events.OnWebAppsHandle;

		//Обработка, когда пользователю отказано в доступе
		tg.Handler.Router.OnAccessDenied += PaintingSellingBot.Events.OnAccessDenied;

		//Обработка сообщения с документом
		tg.Handler.Router.OnDocumentHandle += PaintingSellingBot.Events.OnDocumentHandle;

		//Обработка сообщения с аудио
		tg.Handler.Router.OnAudioHandle += PaintingSellingBot.Events.OnAudioHandle;

		//Обработка сообщения с видео
		tg.Handler.Router.OnVideoHandle += PaintingSellingBot.Events.OnVideoHandle;

		//Обработка сообщения с фото
		tg.Handler.Router.OnPhotoHandle += PaintingSellingBot.Events.OnPhotoHandle;

		//Обработка сообщения со стикером
		tg.Handler.Router.OnStickerHandle += PaintingSellingBot.Events.OnStickerHandle;

		//Обработка сообщения с голосовым сообщением
		tg.Handler.Router.OnVoiceHandle += PaintingSellingBot.Events.OnVoiceHandle;

		//Обработка сообщения с неизвестным типом
		tg.Handler.Router.OnUnknownHandle += PaintingSellingBot.Events.OnUnknownHandle;

		//Обработка сообщения с местоположением
		tg.Handler.Router.OnVenueHandle += PaintingSellingBot.Events.OnVenueHandle;

		//Обработка сообщения с игрой
		tg.Handler.Router.OnGameHandle += PaintingSellingBot.Events.OnGameHandle;

		//Обработка сообщения с видеозаметкой
		tg.Handler.Router.OnVideoNoteHandle += PaintingSellingBot.Events.OnVideoNoteHandle;

		//Обработка сообщения с игральной костью
		tg.Handler.Router.OnDiceHandle += PaintingSellingBot.Events.OnDiceHandle;

		//Обработка пропущенной  команды (отсутсвующей в подписках)
		tg.Handler.Router.OnMissingCommand += PaintingSellingBot.Events.OnMissingCommand;
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

#region [Держать консоль открытой]

//Команда для завершения приложения
const string EXIT_COMMAND = "exit";

// Уведомление о запуске программы 
Console.WriteLine("Запуск программы");
// Уведомление о команде закрытия программы 
Console.WriteLine($"Для закрытие программы напишите {EXIT_COMMAND}");

//Ожидание ввода команды
while(true)
{
	if(Console.ReadLine().ToLower() == EXIT_COMMAND)
	{
		Environment.Exit(0);
	}
}

#endregion

#region [Логгирование]

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