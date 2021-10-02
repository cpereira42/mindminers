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
        private int     _hour;
        private int     _min;
        private int     _sec;
        private int     _ms;
        
        public int set_time(int limit, string msg)
        {
            var option = "";
            int num = 0;

            Console.Write("Please set " + msg + " : ");
            option = Console.ReadLine();
            num = Int32.Parse(option);
            if (num > limit)
            {
                Console.WriteLine("Please set "+ msg + " less " + limit);
                return (set_time(limit, msg));
            }
            else
                return(num);
        }

        public void get_timestamp()
        {
            _hour = set_time(24, "hour");
            _min = set_time(60, "minutes");
            _sec = set_time(60, "seconds");
            _ms = set_time(999, "mileseconds");

            Console.Write("Hour: "+_hour); 
            Console.Write(" minute: "+_min); 
            Console.Write(" seconds: "+_sec); 
            Console.WriteLine(" mileseconds: "+_ms); 
        }

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