using System;
using System.IO;
using System.Text;

namespace subtitles
{
    class Program
    {
        static void Main(string[] args)
        {
            Subtitles teste = new Subtitles();
            Console.WriteLine("Welcome Mindminers Subtitles");
            teste.msg();
            //teste.change_time("01:02:03,403 --> 05:06:07,813");
            //var time = new TimeSpan(0, 1, 59, 3, 4);
            //var time2 = new TimeSpan(0, 5, 6,7 ,8);

            //var total = time + time2;
            //Console.WriteLine("Soma = "+ total);
        }
    }
}
