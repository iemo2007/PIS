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
    public class TrainTripViewModel
    {

        [Key]
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainNo")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "TrainNoRequired", ErrorMessageResourceType = typeof(Resources.TrainTrip))]
        public string TrainNo { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "StartStation")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StartStationRequired", ErrorMessageResourceType = typeof(Resources.TrainTrip))]
        public string StartStationCode { get; set; }
        public string StartStationName { get; set; }
        public IEnumerable<StationsViewModel> StartStations { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "EndStation")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EndStationRequired", ErrorMessageResourceType = typeof(Resources.TrainTrip))]
        public string EndStationCode { get; set; }
        public string EndStationName { get; set; }
        public IEnumerable<StationsViewModel> EndStations { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "StartPlatformNumber")]
        public string StartPlatformNumber { get; set; } = "1";


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "EndPlatformNumber")]
        public string EndPlatformNumber { get; set; } = "1";


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "WithoutPlatform")]
        public bool HasNoStartPlatForm { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "WithoutPlatform")]
        public bool HasNoEndPlatForm { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "PlatformNumber")]
        public string PlatformNumber { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "StationName")]
        public string StationName { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "StationCode")]
        public string StationCode { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DepartureTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = nameof(Resources.Train.RequiredDepartureTime))]

        public string DepartureTime { get; set; }


        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "ArrivalTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Train), ErrorMessageResourceName = nameof(Resources.Train.RequiredArrivalTime))]

        public string ArrivalTime { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "Order")]
        public string Order { get; set; }
    }
}
