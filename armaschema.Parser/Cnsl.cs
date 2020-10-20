using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace armaschema.Parser
{
    static class Cnsl
    {
        public static void WriteTd(string message, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("----------------");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Brk(char brkChar = '#', int length = 10, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(String.Concat(Enumerable.Repeat(brkChar, length)));
            Console.ResetColor();
        }
    }
}
