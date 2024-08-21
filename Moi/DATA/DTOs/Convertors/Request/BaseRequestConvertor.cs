using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GaragesStructure.DATA.DTOs.Convertors.Request;

public class BaseRequestConvertor
{
    
    public string key { get; set; }
    public string action { get; set; }
}