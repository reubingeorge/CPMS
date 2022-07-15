using CPMS.Interfaces;

namespace CPMS.Services
{
    /// <summary>
    /// Class <c>BufferedFileUploadLocalService</c> is used to upload a file from the front-end to the server side.
    /// </summary>
    public class BufferedFileUploadLocalService : IBufferedFileUploadService
    {
        /// <summary>
        /// Method <c>UploadFile</c> is used to upload a file to the server running the software.
        /// </summary>
        /// <param name="file">Object containing the information of the uploaded file</param>
        /// <returns>True if the file has been uploaded.</returns>
        /// <exception cref="Exception">Error causing a failure in the upload.</exception>
        public async Task<bool> UploadFile(IFormFile file)
        {
            string path;
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "uploads"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var filestream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
