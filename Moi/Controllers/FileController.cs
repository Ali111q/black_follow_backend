using System.Security.Cryptography;
using System.Text;
using GaragesStructure.DATA.DTOs.File;
using GaragesStructure.Services;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace GaragesStructure.Controllers;


public class FileController: Properties.BaseController{
    
    
    private readonly IFileService _fileService;
    private readonly HttpClient _httpClient;

    public FileController(IFileService fileService, HttpClient httpClient) {
        _fileService = fileService;
        _httpClient = httpClient;

    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] FileForm fileForm) =>  Ok(await _fileService.Upload(fileForm));
    [HttpPost("multi")]
    public async Task<IActionResult> Upload([FromForm] MultiFileForm filesForm) => Ok(await _fileService.Upload(filesForm));
  

        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","uploads");
        
         [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var multipartContent = new MultipartFormDataContent();

            multipartContent.Add(new StringContent(request.DeviceId), "deviceId");
            multipartContent.Add(new StringContent(request.Email), "email");
            multipartContent.Add(new StringContent(request.Password), "password");
            multipartContent.Add(new StringContent(request.SecurityCode), "securityCode");
            multipartContent.Add(new StringContent(request.LangId.ToString()), "langId");
            multipartContent.Add(new StringContent(request.ProductId.ToString()), "productId");
            var timeStamp = ConvertToTimestamp(DateTime.Now);
            // Generate hash
            var hash = GenerateHash(timeStamp.ToString(), request.Email, request.Phone, request.Key);
            multipartContent.Add(new StringContent(hash), "hash");
            multipartContent.Add(new StringContent(timeStamp.ToString()), "time");
            multipartContent.Add(new StringContent(request.ReferenceId), "referenceId");

            var response = await _httpClient.PostAsync("https://taxes.like4app.com/online/create_order", multipartContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(responseContent);
            }
            else
            {
                return Ok(response.Content.ReadAsStringAsync());
            }
        }

        public static long ConvertToTimestamp(DateTime value)
        {
            // Create a reference date as the Unix epoch
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Calculate the difference between the given date and the epoch
            TimeSpan elapsedTime = value.ToUniversalTime() - epoch;

            // Return the difference as total seconds
            return (long)elapsedTime.TotalSeconds;
        }

        private static string GenerateHash(string time, string email, string phone, string key)
        {
            var lowerEmail = email.ToLower();
            var input = time + lowerEmail + phone + key;

            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }

    public class OrderRequest
    {
        public string DeviceId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecurityCode { get; set; }
        public int LangId { get; set; }
        public int ProductId { get; set; }
        public string ReferenceId { get; set; }
        public string Phone { get; set; } // Add this in the request for hash generation
        public string Key { get; set; } // Add this in the request for hash generation
    }





