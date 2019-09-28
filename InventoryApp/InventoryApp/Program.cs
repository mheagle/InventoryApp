using System;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var element = new Element
            {
                Material = "Material",
                Weight = 123,
                WSPrice = 123.45M,
                Location = "location",
            };
            element.WSWeightValue();

            Console.WriteLine($"InventoryNo:  {element.InventoryNumber}," 
                $"Material: { element.Material}," +
                $"  Grams: { element.Weight}" );
        }
}