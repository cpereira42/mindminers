using System;
using System.IO;
using System.Text;

namespace subtitles
{
    class Program
    {
        static int get_time()
        {
            Console.WriteLine("Please choose timestamp"); 
            var option = Console.ReadLine();
            //get_output();
            return (0);
            // verificar entrada se está no padrão? ou pegar separados?
        }

        //static int get_output()
        //{
         //   Console.WriteLine("Please choose output file"); 
         //   var option = Console.ReadLine();
//
  //      }


        static void Main(string[] args)
        {
            Subtitles teste = new Subtitles();
            Console.WriteLine("welcome Mindminers Subtitles");
            teste.get_timestamp();
            //teste.msg();
        }
    }
}
