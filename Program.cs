using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Timer: IDisposable
    {
        private DateTime start;
        private DateTime end;
        private TimeSpan duration;

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        

        public Timer() {
           start = DateTime.Now;
        }
        

        public void Dispose() 
        {
            End = DateTime.Now;
            duration = End.Subtract(Start);
        }

        ~Timer() {
            Dispose();
        }

        public static void MMain(String[] args) {
            Timer t = new Timer();

            for (int i = 0; i < 100; i++) {
                Console.WriteLine("Hi");
            }

            t.Dispose();

            Console.WriteLine("{0}", t.Duration.Milliseconds.ToString());
            while (true) ;
        }
    }
}
