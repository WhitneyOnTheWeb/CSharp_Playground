/************************************************************************************************************************************************
 * Bellevue Class:  PROG 110
 * Instructor:  S. Unwin
 * Term:  Fall 2013
 * 
 * Solution/Project Name:  KingProject4
 * File Name:  BankAcct.cs
 * 
 * This program will generate information for a bank
 * account, and show starting balance, total deposits,
 * total withdrawls and ending balance in addition to
 * account holder name and account number.
 *
 * Programmer:  Whitney King
 * Assigned Project Number:  6
 * 
 * Revision       Date               Release Comment
 * --------     ---------            ---------------
 * 1.0          11/27/2013            Initial Code Concept, Method Outline
 * 1.1          11/30/2013            Bug Fixes, Modify Balance/CalcBalance/Display Summary Methods
 * 1.2          12/1/2013             Bug Fixes, Fix Math, Console Formatting
 * 
 ***********************************************************************************************************************************************/

using System;

namespace KingProject6
{
    class BankAcct
    {
        /****************************************************************************************************************************************/
        /*                                                               Main Method                                                            */
        /****************************************************************************************************************************************/
        static void Main()
        {
            //===========================================================Console Window Settings=================================================
            Console.Title = "Whitney King - Project 6";  //Set Console Title
            Console.SetWindowSize(95, 50);  //Set Console Dimesions

            double account = 0;
            string[] name = new string[2];
            const int TRANSACTION_LIMIT = 20;

            //=============================================================Program Display=======================================================
            WelcomeMessage();
            CreateAccount(account, TRANSACTION_LIMIT, name);

        }

        /******************************************************************************************************************************************/
        /*                                                         Welcome Message Method                                                         */
        /******************************************************************************************************************************************/
        public static void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;                                
            for (int count = 0; count < 95; count++)                                      //Loop for Line of *
                Console.Write("*");

            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("\n\t\t\t    Welcome to the Vulcan International Bank");
            Console.WriteLine("\t\t\t\t  Bank Account Management Tool\n");

            Console.ForegroundColor = ConsoleColor.Yellow;                                
            for (int count = 0; count < 95; count++)                                      //Loop for Line of *
                Console.Write("*");

            Console.ForegroundColor = ConsoleColor.Gray;                                  
            Console.WriteLine("\n\t        You may use this program to create a new bank account with V.I.B," +
                              "\n\t\t     check your account balance, make deposits and withdrawls," +
                              "\n\t\t\t      and view an account activity summary.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;                             
            Console.Write("\n\t\t\t         Data to enter is shown in ");
            Console.ForegroundColor = ConsoleColor.White;                                
            Console.WriteLine("white");
            Console.ForegroundColor = ConsoleColor.DarkCyan;                             
            Console.Write("\t\t       Specific prompts needed to progress are shown in ");
            Console.ForegroundColor = ConsoleColor.Green;                                
            Console.WriteLine("green\n");

            Console.ForegroundColor = ConsoleColor.Yellow;                               
            for (int count = 0; count < 95; count++)                                     //Loop for Line of *
                Console.Write("*");
        }

        /******************************************************************************************************************************************/
        /*                                                         Create Account Method                                                          */
        /******************************************************************************************************************************************/
        public static void CreateAccount(double initialDeposit, int TRANSACTION_LIMIT, string[] name)
        {
            //================================================================Variables============================================================
            const int MIN = 1000,
                      MAX = 5000;
            string userInput,
                   depositWithdrawl = "";
            double depositAmount = 0,
                   withdrawlAmount = 0,
                   accountBalance = 0;
            int deposits = 0,
                withdrawls = 0;
            name = new string[2];
            double[] transactions = new double[TRANSACTION_LIMIT];
            string[] transactionType = new string[TRANSACTION_LIMIT];
            bool error = false;
            
            Random rand = new Random();

            //===============================================================Name Inputs===========================================================
            Console.ForegroundColor = ConsoleColor.White;  
            Console.WriteLine();
            for(int X = 0; X < name.Length; ++X)
                {
                    string firstLast = "First";    
                    if(X == 0)  
                        firstLast = "First";
                    else if(X == 1)
                        firstLast = "Last";
                    Console.Write("\t   Enter {0} Name >> ",
                        firstLast);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userInput = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White; 
                    if(userInput == "")
                        ThrowFirstError(ref userInput, ref error);  //Error Handling
                    name[X] = userInput;
                }

            //==============================================================Deposit Input==========================================================
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t   Enter Initial Deposit Amount >> ");
            Console.ForegroundColor = ConsoleColor.Cyan; 
            userInput = Console.ReadLine();

            while (!double.TryParse(userInput, out initialDeposit))
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("\n\t   Invalid Data Entered. Please enter only numbers.");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write("\t   Enter Initial Deposit Amount >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;  
                userInput = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.White; 
            initialDeposit = Convert.ToDouble(userInput);
            accountBalance = initialDeposit;

            //==========================================================Generate Account Number=====================================================
            int randomNumber = rand.Next(MIN, MAX);
            int accountNumber = randomNumber;
            Console.ForegroundColor = ConsoleColor.Yellow;  
            Console.WriteLine("\n\t\t\t     *************************************");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t\t      Thank you, {0}.",
                name[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;  
            Console.ForegroundColor = ConsoleColor.DarkCyan; 
            Console.Write("\t\t\t\tYour new account number is ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            Console.Write("{0}", 
                accountNumber);
            Console.ForegroundColor = ConsoleColor.Yellow;  
            Console.WriteLine("\n\t\t\t     *************************************");
            InitiateNewTransaction(initialDeposit, depositWithdrawl, name, depositAmount, withdrawlAmount, deposits, withdrawls, accountBalance,
                accountNumber, transactions, transactionType, TRANSACTION_LIMIT);
        }

        /******************************************************************************************************************************************/
        /*                                                         New Transaction Method                                                         */
        /******************************************************************************************************************************************/
        public static void InitiateNewTransaction(double initialDeposit, string depositWithdrawl, string[]name, 
            double depositAmount, double withdrawlAmount, int deposits, int withdrawls, double accountBalance, 
            int accountNumber, double[] transactions, string[] transactionType, int TRANSACTION_LIMIT)
        {
            //================================================================Variables===========================================================
            bool error = false,
                 newEntry = true;
            string userChoice = "";            

            //=============================================================Continue/Exit Logic====================================================
            do
                { 
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write("\n\t   NEW");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write(" transaction, show account ");
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write("BALANCE");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write(", or summarize and ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("EXIT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("? >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToUpper();
                Console.ForegroundColor = ConsoleColor.White;

                switch (userChoice)
                {
                    case "NEW":
                        error = false;
                        newEntry = true;
                        ModifyBalance(initialDeposit, depositWithdrawl, name, depositAmount, withdrawlAmount, accountBalance,
                            deposits, withdrawls, accountNumber, transactions, transactionType, TRANSACTION_LIMIT);
                        break;
                     case "BALANCE":
                        error = false;
                        newEntry = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t     *************************************");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("\t\t\t\t Available Funds:  ");
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("{0}",
                            accountBalance.ToString("C2"));
                         Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t     *************************************");
                        Console.ForegroundColor = ConsoleColor.White; 
                        break;
                    case "EXIT":
                        error = false;
                        newEntry = false;
                        DisplaySummary(initialDeposit, depositWithdrawl, name, depositAmount, withdrawlAmount,
                           deposits, withdrawls, accountBalance, accountNumber, transactions, transactionType);
                        break;
                    default:
                        do
                        {
                            error = true;
                            ThrowSecondError(ref userChoice, ref error);  //Error Handling
                            switch (userChoice)
                            {
                                case "NEW":
                                    error = false;
                                    newEntry = true;
                                    ModifyBalance(initialDeposit, depositWithdrawl, name, depositAmount, withdrawlAmount, accountBalance,
                                        deposits, withdrawls, accountNumber, transactions, transactionType, TRANSACTION_LIMIT);
                                    break;
                                case "BALANCE":
                                    error = false;
                                    newEntry = true;
                                    Console.ForegroundColor = ConsoleColor.Yellow; 
                                    Console.WriteLine("\n\t\t\t     *************************************");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan; 
                                    Console.Write("\t\t\t\t Available Funds:  ");
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("{0}",
                                        accountBalance.ToString("C2"));
                                    Console.ForegroundColor = ConsoleColor.Yellow; 
                                    Console.WriteLine("\n\t\t\t     *************************************");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "EXIT":
                                    error = false;
                                    newEntry = false;
                                    DisplaySummary(initialDeposit, depositWithdrawl, name, depositAmount, withdrawlAmount,
                                        deposits, withdrawls, accountBalance, accountNumber, transactions, transactionType);
                                    break;
                            }
                        } while (error == true);
                    break;
                }
            } while (newEntry == true);
        }

        /******************************************************************************************************************************************/
        /*                                                         Modify Balance Method                                                          */
        /******************************************************************************************************************************************/
        private static void ModifyBalance(double initialDeposit, string depositWithdrawl, string[]name, 
            double depositAmount, double withdrawlAmount, double accountBalance, int deposits, 
            int withdrawls, int accountNumber, double[] transactions, string[]transactionType, int TRANSACTION_LIMIT)
        {
            //==============================================================Variables==============================================================
            string userInput;
            bool logic = false;
            int numberTransactions = deposits + withdrawls;
            double depositTotal = 0,
                   withdrawlTotal = 0;
            
            //=====================================================Deposit/Withdraw Transaction Logic=============================================
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Write("\n\t   Do you want to make a ");
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write("DEPOSIT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" or a ");
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write("WITHDRAWL");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("? >> ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            depositWithdrawl = Console.ReadLine();
            depositWithdrawl = depositWithdrawl.ToUpper();
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                    switch (depositWithdrawl)
                    {
                    //===============================================================Deposit Logic========================================================
                        case "DEPOSIT":
                            logic = false;
                            Console.Write("\n\t   Please enter deposit amount >> ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            userInput = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            while (!double.TryParse(userInput, out depositAmount))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t   Invalid Data Entered. Please enter only positive numbers.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\t   Please enter deposit amount >> ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                userInput = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            depositAmount = Convert.ToDouble(userInput);
                            deposits = deposits + 1;
                            numberTransactions = deposits + withdrawls;
                            transactions[numberTransactions - 1] = depositAmount;
                            transactionType[numberTransactions - 1] = depositWithdrawl;
                            
                            break;
                    //==============================================================Withdrawl Logic=======================================================
                        case "WITHDRAWL":
                            logic = false;
                            Console.Write("\n\t   Please enter withdrawl amount >> ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            userInput = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            while (!double.TryParse(userInput, out withdrawlAmount))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t   Invalid Data Entered. Please enter only positive numbers.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\t   Please enter withdrawl amount >> ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                userInput = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        //==============================================Insufficient Funds Logic=================================================== 
                            if (Convert.ToDouble(userInput) > accountBalance)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n\t\t     ****************************************************");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\t\t\t   Insufficient funds to withdrawl ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("{0}", 
                                    Convert.ToDouble(userInput).ToString("C2"));
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t\t      Current account balance is ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("{0}",
                                    accountBalance.ToString("C2"));
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\t\t     ****************************************************");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\n\t   Please enter withdrawl amount less than or equal to {0} >> ",
                                    accountBalance.ToString("C2"));
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                userInput = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                while (!double.TryParse(userInput, out withdrawlAmount))
                                {
                                    Console.WriteLine("\n\t   Invalid Data Entered.");
                                    Console.Write("\t   Please enter withdrawl amount less than or equal to {0} >> ",
                                        accountBalance.ToString("C2"));
                                    userInput = Console.ReadLine();
                                }
                            }
                            withdrawlAmount = (Convert.ToDouble(userInput) * (-1));
                            withdrawls = withdrawls + 1;
                            numberTransactions = deposits + withdrawls;
                            transactions[numberTransactions - 1] = withdrawlAmount;
                            transactionType[numberTransactions - 1] = depositWithdrawl;
                            
                            break;
                        case "WITHDRAW":
                            logic = false;
                            Console.Write("\n\t   Please enter withdrawl amount >> ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            userInput = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            while (!double.TryParse(userInput, out withdrawlAmount))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t   Invalid Data Entered. Please enter only positive numbers.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\t   Please enter withdrawl amount >> ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                userInput = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (Convert.ToDouble(userInput) > accountBalance)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n\t\t     ****************************************************");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\t\t\t   Insufficient funds to withdrawl ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("{0}",
                                    Convert.ToDouble(userInput).ToString("C2"));
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t\t      Current account balance is ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("{0}",
                                    accountBalance.ToString("C2"));
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\t\t     ****************************************************");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\n\t   Please enter withdrawl amount less than or equal to {0} >> ",
                                    accountBalance.ToString("C2"));
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                userInput = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                while (!double.TryParse(userInput, out withdrawlAmount))
                                {
                                    Console.WriteLine("\n\t   Invalid Data Entered.");
                                    Console.Write("\t   Please enter withdrawl amount less than or equal to {0} >> ",
                                        accountBalance.ToString("C2"));
                                    userInput = Console.ReadLine();
                                }
                            }
                            withdrawlAmount = (Convert.ToDouble(userInput) * (-1));
                            withdrawls = withdrawls + 1;
                            numberTransactions = deposits + withdrawls;
                            transactions[numberTransactions - 1] = withdrawlAmount;
                            transactionType[numberTransactions - 1] = depositWithdrawl;
                            break;
                        default:
                            ThrowFourthError(ref depositWithdrawl, ref logic);  //Invalid Data Handling
                            logic = true;
                            break;
                    }
            }while (logic == true);
            CalcBalance(initialDeposit, depositWithdrawl, name, depositTotal, withdrawlTotal, deposits, withdrawls, accountBalance,
                accountNumber, transactions, transactionType, TRANSACTION_LIMIT);  
         }  

        /******************************************************************************************************************************************/
        /*                                                           CalcBalance Method                                                           */
        /******************************************************************************************************************************************/
        private static void CalcBalance(double initialDeposit, string depositWithdrawl, string[] name, double depositTotal, double withdrawlTotal, 
            int deposits, int withdrawls, double accountBalance, int accountNumber, double[] transactions, 
            string[] transactionType, int TRANSACTION_LIMIT)
        {
            //==============================================================Variables==============================================================
            int numberTransactions = deposits + withdrawls;
            string userChoice;
            bool error = false;

            //==========================================================Transaction Limit Check====================================================  
                for (int X = 0; X <= numberTransactions; X++)
                {
                    if (transactionType[TRANSACTION_LIMIT - 1] != null)
                    {
                        {
                            error = true;
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine("\n\t   Transaction Limit Reached.");
                            Console.ForegroundColor = ConsoleColor.White; 
                            Console.Write("\t   Type ");
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.Write("EXIT");
                            Console.ForegroundColor = ConsoleColor.White; 
                            Console.Write(" to summarize and quit >> ");
                            Console.ForegroundColor = ConsoleColor.Cyan; 
                            userChoice = Console.ReadLine();
                            userChoice = userChoice.ToUpper();
                            Console.ForegroundColor = ConsoleColor.White; 
                            switch (userChoice)
                            {
                                case "EXIT":
                                    error = false;
                                    if (transactionType[X] == "DEPOSIT")
                                    {
                                        depositTotal = depositTotal + transactions[X];
                                    }
                                    else if (transactionType[X] == "WITHDRAWL" || transactionType[X] == "WITHDRAW")
                                    {
                                        withdrawlTotal = withdrawlTotal + transactions[X];
                                    }
                                    accountBalance = initialDeposit + depositTotal + withdrawlTotal;
                                    DisplaySummary(initialDeposit, depositWithdrawl, name, depositTotal, withdrawlTotal,
                                       deposits, withdrawls, accountBalance, accountNumber, transactions, transactionType);
                                    break;
                                default:
                                    do
                                    {
                                        error = true;
                                        ThrowThirdError(ref userChoice, ref error);  //Error Handling
                                        switch (userChoice)
                                        {
                                            case "EXIT":
                                                error = false;
                                                if (transactionType[X] == "DEPOSIT")
                                                    {
                                                        depositTotal = depositTotal + transactions[X];
                                                    }
                                                else if (transactionType[X] == "WITHDRAWL" || transactionType[X] == "WITHDRAW")
                                                    {
                                                        withdrawlTotal = withdrawlTotal + transactions[X];
                                                    }
                                                    accountBalance = initialDeposit + depositTotal - withdrawlTotal;
                                                DisplaySummary(initialDeposit, depositWithdrawl, name, depositTotal, withdrawlTotal,
                                                    deposits, withdrawls, accountBalance, accountNumber, transactions, transactionType);
                                                break;
                                        }
                                    } while (error == true);
                                    break;
                            }
                        }
                    }
                    //========================================================Transaction Math======================================================== 
                    if (transactionType[X] == "DEPOSIT")
                    {
                        depositTotal = depositTotal + transactions[X];
                    }
                    else if (transactionType[X] == "WITHDRAWL" || transactionType[X] == "WITHDRAW")
                    {
                        withdrawlTotal = withdrawlTotal + transactions[X];
                    }
                }
            accountBalance = initialDeposit + depositTotal + withdrawlTotal;
            InitiateNewTransaction(initialDeposit, depositWithdrawl, name, depositTotal, withdrawlTotal, deposits, withdrawls, 
                accountBalance, accountNumber, transactions, transactionType, TRANSACTION_LIMIT);
        }
        
        /******************************************************************************************************************************************/
        /*                                                         Display Summary Method                                                         */
        /******************************************************************************************************************************************/
        public static void DisplaySummary(double initialDeposit, string depositWithdrawl, string[] name, double depositAmount, double withdrawlAmount,
            int deposits, int withdrawls, double accountBalance, int accountNumber, double[] transactions, string[] transactionType)
        {
            Console.Clear();

            //============================================================Closing Message===========================================================
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int count = 0; count < 95; count++)                                      //Loop for Line of *
                Console.Write("*");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\t\t\tThank you for using the Vulcan International Bank" +
                "\n\t\t\t\t   Bank Account Management Tool!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\t\t\t\t     Created by Whitney King\n\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int count = 0; count < 95; count++)                                      //Loop for Line of *
                Console.Write("*");

            //==============================================================Summary Table============================================================
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\t\t\t\t\tAccount Summary");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t    ----------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\t\tName on Account:    ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} {1}",
                name[0],
                name[1]);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\t\tAccount Number:     ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}",
                accountNumber);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\t\tStarting Balance:   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}",
                initialDeposit.ToString("C2"));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\t\t{0, -3}Deposit(s):      ", 
                deposits);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0}",
                depositAmount.ToString("C2"));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\t\t{0, -3}Withdrawl(s):    ", 
                withdrawls);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("{0}",
                withdrawlAmount.ToString("C2"));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\t\tEnding Balance:     ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}",
                accountBalance.ToString("C2"));

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\t\t\t    ----------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t\t\t    Please press any key to end the program.\n\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int count = 0; count < 95; count++)                                      //Loop for Line of *
                Console.Write("*");

            //================================================================ASCII Art==============================================================

            DrawASCIIArt();

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int count = 0; count < 95; count++)                                      //Loop for Line of *
                Console.Write("*");

            Console.ReadKey();
            Environment.Exit(0);

        }

        /******************************************************************************************************************************************/
        /*                                                        Throw First Error Method                                                        */
        /******************************************************************************************************************************************/
        public static void ThrowFirstError(ref string userInput, ref bool errorHandling)
        {
            errorHandling = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;                      
                Console.WriteLine("\n\t   Invalid Data Entered.");
                Console.ForegroundColor = ConsoleColor.White;                
                Console.Write("\t   Please enter only letters for your name >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;                
                userInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;          
                if (userInput == null || userInput.Length == 0)
                    errorHandling = true;
                else
                    errorHandling = false;
            } while (errorHandling == true);
        }

        /******************************************************************************************************************************************/
        /*                                                       Throw Second Error Method                                                        */
        /******************************************************************************************************************************************/
        public static void ThrowSecondError(ref string userChoice, ref bool errorHandling)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;                    
                Console.WriteLine("\n\t   Invalid Data Entered.");
                Console.ForegroundColor = ConsoleColor.Green;  
                Console.Write("\t   NEW");
                Console.ForegroundColor = ConsoleColor.White;  
                Console.Write(" transaction, show account ");
                Console.ForegroundColor = ConsoleColor.Green;  
                Console.Write("BALANCE");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write(", or summarize and ");
                Console.ForegroundColor = ConsoleColor.Green;  
                Console.Write("EXIT");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write("? >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;  
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToUpper();
                Console.ForegroundColor = ConsoleColor.White;  
                if (userChoice == "NEW" || userChoice == "EXIT" || userChoice == "BALANCE")
                {
                    errorHandling = false;
                }
                else
                    errorHandling = true;
            } while (errorHandling == true);
        }

        /******************************************************************************************************************************************/
        /*                                                        Throw Third Error Method                                                        */
        /******************************************************************************************************************************************/
        public static void ThrowThirdError(ref string userChoice, ref bool errorHandling)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;                     
                Console.WriteLine("\t   Invalid Data Entered. Transaction Limit Reached.");
                Console.ForegroundColor = ConsoleColor.White;          
                Console.Write("\t   Type ");
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write("EXIT");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write("to summarize and quit >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;       
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToUpper();
                Console.ForegroundColor = ConsoleColor.White;              
                if (userChoice == "EXIT")
                {
                    errorHandling = false;
                }
                else
                    errorHandling = true;
            } while (errorHandling == true);
        }

        /******************************************************************************************************************************************/
        /*                                                       Throw Fourth Error Method                                                        */
        /******************************************************************************************************************************************/
        public static void ThrowFourthError(ref string depositWithdrawl, ref bool transactionType)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;               
                Console.WriteLine("\n\t   Invalid Data Entered.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t   Do you want to make a ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("DEPOSIT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" or a ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("WITHDRAWL");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("? >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                depositWithdrawl = Console.ReadLine();
                depositWithdrawl = depositWithdrawl.ToUpper();
                Console.ForegroundColor = ConsoleColor.White;            
                if (depositWithdrawl == "DEPOSIT")
                {
                    transactionType = false;
                }
                else if (depositWithdrawl == "WITHDRAWL" || depositWithdrawl == "WITHDRAW")
                {
                    transactionType = false;
                }
                else
                    transactionType = true;
            } while (transactionType == true);
        }

        /******************************************************************************************************************************************/
        /*                                                            ASCII Art Method                                                            */
        /******************************************************************************************************************************************/
        public static void DrawASCIIArt()
        {
            //ASCII Art Credit:  http://startrekasciiart.blogspot.com
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n");
            Console.WriteLine("          _____________________________,----,__");
            Console.WriteLine(@"         |==============================<| /___\          ____,-------------.____");
            Console.WriteLine("         `------------------.-----.---.___.--'     __.--'-----------------------`--.__");
            Console.WriteLine("                            `._   `.            =======================================");
            Console.WriteLine("                           ____`.___`._____,----'     `--------,----------------'");
            Console.WriteLine("                          /_|___________-----<       ========,'");
            Console.WriteLine("                                        `-.                ,'");
            Console.WriteLine("                                           `----.______,--'");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(@"            ________________ _     _____      _______________        ________   ___");
            Console.WriteLine(@"          ,' ________   ___// \    \  __`-.  /___   ___/\  __`-.   ,' ___/\ /  ,' /");
            Console.WriteLine(@"         |  `-.__    | |   / . \   | |,',-'      | |    | |,',-'  | ,'___ | |,',-'");
            Console.WriteLine(@"          `-.___ `,  | |  / /_\ \  |  _ `-,      | |    |  _ `-,  |  ___/ |  _ `-,");
            Console.WriteLine(@"          ______\  \ | | / _____ \ | | `-. \_    | |    | | `-. \_| `.___ | | `-. \_");
            Console.WriteLine(@"         /_________| /_|/_/     \_\|_\   /__/    /_\    |_\   /__/ `.____||_\   /__/");
            Console.WriteLine("\n");
        }
    }
}          

