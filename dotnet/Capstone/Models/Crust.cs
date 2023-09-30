namespace Capstone.Models
{
    public class Crust
    {
        /// <summary>
        /// the id the of the crust 
        /// </summary>
        public int CrustID { get; set; }
        /// <summary>
        /// the name of the crust
        /// </summary>
        public string CrustName { get; set; }
        /// <summary>
        /// the id of the crust in the usda api
        /// </summary>
        public int FDCID { get; set; }
        /// <summary>
        /// the price of the crust
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// if the crust is in stock
        /// </summary>
        public bool IsAvailable { get; set; }
    }
    public class NewCrust
    {
        public string CrustName { get; set; }
        public int FDCID { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
