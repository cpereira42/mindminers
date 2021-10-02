using System;
using System.IO;
using System.Text;

namespace subtitles
{
    public class Times
    {
        private int         _hour;
        private int         _min;
        private int         _sec;
        private int         _ms;
        private int         _signal;
        private TimeSpan    timestamp;

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
            new_time += timestamp;
            total += new_time.ToString("hh") + ":" ;
            total += new_time.ToString("mm") + ":" ;
            total += new_time.ToString("ss") + "," ;
            total += new_time.ToString("fff");
            return (total);
        }

        public int set_signal()
        {
            string option;

            Console.Write("Please set Signal + to increment or - to decrement");
            option = Console.ReadLine();
            if (option == "+")
                return(1);
            else if (option == "-")
                return(-1);
            else
                return(set_signal());
            
        }

        public void get_timestamp()
        {
            _signal = set_signal();
            _hour = set_time(24, "hour");
            _min = set_time(60, "minutes");
            _sec = set_time(60, "seconds");
            _ms = set_time(1000, "mileseconds");
            Console.Write("Hour: "+_hour); 
            Console.Write(" minute: "+_min); 
            Console.Write(" seconds: "+_sec); 
            Console.WriteLine(" mileseconds: "+_ms); 
            timestamp = new TimeSpan(0, _hour, _min, _sec, _ms) * _signal;
        }
    }
}