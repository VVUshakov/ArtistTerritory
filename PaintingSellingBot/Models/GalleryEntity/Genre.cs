using System.ComponentModel.DataAnnotations;

namespace PaintingSellingBot.Models.GalleryEntity
{
	/// <summary>
	/// Класс для сущности "Жанр исполнения картины"
	/// </summary>
	public class Genre
	{
		[Key] public required int GenreID { get; set; } // Первичный ключ
		[Required] public required string Name { get; set; } // Жанр исполнения картины

		/// <summary>
		/// Навигационное свойство для связи с сущностью "Picture".
		/// Отслеживание коллекции всех картин, созданных в одном жанре исполнения
		/// </summary>
		public virtual ICollection<Picture>? Pictures { get; set; }
	}
}
