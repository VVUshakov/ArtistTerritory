using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintingSellingBot.Models.GalleryEntity
{
	/// <summary>
	/// Класс для сущности "Картина"
	/// </summary>	
	public class Picture
	{
		[Key] public required int PictureID { get; set; } // Первичный ключ
		[Required] public required string Title { get; set; } // Название
		public virtual required Artist Artist { get; set; } // Художник		
		public string? Year { get; set; } // Год создания
		public string? Description { get; set; } // Описание
		public virtual Technique? Technique { get; set; } // Техника исполнения
		public virtual Genre? Genre { get; set; } // Жанр
		[Required] public required decimal Price { get; set; } // Цена


		[ForeignKey("Artist")] public int ArtistID { get; set; } //	Связь с сущностью "Художник"
		[ForeignKey("Technique")] public int TechniqueID { get; set; }  // Связь с сущностью "Техника исполнения"
		[ForeignKey("Genre")] public int GenreID { get; set; } // Связь с сущностью "Жанр исполнения"
	}
}
