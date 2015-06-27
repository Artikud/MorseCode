using System;
using System.Collections.Generic;
using System.Threading;

namespace MorseCode
{
    static class Program
    {
        public static Dictionary<char, List<byte>> MorseAlphabet { get; private set; }
        private static readonly char EndMessageSymbol = '~';

        static Program()
        {
            MorseAlphabet = new Dictionary<char, List<byte>>
            {
                {'a', new List<byte>{0,1}},
                {'b',new List<byte>{1,0,0,0}},
                {'w',new List<byte>{0,1,1}},
                {'g',new List<byte>{1,1,0}},
                {'d',new List<byte>{1,0,0}},
                {'e',new List<byte>{0}},
                {'v',new List<byte>{0,0,0,1}},
                {'z',new List<byte>{1,1,0,0}},
                {'i',new List<byte>{0,0}},
                {'j',new List<byte>{0,1,1,1}},
                {'k',new List<byte>{1,0,1}},
                {'l',new List<byte>{0,1,0,0}},
                {'m',new List<byte>{1,1}},
                {'n',new List<byte>{1,0}},
                {'o',new List<byte>{1,1,1}},
                {'p',new List<byte>{0,1,1,0}},
                {'r',new List<byte>{0,1,0}},
                {'s',new List<byte>{0,0,0}},
                {'t',new List<byte>{1}},
                {'u',new List<byte>{0,0,1}},
                {'f',new List<byte>{0,0,1,0}},
                {'h',new List<byte>{0,0,0,0}},
                {'c',new List<byte>{1,0,1,0}},
                {'q',new List<byte>{1,1,0,1}},
                {'y',new List<byte>{1,0,1,1}},
                {'x',new List<byte>{1,0,0,1}},
                {'1',new List<byte>{0,1,1,1,1}},
                {'2',new List<byte>{0,0,1,1,1}},
                {'3',new List<byte>{0,0,0,1,1}},
                {'4',new List<byte>{0,0,0,0,1}},
                {'5',new List<byte>{0,0,0,0,0}},
                {'6',new List<byte>{1,0,0,0,0}},
                {'7',new List<byte>{1,1,0,0,0}},
                {'8',new List<byte>{1,1,1,0,0}},
                {'9',new List<byte>{1,1,1,1,0}},
                {'0',new List<byte>{1,1,1,1,1}},
                {'.',new List<byte>{0,0,0,0,0,0}},
                {',',new List<byte>{0,1,0,1,0,1}},
                {'~',new List<byte>{0, 0, 1, 0, 1}}
            };
        }

        static void Main()
        {
            var inputString = Console.ReadLine();
            if (inputString == null)
                return;

            inputString += EndMessageSymbol;
            foreach (var charToMorse in inputString.ToLowerInvariant())
            {
                List<byte> outList;
                if (!MorseAlphabet.TryGetValue(charToMorse, out outList))
                    continue;

                MorseAlphabet[charToMorse].ForEach(sc =>
                {
                    Beep(sc);
                    Thread.Sleep(400);
                });
            }
        }

        private static void Beep(byte signalCode)
        {
            var sygnalLenght = 200;
            if (signalCode.ToBool())
                sygnalLenght = 800;
            Console.Beep(800, sygnalLenght);
        }
        public static bool ToBool(this byte input)
        {
            return input == 1;
        }
    }
}
