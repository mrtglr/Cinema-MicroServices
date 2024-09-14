﻿namespace Cinema.Services.AuthAPI.Application.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpire { get; set; }
    }
}
