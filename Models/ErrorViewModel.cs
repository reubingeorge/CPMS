namespace CPMS.Models
{
    /// <summary>
    /// Class <c>ErrorViewModel</c> depicts the error caused by any controller.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}