using GaragesStructure.DATA.DTOs.File;
using GaragesStructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GaragesStructure.Controllers;


public class FileController: Properties.BaseController{
    
    
    private readonly IFileService _fileService;

    public FileController(IFileService fileService) {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] FileForm fileForm) =>  Ok(await _fileService.Upload(fileForm));
    [HttpPost("multi")]
    public async Task<IActionResult> Upload([FromForm] MultiFileForm filesForm) => Ok(await _fileService.Upload(filesForm));
  

        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","uploads");
        [HttpPost("upload-chunks")]
        public async Task<IActionResult> UploadChunk(IFormFile chunk, [FromForm] int chunkNumber,[FromForm] int totalChunks,[FromForm] string fileName)
        {
            if (chunk == null || chunk.Length == 0)
            {
                return BadRequest("No chunk uploaded.");
            }

            string filePath = Path.Combine(_uploadFolder, fileName);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }

            // Append the chunk to the file
            using (var stream = new FileStream(filePath, chunkNumber == 0 ? FileMode.Create : FileMode.Append))
            {
                await chunk.CopyToAsync(stream);
            }

            // Check if all chunks have been uploaded
            if (chunkNumber == totalChunks - 1)
            {
                // All chunks uploaded, handle post-upload logic here if needed
                return Ok(new
                {
                    path="uploads/" + fileName
                });
            }

            return Ok(new { message = "Chunk uploaded successfully." });
        }
    }



