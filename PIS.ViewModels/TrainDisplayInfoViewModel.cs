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
    public class TrainDisplayInfoDetailsViewModel
    {
        public string StationCode { get; set; }

        [Display(ResourceType = typeof(Resources.Stations), Name = "StationNameAr")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "RequiredStationNameErrorMsg", ErrorMessageResourceType = typeof(Resources.Stations))]

        public string NameArb { get; set; }
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "ArrivalTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]

        public DateTime ArrivalTime { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "DepartureTime")]
        [RegularExpression("^([0-1][0-9]|[2][0-3]):([0-5][0-9])(:([0-5][0-9])){0,1}$", ErrorMessageResourceName = "InvalidEntry", ErrorMessageResourceType = typeof(Resources.Common))]
        public DateTime DeptTime { get; set; }

        public double? OrderNumber { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "PlateformNo")]
        public string PlateformNo { get; set; }
    }
    public class TrainDisplayInfoViewModel
    {
        public List<TrainDisplayInfoDetailsViewModel> TrainDisplayInfoDetails;

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainNo")]
        public string TrainNo { get; set; }
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = "TrainTypeAName")]
        public string TrainType { get; set; }
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = nameof(Resources.TrainTrip.Class1AName))]
        public string ClassCode1 { get; set; }
        [Display(ResourceType = typeof(Resources.TrainTrip), Name = nameof(Resources.TrainTrip.Class0AName))]
        public string ClassCode2 { get; set; }

        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Saturday))]
        public bool Saturday { get; set; }
        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Sunday))]
        public bool Sunday { get; set; }
        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Monday))]
        public bool Monday { get; set; }
        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Tuesday))]
        public bool Tuesday { get; set; }
        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Wednesday))]
        public bool Wednesday { get; set; }
        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Thursday))]
        public bool Thursday { get; set; }
        [Display(ResourceType = typeof(Resources.DaysOfTheWeek), Name = nameof(Resources.DaysOfTheWeek.Friday))]
        public bool Friday { get; set; }

        [Display(ResourceType = typeof(Resources.TrainTrip), Name = nameof(Resources.TrainTrip.A_Journy))]
        public string TripNameArb { get; set; }

        public string TripNameEn { get; set; }

        public string StartStation { get; set; }
        public string FinalStation { get; set; }

        public string ClassAName1 { get; set; }
        public string ClassAName2 { get; set; }
    }
}
