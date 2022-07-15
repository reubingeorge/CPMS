using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    /// <summary>
    /// Class <c>AuthorModel</c> represents the information of a single Author.
    /// </summary>
    public class AuthorModel
    {
        [Display(Name = "ID")]
        [Range(0, 100000, ErrorMessage = "ID must be between 1 and 100000")]
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

        /// <summary>
        /// Default constructor
        /// </summary>
        public AuthorModel()
        {
            AuthorID        = -1;
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

        /// <summary>
        /// Non-Default Constructor
        /// </summary>
        /// <param name="authorID">Author ID</param>
        /// <param name="firstName">First Name</param>
        /// <param name="middleInitial">Middle Initial</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="affiliation">Affiliation</param>
        /// <param name="department">Department</param>
        /// <param name="address">Address</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="zipCode">Zip Code</param>
        /// <param name="phoneNumber">Phone Number</param>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
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
