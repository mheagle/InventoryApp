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
                        Console.WriteLine("Material Type:  ");
                        //Convert enum to array
                       var materialTypes = Enum.GetNames(typeof(TypeOfMaterials));
                        //Loop through the array and print out
                        for (var i = 0; i < materialTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {materialTypes[i]}");
                        }
                        var materialType = Enum.Parse<TypeOfMaterials>(Console.ReadLine());

                        Console.Write("Enter weight in grams: ");
                        var gramweight = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter wholesale price: ");
                        var wholesale = Convert.ToDecimal(Console.ReadLine());

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