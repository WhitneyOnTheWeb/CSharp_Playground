using System;

namespace WhileLoop
{
    class TippingTable2
    {
        static void Main()
        {
            double dinnerPrice = 10.00,
                   tipRate = 0,
                   tip;
            const double LOWRATE = .10,
                         MAXRATE = .25,
                         TIPSTEP = .05,
                         MAXDINNER = 100.00,
                         DINNERSTEP = 10.00;
            const int    NUM_DASHES = 40;

            Console.Write("   Price");
            
            for (tipRate = LOWRATE; tipRate <= MAXRATE; tipRate += TIPSTEP)
                Console.Write("{0, 8}", 
                    tipRate.ToString("F"));
            
            Console.WriteLine();

            for (int x = 0; x < NUM_DASHES; ++x)
                Console.Write("-");
            
            Console.WriteLine();

            do
            {
                Console.Write("{0, 8}",
                    dinnerPrice.ToString("C"));
                while (tipRate <= MAXRATE)
                {
                    tip = dinnerPrice * tipRate;
                    Console.Write("{0, 8}",
                        tip.ToString("F"));
                    tipRate += .05;
                }
                dinnerPrice += DINNERSTEP;
                tipRate = LOWRATE;
                Console.WriteLine();
            }   while (dinnerPrice <= MAXDINNER);
            

            Console.ReadKey();
            
        }
    }
}
