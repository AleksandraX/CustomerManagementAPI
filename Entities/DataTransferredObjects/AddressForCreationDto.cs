
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementPortal.Entities.DataTransferredObjects
{
    public class AddressForCreationDto
    {
        public string Country { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Address street is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Street is 100 characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Street is 3 characters.")]
        public string Street { get; set; }


        [Required(ErrorMessage = "ZipCode is a required field.")]
        [MaxLength(6, ErrorMessage = "Maximum length for the ZipCode is 6 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the ZipCode is 5 characters.")]
        public string ZipCode { get; set; }
    }
}
