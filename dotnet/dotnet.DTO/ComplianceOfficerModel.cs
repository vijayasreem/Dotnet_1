
using System.ComponentModel.DataAnnotations;

namespace dotnet
{
    public class ComplianceOfficerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "PAN is required")]
        public string Pan { get; set; }

        [Required(ErrorMessage = "Aadhar is required")]
        public string Aadhar { get; set; }

        public string OtherID { get; set; }

        public string Organization { get; set; }

        public string Notes { get; set; }
    }
}
