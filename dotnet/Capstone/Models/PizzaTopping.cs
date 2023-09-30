namespace Capstone.Models
{
    public class PizzaTopping
    {
        public int PizzaToppingID { get; set; }
        public Topping Topping { get; set; }
        public int PizzaID { get; set; }
        public bool IsExtra { get; set; }
        public bool Quad1 { get; set; }
        public bool Quad2 { get; set; }
        public bool Quad3 { get; set; }
        public bool Quad4 { get; set; }
    }
    public class NewPizzaTopping
    {
        public int ToppingId { get; set; }
        public int PizzaID { get; set; }
        public bool IsExtra { get; set; }
        public bool Quad1 { get; set; }
        public bool Quad2 { get; set; }
        public bool Quad3 { get; set; }
        public bool Quad4 { get; set; }
    }
}
