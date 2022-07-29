using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    /// <summary>
    /// Class <c>Topics</c> contains the topics that will be used by either Paper or Reviewer
    /// </summary>
    public class Topics
    {
        [Display(Name = "Analysis Of Algorithms")]
        public bool AnalysisOfAlgorithms { get; set; }

        [Display(Name = "Applications")]
        public bool Applications { get; set; }

        [Display(Name = "Architecture")]
        public bool Architecture { get; set; }

        [Display(Name = "Artificial Intelligence")]
        public bool ArtificialIntelligence { get; set; }

        [Display(Name = "Computer Engineering")]
        public bool ComputerEngineering { get; set; }

        [Display(Name = "Curriculum")]
        public bool Curriculum { get; set; }

        [Display(Name = "Data Structures")]
        public bool DataStructures { get; set; }

        [Display(Name = "Databases")]
        public bool Databases { get; set; }

        [Display(Name = "Distanced Learning")]
        public bool DistancedLearning { get; set; }

        [Display(Name = "Distributed Systems")]
        public bool DistributedSystems { get; set; }

        [Display(Name = "Ethical Societal Issues")]
        public bool EthicalSocietalIssues { get; set; }

        [Display(Name = "First Year Computing")]
        public bool FirstYearComputing { get; set; }

        [Display(Name = "Gender Issues")]
        public bool GenderIssues { get; set; }

        [Display(Name = "Grant Writing")]
        public bool GrantWriting { get; set; }

        [Display(Name = "Graphics Image Processing")]
        public bool GraphicsImageProcessing { get; set; }

        [Display(Name = "Human Computer Interaction")]
        public bool HumanComputerInteraction { get; set; }

        [Display(Name = "Laboratory Environments")]
        public bool LaboratoryEnvironments { get; set; }

        [Display(Name = "Literacy")]
        public bool Literacy { get; set; }

        [Display(Name = "Mathematics In Computing")]
        public bool MathematicsInComputing { get; set; }

        [Display(Name = "Multimedia")]
        public bool Multimedia { get; set; }

        [Display(Name = "Networking Data Communications")]
        public bool NetworkingDataCommunications { get; set; }

        [Display(Name = "Non Major Courses")]
        public bool NonMajorCourses { get; set; }

        [Display(Name = "Object Oriented Issues")]
        public bool ObjectOrientedIssues { get; set; }

        [Display(Name = "Operating Systems")]
        public bool OperatingSystems { get; set; }

        [Display(Name = "Parallel Processing")]
        public bool ParallelProcessing { get; set; }

        [Display(Name = "Pedagogy")]
        public bool Pedagogy { get; set; }

        [Display(Name = "Programming Languages")]
        public bool ProgrammingLanguages { get; set; }

        [Display(Name = "Research")]
        public bool Research { get; set; }

        [Display(Name = "Security")]
        public bool Security { get; set; }

        [Display(Name = "Software Engineering")]
        public bool SoftwareEngineering { get; set; }

        [Display(Name = "Systems Analysis And Design")]
        public bool SystemsAnalysisAndDesign { get; set; }

        [Display(Name = "Using Technology In The Classroom")]
        public bool UsingTechnologyInTheClassroom { get; set; }

        [Display(Name = "Web And Internet Programming")]
        public bool WebAndInternetProgramming { get; set; }

        [Display(Name = "Other")]
        public bool Other { get; set; }

        [Display(Name = "Description")]
        public string? OtherDescription { get; set; }
    }
}
