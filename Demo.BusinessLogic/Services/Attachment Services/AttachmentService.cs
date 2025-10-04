using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Attachment_Services
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = [".png", ".jpg", ".jpeg"];
        //2MB ==> Byte ==> 2 * 1024 * 1024 = 2_097_152
        const int maxSize = 2_097_152;
        public string? Upload(IFormFile file, string folderName)
        {
            //1- check Extention
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension)) return null;

            // 2- check Size
            if(file.Length > maxSize || file.Length == 0) return null;

            // 3- Get Located Path
            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}";
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","files", folderName);

            // 4- Make attachment name unique
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            // 5- Get File Path
            var filePath = Path.Combine(folderpath, fileName);

            // 6- Create the Stream
            using FileStream fs = new FileStream(filePath, FileMode.Create);

            // 7- Use Stream To Copy The File
            file.CopyTo(fs);

            // 8- Return FileName To Store in db 
            return fileName;

        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            { 
                File.Delete(filePath);
                return true;
            }
            return false;
        }

    }
}
