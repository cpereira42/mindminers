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
                Console.WriteLine("teste:"); 
                times.get_timestamp();
                Console.WriteLine("22:"); 
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
            file.Close();  
            System.Console.WriteLine("There were {0} lines.", counter); 
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
            Console.Write(times.get_date(1) + ":");
            Console.Write(times.get_date(2) + ":");
            Console.Write(times.get_date(3) + ",");
            Console.WriteLine(times.get_date(4));
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