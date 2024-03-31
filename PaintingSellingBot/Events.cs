using PaintingSellingBot.Extension;

namespace PaintingSellingBot
{
	public class Events
	{
		/// <summary>Обработка_Пользователю отказано в доступе</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnAccessDenied(Telegram.Bot.ITelegramBotClient botclient,
												Telegram.Bot.Types.Update update)
		{
			//Обработка данных
		}

		/// <summary>Обработка WebApps</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnWebAppsHandle(Telegram.Bot.ITelegramBotClient botclient,
												 Telegram.Bot.Types.Update update)
		{
			var webApp = update.Message.WebAppData;
			//Обработка данных
		}

		/// <summary>Обработка голосований</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnPollHandle(Telegram.Bot.ITelegramBotClient botclient,
											  Telegram.Bot.Types.Update update)
		{
			var poll = update.Message.Poll;
			//Обработка данных
		}

		/// <summary>Обработка контактных данных</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnContactHandle(Telegram.Bot.ITelegramBotClient botclient,
												 Telegram.Bot.Types.Update update)
		{
			var contact = update.Message.Contact;
			//Обработка данных
		}

		/// <summary>Обработчик локации</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnLocationHandle(Telegram.Bot.ITelegramBotClient botclient,
												  Telegram.Bot.Types.Update update)
		{
			var location = update.Message.Location;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с местоположением</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnVenueHandle(Telegram.Bot.ITelegramBotClient botclient,
											   Telegram.Bot.Types.Update update)
		{
			var venue = update.Message.Venue;
			//Обработка данных
		}

		/// <summary>Обработка_Не верный тип чата</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnWrongTypeChat(Telegram.Bot.ITelegramBotClient botclient,
												 Telegram.Bot.Types.Update update)
		{
			string msg = "Неверный тип чата";
			await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
		}

		/// <summary>Обработка_Не найдена команда</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnMissingCommand(Telegram.Bot.ITelegramBotClient botclient,
												  Telegram.Bot.Types.Update update)
		{
			string msg = "Не найдена команда";
			await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
		}

		/// <summary>Событие_Проверка привилегий пользователя</summary>
		/// <param name="callback">callback функция выполняется в случае успеха</param>
		/// <param name="flags">Флаги которые должны присуствовать</param>
		public static async Task OnCheckPrivilege(Telegram.Bot.ITelegramBotClient botclient,
												  Telegram.Bot.Types.Update update,
												  Func<Telegram.Bot.ITelegramBotClient, Telegram.Bot.Types.Update, Task> callback,
												  int? flags = null)
		{
			if(flags != null)
			{
				var flag = flags.Value;

				//Проверяем флаги через int
				if(update.GetIntPrivilege().Contains(flag))
				{
					await callback(botclient, update);
					return;
				}

				//Проверяем флаги через enum UserPrivilage
				if(((PaintingSellingBot.Models.Enums.UserPrivilege)flag).HasFlag(update.GetFlagPrivilege()))
				{
					await callback(botclient, update);
					return;
				}

				string errorMsg = "У вас нет доступа к данной функции";
				await PRTelegramBot.Helpers.Message.Send(botclient, update, errorMsg);
				return;
			}
			string msg = "Проверка привилегий";
			await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
		}

		/// <summary>Обработка сообщения с игрой</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnGameHandle(Telegram.Bot.ITelegramBotClient botclient,
											  Telegram.Bot.Types.Update update)
		{
			var game = update.Message.Game;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с игральной костью</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnDiceHandle(Telegram.Bot.ITelegramBotClient botclient,
											  Telegram.Bot.Types.Update update)
		{
			var dice = update.Message.Dice;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с неизвестным типом</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnUnknownHandle(Telegram.Bot.ITelegramBotClient botclient,
												 Telegram.Bot.Types.Update update)
		{
			//Обработка данных
		}

		/// <summary>Обработка_Не правильный тип сообщений</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnWrongTypeMessage(Telegram.Bot.ITelegramBotClient botclient,
													Telegram.Bot.Types.Update update)
		{
			string msg = "Неверный тип сообщения";
			await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
		}

		/// <summary>Обработка сообщения с голосовым сообщением</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnVoiceHandle(Telegram.Bot.ITelegramBotClient botclient,
											   Telegram.Bot.Types.Update update)
		{
			var voice = update.Message.Voice;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с аудио</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnAudioHandle(Telegram.Bot.ITelegramBotClient botclient,
											   Telegram.Bot.Types.Update update)
		{
			var audio = update.Message.Audio;
			//Обработка данных
		}

		/// <summary>Обработка сообщения со стикером</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnStickerHandle(Telegram.Bot.ITelegramBotClient botclient,
												 Telegram.Bot.Types.Update update)
		{
			var sticker = update.Message.Sticker;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с фото</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnPhotoHandle(Telegram.Bot.ITelegramBotClient botclient,
											   Telegram.Bot.Types.Update update)
		{
			var photo = update.Message.Photo;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с видео</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnVideoHandle(Telegram.Bot.ITelegramBotClient botclient,
											   Telegram.Bot.Types.Update update)
		{
			var video = update.Message.Video;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с видеозаметкой</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnVideoNoteHandle(Telegram.Bot.ITelegramBotClient botclient,
												   Telegram.Bot.Types.Update update)
		{
			var videonote = update.Message.VideoNote;
			//Обработка данных
		}

		/// <summary>Обработка сообщения с документом</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		public static async Task OnDocumentHandle(Telegram.Bot.ITelegramBotClient botclient,
												  Telegram.Bot.Types.Update update)
		{
			var document = update.Message.Document;
			//Обработка данных
		}

		/// <summary>Обработка_Пользователь написал в чат start с deeplink (с аргументом)</summary>
		/// <param name="botclient">Текущий запущенный клиент бота</param>
		/// <param name="update">Обновление от бота</param>
		/// <param name="args">Сообщение при первом запуске бота</param>
		public static async Task OnUserStartWithArgs(Telegram.Bot.ITelegramBotClient botclient,
													 Telegram.Bot.Types.Update update,
													 string args)
		{
			string msg = "Пользователь отправил старт с аргументом";
			await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
		}
	}
}
