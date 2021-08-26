using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstProject.Entities
{
    public class Customer
    {
        public int Id { get; set; }


        [Display(Name= "Name")]
        [Required]
        [StringLength(50, ErrorMessage =
            "Customer Name should be less than or equal to 50 characters.")]
        public string Name { get; set; }



        [Display(Name= "Surname")]
        [Required]
        [StringLength(50, ErrorMessage =
            "Customer Surname should be less than or equal to 50 characters.")]
        public string Surname { get; set; }

       

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        public List<Order> Orders { get; set; } //bir müşteri birden fazla sipariş verebilir.




    }

}
