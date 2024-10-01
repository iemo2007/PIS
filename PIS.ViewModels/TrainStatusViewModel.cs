using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PIS.ViewModels
{
    public class TrainStatusViewModel
    {
        [Key]
        public int StatusID { get; set; }

        [Display(ResourceType = typeof(Resources.Train), Name = "TrainStatus")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = "RequiredTrainStatus")]
        public string StatusName { get; set; }

        [Display(ResourceType = typeof(Resources.Train), Name = "LabelArabicStatusName")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = "RequiredArabicStatusName")]
        public string StatusSymbol { get; set; }

        [Display(ResourceType = typeof(Resources.Train), Name = "LabelEnglishStatusName")]
        public string StatusEnSymbol { get; set; }

        public DateTime LastModified { get; set; }
        public DateTime? audDateLastChanged { get; set; }
    }
}
