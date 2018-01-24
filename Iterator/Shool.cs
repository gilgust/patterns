using System; 

namespace Iterator
{
    class Shool : ProcessAducation
    {
        public string Name { get; set; }

        public Shool( string name) : base(name)
        {
        }

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
            Console.WriteLine("Оттестат об окончании {0} \n", Name);
        }
    }
}
