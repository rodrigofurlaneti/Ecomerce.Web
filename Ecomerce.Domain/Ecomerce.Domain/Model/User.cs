namespace Ecomerce.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Profile? Profile { get; set; }
        public bool Status { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
