using Microsoft.AspNetCore.Http;
using System;

namespace ShoeShopApp.Services
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
        bool DeleteImage(string imageFileName);
    }
}
