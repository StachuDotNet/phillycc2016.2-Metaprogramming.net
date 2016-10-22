using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedPeople();

            using (var db = new MyDbContext())
            {
                var teens = db.People
                    //.Where(person => person.Age < 20 && person.Age > 12)
                    .ToList();

                Console.ReadLine();
            }
        }

        private static void SeedPeople()
        {
            using (var db = new MyDbContext())
            {
                var emptyTable = !db.People.Any();

                if (emptyTable)
                {
                    var peopleToInsert = new List<Person>
                    {
                        new Person { FirstName = "John", LastName = "Smith", Age = 43 },
                        new Person { FirstName = "Judy", LastName = "Green", Age = 16 },
                        new Person { FirstName = "Stachu", LastName = "Korick", Age = 24 },
                        new Person { FirstName = "George", LastName = "Maass", Age = 13 }
                    };

                    foreach (var p in peopleToInsert)
                        p.Id = Guid.NewGuid();

                    db.People.AddRange(peopleToInsert);

                    db.SaveChanges();
                }
            }
        }
    }
}
