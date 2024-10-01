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
    public class TrainScheduleViewMode
    {
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainNo")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = nameof(Resources.Train.RequiredTrainNumber))]
        public string TrainNo { get; set; }


        public string CurrentStation { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "ArrivalTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = nameof(Resources.Train.RequiredArrivalTime))]

        public string ArrivalTime { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DepartureTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = nameof(Resources.Train.RequiredDepartureTime))]

        public string DeptTime { get; set; }


        public string StartStationCode { get; set; }

        public string FinalStationCode { get; set; }
        public string E_Journy { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "A_Journy")]
        public string A_Journy { get; set; }
        public string Class0Code { get; set; }
        public string Class0EName { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "Class0AName")]
        public string Class0AName { get; set; }
        public string Class1Code { get; set; }
        public string Class1EName { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "Class1AName")]
        public string Class1AName { get; set; }
        public string TrainTypeCode { get; set; }
        public string TrainTypeEName { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainTypeAName")]
        public string TrainTypeAName { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "PlateformNo")]
        public string PlateformNo { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DelayStatus")]
        public string DelayStatus { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DelayReason")]
        public string DelayReason { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "WithoutPlatform")]
        public bool WithoutPlatform
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PlateformNo) || PlateformNo.Trim() == "-" || PlateformNo.Trim() == "_")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public double? StationOrder { get; set; }
        public bool Modified { get; set; }
        public DateTime? audDateLastChanged { get; set; }
        public bool IsNew { set; get; }

        [Display(ResourceType = typeof(Resources.Train), Name = nameof(Resources.Train.OrignalDepatruteTime))]
        public string OrignalDepatruteTime { get; set; }

        [Display(ResourceType = typeof(Resources.Train), Name = nameof(Resources.Train.OrignalArrivalTime))]

        public string OrignalArrivalTime { get; set; }
    }

    public class SearchTrainScheduleViewMode
    {


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainNo")]
        public string TrainNo { get; set; }



        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "ArrivalTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]
        public string ArrivalTime { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DepartureTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]

        public string DeptTime { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "A_Journy")]
        public string A_Journy { get; set; }



        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "Class0AName")]
        public string Class0AName { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "Class1AName")]
        public string Class1AName { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainTypeAName")]
        public string TrainTypeAName { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "PlateformNo")]
        public string PlateformNo { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DelayStatus")]
        public string DelayStatus { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = nameof(Resources.TrainTrip.DelayReason))]
        public string DelayReason { get; set; }

    }
}
