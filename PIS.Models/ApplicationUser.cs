using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string StationNo { get; set; }
        public System.DateTime LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }

    }
}
