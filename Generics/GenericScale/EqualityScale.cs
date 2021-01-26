using System;

namespace GenericScale
{
    public class EqualityScale<T> 
    {
        private T elementOne;
        private T elementTwo;

        public EqualityScale(T elementOne, T elementTwo)
        {
            this.elementOne = elementOne;
            this.elementTwo = elementTwo;
        }

        public bool AreEqual()
        {
            return elementOne.Equals(elementTwo);
        }
    }
}
 