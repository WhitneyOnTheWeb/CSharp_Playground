/****************************************************************************************************************************************
 * Bellevue Class:  PROG 110
 * Instructor:  S. Unwin
 * Term:  Fall 2013
 * 
 * Solution/Project Name:  KingProject3
 * File Name:  Invoice2.cs
 * 
 * This program will generate an invoice for an order of Tribbles
 * from Tribbles Habitat for Happiness based on user generated
 * input about the purchaser and order. Additionally, it will
 * validate the data entered into each field by the user.
 * 
 * Programmer:  Whitney King
 * Assigned Project Number:  3
 * Revision       Date               Release Comment
 * --------     ---------            ---------------
 * 1.0          10/20/2013            Code Edits for Feature Requests
 *
 * **Asks user for:
 *      - Name
 *      - Address
 *      - City
 *      - State
 *      - Zip Code
 *      - Number of Tribbles Purchased
 *      
 * **Prompts user to generate invoice after all info is entered.
 * **Generates formatted invoice with order info in the command window.
 * **Bases price for Tribbles on the total number of Tribbles ordered.
 * **Prompts user to close window with keypress. Must be reopened for additional invoices.
 * 
 ***************************************************************************************************************************************/

using System;                                                                      //Namespaces used by the file
namespace KingProject3
{
 /**************************************************************************************************************************************
 *This class will prompt user for info and return formatted information about their order
 ***************************************************************************************************************************************/
    class Invoice2
    {
        static void Main()                                                         //Begin invoice method
        {
            /*******************************************************************************************************************************/
            /*Variables*/
            /*******************************************************************************************************************************/
            string name,                                                           //Declare String variables
                   streetAddress,
                   city,
                   state,
                   zipCode;                                                        //Declare Integer variables
            int tribbleCount;
            const double TAX_RATE = 0.095;                                         //Declare Constants
            const string BUSINESS_NAME = "Tribbles Habitat for Happiness";
            double tribblePrice = 0,                                               //Declare double variables
                   subTotal,
                   taxAmount,
                   totalPrice;

            /******************************************************************************************************************************/
            /*Console Window Settings and Text*/
            /******************************************************************************************************************************/
            // Window Settings

            Console.Title = "Whitney King - Project 3";                           //Set Console Title
            Console.SetWindowSize(90, 45);                                        //Set Console width and height
            Console.ForegroundColor = ConsoleColor.DarkGreen;                     //Color Console Text

            // Intro

            Console.WriteLine("\n   This program will create an invoice for an order from {0}\n", BUSINESS_NAME);
            Console.ForegroundColor = ConsoleColor.DarkCyan;                      //Color Console Text
            Console.WriteLine("***********************************************************************" +
                              "*******************\n");
            //User Input 

            //Name
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                   //Color Console Text
            Console.Write("           Enter Full Name (First and Last) >> ");     //Ask for Name
            Console.ForegroundColor = ConsoleColor.Green;                         //Color Input Text
            name = Console.ReadLine();                                            //Assign user input to name

            //Street Address
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                   //Color Console Text
            Console.Write("           Enter Street Address >> ");                 //Ask for Street Address
            Console.ForegroundColor = ConsoleColor.Green;                         //Color Input Text
            streetAddress = Console.ReadLine();                                   //Assign user input to streetAddress

            //City
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                   //Color Console Text
            Console.Write("           Enter City >> ");                           //Ask for City
            Console.ForegroundColor = ConsoleColor.Green;                         //Color Input Text
            city = Console.ReadLine();                                            //Assign user input to city

            //State
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                   //Color Console Text
            Console.Write("           Enter State (2 Letters) >> ");              //Ask for State
            Console.ForegroundColor = ConsoleColor.Green;                         //Color Input Text
            state = Console.ReadLine();                                           //Assign user input to state

            //Zip Code
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                   //Color Console Text
            Console.Write("           Enter Zip Code >> ");                       //Ask for Zip Code
            Console.ForegroundColor = ConsoleColor.Green;                         //Color Input Text
            zipCode = Console.ReadLine();                                         //Assign user input to zipCode

            //Number of Tribbles
            Console.ForegroundColor = ConsoleColor.DarkMagenta;                   //Color Console Text
            Console.Write("           Number of Tribbles Desired >> ");           //Ask for number to order
            Console.ForegroundColor = ConsoleColor.Green;                         //Color Input Text
            tribbleCount = Convert.ToInt32(Console.ReadLine());                   //Assign user input to tribbleCount
            tribbleCount.ToString();                                              //Handle bug if letters are input

            /******************************************************************************************************************************/
                                                             /*Calculate Tribble Price*/
            /******************************************************************************************************************************/

            if ((tribbleCount > 0) && (tribbleCount < 11))                        //Tribble Price is $130.50 if 1 - 10 are purchased                    
                tribblePrice = 130.50;
            else if ((tribbleCount < 26) && (tribbleCount > 10))                  //Tribble Price is $99.99 if 11 - 25 are purchased
                tribblePrice = 99.99;
            else if (tribbleCount > 25)                                           //Tribble Price is $55.25 each if 26 or more are purchased.
                tribblePrice = 55.25;
            else
                tribblePrice = 0;                                                 //Sets tribblePrice to 0 for error handling

            /******************************************************************************************************************************/
                                                                /*Error Handling
            /******************************************************************************************************************************/

            if (tribblePrice <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;      //Color Console Text
                Console.Write("           Invalid amount of Tribbles. Please restart the program and carefully follow prompts "); //Invalid data message
                Console.ReadKey();                                       //Close Program
            }
            else if (((name == null) || (name.Length == 0))
                   || ((streetAddress == null) || (streetAddress.Length == 0))
                   || ((city == null) || (city.Length == 0))
                   || ((state == null) || ((state.Length == 0)) || ((state.Length > 2) || (state.Length < 2))
                   || ((zipCode == null) || ((zipCode.Length == 0) || (zipCode.Length > 5)))))
            {
                Console.ForegroundColor = ConsoleColor.Red;      //Color Console Text
                Console.Write("\n\n\n               You have entered invalid data into one or more fields.\n           " +
                              "    Please restart the program and carefully follow prompts."); //Invalid data message
                Console.ReadKey();                               //Close Program
            }

            /******************************************************************************************************************************/
                                                                /*Invoice Display
            /******************************************************************************************************************************/

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;                        //Color Console Text
                Console.WriteLine("\n\n                  Please review the above data, if any fields are incorrect,\n" +
                                  "                         please close the program and start over.\n" +
                                  "               If all data is correct, press any key to continue to your invoice.\n\n");
                Console.ReadKey();
                Console.Clear();
                //Header, Display Banner
                Console.ForegroundColor = ConsoleColor.DarkCyan;                        //Color Console Text
                Console.WriteLine("\n***********************************************************************" +
                                  "*******************\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;                      //Color Console Text
                Console.WriteLine(@"                   _______________________________________________________");
                Console.WriteLine(@"          ________|                                                       |_______");
                Console.WriteLine(@"          \       |              {0}           |      /", BUSINESS_NAME);               //Display Business Name in Banner
                Console.WriteLine(@"           \      |                        Invoice                        |     /");
                Console.WriteLine(@"           /      |_______________________________________________________|     \ ");
                Console.WriteLine(@"          /__________)                                                 (_________\ ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;                        //Color Console Text
                Console.WriteLine("\n\n***********************************************************************" +
                                  "*******************\n\n");

                //Order summary
                Console.ForegroundColor = ConsoleColor.DarkMagenta;                     //Color Console Text
                Console.WriteLine("              You've ordered {0} colorful tribbles at a price of {1} each.\n\n",
                                 tribbleCount,
                                 tribblePrice.ToString("C"));

                //Address Confirmation
                Console.WriteLine("                             The tribbles will be shipped to:\n\n");
                Console.ForegroundColor = ConsoleColor.Green;                           //Color Console
                Console.WriteLine("                                " + "{0, -30}",      //Write Name
                                 name);           //0 
                Console.WriteLine("                                " + "{0, -30}",      //Write Street Address
                                 streetAddress);  //0
                state = state.ToUpper();
                Console.WriteLine("                                " + "{0, -15}" + "{1, 3}" + "{2, 6}",  //Write City, State, Zip
                                 city,            //0
                                 state,           //1
                                 zipCode);        //2

                //Cost Breakdown
                subTotal = tribbleCount * tribblePrice;                        //ReCalculate Subtotal
                taxAmount = subTotal * TAX_RATE;                                //ReCalcuate Tax
                totalPrice = subTotal + taxAmount;                              //ReCalcuate Total

                Console.ForegroundColor = ConsoleColor.Red;                     //Color Console Text

                Console.WriteLine("\n");
                Console.WriteLine("                " + "{0, 25}" + "{1, 15}",                        //Write/Format Subtotal
                                 "Subtotal:",               //0
                                 subTotal.ToString("C"));   //1
                Console.WriteLine("                " + "{0, 25}" + "{1, 15}",                        //Write/Format Tax Amount
                                 "9.5% Tax:",               //0
                                 taxAmount.ToString("C"));  //1
                Console.WriteLine("                                ------------------------");       //Write Total Line
                Console.WriteLine("                " + "{0, 25}" + "{1, 15}",                        //Write Total Amount
                                 "Total:",                  //0
                                 totalPrice.ToString("C")); //1
                Console.ForegroundColor = ConsoleColor.DarkCyan;                       //Color Console Text
                Console.WriteLine("\n\n***********************************************************************" +
                                  "*******************");

                //Closing

                Console.ForegroundColor = ConsoleColor.DarkGreen;                     //Color Console Text
                Console.WriteLine("          Thank you for using the {0} invoice program\n" +
                                 "                                 created by Whitney King.\n\n" +
                                 " Press any key to exit the program. Please reopen this program to create another invoice.\n",
                                 BUSINESS_NAME);
                Console.ForegroundColor = ConsoleColor.DarkCyan;                      //Color Console Text
                Console.WriteLine("***********************************************************************" +
                                  "*******************");
                Console.ReadKey();
            }
        }
    }
 }
