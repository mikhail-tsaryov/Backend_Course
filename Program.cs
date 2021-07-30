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
                    Surname = "��������",
                    Name = "�������",
                    MiddleName = "����������",
                    DateOfBirthday = new DateTime(1964, 5, 12)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "��������",
                    Name = "��������",
                    MiddleName = "�����������",
                    DateOfBirthday = new DateTime(1986, 1, 1)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "�������",
                    Name = "�����",
                    MiddleName = "�������",
                    DateOfBirthday = new DateTime(2000, 10, 30)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "����",
                    Name = "��������",
                    MiddleName = "����������",
                    DateOfBirthday = new DateTime(1939, 6, 18)
                });
                dbContext.Persons.Add(new PersonModel()
                {
                    Surname = "�������",
                    Name = "������",
                    MiddleName = "��������",
                    DateOfBirthday = new DateTime(1997, 12, 6)
                });

                // Add books to the DB
                dbContext.Books.Add(new BookModel()
                {
                    Title = "��� �����������. ������� �� ��������, ���� �� ����� � ����������� �����",
                    AuthorName = "������",
                    Genre = "������������"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "��������� ����",
                    AuthorName = "������",
                    Genre = "������������� �����"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "������",
                    AuthorName = "����������",
                    Genre = "����������� ����������"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "����� �� ������ �� ����. ������� �������� ����",
                    AuthorName = "������",
                    Genre = "����������� ����������"
                });

                dbContext.Books.Add(new BookModel()
                {
                    Title = "�����. � ������� � ���������� ���� ��������",
                    AuthorName = "����",
                    Genre = "��������� � �������"
                });

                dbContext.SaveChanges();
            }
        }
    }
}