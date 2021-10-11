using System;

namespace Learning_App
{
    public interface IJwtAuth
    {
        string Authentication(string mobileno, int otp);
    }
}