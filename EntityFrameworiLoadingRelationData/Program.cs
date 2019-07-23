using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworiLoadingRelationData.DatabaseContext;
using EntityFrameworiLoadingRelationData.Models;

namespace EntityFrameworiLoadingRelationData
{
    class Program
    {
        static void Main(string[] args)
        {


            UniversityDbContext db = new UniversityDbContext();

            var departments = db.Departments.ToList();




            ////Lagy Loading
            //var departments = db.Departments
            //                  .Include(c => c.Students)
            //                  .ToList();




            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Code+" - "+dept.Name);



                //// Eger Loading
                //var students = db.Students.Where(c => c.DepartmentId == dept.Id);
                //dept.Students = students.ToList();


                // Explicity Loading
                db.Entry(dept)
                    .Collection(c => c.Students)
                    .Query()
                    .Where(c => c.IsActive)
                    .Load();




                if (dept.Students != null && dept.Students.Any())
                {
                    foreach (var student in dept.Students)
                    {
                        Console.WriteLine("\t\t Name: "+ student.Name);
                    }
                }
                else
                {
                    Console.WriteLine("\t\t No Student Fount!");
                }
            }


            Console.ReadKey();












            //Student student = new Student()
            //{
            //    Name = "A",
            //    RegNo = "002",
            //};


            //Department department = new Department()
            //{
            //    Name = "Computer Science",
            //    Code = "CSE",
            //};

            //department.Students.Add(student);

            //UniversityDbContext db = new UniversityDbContext();
            //db.Departments.Add(department);

            //bool isSaved = db.SaveChanges() > 0;
            //if (isSaved)
            //{
            //    Console.WriteLine("Successfull");
            //}
            

        }
    }
}
