using System;
using System.Collections.Generic;
using System.Text;

namespace GreatQuotes.Data
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
