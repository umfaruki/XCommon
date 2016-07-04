﻿using System;

namespace XCommon.Application.Login
{
    public class SignUpExternalEntity
    {
        public UserProvider Provider { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UrlImage { get; set; }

        public string UrlCover { get; set; }

        public string UrlProfile { get; set; }

        public string Language { get; set; }

        public bool Male { get; set; }

        public string Token { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}