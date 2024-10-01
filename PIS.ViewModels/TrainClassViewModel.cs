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
    public class TrainClassViewModel
    {
        public string ClassCode { get; set; }
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = nameof(Resources.TrainTrip.TrainEnglisgClass))]
        public string ClassEName { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = nameof(Resources.TrainTrip.TrainArabicClass))]
        public string ClassAName { get; set; }
        public System.DateTime LastModified { get; set; }
        public DateTime? audDateLastChanged { get; set; }
    }
}
