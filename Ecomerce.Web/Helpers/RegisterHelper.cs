using Ecomerce.Web.Models;
using System.Text.Json;

namespace Ecomerce.Web.Helpers
{
    public static class RegisterHelper
    {
        public static BuyerModel DeparaViewToController(IFormCollection iFormCollection)
        {
            BuyerModel buyerModel = new BuyerModel();

            foreach (var form in iFormCollection)
            {

                if (form.Key.Equals("FullName"))
                {
                    buyerModel.FullName = form.Value;
                }
                else if (form.Key.Equals("Gender"))
                {
                    if(form.Value.Equals("1"))
                        buyerModel.Gender = "Male";
                    else
                        buyerModel.Gender = "Female";
                }
                else if (form.Key.Equals("DateOfBirth"))
                {
                    buyerModel.DateOfBirth = form.Value;
                }
                else if(form.Key.Equals("RegistrationOfIndividuals"))
                {
                    buyerModel.RegistrationOfIndividuals = form.Value;
                }
                else if(form.Key.Equals("Telephone"))
                {
                    buyerModel.Telephone = form.Value;
                }
                else if (form.Key.Equals("ZipCode"))
                {
                    buyerModel.ZipCode = form.Value;
                }
                else if (form.Key.Equals("Address"))
                {
                    buyerModel.Address = form.Value;
                }
                else if (form.Key.Equals("Number"))
                {
                    buyerModel.Number = form.Value;
                }
                else if (form.Key.Equals("Neighborhood"))
                {
                    buyerModel.Neighborhood = form.Value;
                }
                else if (form.Key.Equals("City"))
                {
                    buyerModel.City = form.Value;
                }
                else if (form.Key.Equals("State"))
                {
                    buyerModel.State = form.Value;
                }
                else if (form.Key.Equals("Email"))
                {
                    buyerModel.Email = form.Value;
                }
                else if (form.Key.Equals("Password"))
                {
                    buyerModel.Password = form.Value;
                }
                buyerModel.ConfirmedEmail = false;
            }

            return buyerModel;
        }
    }
}
