using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeFormatToWordFormatConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * We can implement memory management in various ways.
             * But not deep diving into that, Since this is the only managed resource CLR will take care else we can use dispose()
             */
            TimeFormatConverter converter = new TimeFormatConverter();
            converter.NumericTimeFormatConverter();
        }
    }
}
