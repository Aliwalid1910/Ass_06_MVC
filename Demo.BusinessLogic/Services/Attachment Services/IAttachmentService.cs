using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.Attachment_Services
{
    public interface IAttachmentService
    {
        // Upload
        public string? Upload(IFormFile file, string folderName);

        // Delete
        public bool Delete(string filePath);
    }
}
