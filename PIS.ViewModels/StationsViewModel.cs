using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PIS.ViewModels
{
    public class StationsViewModel
    {
        [Key]
        public string StationCode { get; set; }

        [Display(ResourceType = typeof(Resources.Stations), Name = "StationNameAr")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "RequiredStationNameErrorMsg", ErrorMessageResourceType = typeof(Resources.Stations))]
        public string NameArb { get; set; }

        [Display(ResourceType = typeof(Resources.Stations), Name = "StationNameEn")]
        public string NameEngl { get; set; }

        [Display(ResourceType = typeof(Resources.Stations), Name = "LastModified")]
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime LastModified { get; set; }
    }
}
