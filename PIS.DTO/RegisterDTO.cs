using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Station Number is required")]
        public string StationNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid e-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Password should be between {1} & {2} characters")]
        public string Password { get; set; }
    }

}
