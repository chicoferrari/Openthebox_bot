using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.Utils
{
    public class UniqueRandom
    {
        public int GetRandomExcept(int min, int max, List<int> exceptionList)
        {
            var random = new Random();
            var rand = random.Next(min, max);

            while (exceptionList.Contains(rand))
                rand = random.Next(min, max);

            return rand;
        }
    }
}