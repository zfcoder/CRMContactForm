using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMContactForm.Models
{
    /// <summary>
    /// Модель сущности контакта.
    /// </summary>
    public class ContactEntityModel
    {
        /// <summary>
        /// Идентификатор контакта.
        /// </summary>
        public Guid ContactId { get; set; }

        /// <summary>
        /// Полное имя контакта. Обязательное поле.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Полное имя")]
        public string ContactName { get; set; }

        /// <summary>
        /// Телефон контакта.
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?([0-9]?)\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Введен некорректный номер телефона.")]
        [DisplayName("Мобильный телефон")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Дата рождения контакта.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime? BirthDay { get; set; }
        
        /// <summary>
        /// Должность, которую занимает контакт.
        /// </summary>
        [DisplayName("Должность")]
        public string JobTitle { get; set; }
    }
}