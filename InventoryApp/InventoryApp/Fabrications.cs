using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp
{
    #region Properties

    enum TypeOfFabrication
    {
    ColdJoin,
    Solder,
    Texture,
    Setting,
    KeumBoo,
    Patina,
    Wirework,
    Forge,
    Cast
    }
    class Fabrication
    {
        /// <summary>
        /// description of fabrication process
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID number of job
        /// </summary>
        public int JobID { get; set; }

        /// <summary>
        /// amount of labor charges
        /// </summary>
        public decimal LaborAmount { get; set; }

        /// <summary>
        /// retail price afer fabrication labor charges added
        /// </summary>
        public decimal RetailAfter { get; set; }

        /// <summary>
        /// date work completed and entered into inventory
        /// </summary>
        public DateTime WorkCompleted { get; set; }
        /// <summary>
        /// List of fabrication types
        /// </summary>
        public TypeOfFabrication FabricationType { get; set; }

        /// <summary>
        /// Foreign key to Element Inventory Number
        /// </summary>
        public int InventoryNumber { get; set; }

        #endregion


    }
}
