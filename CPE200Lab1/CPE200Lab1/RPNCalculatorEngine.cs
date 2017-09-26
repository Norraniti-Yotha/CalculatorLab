using System;
using System.Collections.Generic;
using System.Linq;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str is "" || str is null)
            {
                return "E";
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();//////////////////////////////////////////////////
            ////////------------------------------------------------------------------------------------------/////
            for (int i = 0; i < parts.Capacity; i++)
            {
                if (parts[i].Length > 1)
                {
                    bool afafk = true;
                    for (int j = 0; j < parts[i].Length; j++)
                    {
                        if (j == 0)
                        {
                            afafk = isNumber(Convert.ToString(parts[i][j]));
                        }
                        else
                        {
                            if (afafk == isNumber(Convert.ToString(parts[i][j])))
                            {
                                if (!afafk) // operator operator
                                {
                                    return "E";
                                }
                            }
                            else
                            {
                                if (afafk) //// number operator
                                {
                                    return "E";
                                }
                                else /// operator number
                                {
                                    if (parts[i][0] != '-')
                                    {
                                        return "E";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ///////------------------------------------------------------------------------------------------//////
            string result;
            string firstOperand, secondOperand;
            string tempy;
            foreach (string token in parts)///////////////////////////////////////////////////////////////////////
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                    }
                    catch
                    {
                        return "E";
                    }
                    ///////////////////////////////////////////////////////////////////////////////
                    result = calculate(token, firstOperand, secondOperand);
                    if (result is "E")
                    {
                        return result;
                    }
                    ///////////////////////////////////////////////////////////////////////////////
                    rpnStack.Push(result);
                    ///////////////////////////////////////////////////////////////////////////////
                }
            }
            result = rpnStack.Pop();
            try
            {
                tempy = rpnStack.Pop();
                rpnStack.Push(tempy);
            }
            catch
            {
                return result;

            }
            return "E";
        }
    }
}