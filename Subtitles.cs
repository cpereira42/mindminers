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
        public Times times = new Times();
        
        public int msg()
        {
            Console.Write("Please choose, 1 to Make a Sinc or 0 to exit : ");
            var option = Console.ReadLine();
            if (option == "1")
                return(set_input());
                
            else if (option == "0")
                return (0);
            else
            {
                Console.WriteLine("Invalid choice");
                return(msg());
            }
        }

        public int set_input()
        {
            Console.Write("Please choose InputFile or 0 to exit : "); 
            _input_file = Console.ReadLine();
            if (_input_file == "0")
                return (0);
            if (File.Exists(_input_file))
            {
                set_output();
                if (_output_file == "0")
                    return (0);
                times.get_timestamp();
                if (confirm() == 1)
                    return (read_file());
                else
                    return (1);
            }
            else
            {
                Console.WriteLine("File not found"); 
                return (set_input());
            }
        }

        public void set_output()
        {
            Console.Write("Please choose OutFile : "); 
            _output_file = Console.ReadLine();
            if (_output_file == "" )
            {
                Console.WriteLine("Invalid Outfile"); 
                set_output();
            }
                
        }

        public int read_file()
        {
            string  line;  
            int     controller;

            controller = 1;
            System.IO.StreamReader file = new System.IO.StreamReader(_input_file);
            while((line = file.ReadLine()) != null)  
            {  
                if (int.TryParse(line, out int num))
                {
                    controller = 1;
                    File.AppendAllText(_output_file, line);
                    File.AppendAllText(_output_file,"\n");
                }
                else if (controller == 0) 
                {
                    File.AppendAllText(_output_file, line);
                    File.AppendAllText(_output_file,"\n");
                }
                else
                {
                    times.split_time(line, _output_file);
                    controller = 0;
                }
            }
            Console.WriteLine("Done !!");
            file.Close();  
            return (1);
        }

        public int confirm()
        {
            var option = "";
            Console.WriteLine("");
            Console.WriteLine("Resume :");
            Console.WriteLine("Inputfile = " + _input_file); 
            Console.WriteLine("Outfile = " + _output_file); 
            times.print_signal();
            Console.Write(times.get_date(1) + ":");
            Console.Write(times.get_date(2) + ":");
            Console.Write(times.get_date(3) + ",");
            Console.WriteLine(times.get_date(4));
            Console.Write("Press 1 to confirm or 0 to back menu : ");
            option = Console.ReadLine();
            if (option == "1")
                return (1);
            else if (option == "0")
                return (0);
            else
                return (confirm());
        }
    }
}