using System; 

namespace HTMLreader
{
    class Program
    {
        static void Main(string[] args)
        { 
            MainPage_2 doc = new MainPage_2("mainPage.html"); 
            doc.Display();

            Console.ReadKey();

        }
    }
}
