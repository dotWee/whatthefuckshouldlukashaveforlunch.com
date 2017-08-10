using System;
namespace whatthefuckshouldlukashaveforlunch.com.Models.Exceptions
{
    public class MensaClosedException : Exception
    {
        public MensaClosedException(string message): base(message)
        {
            
        }
    }
}
