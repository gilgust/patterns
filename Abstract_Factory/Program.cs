using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudent student = new Foreign_Student();
            var CourscWork = student.GetCoursWork();
            Console.WriteLine("{0}, course work ={1}", student.GetInfo(), CourscWork.Grade);

            student = new Bad_Student();
            CourscWork = student.GetCoursWork();
            Console.WriteLine("{0}, course work ={1}", student.GetInfo(), CourscWork.Grade);

            Console.ReadKey();
        }
    }
}
