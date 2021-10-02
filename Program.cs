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
            action.msg();
            //action.times.get_timestamp();
        }
    }
}
