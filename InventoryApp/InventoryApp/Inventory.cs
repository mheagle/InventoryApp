using InventoryApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventoryapp
{
    public static class Inventory
    {

        private static InventoryContext db = new InventoryContext();

        private static decimal markup = 1.5M;
        private static decimal rate = 65;

        /// <summary>
        /// method to create an element
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="locationID"> locationID</param>
        /// <param name="wsprice"> wholesale price</param>
        /// <returns>an instance of the element</returns>
        /// 

        public static Element CreateElement(string description,
            LocationID locationID, decimal wsprice, decimal worktime = 0)
        {
            var element = new Element
            {
                Description = description,
                Location = locationID,
            };

            if (wsprice > 0)
            {
                element.MakeRetail(markup, wsprice);
            }
            db.Elements.Add(element);
            db.SaveChanges();
            return element;
        }

        /// <summary>
        /// find inventory by inventory number
        /// </summary>
        /// <param name="inventoryNumber"></param>
        /// <returns></returns>
        public static Element GetElementByInventoryNumber(int inventoryNumber)
        {
            return db.Elements.Find(inventoryNumber);
        }

        public static void UpdateElement(Element updatedElement)
        {
            var oldElement = GetElementByInventoryNumber(updatedElement.InventoryNumber);
            oldElement.Description = updatedElement.Description;
            oldElement.Location = updatedElement.Location;
            oldElement.Worktime = updatedElement.Worktime;
            oldElement.Retail = updatedElement.Retail;
            oldElement.Labor = updatedElement.Labor;

            db.SaveChanges();
        }

        /// <summary>
        /// for the variable 'a' return all elements where a's description matches user description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static IEnumerable<Element> GetAllElementsByDescription(string description)
        {
            return db.Elements.Where(a => a.Description == description);
        }

        /// <summary>
        /// for the variable 'a' return all elements where a's description matches user description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static IEnumerable<Fabrication> GetAllFabricationsByInventoryNumber(int inventoryNumber)
        {
            return db.Fabrications.Where(a => a.InventoryNumber == inventoryNumber)
            .OrderByDescending(a => a.WorkCompleted);
        }

        /// <summary>
        /// find all elements in a given location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static IEnumerable<Element>
            GetAllElementsbyLocation(LocationID location)
        {
            return db.Elements.Where(a => a.Location == location);
        }

        /// <summary>
        /// go through list of elements and locate one element that matches the inventory number
        /// </summary>
        /// <param name="inventoryNumber">User input inventory number</param>
        /// <param name="labor">amount of labor to add for Keum Boo</param>
        public static void KeumBooWork(int inventoryNumber, decimal worktime)
        {
            var element =
                  db.Elements.SingleOrDefault(
                      a => a.InventoryNumber == inventoryNumber);
            if (element == null)
            {
                ///throw exception
                return;
            }

            element.KeumBooWork(rate, worktime);

            var fabrication = new Fabrication
            {
                WorkCompleted = DateTime.Now,
                FabricationType = TypeOfFabrication.KeumBoo,
                InventoryNumber = element.InventoryNumber,
                Retail = element.Retail
            };
            db.Fabrications.Add(fabrication);
            db.SaveChanges();
        }

        /// <summary>
        /// go through list of elements and locate one element that matches the inventory number
        /// </summary>
        /// <param name="inventoryNumber">User input inventory number</param>
        /// <param name="labor">amount of labor to add for ColdWork</param>
        public static void ColdWork(int inventoryNumber, decimal worktime)
        {
            var element =
                  db.Elements.SingleOrDefault(
                      a => a.InventoryNumber == inventoryNumber);
            if (element == null)
            {
                ///throw exception
                return;
            }

            element.ColdWork(rate, worktime);

            var fabrication = new Fabrication
            {
                WorkCompleted = DateTime.Now,
                FabricationType = TypeOfFabrication.ColdWork,
                InventoryNumber = element.InventoryNumber,
                Retail = element.Retail
            };
            db.Fabrications.Add(fabrication);
            db.SaveChanges();
        }

        /// <summary>
        /// go through list of elements and locate one element that matches the inventory number
        /// </summary>
        /// <param name="inventoryNumber">User input inventory number</param>
        /// <param name="labor">amount of labor to add for Solder work</param>
        public static void SolderWork(int inventoryNumber, decimal worktime)
            {
                var element =
                      db.Elements.SingleOrDefault(
                          a => a.InventoryNumber == inventoryNumber);
                if (element == null)
                {
                    ///throw exception
                    return;
                }

                element.SolderWork(rate, worktime);

                var fabrication = new Fabrication
                {
                    WorkCompleted = DateTime.Now,
                    FabricationType = TypeOfFabrication.ColdWork,
                    InventoryNumber = element.InventoryNumber,
                    Retail = element.Retail
                };
                db.Fabrications.Add(fabrication);
                db.SaveChanges();

        }

    }
}

