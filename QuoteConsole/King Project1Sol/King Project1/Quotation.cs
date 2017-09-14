/****************************************************************
 * Bellevue Class:  PROG 110
 * Instructor:  S. Unwin
 * Term:  Fall 2013
 * 
 * Solution/Project Name:  King Project1
 * File Name:  Quotation.cs
 * This program demonstrates the use of the WriteLine() method
 * to display favorite quotation and background information per
 * requirements in Project 1 guidelines. In addition, it includes
 * examples of text colors in the console and window size control.
 * 
 * Programmer:  Whitney King
 * Assigned Project Number:  1
 * Revision       Date               Release Comment
 * --------     ---------            ---------------
 * 1.0          9/25/2013            Initial build
 * 1.1          9/25/2013            Framed titles, console size
 * 1.2          9/26/2013            Added color and ASCII art.
 *
 * **Returns favorite quotation when opened**
 * **Displays additional background and source info
 * **Closes when any key is pressed**
 * 
 * **************************************************************/

using System;  //Namespaces used by the file
/***********************************************************************
 *This class will display favorite quote and corresponding info about it
 **********************************************************************/
class Quotation
{   // Start class Quotation 
    /*
     * Method:   Main
     * Purpose:  This method contains text to be displyed
     * Input:    N/A
     * Output:   This application will display a favorite quote and provide some background
     * 
     *           Quote:
     * 
     *           God, grant me the serenity to accept the things I cannot change,
     *           The courage to change the things I can,
     *           And wisdom to know the difference.
     *           
     *           Attributed To:  Reinhold Niebuhr
     *           
     *           Significance:
     *           
     *           This quote from Niebuhr has helped me change my perspective on life
     *           and learn to let go of issues that are not fully within my control.  For many
     *           years, I struggled with finding my inner peace, and found myself anxious
     *           and always focused on the “what-ifs” in life so much that I could not enjoy the now.
     *          
     *           Carrying with myself the principles of focusing my energies on the things
     *           within my control (my family, my passions, the amount of work and dedication
     *           I put towards things) and not on the things that I can’t change (wars, social
     *           issues, politics, corporate games) has lead me to live a more fulfilled and
     *           positive life, and helped me take the reins in my own world to walk out of my
     *           depression to move forward and continue growing as a person.
     *           
     *           Source of Quote:  http://en.wikipedia.org/wiki/Serenity_Prayer
     *           
     *           To end this application created by Whitney King, please press any key now.
     * */
    static void Main()
    { // Start Main()
        //Set Console Title
        Console.Title = "Whitney King - Project 1";
        //Set Console width and height
        Console.SetWindowSize(100, 52);
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        // Write Intro
        Console.WriteLine();
        Console.WriteLine("           This application will display my favorite quote and provide some background");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        //Write border
        Console.WriteLine("**************************************************************************************************");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.Cyan;
        //Write header
        Console.WriteLine("-------------\n|   Quote   |\n-------------");
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        // Write quote and ASCII banner
        Console.WriteLine(@"                   _______________________________________________________________");
        Console.WriteLine(@"          ________|                                                               |_______");
        Console.WriteLine(@"          \       |  Grant me the serenity to accept the things I cannot change,  |      /");
        Console.WriteLine(@"           \      |  The courage to change the things I can                       |     /");
        Console.WriteLine(@"            |     |  And wisdom to know the difference.                           |    |");
        Console.WriteLine(@"           /      |_______________________________________________________________|     \ ");
        Console.WriteLine(@"          /__________)                                                         (_________\ ");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Write Attribution Title
        Console.WriteLine("--------------------\n|   Attributed To  |\n--------------------");
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        //Continue Attribution, write peace sign. By Reinhold Neibuhr
        Console.WriteLine("                                          Reinhold Niebuhr");
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"                                               _____");
        Console.WriteLine(@"                                              /  |  \");
        Console.WriteLine(@"                                             /   |   \");
        Console.WriteLine(@"                                            (   /|\   )");
        Console.WriteLine(@"                                             \ / | \ /");
        Console.WriteLine(@"                                              \__|__/");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Write significance/background of chosen quote with text wrapping
        Console.WriteLine("--------------------\n|   Significance   |\n--------------------");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("     This quote from Niebuhr has helped me change my perspective on life andlearn to let go of\nissues that are not fully within my control.  For many years, I struggled with finding my inner\npeace, and found myself anxious, always focused on “what-ifs” in life so much that I could not\n enjoy the now.");
        Console.WriteLine();
        Console.WriteLine("     Carrying with myself the principles of focusing my energies on the things within my control\n(my family, my passions, the amount of work and dedication I put towards things) and not on the\nthings that I can’t change (wars, social issues, politics, corporate games) has lead me to live\na more fulfilled and positive life, and helped me take the reins in my ownworld to walk out of my\ndepression to move forward and continue growing as a person.");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Write source of chosen quote
        Console.WriteLine("-----------------------\n|   Source of Quote   |\n-----------------------");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("     http://en.wikipedia.org/wiki/Serenity_Prayer");
        Console.WriteLine();
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        //Write border
        Console.WriteLine("***************************************************************************************************");
        //Color Console Text
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        // Pause application, close instructions
        Console.WriteLine();
        Console.WriteLine("            To end this application created by Whitney King, please press any key now.");
        Console.ReadKey();
    } // End Main()
}   // End class Quotation

