using System;

namespace Inventoryapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Welcome to the Inventory**");

            while (true)
            {

                Console.WriteLine("O. Exit");
                Console.WriteLine("1. Enter a piece of inventory");
                Console.WriteLine("2. Add Keum Boo work charges");
                Console.WriteLine("3. Add solder charges");
                Console.WriteLine("4. Add cold-working charges");
                Console.WriteLine("5. List all inventory by location");
                Console.WriteLine("6. List all inventory");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the inventory");
                        return;
                    case "1":
                        Console.Write("Description: ");
                        var description = Console.ReadLine();

                        Console.WriteLine("Location:");

                        ///Convert enum to array
                        var location = Enum.GetNames(typeof(LocationID));
                        ///loop through the array and print out
                        for (var i = 0; i < location.Length; i++)
                        {
                            Console.WriteLine($"{i}. {location[i]}");
                        }
                        var locationID = Enum.Parse<LocationID>(Console.ReadLine());

                        Console.Write("Wholesale price of item: ");
                        var wsprice = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Initial assembly time: ");
                        var worktime = Convert.ToDecimal(Console.ReadLine());

                        var element = Inventory.CreateElement(description, locationID, wsprice, worktime);
                        Console.Write($"Description: {element.Description}, Inventory Number {element.InventoryNumber}, Date Acquired: {element.DateAcquired}, Location: {element.Location}, Retail: {element.Retail:C}, Initial assembly time: {element.Worktime}");
                        break;

                    case "2":
                        PrintAllInventory();
                        Console.Write("Inventory Number ");
                        var inventoryNumber = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter time spent on Keum Boo Work: ");
                        worktime = Convert.ToDecimal(Console.ReadLine());
                        Inventory.KeumBooWork(inventoryNumber, worktime);
                        Console.WriteLine("Keum Boo charge added successfully");

                        break;

                    case "3":
                        PrintAllInventory();
                        Console.Write("Inventory Number ");
                        inventoryNumber = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter time spent on soldering: ");
                        worktime = Convert.ToDecimal(Console.ReadLine());
                        Inventory.SolderWork(inventoryNumber, worktime);
                        Console.WriteLine("Keum Boo charge added successfully");

                        break;

                    case "4":
                        PrintAllInventory();
                        Console.Write("Inventory Number ");
                        inventoryNumber = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter time spent on cold-working piece: ");
                        worktime = Convert.ToDecimal(Console.ReadLine());
                        Inventory.ColdWork(inventoryNumber, worktime);
                        Console.WriteLine("Cold-working charge added successfully");

                        break;

                    case "5":
                        Console.Write("List Inventory by Location:  ");

                        //convert enum for locations to array
                        var category = Enum.GetNames(typeof(LocationID));

                        //loop through the array and print out
                        for (var a = 0; a < category.Length; a++)

                        {
                            Console.WriteLine($"{a}. {category[a]}");
                        }

                        var locationcategory = Enum.Parse<LocationID>(Console.ReadLine());

                        var locationchoice =
                            Inventory.GetAllElementsbyLocation(locationcategory);
                        _ = locationchoice.GetEnumerator();

                        foreach (var myelement in locationchoice)
                        {
                            Console.Write($"Description: {myelement.Description}, Inventory Number {myelement.InventoryNumber}, Date Acquired: {myelement.DateAcquired}, Location: {myelement.Location}, Retail: {myelement.Retail:C}");
                        }
                        break;

                    case "6":
                        PrintAllInventory();
                        break;

                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }

            }
        }

        private static void PrintAllInventory()
        {
            Console.Write("Description: ");
            var description = Console.ReadLine();
            var elements = Inventory.GetAllElementsByDescription(description);
            foreach (var listelement in elements)
            {
                Console.Write($"Description: {listelement.Description}, Inventory Number {listelement.InventoryNumber}, Date Acquired: {listelement.DateAcquired}, " +
                    $"Location: {listelement.Location}, Retail: {listelement.Retail:C}");
            }
        }
    }
}
