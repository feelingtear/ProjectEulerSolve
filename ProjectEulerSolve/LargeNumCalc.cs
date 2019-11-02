using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolve
{
    public static class LargeNumCalc
    {
        /// <summary>
        /// 计算阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Factor(int n)
        {
            const int num = 2;

            //100!值太大了，不能直接计算

            //16598*2
            //465487984654313132154654855465420
            string curValue = 1.ToString();

            for (int i = 1; i <= n; i++)
            {
                //每一位计算
                int highStepNum = 0;
                string combineString = string.Empty;
                //2056
                for (int index = curValue.Length - 1; index >= 0; index--)
                {
                    int posNum = int.Parse(curValue[index].ToString()) * i + highStepNum;
                    string posStr = posNum.ToString();
                    if (posNum >= 10)
                    {
                        highStepNum = int.Parse(posStr.Substring(0, posStr.Length - 1));
                        if (index > 0)
                        {
                            posStr = posStr[posStr.Length - 1].ToString();
                        }
                    }
                    else
                    {
                        highStepNum = 0;
                    }
                    combineString = posStr + combineString;
                }
                curValue = combineString;
            }          

            return curValue;
        }
    }
}
