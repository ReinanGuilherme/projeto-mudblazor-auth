﻿namespace MudblazorAuth.Communication.Requests
{
    public class RequestAccountRegister
    {
        public string  Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public long IdProfile { get; set; }
    }
}
