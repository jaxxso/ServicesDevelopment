using System;

namespace WebDev.services
{
    public class UsersService
    {
        private string BaseUrl { get; }

        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
