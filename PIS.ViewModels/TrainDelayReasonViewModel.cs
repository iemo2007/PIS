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
    public class TrainDelayReasonViewModel
    {
        [Key]
        public int ResonID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DelayReasonRequired", ErrorMessageResourceType = typeof(Resources.TrainDelayReason))]
        [Display(ResourceType = typeof(Resources.TrainDelayReason), Name = nameof(Resources.TrainDelayReason.DelayReason))]
        public string ResonName { get; set; }

        public Nullable<System.DateTime> LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }
    }
}
