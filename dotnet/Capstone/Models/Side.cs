using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Capstone.Models
{
    public class Side
    {
        /// <summary>
        /// the id of the side
        /// </summary>
        public int SideID { get; set; }
        /// <summary>
        /// the name of the side
        /// </summary>
        public string SideName { get; set; }
        /// <summary>
        /// the id of the side in the usda api
        /// </summary>
        public int FDCID { get; set; }
        /// <summary>
        /// if the side is wings
        /// </summary>
        public bool IsWing { get; set; }
        /// <summary>
        /// if the side is in stock
        /// </summary>
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
    public class NewSide
    {
        public string SideName { get; set; }
        public int FDCID { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string SideType { get; set; }
    }
}
