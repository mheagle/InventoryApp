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
        private static List<Fabrication> fabrications = new List<Fabrication>();
        public static Element CreateElement(
            TypeOfMaterials materialType,
            LocationID location,
            decimal weight,
            decimal markup,
            decimal wsprice,
            decimal rate,
            decimal worktime
            )

        {
            var element = new Element

            {
                Material = materialType,
                Location = location,
                Weight = weight,
                Rate = rate,
                Worktime = worktime
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
        /// <summary>
        /// add labor charge to a single element based on inventory number
        /// </summary>
        /// <param name="inventorynumber">inventory number</param>
        /// <param name="laborcharge">labor charge</param>
        public static decimal LaborCharge(int inventorynumber, decimal rate, decimal worktime)
        {
            var element =
            elements.SingleOrDefault(a => a.InventoryNumber == inventorynumber);

            if (element == null)
            {
                ///throw exception
                return 0;
            }
            element.FabricationCharge(rate, worktime);
            

            var fabrication = new Fabrication
            {
                WorkCompleted = DateTime.Now,
                Description = "Keum Boo",
                FabricationType = TypeOfFabrication.KeumBoo,
                InventoryNumber = element.InventoryNumber,


            };
            fabrications.Add(fabrication);
        }
    }
}



