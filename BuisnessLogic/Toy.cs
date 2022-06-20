using BuisnessLogic.Enums;

namespace BuisnessLogic
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public Subject Subject { get; set; } // тематика
    }


}
