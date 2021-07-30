using Backend_1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitDatabase();
            CreateHostBuilder(args).Build().Run();                        
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void InitDatabase()
        {
            using (var dbContext = new ApplicationContext())
            {
                dbContext.Books.RemoveRange(dbContext.Books);
                dbContext.Persons.RemoveRange(dbContext.Persons);
                dbContext.SaveChanges();

                // Add persons to the DB
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "Горбунов",
                    Name = "Николай",
                    MiddleName = "Дмитриевич",
                    DateOfBirthday = new DateTime(1964, 5, 12)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "Соловьёв",
                    Name = "Вениамин",
                    MiddleName = "Григорьевич",
                    DateOfBirthday = new DateTime(1986, 1, 1)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "Лихачёв",
                    Name = "Орест",
                    MiddleName = "Кимович",
                    DateOfBirthday = new DateTime(2000, 10, 30)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "Зуев",
                    Name = "Митрофан",
                    MiddleName = "Аркадьевич",
                    DateOfBirthday = new DateTime(1939, 6, 18)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "Назаров",
                    Name = "Елисей",
                    MiddleName = "Наумович",
                    DateOfBirthday = new DateTime(1997, 12, 6)
                });

                // Add books to the DB
                dbContext.Books.Add(new BookModel()
                {
                    Title = "Дом минималиста. Комната за комнатой, путь от хаоса к осмысленной жизни",
                    AuthorName = "Беккер",
                    Genre = "Саморазвитие"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "Тревожные люди",
                    AuthorName = "Бакман",
                    Genre = "Остросюжетная проза"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "Предел",
                    AuthorName = "Лукьяненко",
                    Genre = "Космическая фантастика"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "Звезд не хватит на всех. Коллапс Буферной Зоны",
                    AuthorName = "Глебов",
                    Genre = "Космическая фантастика"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "Выбор. О свободе и внутренней силе человека",
                    AuthorName = "Эгер",
                    Genre = "Биографии и мемуары"
                });

                dbContext.SaveChanges();
            }
        }
    }
}