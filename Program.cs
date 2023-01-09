using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KizhiPart1
{
    public class Program
    {
        public static void Main()
        {
            for (int i = 0; i < 5;i++)
            {
                var command = Console.ReadLine();
                Interpreter.ExecuteLine(command);
            }
        }
    }
}
