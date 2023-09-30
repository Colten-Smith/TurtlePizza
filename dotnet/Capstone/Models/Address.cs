namespace Capstone.Models
{
    public class Address
    {
        /// <summary>
        /// The street address component of the full address.
        /// </summary>
        public string StreetAddress { get;  set; }
        /// <summary>
        /// The apartment number component of the full address. Can be null if none exists.
        /// </summary>
        public int? AptNum { get;  set; }
        /// <summary>
        /// The ZIP Code component of the full address.
        /// </summary>
        public int ZIP { get;  set; }
        /// <summary>
        /// The City component of the full address.
        /// </summary>
        public string City { get;  set; }
        /// <summary>
        /// The State component of the full address.
        /// </summary>
        public string State { get;  set; }
        /// <summary>
        /// The User ID associated with the address.
        /// </summary>
        public int UserID { get;  set; }
        /// <summary>
        /// The ID of the address.
        /// </summary>
        public int AddressID { get;  set; }
    }
    public class NewAddress
    {
        /// <summary>
        /// The street address component of the full address.
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// The apartment number component of the full address. Can be null if none exists.
        /// </summary>
        public byte? AptNum { get; set; }
        /// <summary>
        /// The ZIP Code component of the full address.
        /// </summary>
        public int ZIP { get; set; }
        /// <summary>
        /// The City component of the full address.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The State component of the full address.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The User ID associated with the address.
        /// </summary>
        public int UserID { get; set; }
    }
}
