﻿
using System.Text.Json.Serialization;

namespace Restaurant.Core.Application.Dtos.Account
{
    public class AuthenticationResponse : BaseResponse
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? JWToken { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
    }
}
