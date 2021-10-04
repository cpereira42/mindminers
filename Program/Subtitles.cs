using System;
using System.IO;
using System.Text;


namespace Program
{
    public class Subtitles
    {
        public int          num;
        private string      _input_file;
        private string      _output_file;
        public Times times = new Times();

        public int msg()
        {
            Console.Write("Please choose 1 to make a synchronization or 0 to exit: ");
            var option = Console.ReadLine();
            if (option == "1")
                return(verify_input());
                
            else if (option == "0")
                return (0);
            else
            {
                Console.WriteLine("Invalid choice");
                return(msg());
            }
        }

        public int set_input(string name)
        {
            _input_file = name;
            return (1);
        }
        public int set_output(string name)
        {
            _output_file = name;
            return (1);
        }

        public int verify_input()
        {
            string name = "";
            Console.Write("Please choose the input file or 0 to exit: "); 
            name = Console.ReadLine();
            if (name == "0")
                return (0);
            if (File.Exists(name))
            {
                set_input(name);
                get_output();
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
                return (verify_input());
            }
        }

        public void get_output()
        {
            string name;

            Console.Write("Please choose the output file: "); 
            name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Invalid output file"); 
                get_output();
            }
            else
                set_output(name);
                
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
            Console.WriteLine("Input file = " + _input_file); 
            Console.WriteLine("Output file = " + _output_file); 
            times.print_signal();
            Console.Write(times.get_date(1) + ":");
            Console.Write(times.get_date(2) + ":");
            Console.Write(times.get_date(3) + ",");
            Console.WriteLine(times.get_date(4));
            Console.Write("Press 1 to confirm or 0 to back menu: ");
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
