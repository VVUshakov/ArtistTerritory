namespace PaintingSellingBot.Extension
{
	public static class UserUpdate
	{
		public static PaintingSellingBot.Models.Enums.UserPrivilege GetFlagPrivilege(this Telegram.Bot.Types.Update update)
			=> PaintingSellingBot.Models.Enums.UserPrivilege.Registered;

		public static List<int> GetIntPrivilege(this Telegram.Bot.Types.Update update)
			=> update is null ? throw new ArgumentNullException(nameof(update)) : ([1, 2]);
	}
}
