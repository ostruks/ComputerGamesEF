using System.Collections.Generic;

namespace Library.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int License { get; set; }
        public List<Game> Games { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {License}";
        }
    }
}
