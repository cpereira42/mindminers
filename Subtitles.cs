using System;
using System.IO;
using System.Text;

namespace subtitles
{
    public class Subtitles
    {
        public int      num;
        private string  _input_file;
        private string  _output_file;

        public void set_input()
        {
            Console.WriteLine("Please choose InputFile or 0 to exit:"); 
            _input_file = Console.ReadLine();
            if (_input_file == "0")
                return ;
            
            if (File.Exists(_input_file))
                set_output();
            else
            {
                Console.WriteLine("File not found"); 
                set_input();
            }
        }

        public void set_output()
        {
            Console.WriteLine("Please choose OutFile"); 
            _output_file = Console.ReadLine();
            confirm();
        }

        public int confirm()
        {
            var option = "";
            Console.WriteLine("");
            Console.WriteLine("Resume :");
            Console.WriteLine("Inputfile = " + _input_file); 
            Console.WriteLine("Outfile = " + _output_file); 
            Console.WriteLine("Press 1 to confirm ou 0 to exit :");
            option = Console.ReadLine();
            if (option == "1")
                Console.WriteLine("GO");
            else if (option == "0")
                return (0);
            else
                confirm();
            return (0);
        }

        public void msg()
        {
            Console.WriteLine("Please choose :");
            Console.WriteLine("1 - Make a Sinc");
            Console.WriteLine("2 - Exit");
            var option = Console.ReadLine();
            if (option == "1")
                set_input ();
                
            else if (option == "2")
                Console.WriteLine("2 - Exit");
            else
            {
                Console.WriteLine("Invalid choice");
                msg();
            }
        }

    }
}