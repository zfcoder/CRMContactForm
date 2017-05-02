using CRMContactForm.Models;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;

namespace CRMContactForm.DataAccessLayers
{
    /// <summary>
    /// Хелпер для работы с сущностью "contact".
    /// </summary>
    public class DalContactEntity
    {
        /// <summary>
        /// Метод создает новую запись сущности "contact".
        /// </summary>
        /// <param name="contactModel">Объект модели контакта.</param>
        public void AddContactToCrm(ContactEntityModel contactModel)
        {
            // Получаем токен.
            var token = new CrmAuthenticationToken
            {
                AuthenticationType = 0,
                OrganizationName = "AdventureWorksCycle"
            };

            var connectionString = System.Configuration.ConfigurationManager.
                ConnectionStrings["CrmConnection"].ConnectionString;
            
            // Получаем сервис организации CRM.
            var service = new CrmService
            {
                Url = connectionString,
                CrmAuthenticationTokenValue = token,
                Credentials = System.Net.CredentialCache.DefaultCredentials
            };

            // Создаем новую запись.
            var newContact = new contact
            {
                fullname = contactModel.ContactName,
                mobilephone = contactModel.MobilePhone,
                emailaddress1 = contactModel.Email,
                jobtitle = contactModel.JobTitle
            };

            if (contactModel.BirthDay.HasValue)
            {
                newContact.birthdate = CrmDateTime.FromUser(contactModel.BirthDay.Value);
            }

            service.Create(newContact);
        }
    }
}