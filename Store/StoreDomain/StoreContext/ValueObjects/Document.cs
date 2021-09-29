using System;

namespace StoreDomain.StoreContext.ValueObjects
{
    public class Document
    {
        public Document(string number)
        {
            number = number;
        }
        public string Number { get; private set; }

        public override string ToString()
        {
            return $"{Number}";
        }
    }
}