using System;

namespace Learning_App.Utils{
    public class RandomNumber{
        public int GenerateRandomNo()
        {

        int _min = 1000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
        }
    }
    
}
