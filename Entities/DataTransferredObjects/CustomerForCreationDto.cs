
using System;
using System.ComponentModel.DataAnnotations;
using CustomerManagementPortal.Entities.Enums;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Entities.DataTransferredObjects
{
    public class CustomerForCreationDto
    {
        [Required(ErrorMessage = "Customer name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Name is 3 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer last name is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the last name is 40 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }

        public Guid CountryId { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }
    }
}
