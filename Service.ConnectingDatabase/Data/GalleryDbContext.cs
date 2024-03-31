using Microsoft.EntityFrameworkCore;
using PaintingSellingBot.Extension;


namespace Service.ConnectingDatabase.Data
{
    /// <summary>
    /// Класс для контекста базы данных.
    /// Класс GalleryContext наследуется от DbContext и определяет набор сущностей, 
    /// которые будут управляться этим контекстом.
    /// </summary>
    public class GalleryDbContext : DbContext
    {
        //TODO: Изменить на получение из конфигурационного файла
        private static readonly string nameDb = "SQLite";

        //TODO: Изменить на получение из конфигурационного файла
        // TODO: Нужно заменить "YourConnectionStringHere" на реальную строку подключения
        private static readonly string connectionStringDb = "YourConnectionStringHere";

        public GalleryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Используется для настройки подключения к базе данных
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Вызов метода расширения для выбора базы данных
            optionsBuilder.UseDatabase(nameDb);
        }

        /// <summary>
        /// Используется для настройки моделей сущностей и связей между ними (конфигурация связей)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // "Картина" имеет связь с "Художник" через свойство ArtistID
            modelBuilder.Entity<Picture>()
                .HasOne(p => p.Artist)
                .WithMany()
                .HasForeignKey(p => p.ArtistID);

            // "Картина" имеет связь с "Техника исполнения" через свойство TechniqueID
            modelBuilder.Entity<Picture>()
            .HasOne(p => p.Technique)
            .WithMany()
            .HasForeignKey(p => p.TechniqueID);

            // "Картина" имеет связь с "Жанр" через свойство GenreID
            modelBuilder.Entity<Picture>()
                .HasOne(p => p.Genre)
                .WithMany()
                .HasForeignKey(p => p.GenreID);
        }
    }
}
