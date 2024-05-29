using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sieu_thi_mini.Test;

namespace sieu_thi_mini.Test
{
    public static class debugTest
    {
        public static void ModulTests() 
        {
            try
            {
                int num = 0;

                test wTest = new test();

                string result = wTest.ReturnTest(num);

                if (result == "HELLO")
                {
                    Console.WriteLine("PASSED: TestDumbestFun");
                }
                else
                {
                    Console.WriteLine("FAILD: Error");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
