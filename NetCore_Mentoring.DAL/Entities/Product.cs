namespace NetCore_Mentoring.DAL.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }
    }
}
