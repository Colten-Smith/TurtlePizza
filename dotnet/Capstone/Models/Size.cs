using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Capstone.Models
{
    public class Size
    {
        /// <summary>
        /// the id of the size
        /// </summary>
        public int SizeID { get; set; }
        /// <summary>
        /// the size name of the size 
        /// </summary>
        public string SizeName {get; set;}
        /// <summary>
        /// the price of the size
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// if the size is in stock
        /// </summary>
        public bool IsAvailable { get; set; }
    }
    public class NewSize
    {
        public string SizeName { get; set; }
        public decimal Price { get; set; }
        public string FoodType { get; set; }
        public bool IsAvailable { get; set; }
    }
}
