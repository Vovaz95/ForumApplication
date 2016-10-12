using System;

namespace ForumApplication.Service
{
    public static class PasswordEncoder
    {
        public static string Encode(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = Convert.ToBase64String(data); ;

            return hash;
        }
    }
}