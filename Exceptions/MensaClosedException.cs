using System;

namespace WhatTheFuckShouldLukasHaveForLunch.Exceptions
{
    public class MensaClosedException : Exception
    {
        public MensaClosedException(string message): base(message)
        {
            
        }
    }
}
