using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HW20.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get ; set ; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }

        [Display(Name = "Отчетсво")]
        [Required(ErrorMessage = "Введите отчетсво")]
        public string MiddleName { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Введите номер телефона")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание")]
        public string Information { get; set; }
    }
}
