namespace Ecomerce.Domain.Entities
{
    public class BaseRegisterEntity
    {
        public int Id { get; set; }
        public string? Telephone { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? ConfirmedEmail { get; set; }
        public bool? Status { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }

    }
}
