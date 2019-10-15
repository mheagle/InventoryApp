using System;

namespace InventoryApp
{
    class Program
    {
        private const decimal keystone = 1.4M;

        static void Main(string[] args)
        {
            Console.WriteLine("*Welcome to the Inventory, Please select an option:*");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Enter New Item");
                Console.WriteLine("2. Calculate Retail Price");
                Console.WriteLine("3. List All Available Inventory");
                Console.WriteLine("4. List All Sold Inventory");

                var option = Console.ReadLine();
                switch(option)
                {

                case "0":
			    Console.WriteLine("Thank you for visiting the Inventory");
                    return;
			    case "1":
			    break;
			    case "2":
			    break;
			    case "3":
			    break;
			    case "4":
			    break;
                default:
			Console.WriteLine("Please select a valid option from the menu");
                break;
            }
        }
    }
}
}