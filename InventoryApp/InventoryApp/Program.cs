using System;
using System.Collections;

namespace InventoryApp
{
    class Program
    {
     

        static void Main(string[] args)
        {
            Console.WriteLine("*Welcome to the Inventory, Please select an option:*");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Enter New Item");
                Console.WriteLine("2. Add Fabrication Charges");
                Console.WriteLine("3. List Inventory by Location Category");
                

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

                        Console.WriteLine("Location ID: ");
                        //convert enum for locations to array
                        var location = Enum.GetNames(typeof(LocationID));
                        //loop through the array and print out
                        for (var a = 0; a < location.Length; a++)
                        {
                            Console.WriteLine($"{a}. {location[a]}");
                        }
                        var locations = Enum.Parse<LocationID>(Console.ReadLine());

                        Console.Write("Enter weight in grams: ");
                        var gramweight = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Enter wholesale price: ");
                        var wholesale = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Enter Mark Up: ");
                        var markup = Convert.ToDecimal(Console.ReadLine());


                        Console.Write("Enter 1 if there labor charges on this listing ");
                        int response = Convert.ToInt32(Console.ReadLine());
 

                        Console.Write("Enter hourly rate for fabrication: ");
                        var rate = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Enter time spent on fabrication and assembly: ");
                        var worktime = Convert.ToDecimal(Console.ReadLine());

                        var element = Inventory.CreateElement(materialType, locations, gramweight, wholesale, markup, rate, worktime);

                        Console.WriteLine($"Inventory Number : {element.InventoryNumber}, Material: { element.Material}, Location: {element.Location}, Date Acquired: {element.DateAcquired}, Grams: {element.Weight},  Retail Price: {element.RPrice:C}");
                        break;

                  case "2":
                        while (true)
                        {
                            Console.WriteLine("0. Exit, No labor charges");
                            Console.WriteLine("1. Enter Labor Charges");


                            var option2 = Console.ReadLine();
                            switch (option2)
                            {
                                case "0":
                                    Console.WriteLine("No labor charges incurred, return to main menu");
                                    return;

                                case "1":
                                    Console.Write("Enter hourly rate for fabrication: ");
                                    rate = Convert.ToDecimal(Console.ReadLine());

                                    Console.Write("Enter time spent on fabrication and assembly: ");
                                    worktime = Convert.ToDecimal(Console.ReadLine());

                                    Console.Write("Inventory Number: ");
                                    var inventoryNumber = Convert.ToInt32(Console.ReadLine());
                                    rate = Convert.ToDecimal(Console.ReadLine());
                                    worktime = Convert.ToDecimal(Console.ReadLine());
                                    Inventory.LaborCharge(inventoryNumber, rate, worktime);
                                    

                                    break;

                                default:
                                    Console.WriteLine("Please select a valid option from the menu");
                                    break;
                            }
                        }

                            
                       
                case "3":
                        Console.Write("List Inventory by Location Category:  ");

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
                            Console.WriteLine($"Inventory Number : {myelement.InventoryNumber}, Material: { myelement.Material}, Location: {myelement.Location}, Date Acquired: {myelement.DateAcquired}, Grams: {myelement.Weight},  Retail Price: {myelement.RPrice:C}");
                        }
                        break;
                default:
			Console.WriteLine("Please select a valid option from the menu");
                break;
            }
        }
    }
}
}