/*
 *      This is an extended example that demonstrates how powerful the use of lambdas can be. Far from making the code
 *      less readable, they actually allow you to write much more concise code (once you know what is going on).
 *      
 */


using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DelegatesAndLambdas
{
    [TestFixture]
    public class ExtendedExamples
    {
        public void Example_that_uses_multiple_lambdas()
        {
            var films = new List<Film>
                        {
                            new Film {Name = "Jaws", Year = 1975},
                            new Film {Name = "Singing in the rain", Year = 1952},
                            new Film {Name = "Some like it hot", Year = 1952},
                            new Film {Name = "The wizard of Oz", Year = 1939},
                            new Film {Name = "It's a wonderful life", Year = 1946},
                            new Film {Name = "American Beauty", Year = 1999},
                            new Film {Name = "High Fidelity", Year = 2000},
                            new Film {Name = "The usual suspects", Year = 1995}
                        };


            Action<Film> print = film => Console.WriteLine(film);
            
            Console.WriteLine("\tPrint all:");
            films.ForEach(print);

            Console.WriteLine("\tPrint those newer than 1960:");
            films.FindAll(film => film.Year > 1960).ForEach(print);

            Console.WriteLine("\tSort by name and print");
            films.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            films.ForEach(print);

        }

    }

    public class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            return string.Format("Name={0}, Year={1}", Name, Year);
        }
    } 
}