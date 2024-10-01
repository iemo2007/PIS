using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace PIS.DTO
{
    public class StationsViewModel
    {
        public string StationCode { get; set; }
        public string NameArb { get; set; }
        public string NameEngl { get; set; }
        public System.DateTime LastModified { get; set; }
    }
}
