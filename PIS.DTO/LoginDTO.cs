using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is mandatory")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is mandaory")]
        public string Password { get; set; }
    }
}
