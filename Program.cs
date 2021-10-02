using System;
using System.IO;
using System.Text;

namespace subtitles
{
    class Program
    {
        static void Main(string[] args)
        {
            Subtitles action = new Subtitles();
            Console.WriteLine("Welcome Mindminers Subtitles");
            while (action.msg() == 1)
            {
                ;
            }

            //action.times.get_timestamp();
        }
    }
}
