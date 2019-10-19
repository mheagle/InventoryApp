using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryApp
{
    static class Inventory
        ///creates a new piece of invetory using the classes listed in element class
    {
        private static List<Element> elements = new List<Element>();
        public static Element CreateElement(
            TypeOfMaterials materialType,
            LocationID location,
            int weight,
            decimal wsPrice,
            decimal retailPrice)

        {
            var element = new Element

            {
                Weight = weight,
                Material = materialType,

            };

            ///attach retail price to element
            if (retailPrice > 0)
            {
                element.MakeRetail(retailPrice);
            }
            elements.Add(element);
            return element;

        }

}
    /// <summary>
    /// find all elements in a given location
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public static IEnumerable<Element>
    GetAllElementsByLocation(string location);
       {
         return elements.Where(a => a.Location == location);
        }

}