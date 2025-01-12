using System.Text.Json.Serialization;
using myportfolio.Models;

public class LoginResponse
{
    public string message { get; set; } 
    public string Token { get; set; }
    public User User { get; set; }

    [JsonIgnore]
    public bool Succes { get; set; }
   
}