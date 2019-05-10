using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithFSM
{
    public delegate void ChangeTextDelegate(string msg);

    class Calculator
    {
        public float a, b;

        ChangeTextDelegate changeDelegate; // экземпляр

        public Calculator(ChangeTextDelegate changeTextDelegate)
        {
            this.changeDelegate = changeTextDelegate;
        }
        


        public void Calc()
        {
            changeDelegate.Invoke((a + b).ToString());
        }
    }
}
