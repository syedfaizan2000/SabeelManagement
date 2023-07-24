using System.ComponentModel.DataAnnotations;

namespace SabeelManagement.Models
{
    public class SabeelRegistrationModel
    {
        [Required(ErrorMessage = "Sabeel Name is required.")]
        public string SabeelName { get; set; } = null!;

        [Required(ErrorMessage = "Organization Name is required.")]
        public string OrganizationName { get; set; } = null!;

        [Required(ErrorMessage = "CNIC is required.")]
        public string CNIC { get; set; } = null!;

        [Required(ErrorMessage = "Mobile Number is required.")]
        public string MobileNumber { get; set; } = null!;

        [Required(ErrorMessage = "Area is required.")]
        public string AreaId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = null!;
    }
}
