using System.Web.Mvc;
using CRMContactForm.DataAccessLayers;
using CRMContactForm.Models;

namespace CRMContactForm.Controllers
{
    /// <summary>
    /// Контроллер контакта.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Основной контроллер.
        /// </summary>
        /// <returns>Представление.</returns>
        public ActionResult Index()
        {
            return View(new ContactEntityModel());
        }

        /// <summary>
        /// Метод создает новую запись контакта в CRM, предварительно проверив входящие данные.
        /// </summary>
        /// <param name="contactModel">Объект модели контакта.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        [HandleError()]
        public ActionResult Index([Bind(Include =
"ContactName, MobilePhone, BirthDay, JobTitle,Email")] ContactEntityModel contactModel)
        {
            if (ModelState.IsValid)
            {
                var contactHelper = new DalContactEntity();

                contactHelper.AddContactToCrm(contactModel);
            }
            return View(contactModel);
        }
    }
}
