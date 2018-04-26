using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedleInAHaystack
{
    class Program
    {
        static void Main(string[] args)
        {

            var bob =StrStr("aerttyljsdgvsjgsjdgsjdhgjshsjadhgfjdshgfjsgfdsafhzzz", "zzz");
            int StrStr( string haystack, string needle)
            {
                var haystackArr = haystack.ToCharArray();
                var needleArr = needle.ToCharArray();
                for(int i = 0; i< haystackArr.Length; i++)
                {
                    for(int j = 0; j < needleArr.Length; j++)
                    {
                        if(needleArr[j]== haystackArr[i])
                        {
                            return i;
                        }
                    }
                }
                return -1;
            }
        }
    }
}
