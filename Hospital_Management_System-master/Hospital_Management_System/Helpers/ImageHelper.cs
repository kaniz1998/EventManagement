using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hospital_Management_System.Helpers
{
    public class ImageHelper
    {
        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = Path.Combine("wwwroot", "Images");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                return Path.Combine("Images", fileName); 
            }

            return null;
        }
    }

    //private byte[] ConvertFileToByte(IFormFile file)
    //{
    //    byte[] fileBytes = null;
    //    if (file != null)
    //    {
    //        if (file.Length > 0)
    //        {
    //            using (var ms = new MemoryStream())
    //            {
    //                file.CopyTo(ms);
    //                fileBytes = ms.ToArray();
    //            }
    //        }
    //    }
    //    return fileBytes;
    //}

    //private IFormFile ConvertByteToFile(byte[] byteArray)
    //{
    //    var stream = new MemoryStream(byteArray);
    //    IFormFile file = new FormFile(stream, 0, byteArray.Length, "name", "fileName");
    //    return file;
    //}
}
