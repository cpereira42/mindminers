using System;
using System.IO;
using System.Text;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            Subtitles action = new Subtitles();
            Console.WriteLine("Welcome to the Mindminers Subtitles");
            while (action.begin() == 1)
            {
                ;
            }
            Console.WriteLine("Bye");
        }
    }
}