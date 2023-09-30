using System.Security.Policy;

namespace Capstone.Models
{
    public class Sauce
    {
        /// <summary>
        /// the id of sauce
        /// </summary>
        public int SauceID { get; set; }
        /// <summary>
        /// the name of sauce
        /// </summary>
        public string SauceName { get; set; }
        /// <summary>
        /// the id in the usda api for the sauce
        /// </summary>
        public int FDCID { get; set; }
        /// <summary>
        /// if the sauce is in stock
        /// </summary>
        public bool IsAvailable { get; set; }
    }
    public class NewSauce
    {
        public string SauceName { get; set; }
        public int FDCID { get; set; }
        public bool IsAvailable { get; set; }
    }
}
