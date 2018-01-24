using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Shool: ProcessAducation
    {
        public override void Enter()
        {
            Console.WriteLine("Подать документы.");
        }

        public override void Study()
        {
            Console.WriteLine("Обязательная сдача контрольных работ");
        }

        public override void PassExams()
        {
            Console.WriteLine("обязательные 3 экзамина на выбор");
        }

        public override void GetAttestat()
        {
            Console.WriteLine("Оттестат о среднем образовании");
        }
    }
}
