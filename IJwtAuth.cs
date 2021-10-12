using System;

namespace Learning_App
{
    public interface IJwtAuth
    {
        string GenerateToken(string mobileno, int otp);
    }
}