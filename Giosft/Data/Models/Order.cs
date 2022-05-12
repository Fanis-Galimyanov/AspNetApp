using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Site_1.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(15)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(15)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string surname { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string adress { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(40)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Данная строка не может быть пустой!!!")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
