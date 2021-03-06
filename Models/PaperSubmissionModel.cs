using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    /// <summary>
    /// Class <c>PaperSubmissionModel</c> represents the model of a paper submitted by an author.
    /// </summary>
    public class PaperSubmissionModel : PaperModel
    {
        [Required(ErrorMessage = "Please upload your Paper")]
        public IFormFile Formfile { get; set; }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PaperSubmissionModel()
        {
            PaperID = -1;
            AuthorID = -1;
            Active = true;
            FilenameOriginal = "Nothing";
            Filename = "Nothing";
            Title = "Nothing";
            Certification = "Not";
            NotesToReviewers = "Nothing";
            AnalysisOfAlgorithms = false;
            Applications = false;
            Architecture = false;
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
            OtherDescription = "Nothing";
            Formfile = null;
        }

        /// <summary>
        /// Non-Default Constructor
        /// </summary>
        /// <param name="paperID"></param>
        /// <param name="authorID"></param>
        /// <param name="active"></param>
        /// <param name="filenameOriginal"></param>
        /// <param name="filename"></param>
        /// <param name="title"></param>
        /// <param name="certification"></param>
        /// <param name="notesToReviewers"></param>
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
        /// <param name="formfile"></param>
        public PaperSubmissionModel(
            int paperID, int authorID, 
            bool active, 
            string filenameOriginal, string filename, 
            string title, string? certification, 
            string? notesToReviewers, 
            bool analysisOfAlgorithms, bool applications, 
            bool architecture, bool artificialIntelligence, 
            bool computerEngineering, bool curriculum, 
            bool dataStructures, bool databases, 
            bool distancedLearning, bool distributedSystems, 
            bool ethicalSocietalIssues, bool firstYearComputing, 
            bool genderIssues, bool grantWriting, 
            bool graphicsImageProcessing, bool humanComputerInteraction, 
            bool laboratoryEnvironments, bool literacy, 
            bool mathematicsInComputing, bool multimedia, 
            bool networkingDataCommunications, bool nonMajorCourses, 
            bool objectOrientedIssues, bool operatingSystems, 
            bool parallelProcessing, bool pedagogy, 
            bool programmingLanguages, bool research, 
            bool security, bool softwareEngineering, 
            bool systemsAnalysisAndDesign, bool usingTechnologyInTheClassroom, 
            bool webAndInternetProgramming, bool other, 
            string? otherDescription, IFormFile formfile)
        {
            PaperID = paperID;
            AuthorID = authorID;
            Active = active;
            FilenameOriginal = filenameOriginal;
            Filename = filename;
            Title = title;
            Certification = certification;
            NotesToReviewers = notesToReviewers;
            AnalysisOfAlgorithms = analysisOfAlgorithms;
            Applications = applications;
            Architecture = architecture;
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
            this.Formfile = formfile;
        }
    }
}
