using RestSharp;
using System;

namespace Capstone.Models
{
    public class Payment
    {
        /// <summary>
        /// The card number associated with the method of payment.
        /// </summary>
        public string CardNum { get;  set; }
        /// <summary>
        /// The expiration date associated with the method of payment.
        /// </summary>
        public DateTime ExpDate { get;  set; }
        /// <summary>
        /// The Card Verification Code associated with the method of payment.
        /// </summary>
        public int CVC { get;  set; }
        /// <summary>
        /// The UserID associated with the method of payment.
        /// </summary>
        public int? UserID { get;  set; }
        /// <summary>
        /// The ID associated with the method of payment.
        /// </summary>
        public int PaymentID { get;  set; }
    }
    public class NewPayment
    {
        /// <summary>
        /// The card number associated with the method of payment.
        /// </summary>
        public string CardNum { get; set; }
        /// <summary>
        /// The expiration date associated with the method of payment.
        /// </summary>
        public DateTime ExpDate { get; set; }
        /// <summary>
        /// The Card Verification Code associated with the method of payment.
        /// </summary>
        public int CVC { get; set; }
        /// <summary>
        /// The UserID associated with the method of payment.
        /// </summary>
        public int? UserID { get; set; }
    }
}
