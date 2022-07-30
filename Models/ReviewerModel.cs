using System.ComponentModel.DataAnnotations;
namespace CPMS.Models
{
    /// <summary>
    /// Class <c>ReviewerModel</c> depicts the model of any individual reviewer.
    /// </summary>
    public class ReviewerModel : TopicsModel
    {
        [Display(Name = "ID")]
        [Range(1, 100000, ErrorMessage = "ID must be between 1 and 100000")]
        [Required(ErrorMessage = "ID is required")]
        public int ReviewerID { get; set; }

        [Display(Name = "Active Reviewer")] 
        public bool Active { get; set; }


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
        public string Password { get; set; }

        

        [Display(Name = "Reviews Acknowledged")] 
        public bool ReviewsAcknowledged { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReviewerModel()
        {
            ReviewerID = 0;
            Active = true;
            Email = "Nothing";
            Password = "Nothing";
            FirstName = "Nothing";
            MiddleInitial = "N";
            LastName = "Nothing";
            Affiliation = "Nothing";
            Address = "Nothing";
            City = "Nothing";
            State = "Nothing";
            ZipCode = "00000";
            PhoneNumber = "0000000000";
            Department = "Nothing";
            AnalysisOfAlgorithms = false;
            Architecture = false;
            Applications = false;
            ArtificialIntelligence = false;
            ComputerEngineering = false;
            Curriculum = false;
            DataStructures = false;
            Databases = false;
            DistancedLearning = false;
            DistributedSystems = false;
            EthicalSocietalIssues = false;
            FirstYearComputing = false;
            GenderIssues = false;
            GrantWriting = false;
            GraphicsImageProcessing = false;
            HumanComputerInteraction = false;
            LaboratoryEnvironments = false;
            Literacy = false;
            MathematicsInComputing = false;
            Multimedia = false;
            NetworkingDataCommunications = false;
            NonMajorCourses = false;
            ObjectOrientedIssues = false;
            OperatingSystems = false;
            ParallelProcessing = false;
            Pedagogy = false;
            ProgrammingLanguages = false;
            Research = false;
            Security = false;
            SoftwareEngineering = false;
            SystemsAnalysisAndDesign = false;
            UsingTechnologyInTheClassroom = false;
            WebAndInternetProgramming = false;
            Other = false;
            OtherDescription = null;
            ReviewsAcknowledged = false;

        }

        /// <summary>
        /// Non-Default Constructor
        /// </summary>
        /// <param name="reviewerID"></param>
        /// <param name="active"></param>
        /// <param name="firstName"></param>
        /// <param name="middleInitial"></param>
        /// <param name="lastName"></param>
        /// <param name="affiliation"></param>
        /// <param name="department"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="analysisOfAlgorithms"></param>
        /// <param name="applications"></param>
        /// <param name="architecture"></param>
        /// <param name="artificialIntelligence"></param>
        /// <param name="computerEngineering"></param>
        /// <param name="curriculum"></param>
        /// <param name="dataStructures"></param>
        /// <param name="databases"></param>
        /// <param name="distancedLearning"></param>
        /// <param name="distributedSystems"></param>
        /// <param name="ethicalSocietalIssues"></param>
        /// <param name="firstYearComputing"></param>
        /// <param name="genderIssues"></param>
        /// <param name="grantWriting"></param>
        /// <param name="graphicsImageProcessing"></param>
        /// <param name="humanComputerInteraction"></param>
        /// <param name="laboratoryEnvironments"></param>
        /// <param name="literacy"></param>
        /// <param name="mathematicsInComputing"></param>
        /// <param name="multimedia"></param>
        /// <param name="networkingDataCommunications"></param>
        /// <param name="nonMajorCourses"></param>
        /// <param name="objectOrientedIssues"></param>
        /// <param name="operatingSystems"></param>
        /// <param name="parallelProcessing"></param>
        /// <param name="pedagogy"></param>
        /// <param name="programmingLanguages"></param>
        /// <param name="research"></param>
        /// <param name="security"></param>
        /// <param name="softwareEngineering"></param>
        /// <param name="systemsAnalysisAndDesign"></param>
        /// <param name="usingTechnologyInTheClassroom"></param>
        /// <param name="webAndInternetProgramming"></param>
        /// <param name="other"></param>
        /// <param name="otherDescription"></param>
        /// <param name="reviewsAcknowledged"></param>
        public ReviewerModel(
            int reviewerID,
            bool active,
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
            string password,
            bool analysisOfAlgorithms,
            bool applications,
            bool architecture,
            bool artificialIntelligence,
            bool computerEngineering,
            bool curriculum,
            bool dataStructures,
            bool databases,
            bool distancedLearning,
            bool distributedSystems,
            bool ethicalSocietalIssues,
            bool firstYearComputing,
            bool genderIssues,
            bool grantWriting,
            bool graphicsImageProcessing,
            bool humanComputerInteraction,
            bool laboratoryEnvironments,
            bool literacy,
            bool mathematicsInComputing,
            bool multimedia,
            bool networkingDataCommunications,
            bool nonMajorCourses,
            bool objectOrientedIssues,
            bool operatingSystems,
            bool parallelProcessing,
            bool pedagogy,
            bool programmingLanguages,
            bool research,
            bool security,
            bool softwareEngineering,
            bool systemsAnalysisAndDesign,
            bool usingTechnologyInTheClassroom,
            bool webAndInternetProgramming,
            bool other,
            string? otherDescription,
            bool reviewsAcknowledged)

        {
            ReviewerID = reviewerID;
            Active = active;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            LastName = lastName;
            Affiliation = affiliation;
            Department = department;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            AnalysisOfAlgorithms = analysisOfAlgorithms;
            Architecture = architecture;
            Applications = applications;
            ArtificialIntelligence = artificialIntelligence;
            ComputerEngineering = computerEngineering;
            Curriculum = curriculum;
            DataStructures = dataStructures;
            Databases = databases;
            DistancedLearning = distancedLearning;
            DistributedSystems = distributedSystems;
            EthicalSocietalIssues = ethicalSocietalIssues;
            FirstYearComputing = firstYearComputing;
            GenderIssues = genderIssues;
            GrantWriting = grantWriting;
            GraphicsImageProcessing = graphicsImageProcessing;
            HumanComputerInteraction = humanComputerInteraction;
            LaboratoryEnvironments = laboratoryEnvironments;
            Literacy = literacy;
            MathematicsInComputing = mathematicsInComputing;
            Multimedia = multimedia;
            NetworkingDataCommunications = networkingDataCommunications;
            NonMajorCourses = nonMajorCourses;
            ObjectOrientedIssues = objectOrientedIssues;
            OperatingSystems = operatingSystems;
            ParallelProcessing = parallelProcessing;
            Pedagogy = pedagogy;
            ProgrammingLanguages = programmingLanguages;
            Research = research;
            Security = security;
            SoftwareEngineering = softwareEngineering;
            SystemsAnalysisAndDesign = systemsAnalysisAndDesign;
            UsingTechnologyInTheClassroom = usingTechnologyInTheClassroom;
            WebAndInternetProgramming = webAndInternetProgramming;
            Other = other;
            OtherDescription = otherDescription;
            ReviewsAcknowledged = reviewsAcknowledged;
        }
    }
}