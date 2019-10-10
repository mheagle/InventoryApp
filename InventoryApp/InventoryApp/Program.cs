using System;

namespace InventoryApp
{
    class Program
    {
        private const decimal keystone = 1.4M;

        static void Main(string[] args)
        {
            var element = new Element
            {
                Material = TypeOfMaterials.Stone,
                Weight = 123,
                WSPrice = 123.45M,
                Location = LocationID.Stock,
            };
            element.MakeRetail(keystone);

            Console.WriteLine($"Inventory Number :  {element.InventoryNumber}, "+
                $"Material : { element.Material}, " +
                $"Date Aquired : { element.DateAcquired}, " +
                $"Grams : { element.Weight}");
        }
    }
}