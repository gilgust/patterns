using System; 

namespace Iterator
{
    class University: ProcessAducation
    {
        public string Name { get; set; }

        public University(string name): base(name)
        {
        }
        public override void Enter()
        {
            Console.WriteLine("Подать документы в {0}.", Name);
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
            Console.WriteLine("Диплом от оконцании {0} \n", Name);
        }
    }
}
