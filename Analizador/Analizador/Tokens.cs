using System;
namespace Analizador
{
    public class Tokens
    {
        public string type;
        public string value;

        public Tokens(string type, string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}