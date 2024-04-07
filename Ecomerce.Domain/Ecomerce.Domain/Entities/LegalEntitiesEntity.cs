namespace Ecomerce.Domain.Entities
{
    public class LegalEntitiesEntity : BaseRegisterEntity
    {
        public string? NationalRegisterOfLegalEntities { get; set; }
        public string? CorporateReason { get; set; }
        public string? FantasyName { get; set; }
        public string? Situation { get; set; }
        public string? Members { get; set; }
    }
}
