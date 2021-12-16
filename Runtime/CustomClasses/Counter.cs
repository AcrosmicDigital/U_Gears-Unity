using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U.Gears.Math;
using UnityEngine;

namespace U.Gears
{
    public class Counter
    {

        public enum CountMode
        {
            LimitTopBottom,
            LimitTop,
            LimitBottom,
            NoLimits,
        }


        public int Top => to;
        public int Bottom => from;
        public CountMode Mode => countMode;
        public bool IsTop => Current == to;
        public bool IsBottom => Current == from;
        public int Current => current;




        private int current = 0;
        private int from = 0;
        private int to = 0;
        private CountMode countMode = CountMode.LimitTopBottom;


        public Counter(Properties props)
        {
            if (props.from > props.to)
            {
                var cc = props.to;
                props.to = props.from;
                props.from = cc;
            }

            this.from = props.from;
            this.to = props.to;
            this.countMode = props.countMode;
            this.current = props.current.MinMax(from, to);
        }


        public int Next()
        {
            if (current + 1 <= to) current++;
            else
            {
                if (countMode == CountMode.LimitBottom || countMode == CountMode.NoLimits)
                    current = from;
            }

            return Current;
        }

        public int Prev()
        {
            if (current - 1 >= from) current--;
            else
            {
                if (countMode == CountMode.LimitTop || countMode == CountMode.NoLimits)
                    current = to;
            }

            return Current;
        }

        public int Next(int steps)
        {
            for (int i = 0; i < steps.Min(0); i++)
            {
                Next();
            }

            return Current;
        }

        public int Prev(int steps)
        {
            for (int i = 0; i < steps.Min(0); i++)
            {
                Prev();
            }

            return Current;
        }


        public void ToBottom()
        {
            // Suma uno
            this.current = this.from;

        }

        public void ToTop()
        {
            // Suma uno
            this.current = this.to;

        }

        public void To(int target)
        {
            // Suma uno
            this.current = target.MinMax(from, to);

        }


        public class Properties
        {
            public int current { get; set; } = 0;
            public int from { get; set; } = 0;
            public int to { get; set; } = 10;
            public CountMode countMode { get; set; } = CountMode.LimitTopBottom;
        }


    }
}
