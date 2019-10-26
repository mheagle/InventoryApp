using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp
{
    enum TypeOfAssembly
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
    class Assembly
    {/// <summary>
    /// assembly rate charge per hour
    /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// amount of time spent assembling piece in hours
        /// </summary>
        public int Worktime { get; set; }
        /// <summary>
        /// ID number of job
        /// </summary>
        public int JobID { get; set; }
        /// <summary>
        /// date work completed and entered into inventory
        /// </summary>
        public DateTime WorkCompleted { get; set; }
        /// <summary>
        /// Variety of Assembly types
        /// </summary>
        public TypeOfAssembly AssemblyType { get; set; }
        /// <summary>
        /// Weight value after assembly
        /// </summary>
        public decimal WeightValue { get; set; }
        /// <summary>
        /// Foreign key to Element Inventory Number
        /// </summary>
        public int InventoryNumber { get; set; }
    }
}
