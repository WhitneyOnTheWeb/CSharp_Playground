using System;
namespace CompareThreeNumbers
{
    class CompareThreeNumbers
    {
        static void Main()
        {
            string numberString;
            int numOne,
                numTwo,
                numThree;

            Console.Write("Enter an integer >> ");
                numberString = Console.ReadLine();
                numOne = Convert.ToInt32(numberString);
                Console.WriteLine();

            Console.Write("Enter an integer >> ");
                numberString = Console.ReadLine();
                numTwo = Convert.ToInt32(numberString);
                Console.WriteLine();

            Console.Write("Enter an integer >> ");
                numberString = Console.ReadLine();
                numThree = Convert.ToInt32(numberString);
                Console.WriteLine();

                if (numOne == numTwo)
                    if (numOne == numThree)
                        Console.WriteLine("All three numbers are equal");
                    else
                        Console.WriteLine("The first two numbers are equal");
                else
                    if (numOne == numThree)
                        Console.WriteLine("The first and last numbers are equal");
                    else
                        if (numTwo == numThree)
                            Console.WriteLine("The last two numbers are equal");
                        else
                            Console.WriteLine("None of the numbers are equal");
                Console.ReadKey();
        }
    }
}
