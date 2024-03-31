using System.ComponentModel.DataAnnotations;


namespace PaintingSellingBot.Models.GalleryEntity
{
	/// <summary>
	/// Класс для сущности "Техника исполнения картины"
	/// </summary>
	public class Technique
	{
		[Key] public required int TechniqueID { get; set; } // Первичный ключ
		[Required] public required string Name { get; set; } //Техника исполнения картины

		/// <summary>
		/// Навигационное свойство для связи с сущностью "Picture".
		/// Отслеживание коллекции всех картин, созданных одной техникой исполнения
		/// </summary>
		public virtual ICollection<Picture>? Pictures { get; set; }
	}
}
