using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp
{
    static class Inventory
    {
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


            if (retailPrice > 0)
            {
                element.MakeRetail(retailPrice);
            }

            return element;

        }

    }
}