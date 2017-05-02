using CRMContactForm.Models;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;

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
            var connection =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["CrmConnection"].ConnectionString; //Подключение к CRM. Строка подключения указана в файле web.config.
            using (var service = new OrganizationService(connection))
            {
                var contact = new Entity("contact");
                contact["fullname"] = contactModel.ContactName;
                contact["phone"] = contactModel.MobilePhone;
                contact["email"] = contactModel.Email;
                contact["jobtitle"] = contactModel.JobTitle;
                contact["birthday"] = contactModel.BirthDay;
                service.Create(contact);
            }
        }
    }
}