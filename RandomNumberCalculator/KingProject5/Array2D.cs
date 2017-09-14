/****************************************************************************************************************************************
 * Bellevue Class:  PROG 110
 * Instructor:  S. Unwin
 * Term:  Fall 2013
 * 
 * Solution/Project Name:  KingProject4
 * File Name:  AmortPayment.cs
 * 
 *This program will populate a 10 x 5 Array
 *with random numbers between 1 - 100 (inclusive).
 *After the numbers are populated, the console will
 *display a sum and average of the numbers displayed.
 *
 * It will ask the user if they would like to populate
 * another table, and if so it will generate a different
 * random number table.
 * 
 * Programmer:  Whitney King
 * Assigned Project Number:  5
 * 
 * Revision       Date               Release Comment
 * --------     ---------            ---------------
 * 1.0          11/20/2013            Initial Code Concept, Testing, Finalization
 *
 *  - Displays Table Header
 *  - Displays 10 x 5 number table
 *  - Sums Numbers in Table
 *  - Averages Numbers in Table
 *  - Prompts for new table with graceful error handling
 *  - Closes if no additional table is desired
 * 
 ***************************************************************************************************************************************/

using System;

namespace KingProject5
{
    class Array2D
    {
        static void Main()
        {

            /***************************************************************************************************************************/
            /*                                                Console Window Settings                                                  */
            /***************************************************************************************************************************/

            Console.Title = "Whitney King - Project 5";                           //Set Console Title
            Console.SetWindowSize(77, 35);                                        //Set Console Dimesions

            /***************************************************************************************************************************/
            /*                                                      Variables                                                          */
            /***************************************************************************************************************************/

            string continueProgram;
            const int ROW = 10,
                      COLS = 5,
                      MAX = 100,
                      MIN = 1;
            int[ , ] numbers = new int[ROW, COLS];
            bool recalculate = true,
                 errorHandling;
            Random rand = new Random();

            /***************************************************************************************************************************/
            /*                                                   Program Display                                                       */
            /***************************************************************************************************************************/
            
            do                                                     //Begin Random Number Calculation
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;                                 //Color Console Text
                Console.WriteLine(".oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.\n");
                Console.ForegroundColor = ConsoleColor.DarkGray;                                  //Color Console Text
                Console.WriteLine(@"            _____________________________________________________");
                Console.WriteLine(@"   ________|                                                     |_______");
                Console.Write(@"   \       |       ");
                Console.ForegroundColor = ConsoleColor.Magenta;                                   //Color Console Text
                Console.Write(" Welcome to the Random Number Calculator! ");
                Console.ForegroundColor = ConsoleColor.DarkGray;                                  //Color Console Text
                Console.WriteLine("    |      /");
                Console.Write(@"    \      |              ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;                               //Color Console Text
                Console.Write("Created By:  Whitney King       ");
                Console.ForegroundColor = ConsoleColor.DarkGray;                                  //Color Console Text
                Console.WriteLine("       |     /");
                Console.WriteLine(@"    /      |_____________________________________________________|     \ ");
                Console.WriteLine(@"   /__________)                                               (_________\ ");
                Console.WriteLine();

                int sum = 0;                                                                      //Reset sum and average
                double average = 0;

                //======================================================Fill Array========================================================
                for(int X = 0; X < numbers.GetLength(0); ++X)
                {
                    for (int Y = 0; Y < numbers.GetLength(1); ++Y)
                    {
                        int randomNumber = rand.Next(MIN, MAX);   //Generate Random Number
                        numbers[X, Y] = randomNumber;             //Assign Random Number to specific Array location
                    }
                }

                foreach (int calcSum in numbers)
                {
                    sum += calcSum;
                    average += calcSum;
                }

                average = Convert.ToDouble(average / (ROW * COLS));

                //=====================================================Table Title=======================================================
                Console.Write("\t\t ");
                for (int count = 0; count < 42; count++)                                         //Loop for Line of -
                    Console.Write("-");
                Console.Write("\n\t\t |         ");
                Console.ForegroundColor = ConsoleColor.Magenta;                                  //Color Console Text
                Console.Write("Table of Random Numbers");
                Console.ForegroundColor = ConsoleColor.DarkGray;                                 //Color Console Text
                Console.WriteLine("        |");                                                  //Title
                Console.Write("\t\t |                ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;                              //Color Console Text
                Console.Write("(1 - 100)");
                Console.ForegroundColor = ConsoleColor.DarkGray;                                 //Color Console Text
                Console.Write("               |");                                               //Title
                Console.Write("\n\t\t ");
                for (int count = 0; count < 42; count++)                                         //Loop for Line of -
                    Console.Write("-");
                Console.WriteLine("\n\t\t |                                        |");

                //=====================================================Table Display=======================================================
                for (int X = 0; X < numbers.GetLength(0); ++X)     
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;                            //Color Console Text
                    Console.Write("\t\t |   ");                    
                    for (int Y = 0; Y < numbers.GetLength(1); ++Y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;                        //Color Console Text
                        Console.Write("{0,6}",                                                  //Display Random Numbers
                            numbers[X, Y]);
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;                            //Color Console Text
                    Console.Write("\t  |");    
                    Console.WriteLine();
                }
                Console.Write("\t\t |                                        |\n");
                Console.Write("\t\t ");
                for (int count = 0; count < 42; count++)                                       //Loop for Line of -
                    Console.Write("-");
                Console.Write("\n\t\t |    ");
                Console.ForegroundColor = ConsoleColor.Cyan;                                   //Color Console Text
                Console.Write("Sum:  {0,5}       Average:  {1,5}",
                    sum.ToString("N0"),
                    average.ToString("F2"));                       //Display sum and average
                Console.ForegroundColor = ConsoleColor.DarkGray;                               //Color Console Text
                Console.Write("   |\n");
                Console.Write("\t\t ");
                for (int count = 0; count < 42; count++)                                       //Loop for Line of -
                    Console.Write("-");
                Console.ForegroundColor = ConsoleColor.DarkGreen;                              //Color Console Text
                Console.WriteLine("\n\n.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.");

           /***************************************************************************************************************************/
           /*                                                    Pause Program                                                        */
           /***************************************************************************************************************************/

                //=================================================New Table Prompt====================================================
                Console.ForegroundColor = ConsoleColor.DarkYellow;                             //Color Console Text
                Console.Write("\n\n\tWould you like to generate a new random table? (Y or N) >> ");
                Console.ForegroundColor = ConsoleColor.White;                                  //Color Console Text
                continueProgram = Console.ReadLine();
                continueProgram = continueProgram.ToUpper();

                switch (continueProgram)                                                       //Loop to Recalculate Random Numbers
                {
                    case "Y":
                        recalculate = true;
                        Console.Clear();
                        break;
                    case "N":
                        recalculate = false;
                        break;
                    //=================================================Error Handling==================================================
                    default:                                                                   //Handle Invalid Data
                        {
                            errorHandling = true;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Red;                        //Color Console Text
                            Console.WriteLine("\n\tInvalid Data Entered. Please indicate 'Y' or 'N'.");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;                 //Color Console Text
                            Console.Write("\n\tWould you like to generate a new random table? (Y or N) >> ");
                            Console.ForegroundColor = ConsoleColor.White;                      //Color Console Text
                            continueProgram = Console.ReadLine();
                            continueProgram = continueProgram.ToUpper();
                            if (continueProgram == "Y")
                            {
                                Console.Clear();
                                errorHandling = false;
                                recalculate = true;
                                
                            }
                            else if (continueProgram == "N")
                            {
                                errorHandling = false;
                                recalculate = false;
                            }
                            else
                                errorHandling = true;
                        }while(errorHandling == true);
                        }
                        break;
                }

            } while (recalculate == true);                                                      //End first do loop

            Console.Clear();
            /***************************************************************************************************************************/
            /*                                                    Closing Screen                                                       */
            /***************************************************************************************************************************/
            Console.ForegroundColor = ConsoleColor.DarkGreen;                              //Color Console Text
            Console.WriteLine("\n.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.");
            Console.ForegroundColor = ConsoleColor.DarkGray;                            //Color Console Text
            Console.WriteLine();
            Console.WriteLine(@"            _____________________________________________________");
            Console.WriteLine(@"   ________|                                                     |_______");
            Console.Write(@"   \       |  ");
            Console.ForegroundColor = ConsoleColor.Magenta;                            //Color Console Text
            Console.Write("Thank you for using the Random Number Calculator!");        //Closing Message
            Console.ForegroundColor = ConsoleColor.DarkGray;                           //Color Console Text
            Console.WriteLine("  |      /");
            Console.Write(@"    \      |       ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                        //Color Console Text
            Console.Write("Please press any key to end the program.");                 //End instruction
            Console.ForegroundColor = ConsoleColor.DarkGray;                           //Color Console Text
            Console.WriteLine("      |     /");
            Console.WriteLine(@"    /      |_____________________________________________________|     \ ");
            Console.WriteLine(@"   /__________)                                               (_________\ ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;                                //Color Console Text
            //ASCII Source Credit:  http://chris.com/ascii/index.php?art=holiday/thanksgiving
            Console.WriteLine("                         _  _");
            Console.WriteLine(@"                        | || |__ _ _ __ _ __ _  _");   //Happy Thanksgiving
            Console.WriteLine(@"                        | __ / _` | '_ \ '_ \ || |");
            Console.WriteLine(@"                        |_||_\__,_| .__/ .__/\_, |");
            Console.WriteLine(@"           _____ _              _ |_|  |_|  _|__/   _");
            Console.WriteLine(@"          |_   _| |_  __ _ _ _ | |_______ _(_)__ __(_)_ _  __ _");
            Console.WriteLine(@"            | | | ' \/ _` | ' \| / (_-< _` | |\ V /| | ' \/ _` |");
            Console.WriteLine(@"            |_| |_||_\__,_|_||_|_\_|__|__, |_| \_/ |_|_||_\__, |");
            Console.WriteLine(@"                                      |___/               |___/");
            Console.ForegroundColor = ConsoleColor.DarkYellow;                         //Color Console Text
            Console.WriteLine();                                                       //Pilgrim ASCII
            Console.WriteLine(@"                                                          .:.");
            Console.WriteLine(@"                                                      .:. \|/  .:.");
            Console.WriteLine(@"                        _                \\,///       \|/  |   \|/");
            Console.WriteLine(@"                      _/_\_    ___       \\|///    <#> |  \|<#> |");
            Console.WriteLine(@"                      (' ')   /.-.\       (')\\       \|<#>|/  \| /");
            Console.WriteLine(@"              _       //U\\   |(')|      //-\\\        |  \| /<#>/");
            Console.WriteLine(@"             ( )   _  \|_|/   /)v(\  <#>_/|_|/\\     \ |/  |/  \|");
            Console.WriteLine(@"            (_` )_('>  | |    \/~\/       |||\\\      \|   |    |/");
            Console.WriteLine(@"            (__,~_)8   |||    //_\\       ||| \\       |/ \| / \| /");
            Console.WriteLine(@"               _YY_   _[|]_  /_____\     _[|]_        \|   |/   |/");
            Console.WriteLine(@"     '''''''''''''''''''''''''''''''''''''''''''''^^^^^^^^^^^^^^^^");
            Console.ForegroundColor = ConsoleColor.DarkGreen;                              //Color Console Text
            Console.WriteLine();
            Console.WriteLine(".oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.");
            Console.ReadKey();
        }
    }
}
