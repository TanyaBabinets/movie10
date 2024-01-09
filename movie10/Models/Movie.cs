using System.ComponentModel.DataAnnotations;
namespace movie10.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name="Название")]
        public string? Title { get; set; }
        [Display(Name = "Оригинальное название")]
        public string? TitleEng { get; set; }
        [Display(Name = "Жанр фильма")]
        public string? Genre { get; set; }
        [Display(Name = "Режиссер")]
        public string? Director { get; set; }
        [Display(Name = "Год выхода")]
        public int Year { get; set; }
        [Display(Name = "Краткое содержание")]
        public string? Description { get; set; }
        [Display(Name = "Постер")]
        public string? Poster { get; set; }



    }
}
