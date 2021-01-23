using Lib.Domain.Extensions.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace Lib.Domain.Extensions.Implements
{
    public class Functional : IFunctional
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Functional(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //Upload Single
        public async Task<string> UploadFiles(List<IFormFile> files, string UploadFolder)
        {
            var result = "";

            if (!Directory.Exists(UploadFolder.ToString()))
            {
                Directory.CreateDirectory(UploadFolder.ToString());
            }

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    //Get .txt, .jpg , ....
                    var extension = System.IO.Path.GetExtension(formFile.FileName);
                    //Create Name
                    var fileName = formFile.Name + extension;
                    var filePath = System.IO.Path.Combine(UploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    result = fileName;
                }
            }

            return result;
        }

        //Upload Multil
        public async Task<string> UploadFile(IFormFile file, string uploadFolder, string name)
        {
            //Create Folder
            var webRootFoderCreate = _hostingEnvironment.WebRootPath + uploadFolder;
            if (!Directory.Exists(webRootFoderCreate.ToString()))
            {
                Directory.CreateDirectory(webRootFoderCreate.ToString());
            }

            var directoryFile = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, uploadFolder);
            //Get .txt, .jpg , ....
            var extension = System.IO.Path.GetExtension(file.FileName);
            //Create Name
            var fileName = name + extension;

            //Create File to wwwroot
            var CreatefilePath = System.IO.Path.Combine(webRootFoderCreate, fileName);
            using (var stream = new FileStream(CreatefilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //Get Directory File to wwwroot
            var filePath = System.IO.Path.Combine(directoryFile, fileName);
            return filePath.Replace(@"\", @"/").ToString();
        }

        //Upload Allow Array
        public async Task<string[]> UploadFilesArray(List<IFormFile> files, IHostingEnvironment env, string uploadFolder, string name)
        {
            string[] result = new string[] { };
            var webRoot = env.WebRootPath;
            var uploads = System.IO.Path.Combine(webRoot, uploadFolder);
            if (!Directory.Exists(uploads.ToString()))
            {
                Directory.CreateDirectory(uploads.ToString());
            }
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    //Get .txt, .jpg , ....
                    var extension = System.IO.Path.GetExtension(formFile.FileName);
                    //Create Name
                    var fileName = name + extension;
                    var filePath = System.IO.Path.Combine(uploads, fileName);

                    //Send to Folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    result.Append(filePath);
                }
            }

            return result;
        }
    }
}