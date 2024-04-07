namespace Ecomerce.Domain.Entities
{
    public class PhysicalPersonEntity : BaseRegisterEntity
    {
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public string? RegistrationOfIndividuals { get; set; }
    }
}
