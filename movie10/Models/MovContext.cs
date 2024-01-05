﻿using Microsoft.EntityFrameworkCore;
namespace movie10.Models
{
    public class MovContext:DbContext
    {
            public DbSet<Movie> Movies { get; set; }
            public MovContext(DbContextOptions<MovContext> options)
               : base(options)
            {
            if (Database.EnsureCreated())
            {
                Movies?.Add(new Movie { Title = "Отступники",
                    TitleEng= "The Departed", Genre = "Триллер, Драма, Криминальный", Director= "Мартин Скорсезе", Year = 2006, 
                    Description = "Ирландский гангстер, внедренный в полицейское управление Бостона (Деймон), и полицейский агент, уже бог знает сколько лет притворяющийся ирландским гангстером (Ди Каприо), " +
                    "получают каждый от своего начальства наказ найти и обезвредить друг друга.", Poster= "/img/dep.jpg"
                });
                Movies?.Add(new Movie { Title = "Талантливый мистер Рипли", TitleEng = "The Talented Mr. Ripley",
                    Genre = "Детектив, Триллер, Драма", Director = "Энтони Мингелла", Year = 1999, Description = "После случайного знакомства один из богатейших людей Америки дает Тому Рипли поручение съездить в Италию и убедить его сына, транжирящего деньги в Европе, вернуться в Штаты. Вскоре Том уже знакомится с Дики Гринлифом и Мардж. " +
                    "Их роскошная жизнь очаровывает Тома, и он решает занять место Дики.", Poster = "/img/riply.jpg"
                });
                Movies?.Add(new Movie { Title = "Аватар", TitleEng = "Avatar", Genre = "Приключение, Фантастика", Director = "Джеймс Кэмерон", Year = 2009, 
                    Description = "Джейка Салли (Сэм Уортингтон), морпеха-ветерана с парализованными ногами, отправляют разрабатываеть природные ископаемые на планету Пандора. " +
                    "В силу того, что тамошние условия совершенно непригодны для человека, исследователям приходится оперировать посредством аватаров — специальных клонов, при создании которых были совмещены ДНК человека и аборигенов, зовущихся На'Ви.", 
                    Poster = "/img/avat.jpg" });
                Movies?.Add(new Movie
                {
                    Title = "Пятый элемент",
                    TitleEng = "The Fifth Element", Genre = "Боевик, Фантастика", Director = "Люк Бессон", Year = 1997, 
                    Description = "Каждые 5 тысяч лет между параллельными измерениями открываются врата, и силы зла и хаоса стремятся нарушить существующую гармонию. " +
                    "И каждые 5 тысяч лет нашей планете нужен герой, который рискнет встать на пути зла. В ХХIII веке таким героем приходится стать нью-йоркскому таксисту Корбену Далласу. " +
                    "Ему помогает посланник высшего разума — хрупкая на вид девушка Лилу.", Poster = "/img/5elem.jpg"
                });
                Movies?.Add(new Movie
                {
                    Title = "Жизнь прекрасна",
                    TitleEng = "La vita e bella",
                    Genre = "Трагикомедия, Военный",
                    Director = "Роберто Бениньи",
                    Year = 1997,
                    Description = "Грустный фильм Роберто Бениньи про холокост",
                    Poster = "/img/bella.jpg"
                });
                Movies?.Add(new Movie
                {
                    Title = "И целого мира мало",
                    TitleEng = "The World Is Not Enough",
                    Genre = "Боевик, Приключение",
                    Director = "Майкл Аптед",
                    Year = 1999,
                    Description = "На этот раз агент Джеймс Бонд оказывается в Испании, где он и " +
                    "эксперт по ядерным вооружениям доктор Кристмас Джонс должны защищать наследницу нефтяного магната Электру Кинг от международного террориста Ренарда",
                    Poster = "/img/bond.jpg"
                });
                Movies?.Add(new Movie
                {
                    Title = "Игры разума",
                    TitleEng = "A Beautiful Mind",
                    Genre = "Рон Ховард",
                    Director = "Биография, Драма",
                    Year = 2001,
                    Description = "Биография математика Джона Форбса Нэша-младшего\r\nДжон Форбс Нэш-мл. (Кроу) был математическим гением. " +
                    "Его развитие теории игр на долгие годы определило рыночную экономику. Нэш страдал тяжелой формой шизофрении, и ни инсулиновые шоки, " +
                    "ни преданная жена (Коннелли) не могли его излечить. " +
                    "Помочь ему мог только он сам.  За заслуги в области экономики в 1994 году он был удостоен Нобелевской премии",
                    Poster = "/img/razum.jpg"
                });
                Movies?.Add(new Movie
                {
                    Title = "Бесславные ублюдки",
                    TitleEng = "Inglourious Basterds",
                    Genre = "Боевик, Приключение, Военный",
                    Director = "Квентин Тарантино",
                    Year = 2009,
                    Description = "Фильм Квентина Тарантино про американский отряд, уничтожающий фашистов",
                    Poster = "/img/besslavnie.jpg"
                });
                Movies?.Add(new Movie
                {
                    Title = "Один дома",
                    TitleEng = "Home Alone",
                    Genre = "Комедия, Семейный, Новогодние",
                    Director = "Крис Коламбус",
                    Year = 1990,
                    Description = "Маленький, но очень изобретательный мальчик остается один дома под Рождество. " +
                    "Многодетная американская семья собирается в отпуск и забывает самого младшего сына Кевина дома. Маленький, " +
                    "но очень изобретательный мальчик, оставшись один дома под Рождество, не теряется, сам готовит, стирает, ходит в магазин и вступает в " +
                    "противоборство с ворами-домушниками.",
                    Poster = "/img/alone.jpg"
                });
                Movies?.Add(new Movie
                {
                    Title = "ВАЛЛ*И",
                    TitleEng = "WALL·E",
                    Genre = "Мультфильм",
                    Director = "Эндрю Стэнтон",
                    Year = 2008,
                    Description = "Мультфильм студии Pixar про любовь двух роботов. " +
                    "В далеком будущем, когда Земля стала необитаемой помойкой, одинокий робот-мусорщик без " +
                    "памяти влюбляется в овальную сущность",
                    Poster = "/img/valle.jpg"
                });
                SaveChanges();
            }

        }
        }
    }

