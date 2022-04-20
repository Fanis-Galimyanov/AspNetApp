using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AspNetApp.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Введите имя")]
        [StringLength(20)]
        [Required(ErrorMessage ="Данная строка не может быть пустой!!!")]
        public string name { get; set; }
        [Display(Name = "Введите Фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string surname { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string adress  { get; set; }
        [Display(Name = "Номер телефона")]
        [StringLength(25)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDeails { get; set; }
    }
}
