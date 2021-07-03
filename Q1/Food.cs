using System;
using System.Collections.Generic;
using System.Text;

namespace Q1
{
    public delegate void Notify(float oldValuel, float newValue);
    public class Food : IFood
    {
        public event Notify AmountChanged;
       
        private float amount;
        public float Amount
        {
            set
            {
                if (AmountChanged != null)
                {
                    AmountChanged(amount, value);
                }
                amount = value;

            }
            get
            {
                return amount;
            }
        }
        public float ComputeCalory()
        {
            return Amount / 100 * 5;
        }

    }

    
}
