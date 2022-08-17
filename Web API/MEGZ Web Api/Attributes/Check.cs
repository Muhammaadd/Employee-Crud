//using System.ComponentModel.DataAnnotations;
//using System.Globalization;
//using MEGZ_Web_Api.ViewModels;
//namespace MEGZ_Web_Api.Attributes
//{
//    public class Check : ValidationAttribute
//    {
//        public char Type { get; set; }
//        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//        {
//            AddEmployeeFormViewModel employee =validationContext.ObjectInstance as AddEmployeeFormViewModel;
//            if (Type == 'S')
//            {
//                DateTime StartTime = DateTime.ParseExact((string)value, "HH:mm", CultureInfo.InvariantCulture);
//                DateTime EndTime = DateTime.ParseExact((Da)employee.CheckOut, "HH:mm",CultureInfo.InvariantCulture);
//                if (StartTime > EndTime)
//                    return new ValidationResult("Start time must be earlier than End time");
//            }
//            else
//            {
//                DateTime EndTime = DateTime.ParseExact((string)value, "HH:mm", CultureInfo.InvariantCulture);
//                DateTime StartTime = DateTime.ParseExact((string)employee.CheckIn, "HH:mm", CultureInfo.InvariantCulture);
//                if (EndTime < StartTime)
//                    return new ValidationResult("End time must be later than start time");
//            }
//            return base.IsValid(value, validationContext);
//        }
//    }
//}
