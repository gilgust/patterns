using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class University: ProcessAducation
    {
        public override void Enter()
        {
            Console.WriteLine("Подать документы.");
            Console.WriteLine("Вступительные экзамены.");
        }

        public override void Study()
        {
            Console.WriteLine("Обязательная сдача лаб. работ, экзаменовб курсовых");
        }

        public override void PassExams()
        {
            Console.WriteLine("Защита дипломной работы");
        }

        public override void GetAttestat()
        {
            Console.WriteLine("Диплом от оконцании данного университета");
        }
    }
}
