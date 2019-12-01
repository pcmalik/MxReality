using MxRealityConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxRealityConsole.Repositories
{
    public class SortUsingBubbleSort : ISort
    {
        public void Sort(string[] stringList)
        {
            if (stringList != null && stringList.Count() > 0)
            {
                string temp;
                int i, j, l;

                l = stringList.Length;

                for (i = 0; i < l; i++)
                {
                    for (j = 0; j < l - 1; j++)
                    {
                        if (stringList[j].CompareTo(stringList[j + 1]) > 0)
                        {
                            temp = stringList[j];
                            stringList[j] = stringList[j + 1];
                            stringList[j + 1] = temp;
                        }
                    }
                }
            }
        }

        public void Reverse(string[] stringList)
        {
            string[] reversedStringList = new string[stringList.Length];
            int i = 0, j = stringList.Length - 1;

            while (i < stringList.Length)
            {
                reversedStringList[i++] = stringList[j--];
            }

            for(var k = 0; k < stringList.Length; k++)
            {
                stringList[k] = reversedStringList[k];
            }
            
        }

    }
}
