using System;

namespace Learning_App
{
    public interface IJwtAuth
    {
        string GenerateToken(int StudentId);
    }
}