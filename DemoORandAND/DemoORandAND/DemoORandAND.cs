using System;

namespace DemoORandAND
{
    class DemoORandAND
    {
        static void Main()
        {
            const int ZONE1 = 1,
                      ZONE2 = 2,
                      LOWQUANTITY = 10;
            string inputString;
            int quantity;
            int deliveryZone;

            Console.WriteLine("Delivery is free for zone {0} or {1}",
                ZONE1,
                ZONE2);
            Console.WriteLine("when the number of boxes is less tha {0}",
                LOWQUANTITY);
            Console.WriteLine("Enter delivery zone >> ");
                inputString = Console.ReadLine();
                deliveryZone = Convert.ToInt32(inputString);
            Console.WriteLine("Enter the number of boxes in the shipment >> ");
                inputString = Console.ReadLine();
                quantity = Convert.ToInt32(inputString);

            if ((deliveryZone == ZONE1 || deliveryZone == ZONE2) && quantity < LOWQUANTITY)
               Console.WriteLine("Delivery is free");
            else
                Console.WriteLine("A delivery charge applies");

            Console.ReadLine();

        }
    }
}
