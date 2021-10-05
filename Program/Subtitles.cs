using System;
using System.IO;
using System.Text;


namespace Program
{
    public class Subtitles
    {
        public int          num;
        public string       msg_error;
        private string      _input_file;
        private string      _output_file;
        public Times times = new Times();

        
        public int begin()
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
                return(begin());
            }
        }

        /*
        // This function verify if the file is valid
        */
        public int verify_input()
        {
            string name = "";
            Console.Write("Please choose the input file or 0 to exit: "); 
            name = Console.ReadLine();
            if (name == "0")
                return (0);
            if (set_input(name) == 1)     // verify if file is valid
            {
                verify_output();         // get output file
                if (_output_file == "0") // verify input is 0 to back to menu
                    return (0);
                times.set_timestamp();   // set times inputs
                if (confirm() == 1)      // confirm the choices
                    return (read_file());// do process
                else
                    return (1);
            }
            else
                return (verify_input()); // verify input again
        }

        public int set_input(string name)
        {
            if (File.Exists(name))      // verify if file exit
            {
                _input_file = name;     
                times.get_limit_sync(name);  // get _first time
                return (1);
            }
            else
            {
                Console.WriteLine("File not found");
                return (0);
            }
                
        }

        public int set_output(string name)
        {
            if (name == "")           // verify if file isn't empty
                return 0;        
            _output_file = name;
            return (1);
        }

        public void verify_output()
        {
            string name;

            Console.Write("Please choose the output file: "); 
            name = Console.ReadLine();
            if (set_output(name) == 0)   // verify if file isn't empty
            {
                Console.WriteLine("Invalid output file"); 
                verify_output();        // get outputfile again
            }
        }

        /*
        // This function will sync
        */
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

        /*
        // This function will display the resume of choice
        */
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
