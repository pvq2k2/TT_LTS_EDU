﻿namespace TT_LTS_EDU.Handle.Request.AuthRequest
{
    public class ResetPasswordRequest
    {
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
