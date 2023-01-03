using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.MVC.Extensions
{
    public static class FormFileExtension
    {
        //IformFile to ByteArray
        public static async Task<byte[]> GetBytesAsync(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        //ByteArray to IFormfile        
        public static async Task<IFormFile> GetFormFileAsync(this string byteString, string name)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(byteString);
            await using var stream = new MemoryStream(byteArray);
            var file = new FormFile(stream, 0, stream.Length, name, "old_Image.jpeg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };
            return file;
        }
    }
}
