using System;
using System.IO;
using System.Text;

namespace Program
{
    public class Times
    {
        private int         _hour;
        private int         _min;
        private int         _sec;
        private int         _ms;

        private string      _first_time;
        private int         _limit_hour;
        private int         _limit_min;
        private int         _limit_sec;
        private int         _limit_ms;

        private int         _signal;
        private TimeSpan    _timestamp;
        

        public void print_signal()
        {
            if (_signal == -1)
                Console.Write('-');
        }

        /*
        // This function gets the time
        // 1 = Hour
        // 2 = Minutes
        // 3 = Seconds
        // 4 = Milisseconds
        */
        public int get_date(int op)
        {
            if (op == 1)
                return(_hour);
            if (op == 2)
                return(_min);
            if (op == 3)
                return(_sec);
            if (op == 4)
                return(_ms);
            return 0;
        }

        /*
        // This function gets input time and checks the limits, and if it's the correct value
        */  
        public int verify_time(int limit, string msg)
        {
            var option = "";

            Console.Write("Please set " + msg + " less/equal " + limit +": ");
            option = Console.ReadLine();
            if (!int.TryParse(option, out int num) || num > limit || num < 0)
            {
                Console.WriteLine("Invalid input or "+ msg + " more/equal than " + limit);
                return (verify_time(limit, msg));
            }
            else
                return(num);
        }

        /*
        // This funcion puts new time on the file.
        */
        public void split_time(string s, string output)
        {
            string[] s2;

            s2 = s.Split(' ');
            File.AppendAllText(output, change_time(s2[0]));
            File.AppendAllText(output, " --> ");
            File.AppendAllText(output, change_time(s2[2]));
            File.AppendAllText(output, "\n");
        }

        /*
        // This funcion converts the time
        */
        public string change_time(string s)
        {
            string[] time;
            int hour;
            int min;
            int sec;
            int ms;
            TimeSpan new_time;
            string total = "";

            time = s.Split(':');
            hour = Convert.ToInt32(time[0]);
            min = Convert.ToInt32(time[1]);
            time = time[2].Split(',');
            sec = Convert.ToInt32(time[0]);
            ms = Convert.ToInt32(time[1]);
            new_time = new TimeSpan(0, hour, min, sec,ms);
            new_time += _timestamp;
            total += new_time.ToString("hh") + ":" ;
            total += new_time.ToString("mm") + ":" ;
            total += new_time.ToString("ss") + "," ;
            total += new_time.ToString("fff");
            return (total);
        }

        /*
        // This function gets the first time in inputfile
        */
        public void get_limit_sync(string input_file)
        {
            string  line;
            string[] s;

            System.IO.StreamReader file = new System.IO.StreamReader(input_file);
            line = file.ReadLine();
            line = file.ReadLine();
            s = line.Split(' ');
            _first_time = s[0];
            file.Close();  
        }

        /*
        // This function checks if the signal is correct
        */
        public int verify_signal()
        {
            string option;

            Console.Write("Please set signal + to increment or - to decrement: ");
            option = Console.ReadLine();
            if (option == "+")
                set_signal(1);
            else if (option == "-")
                set_signal(-1);
            else
                return(verify_signal());
            return (1);
        }

        /*
        // This function sets the signal and sets the limits of input time
        */
        public void set_signal(int num)
        {
            string[] time;

            _signal = num;
            if (num == 1)
            {
                _limit_hour = 23;
                _limit_min = 59;
                _limit_sec = 59;
                _limit_ms = 999;
            }
            else
            {
                time = _first_time.Split(':');
                _limit_hour = Convert.ToInt32(time[0]);
                _limit_min = Convert.ToInt32(time[1]);
                time = time[2].Split(',');
                _limit_sec = Convert.ToInt32(time[0]);
                _limit_ms = Convert.ToInt32(time[1]);
                Console.WriteLine("Limit to sync = "+ _first_time);
            }
        }

        /*
        // This function sets the time
        // 1 = Hour
        // 2 = Minutes
        // 3 = Seconds
        // 4 = Milisseconds
        // 5 = Sync Time
        */
        public void set_time(int arg, int num)
        {
            if(arg == 1)
                _hour = num;
            if(arg == 2)
                _min = num;
            if(arg == 3)
                _sec = num;
            if(arg == 4)
                _ms = num;
            if(arg == 5)
                _timestamp = new TimeSpan(0, _hour, _min, _sec, _ms) * _signal;
        }

        /*
        // This function sets time
        */
        public void set_timestamp()
        {
            verify_signal();
            set_time(1, verify_time(_limit_hour, "hour"));
            set_time(2, verify_time(_limit_min, "minutes"));
            set_time(3, verify_time(_limit_sec, "seconds"));
            set_time(4, verify_time(_limit_ms, "mileseconds"));
            set_time(5,0);
            Console.Write("Hour: "+_hour); 
            Console.Write(", minute: "+_min); 
            Console.Write(", seconds: "+_sec); 
            Console.WriteLine(", mileseconds: "+_ms); 
        }
    }
}