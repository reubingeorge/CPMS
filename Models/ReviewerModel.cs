using System.ComponentModel.DataAnnotations;
namespace CPMS.Models
{

    public class ReviewerModel
    {
        [Display(Name = "ID")]
        [Range(0, 100000, ErrorMessage = "ID must be between 0.01 and 100000")]
        [Required(ErrorMessage = "ID is required")]
        public int ReviewerID { get; set; }

        [Display(Name = "Active Reviewer")] public bool Active { get; set; }

        [Display(Name = "First Name")] public string? FirstName { get; set; }


        [Display(Name = "Middle Initial")] public string? MiddleInitial { get; set; }


        [Display(Name = "Last Name")] public string? LastName { get; set; }


        [Display(Name = "Affiliation")] public string? Affiliation { get; set; }


        [Display(Name = "Department")] public string? Department { get; set; }


        [Display(Name = "Address")] public string? Address { get; set; }


        [Display(Name = "City")] public string? City { get; set; }


        [Display(Name = "State")] public string? State { get; set; }


        [Display(Name = "Zip Code")] public string? ZipCode { get; set; }


        [Display(Name = "Phone Number")] public string? PhoneNumber { get; set; }


        [Display(Name = "Email")][Required] public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(5)]
        public string Password { get; set; }

        [Display(Name = "Analysis Of Algorithms")] public bool AnalysisOfAlgorithms { get; set; }
        [Display(Name = "Applications")] public bool Applications { get; set; }
        [Display(Name = "Architecture")] public bool Architecture { get; set; }
        [Display(Name = "Artificial Intelligence")] public bool ArtificialIntelligence { get; set; }
        [Display(Name = "Computer Engineering")] public bool ComputerEngineering { get; set; }
        [Display(Name = "Curriculum")] public bool Curriculum { get; set; }
        [Display(Name = "Data Structures")] public bool DataStructures { get; set; }
        [Display(Name = "Databases")] public bool Databases { get; set; }
        [Display(Name = "Distanced Learning")] public bool DistancedLearning { get; set; }
        [Display(Name = "Distributed Systems")] public bool DistributedSystems { get; set; }
        [Display(Name = "Ethical Societal Issues")] public bool EthicalSocietalIssues { get; set; }
        [Display(Name = "First Year Computing")] public bool FirstYearComputing { get; set; }
        [Display(Name = "Gender Issues")] public bool GenderIssues { get; set; }
        [Display(Name = "Grant Writing")] public bool GrantWriting { get; set; }
        [Display(Name = "Graphics Image Processing")] public bool GraphicsImageProcessing { get; set; }
        [Display(Name = "Human Computer Interaction")] public bool HumanComputerInteraction { get; set; }
        [Display(Name = "Laboratory Environments")] public bool LaboratoryEnvironments { get; set; }
        [Display(Name = "Literacy")] public bool Literacy { get; set; }
        [Display(Name = "Mathematics In Computing")] public bool MathematicsInComputing { get; set; }
        [Display(Name = "Multimedia")] public bool Multimedia { get; set; }
        [Display(Name = "Networking Data Communications")] public bool NetworkingDataCommunications { get; set; }
        [Display(Name = "Non Major Courses")] public bool NonMajorCourses { get; set; }
        [Display(Name = "Object Oriented Issues")] public bool ObjectOrientedIssues { get; set; }
        [Display(Name = "Operating Systems")] public bool OperatingSystems { get; set; }
        [Display(Name = "Parallel Processing")] public bool ParallelProcessing { get; set; }
        [Display(Name = "Pedagogy")] public bool Pedagogy { get; set; }
        [Display(Name = "Programming Languages")] public bool ProgrammingLanguages { get; set; }
        [Display(Name = "Research")] public bool Research { get; set; }
        [Display(Name = "Security")] public bool Security { get; set; }
        [Display(Name = "Software Engineering")] public bool SoftwareEngineering { get; set; }
        [Display(Name = "Systems Analysis And Design")] public bool SystemsAnalysisAndDesign { get; set; }
        [Display(Name = "Using Technology In The Classroom")] public bool UsingTechnologyInTheClassroom { get; set; }
        [Display(Name = "Web And Internet Programming")] public bool WebAndInternetProgramming { get; set; }
        [Display(Name = "Other")] public bool Other { get; set; }
        [Display(Name = "Description")] public string? OtherDescription { get; set; }
        [Display(Name = "Reviews Acknowledged")] public bool ReviewsAcknowledged { get; set; }

        public ReviewerModel()
        {
            ReviewerID = 0;
            Active = false;
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