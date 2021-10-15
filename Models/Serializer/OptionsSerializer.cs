using System.Collections.Generic;

public class Option{
    public int Id { get; set; }
    public int QuestionId {get; set;}
    public string OptionValue { get; set; }
}

public class OptionResponse
    {
        public List<Option> Options = new List<Option>();
    }