using System;
using System.IO;
using System.Text;

namespace subtitles
{
    public class Subtitles
    {
        public int          num;
        private string      _input_file;
        private string      _output_file;
        private int         _hour;
        private int         _min;
        private int         _sec;
        private int         _ms;
        private TimeSpan    timestamp;

        public void set_input()
        {
            Console.WriteLine("Please choose InputFile or 0 to exit:"); 
            _input_file = Console.ReadLine();
            if (_input_file == "0")
                return ;
            if (File.Exists(_input_file))
            {
                set_output();
                if (_output_file == "0")
                    return ;
                get_timestamp();
                
                if (confirm() == 1)
                    read_file();
                else
                    Console.WriteLine("Não confirmado");
            }
            else
            {
                Console.WriteLine("File not found"); 
                set_input();
            }
        }

        public int set_time(int limit, string msg)
        {
            var option = "";

            Console.Write("Please set " + msg + " : ");
            option = Console.ReadLine();
            if (!int.TryParse(option, out int num) || num >= limit)
            {
                Console.WriteLine("Please set "+ msg + " less " + limit);
                return (set_time(limit, msg));
            }
            else
                return(num);
        }

        public void read_file()
        {
            int     counter;  
            string  line;  
            int     controller;

            counter = 1;
            controller = 1;

            System.IO.StreamReader file = new System.IO.StreamReader(_input_file);  
            while((line = file.ReadLine()) != null)  
            {  
                if (int.TryParse(line, out int num))
                {
                    controller = 1;
                    System.Console.WriteLine(line);
                }
                else if (controller == 0) 
                    System.Console.WriteLine(line); 
                else
                {
                    split_time(line);
                    break;
                    System.Console.WriteLine("xxxxx");
                    controller = 0;
                }
            }  
            file.Close();  
            System.Console.WriteLine("There were {0} lines.", counter); 
        }

        public void split_time(string s)
        {
            string[] s2;

            s2 = s.Split(' ');
            Console.Write(change_time(s2[0]));
            Console.Write(" --> ");
            Console.WriteLine(change_time(s2[2]));
        }

        public TimeSpan change_time(string s)
        {
            string[] time;
            int hour;
            int min;
            int sec;
            int ms;
            TimeSpan new_time;

            time = s.Split(':');
            hour = Convert.ToInt32(time[0]);
            min = Convert.ToInt32(time[1]);
            time = time[2].Split(',');
            sec = Convert.ToInt32(time[0]);
            ms = Convert.ToInt32(time[1]);
            new_time = new TimeSpan(0, hour, min, sec,ms);
            return (new_time + timestamp);
        }

        public void get_timestamp()
        {
            _hour = set_time(24, "hour");
            _min = set_time(60, "minutes");
            _sec = set_time(60, "seconds");
            _ms = set_time(1000, "mileseconds");
            Console.Write("Hour: "+_hour); 
            Console.Write(" minute: "+_min); 
            Console.Write(" seconds: "+_sec); 
            Console.WriteLine(" mileseconds: "+_ms); 
            timestamp = new TimeSpan(0, _hour, _min, _sec, _ms);
        }

        public void set_output()
        {
            Console.WriteLine("Please choose OutFile"); 
            _output_file = Console.ReadLine();
        }

        public int confirm()
        {
            var option = "";
            Console.WriteLine("");
            Console.WriteLine("Resume :");
            Console.WriteLine("Inputfile = " + _input_file); 
            Console.WriteLine("Outfile = " + _output_file); 
            Console.WriteLine(_hour + ":" + _min + ":" + _sec + "," + _ms); 
            Console.WriteLine("Press 1 to confirm ou 0 to exit :");
            option = Console.ReadLine();
            if (option == "1")
                read_file();
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