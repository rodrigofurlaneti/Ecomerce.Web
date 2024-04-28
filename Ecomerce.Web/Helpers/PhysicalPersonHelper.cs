using Ecomerce.Domain.Model;

namespace Ecomerce.Web.Helpers
{
    public static class PhysicalPersonHelper
    {
        public static PhysicalPerson DeparaViewToController_PhysicalPerson(IFormCollection iFormCollection)
        {
            PhysicalPerson registerEntity = new PhysicalPerson();

            foreach (var form in iFormCollection)
            {

                if (form.Key.Equals("FullName"))
                {
                    registerEntity.FullName = form.Value;
                }
                else if (form.Key.Equals("Gender"))
                {
                    if (form.Value.Equals("1"))
                        registerEntity.Gender = "Male";
                    else
                        registerEntity.Gender = "Female";
                }
                else if (form.Key.Equals("DateOfBirth"))
                {
                    registerEntity.DateOfBirth = form.Value;
                }
                else if (form.Key.Equals("RegistrationOfIndividuals"))
                {
                    registerEntity.RegistrationOfIndividuals = form.Value;
                }
                else if (form.Key.Equals("Telephone"))
                {
                    registerEntity.Telephone = form.Value;
                }
                else if (form.Key.Equals("ZipCode"))
                {
                    registerEntity.ZipCode = form.Value;
                }
                else if (form.Key.Equals("Address"))
                {
                    registerEntity.Address = form.Value;
                }
                else if (form.Key.Equals("Number"))
                {
                    registerEntity.Number = form.Value;
                }
                else if (form.Key.Equals("Neighborhood"))
                {
                    registerEntity.Neighborhood = form.Value;
                }
                else if (form.Key.Equals("City"))
                {
                    registerEntity.City = form.Value;
                }
                else if (form.Key.Equals("State"))
                {
                    registerEntity.State = form.Value;
                }
                else if (form.Key.Equals("Email"))
                {
                    registerEntity.Email = form.Value;
                }
                else if (form.Key.Equals("Password"))
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
