using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryapp
{
    #region Properties

  public  enum TypeOfFabrication
    {
        ColdWork,
        Solder,
        KeumBoo
    }

   public  class Fabrication

    {
        /// <summary>
        /// description of fabrication process used
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID number of job
        /// </summary>
        public int JobID { get; set; }

        /// <summary>
        /// date work completed and entered into inventory
        /// </summary>
        public DateTime WorkCompleted { get; set; }

        /// <summary>
        /// Type of Fabrication
        /// </summary>
        public TypeOfFabrication FabricationType { get; set; }

        /// <summary>
        /// Retail price
        /// </summary>
        public decimal Retail { get;  set; }

        /// <summary>
        /// Foreign key to Element Inventory Number
        /// </summary>
        public int InventoryNumber { get; set; }

        public virtual Element Element { get; set; }


        #endregion


    }
}
