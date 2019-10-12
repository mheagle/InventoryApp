using System;

namespace InventoryApp
{
    class Program
    {
        private const decimal keystone = 1.4M;

        static void Main(string[] args)
        {

            var element = Inventory.CreateElement(TypeOfMaterials.Sterling, LocationID.Stock, 25, 20M, 50M);

            Console.WriteLine($"Inventory Number :  {element.InventoryNumber}, "+
                $"Material : { element.Material}, " +
                $"Date Aquired : { element.DateAcquired}, " +
                $"Grams : { element.Weight}");
        }
    }
}