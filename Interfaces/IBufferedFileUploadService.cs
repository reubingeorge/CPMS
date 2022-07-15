namespace CPMS.Interfaces
{
    /// <summary>
    /// Interface <c>IBufferedFileUploadService</c> is used to defined an object
    /// that can accept a file
    /// </summary>
    public interface IBufferedFileUploadService
    {
        /// <summary>
        /// Abstract method <c>UploadFile</c> will be used to upload a file from 
        /// the client to the server side.
        /// </summary>
        /// <param name="file">Object that defines the uploaded file</param>
        /// <returns>Asynchronous call that defines if the upload operation has 
        /// been successful or not</returns>
        Task<bool> UploadFile(IFormFile file);
    }
}
