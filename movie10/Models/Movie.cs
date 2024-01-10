using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace movie10.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name="Название")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
 
        [Display(Name = "Оригинальное название")]
        public string? TitleEng { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Жанр фильма")]
        public string? Genre { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Режиссер")]
        public string? Director { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [Range(1900, 2024, ErrorMessage = "Введите год правильно")]
        [Display(Name = "Год выхода")]
        public int Year { get; set; }
        
        [Display(Name = "Краткое содержание")]

        public string? Description { get; set; }
        //[Required(ErrorMessage = "Загрузите постер в формате jpg ")]
        //[Remote(action: "CheckPoster", controller: "Movies", ErrorMessage = "Недопустимый формат или размер файла")]
        //[AllowedExtensions(new string[] { ".jpg" }, ErrorMessage = "Допускаются только файлы формата .jpg")]
        [Display(Name = "Постер")]
        public string? Poster { get; set; }


     
       
    }
}
