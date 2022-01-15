/*using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.DatabaseRepository
{
    public class DatabaseRepository: GenericRepository<Student>, IDatabaseRepository
    {
        public DatabaseRepository(ProjectContext context) : base(context)
        {

        }

        public void OrderByAge()
        {
            var studentsOrderedAsc1 = _table.OrderBy(x => x.Age);
            var studentsOrderedDesc1 = _table.OrderByDescending(x=> x.Age);

            // linq query syntax
            var studentsOrderedAsc2 = from s in _table
                                      orderby s.Age
                                      select s;

            var studentsOrderedDesc2 = from s in _table
                                      orderby s.Age descending
                                      select s;
        }

        public void OrderByAgeAndName()
        {
            var studentsOrderedAsc1 = _table.GetActive().OrderBy(x => x.Age).ThenBy( x => x.Name);
            var studentsOrderedDesc1 = _table.OrderByDescending(x => x.Age).ThenByDescending( x => x.Name);
        }

        public void GroupBy()
        {
            var groupedStudents = from s in _table
                                  group s by s.Age;

            foreach(var studentGroupByAge in groupedStudents)
            {
                Console.WriteLine("Student group age: " + studentGroupByAge.Key);

                foreach(Student s in studentGroupByAge)
                {
                    Console.WriteLine("Student Name: " + s.Name);
                }
            }

            // Method syntax
            var groupedStudents2 = _table.GroupBy( s => s.Age);
        }
    }
}
*/