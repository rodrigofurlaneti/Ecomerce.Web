using Ecomerce.Domain.Entities;

namespace Ecomerce.Web.Helpers
{
    public static class LegalEntitiesHelper
    {
        public static LegalEntitiesEntity DeparaViewToController_LegalEntities(IFormCollection iFormCollection)
        {
            LegalEntitiesEntity registerEntity = new LegalEntitiesEntity();

            foreach (var form in iFormCollection)
            {

                if (form.Key.Equals("NationalRegisterOfLegalEntities"))
                {
                    registerEntity.NationalRegisterOfLegalEntities = form.Value;
                }
                else if (form.Key.Equals("CorporateReason"))
                {
                    registerEntity.CorporateReason = form.Value;
                }
                else if(form.Key.Equals("FantasyName"))
                {
                    registerEntity.FantasyName = form.Value;
                }
                else if (form.Key.Equals("Situation"))
                {
                    registerEntity.Situation = form.Value;
                }
                else if (form.Key.Equals("Members"))
                {
                    registerEntity.Members = form.Value;
                }
                else if(form.Key.Equals("Telephone"))
                {
                    registerEntity.Telephone = form.Value;
                }
                else if (form.Key.Equals("ZipCodeCnpj"))
                {
                    registerEntity.ZipCode = form.Value;
                }
                else if (form.Key.Equals("AddressCnpj"))
                {
                    registerEntity.Address = form.Value;
                }
                else if (form.Key.Equals("NumberCnpj"))
                {
                    registerEntity.Number = form.Value;
                }
                else if (form.Key.Equals("NeighborhoodCnpj"))
                {
                    registerEntity.Neighborhood = form.Value;
                }
                else if (form.Key.Equals("CityCnpj"))
                {
                    registerEntity.City = form.Value;
                }
                else if (form.Key.Equals("StateCnpj"))
                {
                    registerEntity.State = form.Value;
                }
                else if (form.Key.Equals("EmailCnpj"))
                {
                    registerEntity.Email = form.Value;
                }
                else if (form.Key.Equals("PasswordCnpj"))
                {
                    registerEntity.Password = form.Value;
                }
                registerEntity.ConfirmedEmail = false;
                registerEntity.Status = false;
                registerEntity.DateInsert = DateTime.Now;
                registerEntity.DateUpdate = DateTime.Now;
            }

            return registerEntity;
        }
    }
}
