using System;
using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;
using Balta.ContentContext.Enums;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }

            var courses = new List<Course>();
            var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop", EContentLevel.Fundamental);
            var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp", EContentLevel.Beginner);
            var courseDotnet = new Course("Fundamentos .NET", "fundamentos-dotnet", EContentLevel.Advanced);

            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseDotnet);

            var careers = new List<Career>();
            var careerDotnet = new Career("Especialista .NET", "especialista-dotnet");
            var careerItem = new CareerItem(
                2,
                "OOP",
                "",
                courseOOP
            );
            var careerItem2 = new CareerItem(
                1,
                "Comece por aqui",
                "",
                courseCsharp
            );
            var careerItem3 = new CareerItem(
                3,
                "Aprenda .NET",
                "",
                null
             );
            careerDotnet.Items.Add(careerItem);
            careerDotnet.Items.Add(careerItem2);
            careerDotnet.Items.Add(careerItem3);
            careers.Add(careerDotnet);

            foreach (var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach (var item in career.Items.OrderBy(x => x.Sequence))
                {
                    Console.WriteLine($"{item.Sequence} - {item.Title}");
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach (var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }
        }
    }
}
