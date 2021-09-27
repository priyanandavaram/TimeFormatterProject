using System;

namespace TimeFormatToWordFormatConverter
{
    public class TimeFormatConverter
    {
        public const string CurrentSystemTime = "Current system time in 24 hr format - ";
        public const string Message = "System time is converted to Human Friendly text and now the time is - ";
        public const string UserInputMsg = "Please enter numeric time in hh:mm format to convert to Human Readable text : \n";

        public const string ValidationTimeRangeMsg = "Incorrect input. Please enter time in hh:mm format and should be within the 24 hr range. \n";
        public const string ValidationNumericsOnlyMsg = "Incorrect input. Please enter only numeric values. \n";
        public const string ValidationFormatMsg = "Incorrect input. Please enter time in hh:mm format. \n";
        public const string ExitConsoleMsg = "Please press any key to exit the console";

        /* Objective-1 examples - 13:25 - TwentyFive past one, 13:30 - Half past one, 13.31 - twentynine to two
         * Objective-2 examples - 13:00 - One o'clock, 15:00 - Three o'clock, 15:45 - Fifteen to four
         *
         * First step - Display the system time - hours and minutes in 24hr format
          We can also use hh:mm:ss to use 12 hr format.
         * Second step - Later display the Human Friendly text based on system time
         * Third step - Allow user to input the time and validate the user input and convert it to Human Friendly text
         * 
         * Avoiding the duplicate code and reusing the same code for System date and user entered date with passing different time
         * Since this is a test, I'm using same class for enums and constants (In real-time they can be placed in diff classes)
         */

        public void NumericTimeFormatConverter()
        {
            var CurrentTime = DateTime.Now.ToString("HH:mm");

            Console.WriteLine(CurrentSystemTime + CurrentTime + "\n");

            NumericTimeFormatConverter(CurrentTime, false); // False flag to skip the validations for system time

            Console.WriteLine(UserInputMsg); 

            int n;

            string UserEnteredTime = Console.ReadLine();

            string CachingUserEnteredTime = UserEnteredTime; // As we're replacing : for validation purpose, we're storing the value

            /* Validating the user input - User format hh:mm
             * Check for only numberic values, 
             * Format should contain : to distinguish between hrs and mins
             * There should be only 4 numerics 
             * Hours range between 1-23 & mins range between 01-59
             */
            if (!int.TryParse(UserEnteredTime.Replace(":", ""), out n))
            {
                Console.WriteLine(ValidationNumericsOnlyMsg);
            }
            else if (!CachingUserEnteredTime.Contains(":"))
            {
                Console.WriteLine(ValidationFormatMsg);
            }
            else
            {
                NumericTimeFormatConverter(CachingUserEnteredTime, true);
            }
            Console.WriteLine(ExitConsoleMsg);
            Console.ReadKey();
        }
        // Common code functionality for user input and system time
        public void NumericTimeFormatConverter(string Time, bool UserInput)
        {
            string[] HourandMinutes = Time.Split(':');

            int GetHoursfromTime = HourandMinutes[0].Length == 2 ? Convert.ToInt32(HourandMinutes[0]) : 100; //Length to validate for user input, default it will be always 2 for system time

            int GetMinutesfromTime = HourandMinutes[1].Length == 2 ? Convert.ToInt32(HourandMinutes[1]) : 100;

            if (UserInput == false || (UserInput == true && GetHoursfromTime != 100 && GetMinutesfromTime != 100 &&
                (GetHoursfromTime >= 1 && GetHoursfromTime <= 23) && (GetMinutesfromTime >= 00 && GetMinutesfromTime <= 59)))
            {
                //Logic to get the relevant word from enum
                string GetHoursinWordFormat = GetMinutesfromTime <= 30 ? (GetHoursfromTime > 12 ? Convert.ToString((Hours)GetHoursfromTime)
                    : Convert.ToString((Minutes)GetHoursfromTime))
                    : (GetHoursfromTime >= 12 ? Convert.ToString((Hours)(GetHoursfromTime + 1))
                    : Convert.ToString((Minutes)GetHoursfromTime + 1));

                if (GetMinutesfromTime < 30 && GetMinutesfromTime != 0)
                {
                    Console.WriteLine(Message + (Minutes)GetMinutesfromTime + " past " + GetHoursinWordFormat.ToLower() + "\n");
                }
                else if (GetMinutesfromTime == 30)
                {
                    Console.WriteLine(Message + "Half past " + GetHoursinWordFormat.ToLower() + "\n");
                }
                else if (GetMinutesfromTime > 30)
                {
                    int DiffMinute = 60 - GetMinutesfromTime;
                    Console.WriteLine(Message + (Minutes)DiffMinute + " to " + GetHoursinWordFormat.ToLower() + "\n");
                }
                else if (GetMinutesfromTime == 00 || GetMinutesfromTime == 0)
                {
                    Console.WriteLine(Message + GetHoursinWordFormat + " o'clock \n");
                }
            }
            else
            {
                Console.WriteLine(ValidationTimeRangeMsg);
            }

        }

        /* Converting numeric 1 to one can be done using Humanizer dll but due to Virgin Money laptop access related issues
         I couldn't install that dll in my VS2019 */
        enum Hours
        {
            One = 13,
            Two = 14,
            Three = 15,
            Four = 16,
            Five = 17,
            Six = 18,
            Seven = 19,
            Eight = 20,
            Nine = 21,
            Ten = 22,
            Eleven = 23,
            Twelve_AM = 24
        }

        enum Minutes : int
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Eleven = 11,
            Twelve = 12,
            Thirteen = 13,
            Fourteen = 14,
            Fifteen = 15,
            Sixteen = 16,
            Seventeen = 17,
            Eighteen = 18,
            Nineteen = 19,
            Twenty = 20,
            Twentyone = 21,
            Twentytwo = 22,
            Twentythree = 23,
            Twentyfour = 24,
            Twentyfive = 25,
            Twentysix = 26,
            Twentyseven = 27,
            Twentyeight = 28,
            Twentynine = 29,
            Thirty = 30,
            Thirtyone = 31,
            Thirtytwo = 32,
            Thirtythree = 33,
            Thirtyfour = 34,
            Thirtyfive = 35,
            Thirtysix = 36,
            Thirtyseven = 37,
            Thirtyeight = 38,
            Thirtynine = 39,
            Forty = 40,
            Fortyone = 41,
            Fortytwo = 42,
            Fortythree = 43,
            Fortyfour = 44,
            Fortyfive = 45,
            Fortysix = 46,
            Fortyseven = 47,
            Fortyeight = 48,
            Fortynine = 49,
            Fifty = 50,
            Fiftyone = 51,
            Fiftytwo = 52,
            Fiftythree = 53,
            Fiftyfour = 54,
            Fiftyfive = 55,
            Fiftysix = 56,
            Fiftyseven = 57,
            Fiftyeight = 58,
            Fiftynine = 59,
            Sixty = 60

        }

    }
}
