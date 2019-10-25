using iTextSharp.text;
using Microsoft.CodeAnalysis;
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
            decimal markup,
            decimal wsprice)

        {
            var element = new Element

            {
                Material = materialType,
                Location = location,
                Weight = weight,
            };

            ///attach retail price to element
            if (markup > 0)
            {
                element.MakeRetail(markup, wsprice);
            }
            elements.Add(element);
            return element;

        }


        /// <summary>
        /// find all elements in a given location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static IEnumerable<Element>
            GetAllElementsbyLocation(LocationID location)
        {
            return elements.Where(a => a.Location == location);
        }

    }
}



