using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Gears
{
    public class FastCounter
    {

        public int from { get; set; } = 0;
        public int to { get; set; } = 0;
        public bool autoRestart { get; set; } = true;

        public bool isTop => Current == to;
        public bool isBottom => Current == from;


        private int current = 0;



        public FastCounter(int from, int to)
        {
            // Revisa que sean coherentes
            if (from > to || from == to) throw new ArgumentOutOfRangeException("EasyCountScript: 'from' must be less than 'to'");

            this.from = from;
            this.to = to;
        }

        public FastCounter(int from, int to, int initial)
        {
            // Revisa que sean coherentes
            if (from > to || from == to) throw new ArgumentOutOfRangeException("EasyCountScript: 'from' must be less than 'to'");
            if (initial < from || initial > to) throw new ArgumentOutOfRangeException("EasyCountScript: 'initial' must be between 'from' and 'to'");

            this.from = from;
            this.to = to;
            this.current = initial;
        }

        public FastCounter(int from, int to, bool autoRestart)
        {
            // Revisa que sean coherentes
            if (from > to || from == to) throw new ArgumentOutOfRangeException("EasyCountScript: 'from' must be less than 'to'");

            this.from = from;
            this.to = to;
            this.autoRestart = autoRestart;
        }

        public FastCounter(int from, int to, int initial, bool autoRestart)
        {
            // Revisa que sean coherentes
            if (from > to || from == to) throw new ArgumentOutOfRangeException("EasyCountScript: 'from' must be less than 'to'");
            if (initial < from || initial > to) throw new ArgumentOutOfRangeException("EasyCountScript: 'initial' must be between 'from' and 'to'");

            this.from = from;
            this.to = to;
            this.current = initial;
            this.autoRestart = autoRestart;
        }



        public int Current => current;

        public int Next()
        {
            if (current + 1 < to) current++;
            else
            {
                if (autoRestart)
                    current = from;
            }

            return Current;
        }

        public int Prev()
        {
            if (current - 1 > from) current--;
            else
            {
                if (autoRestart)
                    current = to;
            }

            return Current;
        }

        public int Next(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                Next();
            }

            return Current;
        }

        public int Prev(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                Prev();
            }

            return Current;
        }


        public void Reset()
        {
            // Suma uno
            this.current = this.from;

        }

        public void Reset(int initial)
        {
            // Suma uno
            this.current = initial;

        }



    }
}
