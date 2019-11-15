﻿using System;
using System.Collections.Generic;
using System.Text;



namespace InventoryApp

{
    /// <summary>
    /// list of material types 
    /// </summary>
    enum TypeOfMaterials
    {
        Stone,
        Sterling,
        Gold,
        Copper,
    }
    /// <summary>
    /// list of locations for location types
    /// </summary>
    enum LocationID
    {
        Retailer,
        Online,
        Stock,
        Sold,
    }

    /// <summary>
    /// This is a raw material that can be sold as an individual piece
    /// or combined with other materials to create new pieces. Unique inventory numbers are generated, and wholesale and retail amounts are calculated, 
    /// and the user can indicate when the material is sold.
    /// </summary>
    class Element
    {
        private static int lastInventoryNumber = 0;

        #region Properties
        /// <summary>
        /// Raw material type of the element
        /// </summary>
        public TypeOfMaterials Material { get; set; }

        /// <summary>
        /// Weight of the element in grams
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Retail price of item
        /// </summary>
        public decimal RPrice { get; private set; }
        /// <summary>
        /// Weight value defined as value of one unit of weight (gram, ounce, or carat)
        /// </summary>
        public decimal WValue { get; private set; }


        /// Autogenerated inventory number for the raw materials
        /// </summary>
        public int InventoryNumber { get; }

        /// <summary>
        /// Date acquired into inventory
        /// </summary>
        public DateTime DateAcquired { get; private set; }

        /// <summary>
        /// Location of the inventory item, stock, retail shop, online, sold
        /// </summary>
        public LocationID Location { get; set; }

        /// <summary>
        /// labor rate charge per hour
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// amount of time spent assembling piece in hours
        /// </summary>
        public decimal Worktime { get; set; }

        /// <summary>
        /// amount charged for assembly labor
        /// </summary>
        public decimal LaborCharge { get; private set; }


        #endregion


        #region Constructor

        public Element()
        {
            InventoryNumber = ++lastInventoryNumber;
            DateAcquired = DateTime.Now;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculate retail price with user input values for markup and wholesale price
        /// </summary>
        /// <param name="markup">Price markup for retail</param>
        /// <param name="wsprice">Wholesale price</param>
        public void MakeRetail(decimal markup, decimal wsprice)

        {
            RPrice = markup * wsprice;
        }

        /// <summary>
        /// Calculate weight value as price per single unit of weight
        /// </summary>
        /// <param name="weight">weight of element</param>
        /// <param name="wsprice">wholesale price</param>
        public decimal WeightValue(decimal weight, decimal wsprice)
        {
            WValue = weight / wsprice;
            return WValue;
        }

        ///<summary>
        ///Fabrication Labor charges
        ///</summary>
        ///<parm name="rate">charge per hour
        ///<parm name="worktime">time spent fabricating piece in hours
        public decimal FabricationCharge(decimal rate, decimal worktime)
         
        {
            LaborCharge = rate * worktime;
            return LaborCharge;
        }
        #endregion
    }
}

