using System;
using static System.Console;

namespace QueenslandRevenue 
{
    internal class Program 
    {
        static void Main(string[] args) 
        {
            WriteLine("------------- Task 1 ---------------\n");
            WriteLine("*********************************\n" +
                "*                               *\n" +
                "* The Stars shine in Queensland *\n" +
                "*                               *\n" +
                "*********************************");

            WriteLine("\n------------- Task 2 ---------------\n");
            
            int contestant2021, contestant2022;
            int total;
            const int MIN = 0, MAX = 30;
            const int QUIT = 999;

            Write("Number of contestants in 2021: ");
            contestant2021 = Convert.ToInt32(ReadLine());
            
            while (contestant2021 != QUIT) //The contestants last year
            {
                if (contestant2021 < MIN || contestant2021 > MAX)
                {
                    Write("Out of range, please re-enter: "); //re-enter as a new input
                    contestant2021 = Convert.ToInt32(ReadLine());
                }
                else
                    break;
            }
            Write("Number of contestants in 2022: ");
            contestant2022 = Convert.ToInt32(ReadLine());

            while (contestant2022 != QUIT)
            {
                if (contestant2022 < MIN || contestant2022 > MAX)
                {
                    Write("Out of range, please re-enter: ");
                    contestant2022 = Convert.ToInt32(ReadLine());
                }
                else
                    break;
            }
            total = contestant2022 * 25; //total revenue this year
            WriteLine("\n------------- Task 3 ---------------\n" +
                "\nThe revenue expected for 2022 is {0}.", total);

            WriteLine("\n------------- Task 4 ---------------\n");

            if (contestant2022 > 2 * contestant2021)
                WriteLine("The competition is more than twice as big this year!");
            if (contestant2022 > contestant2021 && contestant2022 < 2 * contestant2021)
                WriteLine("The competition is bigger than ever!");
            if (contestant2022 <= contestant2021)
                WriteLine("A tighter race this year! Come out and cast your vote!");
            
            WriteLine("\n------------- Task 5 ---------------\n");

            string[] names = new string[contestant2022];
            char[] codes = new char[contestant2022];
            string[] Talents = { "Singing", "Dancing", "Musical", "Other" };
            char[] talentCode = { 'S', 'D', 'M', 'O' };
            int[] attend = new int[Talents.Length];
            string entryName;
            char entryCode;
            int i, j;

            WriteLine("Competition codes\n" +
                "S: sing\n" +
                "D: dance\n" +
                "M: play instruments\n" +
                "O: other\n");

            for (i = 0; i < contestant2022; i++)
            {
                Write("Please enter contestant name {0}: ", (i + 1));
                entryName = ReadLine();
                names[i] = entryName;
                bool codeFound = false; //reset loop after input the talent code

                while (!codeFound)
                {
                    Write("Please enter contestant talent code: ");
                    codes[i] = Convert.ToChar(ReadLine());

                    for (j = 0; j < talentCode.Length && !codeFound; j++)
                        if (codes[i] == talentCode[j])
                            codeFound = true;
                    if (!codeFound)
                        WriteLine("Invalid code.");
                }
            }
            for (i = 0; i < talentCode.Length; i++)
                for (j = 0; j < codes.Length; j++)
                    if (codes[j] == talentCode[i])
                        attend[i]++;
            for (j = 0; j < Talents.Length; ++j)
                WriteLine("Number of contestant with {0} talent is {1}.", Talents[j], attend[j]);

            bool validCode = false;
            Write("\nSearch for the info of talent code or '!' to quit: ");
            entryCode = Convert.ToChar(ReadLine());

            while (entryCode != '!')
            {
                for (i = 0; i < contestant2022; ++i)
                {
                    if (entryCode == talentCode[i] && entryCode != '!')
                    {
                        validCode = true;
                        WriteLine("\nThe contestant(s) is/are: ");
                        for (j = 0; j < codes.Length; j++)
                            if (codes[j] == entryCode)
                                WriteLine("{0}", names[j]); //list of names
                    }
                    else if (entryCode == '!')
                        break;                                            
                }
                if (!validCode)
                {
                    Write("Invalid code. Please enter info of talent code or '!' to quit: ");
                    entryCode = Convert.ToChar(ReadLine());
                }
                else
                    break;
            }            
        }
    }
}