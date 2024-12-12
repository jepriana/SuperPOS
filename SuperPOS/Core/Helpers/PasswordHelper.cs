﻿using System.Security.Cryptography;
using System.Text;

namespace SuperPOS.Core.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string plainPassword, string hashPassword)
        {
            return hashPassword.Equals(HashPassword(plainPassword));
        }
    }
}