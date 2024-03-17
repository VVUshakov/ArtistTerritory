using PaintingSellingBot.Configs;
using PRTelegramBot.Configs;
using PRTelegramBot.Core;


#region [Запуск PaintingSellingBot]

// Получить конфигурацию бота
var telegramConfig = ConfigApp.GetSettingsBot<TelegramConfig>();
// Получить экземпляр бота из библиотеки PRTelegramBot
var paintingSellingBot = new PRBot(telegramConfig);

// Подписаться на общие логи
paintingSellingBot.OnLogCommon += Telegram_OnLogCommon;
// Подписаться на логи ошибок
paintingSellingBot.OnLogError += Telegram_OnLogError;

// Запустить бот
await paintingSellingBot.Start();

#endregion [Запуск PaintingSellingBot]


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

#endregion [Держать консоль открытой]

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

#endregion [Логгирование]