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
        private int         _signal;
        private TimeSpan    _timestamp;

        public void print_signal()
        {
            if (_signal == -1)
                Console.Write('-');
        }

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


        public int verify_time(int limit, string msg)
        {
            var option = "";

            Console.Write("Please set " + msg + " : ");
            option = Console.ReadLine();
            if (!int.TryParse(option, out int num) || num >= limit)
            {
                Console.WriteLine("Invalid in or "+ msg + " more or equal than " + limit);
                return (verify_time(limit, msg));
            }
            else
                return(num);
        }

        public void split_time(string s, string output)
        {
            string[] s2;

            s2 = s.Split(' ');
            File.AppendAllText(output, change_time(s2[0]));
            File.AppendAllText(output, " --> ");
            File.AppendAllText(output, change_time(s2[2]));
            File.AppendAllText(output, "\n");
        }

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

        public void set_signal(int num)
        {
            _signal = num;
        }

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

        public void get_timestamp()
        {
            verify_signal();
            set_time(1, verify_time(24, "hour"));
            set_time(2, verify_time(60, "minutes"));
            set_time(3, verify_time(60, "seconds"));
            set_time(4, verify_time(1000, "mileseconds"));
            set_time(5,0);
            Console.Write("Hour: "+_hour); 
            Console.Write(" minute: "+_min); 
            Console.Write(" seconds: "+_sec); 
            Console.WriteLine(" mileseconds: "+_ms); 
            Console.WriteLine(_timestamp);
        }
    }
}