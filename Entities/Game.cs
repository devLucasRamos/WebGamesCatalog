using System;

namespace WebGamesCatalog.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Prod { get; set; }
        public double Price { get; set; }
    }
}
