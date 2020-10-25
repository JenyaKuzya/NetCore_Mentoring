using System.Collections.Generic;

namespace NetCore_Mentoring.DAL.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
