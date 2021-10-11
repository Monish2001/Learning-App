using System;

namespace Learning_App
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}