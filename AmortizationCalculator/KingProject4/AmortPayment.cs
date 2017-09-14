/****************************************************************************************************************************************
 * Bellevue Class:  PROG 110
 * Instructor:  S. Unwin
 * Term:  Fall 2013
 * 
 * Solution/Project Name:  KingProject4
 * File Name:  AmortPayment.cs
 * 
 *This program will calculate the interest rate for 
 *loans from Vulcan International Bank.
 *Based on data entered by the user, an amortization
 *schedule and summary of their loan will be produced.
 * 
 * Programmer:  Whitney King
 * Assigned Project Number:  4
 * 
 * Revision       Date               Release Comment
 * --------     ---------            ---------------
 * 1.0          11/5/2013            Initial Code Concept and Layout
 * 1.1          11/6/2013            Code for Table Output / Math
 * 1.2          11/7/2013            Math Troubleshooting and Updates
 * 1.3          11/8/2013            Math Troubleshooting and Updates
 *
 * Prompts user for:
 * 
 *        - Loan Amount
 *        - Annual interest Rate
 *        - Years (Term of Loan)
 *          
 * Monthly payment rates will be produced in table format
 * showing amount owed each month (principle and interest)
 * through the life of the loan.
 * 
 ***************************************************************************************************************************************/

using System;

namespace KingProject4
{
    class AmortPayment
    {
        static void Main()
        {
            /***************************************************************************************************************************/
            /*                                                Console Window Settings                                                  */
            /***************************************************************************************************************************/
            
            Console.Title = "Whitney King - Project 4";                           //Set Console Title
            Console.SetWindowSize(95, 60);                                        //Set Console Dimesions

            /***************************************************************************************************************************/
            /*                                                       Variables                                                         */
            /***************************************************************************************************************************/

            string inputLoanAmount,
                   inputInterestRate,
                   inputDownPayment,
                   inputLoanYears,
                   continueProgram;
            int loanYears,
                loanMonths;
            double annualInterestRate = 0,
                   monthlyInterestRate = 0,
                   downPayment = 0,
                   loanAmount = 0;
            bool recalculate = true,
                 errorHandling;

            /***************************************************************************************************************************/
            /*                                                     Introduction                                                        */
            /***************************************************************************************************************************/

            Console.ForegroundColor = ConsoleColor.Yellow;                                //Color Console Text
            for (int count = 0; count < 95; count++)                                      //Loop for Line of ►
                Console.Write("►");
           
            Console.ForegroundColor = ConsoleColor.Cyan;                                  //Color Console Text
            Console.WriteLine("\n\t\t\tVulcan International Bank Amortization Calculator\n\n");

            Console.ForegroundColor = ConsoleColor.Blue;                                  //Color Console Text
            Console.WriteLine("     You may use this calculator to generate information on Vulcan International Bank loans" +
                              "\n     based on user specifications. Please enter the desired loan amount, your loan interest" +
                              "\n\t     rate, and the number of years you wish to finance the loan below.\n\n");

            Console.ForegroundColor = ConsoleColor.Yellow;                                //Color Console Text
            for (int count = 0; count < 95; count++)                                      //Loop for Line of ►
                Console.Write("►");

            /***************************************************************************************************************************/
            /*                                                      User Input                                                         */
            /***************************************************************************************************************************/

            do                                                                            //Begin do loop for first calculation
            {
                //==================================================Loan Amount==========================================================
                Console.ForegroundColor = ConsoleColor.Cyan;                              //Color Console Text
                Console.Write("\n\n\tLoan Amount Desired >> ");
                Console.ForegroundColor = ConsoleColor.White;                             //Color Console Text
                inputLoanAmount = Console.ReadLine();                                     //Capture User Input

                if(int.Parse(inputLoanAmount) >= 0)                                       //Data Validation
                    loanAmount = int.Parse(inputLoanAmount);                              //Assign Numeric Value
                else if (inputLoanAmount == "" || int.Parse(inputLoanAmount) < 0)             
                {
                    errorHandling = true;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;                       //Color Console Text
                        Console.WriteLine("\n\tInvalid Data Entered. Please enter only numbers.");
                        Console.ForegroundColor = ConsoleColor.Cyan;                      //Color Console Text
                        Console.Write("\tLoan Amount Desired >> ");
                        Console.ForegroundColor = ConsoleColor.White;                     //Color Console Text
                        inputLoanAmount = Console.ReadLine();                             //Capture User Input
                        if (inputLoanAmount != "")
                            errorHandling = false;
                    } while (errorHandling == true);
                    loanAmount = int.Parse(inputLoanAmount);                              //Assign Numeric Value
                }

                //==================================================Down Payment==========================================================
                Console.ForegroundColor = ConsoleColor.Cyan;                              //Color Console Text
                Console.Write("\n\n\tDown Payment Amount >> ");
                Console.ForegroundColor = ConsoleColor.White;                             //Color Console Text
                inputDownPayment = Console.ReadLine();                                     //Capture User Input

                if (int.Parse(inputLoanAmount) >= 0)                                       //Data Validation
                    downPayment = int.Parse(inputDownPayment);                            //Assign Numeric Value
                else if (inputDownPayment == "" || int.Parse(inputDownPayment) < 0)
                {
                    errorHandling = true;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;                       //Color Console Text
                        Console.WriteLine("\n\tInvalid Data Entered. Please enter only numbers.");
                        Console.ForegroundColor = ConsoleColor.Cyan;                      //Color Console Text
                        Console.Write("\n\n\tDown Payment Amount >> ");
                        Console.ForegroundColor = ConsoleColor.White;                     //Color Console Text
                        inputDownPayment = Console.ReadLine();                             //Capture User Input
                        if (inputDownPayment != "")
                            errorHandling = false;
                    } while (errorHandling == true);
                    downPayment = int.Parse(inputDownPayment);                              //Assign Numeric Value
                }

                //====================================================Interest Rate======================================================
                Console.ForegroundColor = ConsoleColor.Cyan;                              //Color Console Text
                Console.Write("\n\n\tAnnual Interest Rate (ex. 5.5) >> ");
                Console.ForegroundColor = ConsoleColor.White;                             //Color Console Text
                inputInterestRate = Console.ReadLine();                                   //Capture User Input

                if (double.Parse(inputInterestRate) >= 0)                                 //Data Validation
                {
                    annualInterestRate = double.Parse(inputInterestRate);                 //Assign Numeric Values
                    monthlyInterestRate = annualInterestRate / 12 / 100;
                }
                else if (inputInterestRate == "" || double.Parse(inputInterestRate) < 0)
                {
                    errorHandling = true;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;                       //Color Console Text
                        Console.WriteLine("\n\tInvalid Data Entered. Please enter only numbers.");
                        Console.ForegroundColor = ConsoleColor.Cyan;                      //Color Console Text
                        Console.Write("\n\tAnnual Interest Rate (ex. 5.5) >> ");
                        Console.ForegroundColor = ConsoleColor.White;                     //Color Console Text
                        inputLoanAmount = Console.ReadLine();                             //Capture User Input
                        if (inputLoanAmount != "")
                            errorHandling = false;
                    } while (errorHandling == true);
                    annualInterestRate = double.Parse(inputInterestRate);                 //Assign Numeric Values
                    monthlyInterestRate = ((annualInterestRate / 12) / 100);
                }

                //====================================================Loan Years============================================================
                Console.ForegroundColor = ConsoleColor.Cyan;                              //Color Console Text
                Console.Write("\n\n\tTerm of Loan (years, whole) >> ");
                Console.ForegroundColor = ConsoleColor.White;                             //Color Console Text
                inputLoanYears = Console.ReadLine();                                      //Capture User Input

                if (int.Parse(inputLoanYears) > 0)     //Data Validation
                {
                    loanYears = int.Parse(inputLoanYears);                                //Assign Numeric Values
                    loanMonths = loanYears * 12;
                }
                else if (inputLoanYears == "" || int.Parse(inputLoanYears) <= 0)
                {
                    errorHandling = true;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;                       //Color Console Text
                        Console.WriteLine("\n\tInvalid Data Entered. Please enter only numbers.");
                        Console.ForegroundColor = ConsoleColor.Cyan;                      //Color Console Text
                        Console.Write("\n\tTerm of Loan (years, whole) >> ");
                        Console.ForegroundColor = ConsoleColor.White;                     //Color Console Text
                        inputLoanYears = Console.ReadLine();                              //Capture User Input
                        if (inputLoanAmount != "")
                            errorHandling = false;
                    } while (errorHandling == true);
                    loanYears = int.Parse(inputLoanYears);                                //Assign Numeric Values
                    loanMonths = loanYears * 12;
                }
                else
                    {
                        errorHandling = true;    
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Red;                       //Color Console Text
                            Console.WriteLine("\n\tInvalid Data Entered. Please enter only numbers.");
                            Console.ForegroundColor = ConsoleColor.Cyan;                      //Color Console Text
                            Console.Write("\n\tTerm of Loan (years, whole) >> ");
                            Console.ForegroundColor = ConsoleColor.White;                     //Color Console Text
                            inputLoanYears = Console.ReadLine();                              //Capture User Input
                            if (inputLoanAmount != "")
                                errorHandling = false;
                        } while (errorHandling == true);
                        loanYears = int.Parse(inputLoanYears);                                //Assign Numeric Values
                        loanMonths = loanYears * 12;
                    }

                //=======================================================================================================================

                Console.ForegroundColor = ConsoleColor.White;                             //Color Console Text
                Console.WriteLine("\n\t\tPress any key to continue to the amortization table for your loan");
                Console.ReadKey();

             /***************************************************************************************************************************/
             /*                                                    Table Output                                                         */
             /***************************************************************************************************************************/

                //====================================================Math Variables=====================================================
                int numberPayments = loanMonths;
                double loanBalance = loanAmount - downPayment,
                       interestTerm = Math.Pow((1 + monthlyInterestRate), numberPayments),
                       monthlyPaymentAmount = ((monthlyInterestRate * (loanAmount - downPayment) * interestTerm) / (interestTerm - 1)),
                       monthlyInterestPaid = loanBalance * monthlyInterestRate,
                       monthlyPrincipalPaid = 0,
                       interestTotal = 0;

                //=====================================================Table Output=======================================================
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;                             //Color Console Text
                for (int count = 0; count < 95; count++)                                   //Loop for Line of ►
                    Console.Write("►");

                Console.ForegroundColor = ConsoleColor.DarkCyan;                           //Color Console Text
                Console.WriteLine("\n\n\t\t\t   Month    Interest    Principal   New");
                Console.WriteLine("\t\t\t   No.      Paid        Paid        Balance");
                Console.ForegroundColor = ConsoleColor.DarkYellow;                         //Color Console Text
                Console.Write("\t\t\t");
                for (int count = 0; count < 48; count++)                                   //Loop for Line of -
                    Console.Write("-");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text

                for (int count = 1; count <= numberPayments; count++)
                {   
                    while (count <= numberPayments)                                        //Math Value Assignment
                    {

                        monthlyInterestPaid = loanBalance * monthlyInterestRate;
                        monthlyPrincipalPaid = monthlyPaymentAmount - monthlyInterestPaid;
                        loanBalance = loanBalance - monthlyPrincipalPaid;
                        interestTotal = interestTotal + monthlyInterestPaid;                       
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;                         //Color Console Text
                        Console.Write("\t\t\t|  ");
                        Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text
                        Console.Write("{0,-4}  {1,10}  {2,10}  {3,10}",                            //Write Values
                            count,
                            monthlyInterestPaid.ToString("F2"), 
                            monthlyPrincipalPaid.ToString("F2"), 
                            loanBalance.ToString("F2"));
                        Console.ForegroundColor = ConsoleColor.DarkYellow;                         //Color Console Text
                        Console.Write("    |");
                        Console.WriteLine();
                        count++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;                                //Color Console Text
                Console.Write("\t\t\t");
                for (int count = 0; count < 48; count++)                                          //Loop for Line of -
                    Console.Write("-");
                Console.WriteLine();

                monthlyPaymentAmount = (monthlyInterestRate * (loanAmount - downPayment) * Math.Pow(1 + monthlyInterestRate, numberPayments)) / (Math.Pow(1 + monthlyInterestRate, numberPayments) - 1); 

                //=====================================================Summary============================================================
                Console.ForegroundColor = ConsoleColor.DarkCyan;                           //Color Console Text
                Console.Write("\n\t\t\t Payment Amount:  "); 
                Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text
                Console.Write("{0}", monthlyPaymentAmount.ToString("C2"));

                Console.ForegroundColor = ConsoleColor.DarkCyan;                           //Color Console Text
                Console.Write("\n\t\t\t Interest Paid Over Life of Loan:  ");
                Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text
                Console.Write("{0}", interestTotal.ToString("C2"));

                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;                             //Color Console Text
                for (int count = 0; count < 95; count++)                                   //Loop for Line of #
                    Console.Write("#");

             /***************************************************************************************************************************/
             /*                                                    Pause Program                                                        */
             /***************************************************************************************************************************/

                Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text
                Console.Write("\n\n\tWould you like to run a new calculation (Y or N)?  >> ");
                continueProgram = Console.ReadLine();
                continueProgram = continueProgram.ToUpper();

                switch (continueProgram)
                {
                    case "Y":
                        recalculate = true;
                        break;
                    case "N":
                        recalculate = false;
                        break;
                    default:
                        {
                            errorHandling = true;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Red;                    //Color Console Text
                            Console.WriteLine("\n\tInvalid Data Entered.");
                            Console.ForegroundColor = ConsoleColor.White;                  //Color Console Text
                            Console.Write("\tWould you like to run a new calculation (Y or N)?  >> ");
                            continueProgram = Console.ReadLine();
                            continueProgram = continueProgram.ToUpper();
                            if (continueProgram == "Y")
                            {
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

            } while (recalculate == true);                                             //End first do loop

            /***************************************************************************************************************************/
            /*                                                        Closing                                                          */
            /***************************************************************************************************************************/

            Console.Clear();                                                           //Refresh Screen

            Console.ForegroundColor = ConsoleColor.Yellow;                             //Color Console Text
            for (int count = 0; count < 95; count++)                                   //Loop for Line of ►
                Console.Write("►");

            Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text

            //ASCII Art Credit:  http://startrekasciiart.blogspot.com
            Console.WriteLine();
            Console.WriteLine(@"            ________________ _     _____      _______________        ________   ___");
            Console.WriteLine(@"          ,' ________   ___// \    \  __`-.  /___   ___/\  __`-.   ,' ___/\ /  ,' /");
            Console.WriteLine(@"         |  `-.__    | |   / . \   | |,',-'      | |    | |,',-'  | ,'___ | |,',-'");
            Console.WriteLine(@"          `-.___ `,  | |  / /_\ \  |  _ `-,      | |    |  _ `-,  |  ___/ |  _ `-,");
            Console.WriteLine(@"          ______\  \ | | / _____ \ | | `-. \_    | |    | | `-. \_| `.___ | | `-. \_");
            Console.WriteLine(@"         /_________| /_|/_/     \_\|_\   /__/    /_\    |_\   /__/ `.____||_\   /__/");
            Console.WriteLine("\n");


            Console.ForegroundColor = ConsoleColor.Yellow;                            //Color Console Text
            for (int count = 0; count < 95; count++)                                  //Loop for Line of ►
                Console.Write("►");

            Console.ForegroundColor = ConsoleColor.Red;                               //Color Console Text
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine(@"                                             .^.");
            Console.WriteLine(@"                                            /   \");
            Console.WriteLine(@"                                           /     \");
            Console.WriteLine(@"                                   *******/       \*******");
            Console.WriteLine(@"                              ***** *****/         \***** *****");
            Console.WriteLine(@"                          ***** ********/           \******** *****");
            Console.WriteLine(@"                         *** **********/             \********** ***");
            Console.WriteLine(@"                          ***** ******/               \****** *****");
            Console.WriteLine(@"                              ***** */        _**_     \* *****");
            Console.WriteLine(@"                                   */      _-******\    \*");
            Console.WriteLine(@"                                   /    _-' *****   '\   \");
            Console.WriteLine(@"                                   \__-'              '\_/");

            Console.ForegroundColor = ConsoleColor.White;                              //Color Console Text
            Console.WriteLine("\n\n\n\n\n\t  Thank you for using The Vulcan International Bank Amortization Calculator!\n");
            Console.WriteLine("\t\t\t    Please press any key to end the program.\n\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;                              //Color Console Text
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"        .----n---------------------`|``-.                     __");
            Console.WriteLine(@"        \_)||   ]]]] ]]]]]] ]]]]]]  |==[ )             ___.--'--`-.__");
            Console.WriteLine(@"          `------------.-------.---,|,,-'      ___.---' .  .  ____  .`---.___");
            Console.WriteLine(@"                       `-.     `._______.--n-'  ,  '        '    `          `--.__");
            Console.WriteLine(@"                          `-._____||||||____/____]==================================\");
            Console.WriteLine(@"                             '--.__.-----------------._____   .....   ___.----'");
            Console.WriteLine(@"                                                           `--.___.--'");

            Console.ForegroundColor = ConsoleColor.DarkBlue;                           //Color Console Text
            Console.WriteLine("\n\n\n\n\t\t\t\t  Created By: Whitney King");
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;                             //Color Console Text
            for (int count = 0; count < 95; count++)                                   //Loop for Line of ►
                Console.Write("►");
                        Console.ReadKey();
        }
    }
}
