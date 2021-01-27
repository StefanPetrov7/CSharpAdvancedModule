using System;
using System.Collections.Generic;

namespace Generic_Box_of_String
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public T Value => this.value;

        public override string ToString()
        {
            return $"{this.value.GetType()}: {value}";
        }

    }
}

