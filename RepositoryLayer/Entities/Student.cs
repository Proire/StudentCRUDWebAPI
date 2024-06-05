using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities
{
    public class Student(string Name, string Address, string Email)
    {
        [Key]
        public int Prn { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string Name { get; set; } = Name;


        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = Address;


        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = Email;


    }
}
