using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Domain.Extensions.Interfaces
{
    public interface IFunctional
    {
        Task<string> UploadFiles(List<IFormFile> files,/* IHostingEnvironment env,*/ string uploadFolder/*, string name*/);

        Task<string> UploadFile(IFormFile files, /*IHostingEnvironment env,*/ string uploadFolder, string name);

        Task<string[]> UploadFilesArray(List<IFormFile> files, IHostingEnvironment env, string uploadFolder, string idProduct);
    }
}