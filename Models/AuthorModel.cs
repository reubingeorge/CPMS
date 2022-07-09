using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    public class AuthorModel
    {
        [Display(Name = "ID")]
        [Range(0, 100000, ErrorMessage = "ID must be between 0.01 and 100000")]
        [Required(ErrorMessage = "ID is required")]
        public int AuthorID { get; set; }


        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Display(Name = "Middle Initial")]
        public string? MiddleInitial { get; set; }


        [Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [Display(Name = "Affiliation")]
        public string? Affiliation { get; set; }


        [Display(Name = "Department")]
        public string? Department { get; set; }


        [Display(Name = "Address")]
        public string? Address { get; set; }


        [Display(Name = "City")]
        public string? City { get; set; }


        [Display(Name = "State")]
        public string? State { get; set; }


        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }


        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(5)]
        public string Password { get; set;}

        public AuthorModel()
        {
            AuthorID        = 0;
            Email           = "Nothing";
            Password        = "Nothing";
            FirstName       = "Nothing";
            MiddleInitial   = "N";
            LastName        = "Nothing";
            Affiliation     = "Nothing";
            Address         = "Nothing";
            City            = "Nothing";
            State           = "Nothing";
            ZipCode         = "00000";
            PhoneNumber     = "0000000000";
            Department      = "Nothing";

        }

        public AuthorModel(
            int authorID, 
            string? firstName, 
            string? middleInitial, 
            string? lastName, 
            string? affiliation, 
            string? department, 
            string? address, 
            string? city, 
            string? state, 
            string? zipCode, 
            string? phoneNumber, 
            string email, 
            string password)
        {
            AuthorID        = authorID;
            FirstName       = firstName;
            MiddleInitial   = middleInitial;
            LastName        = lastName;
            Affiliation     = affiliation;
            Department      = department;
            Address         = address;
            City            = city;
            State           = state;
            ZipCode         = zipCode;
            PhoneNumber     = phoneNumber;
            Email           = email;
            Password        = password;
        }

        
    }
}
