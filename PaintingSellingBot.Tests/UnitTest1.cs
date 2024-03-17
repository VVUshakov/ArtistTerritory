using Moq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PaintingSellingBot.Tests
{
	[TestFixture]
	public class EventsTests
	{
		/*
		[Test]
		public void OnAccessDenied_WhenUserIsDeniedAccess_ShouldSendMessage()
		{
			// Arrange
			var botclient = new Mock<ITelegramBotClient>();
			var update = new Update();

			// Act
			Events.OnAccessDenied(botclient.Object, update);

			// Assert
			botclient.Verify(x => x.SendTextMessageAsync(It.IsAny<long>(), "Неверный тип чата"), Times.Once);
		}
		*/

		[Test]
		public void OnCheckPrivilege_WhenUserHasPrivileges_ShouldCallCallback()
		{
			// Arrange
			var botclient = new Mock<ITelegramBotClient>();
			var update = new Update();
			var callback = new Mock<Func<ITelegramBotClient, Update, Task>>();
			var flags = 1;

			// Act
			Events.OnCheckPrivilege(botclient.Object, update, callback.Object, flags);

			// Assert
			callback.Verify(x => x(botclient.Object, update), Times.Once);
		}

		[Test]
		public void OnCheckPrivilege_WhenUserDoesNotHavePrivileges_ShouldNotCallCallback()
		{
			// Arrange
			var botclient = new Mock<ITelegramBotClient>();
			var update = new Update();
			var callback = new Mock<Func<ITelegramBotClient, Update, Task>>();
			var flags = 1;

			// Act
			Events.OnCheckPrivilege(botclient.Object, update, callback.Object, flags);

			// Assert
			callback.Verify(x => x(botclient.Object, update), Times.Never);
		}

		/*
		[Test]
		public void OnCheckPrivilege_WhenUserHasPrivileges_ShouldSendMessage()
		{
			// Arrange
			var botclient = new Mock<ITelegramBotClient>();
			var update = new Update();
			var callback = new Mock<Func<ITelegramBotClient, Update, Task>>();
			var flags = 1;

			// Act
			Events.OnCheckPrivilege(botclient.Object, update, callback.Object, flags);

			// Assert
			botclient.Verify(x => x.SendTextMessageAsync(It.IsAny<long>(), "Неверный тип чата"), Times.Never);
		}

		[Test]
		public void OnCheckPrivilege_WhenUserDoesNotHavePrivileges_ShouldSendMessage()
		{
			// Arrange
			var botclient = new Mock<ITelegramBotClient>();
			var update = new Update();
			var callback = new Mock<Func<ITelegramBotClient, Update, Task>>();
			var flags = 1;

			// Act
			Events.OnCheckPrivilege(botclient.Object, update, callback.Object, flags);

			// Assert
			botclient.Verify(x => x.SendTextMessageAsync(It.IsAny<long>(), "Неверный тип чата"), Times.Once);
		}

		[Test]
		public void OnCheckPrivilege_WhenUserHasPrivileges_ShouldNotSendMessage()
		{
			// Arrange
			var botclient = new Mock<ITelegramBotClient>();
			var update = new Update();
			var callback = new Mock<Func<ITelegramBotClient, Update, Task>>();
			var flags = 1;

			// Act
			Events.OnCheckPrivilege(botclient.Object, update, callback.Object, flags);

			// Assert
			botclient.Verify(x => x.SendTextMessageAsync(It.IsAny<long>(), "Неверный тип чата"), Times.Never);

		}
		*/
	}
}