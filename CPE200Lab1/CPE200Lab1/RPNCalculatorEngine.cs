using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            List<string> parts = str.Split(' ').ToList<string>();
            string result = "0";
            Stack rpnStack = new Stack();
            for (int i = 0; parts.Count > i;i++)
            {
                if (isNumber(parts[i]))
                {
                    rpnStack.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    String second = rpnStack.Pop().ToString();
                    String frist = rpnStack.Pop().ToString();
                    result = calculate(parts[i], frist, second,4);
                    rpnStack.Push(result);
                    
                }
            }
            return result;
        }
    }
}
