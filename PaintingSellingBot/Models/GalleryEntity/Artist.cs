using System.ComponentModel.DataAnnotations;

namespace PaintingSellingBot.Models.GalleryEntity
{
	/// <summary>
	/// Класс для сущности "Художник"
	/// </summary>
	public class Artist
	{
		[Key] public required int ArtistID { get; set; } // Первичный ключ
		[Required] public required string Name { get; set; } // Художник

		/// <summary>
		/// Навигационное свойство для связи с сущностью "Picture".
		/// Отслеживание коллекции всех картин, созданных одним художником
		/// </summary>
		public virtual ICollection<Picture>? Pictures { get; set; }
	}
}
