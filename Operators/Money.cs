using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public abstract class Money : IComparable<Money>
    {
        public int Nominal { get; }
        public int Count { get; }
        public int Total
        { 
            get
            {
                return Nominal * Count;
            }
        }
        public Money(int nominal, int count) 
        { 
            Nominal = nominal;
            Count = count;
        }

        public int CompareTo(Money other)
        { 

            return Total.CompareTo(other.Total);
        }

        public static Money operator +(Money a, Money b)
        { 
        if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot add different types of Money.");
            }
            return a.CreateNew(a.Count + b.Count);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot subtract different types of Money.");
            }
            if (a.Count < b.Count)
            {
                throw new InvalidOperationException("Resulting count cannot be negative.");
            }
            return a.CreateNew(a.Count - b.Count);
        }
        public static Money operator *(Money a, int multiplier)
        {
            if (multiplier < 0)
            {
                throw new InvalidOperationException("Multiplier cannot be negative.");
            }
            return a.CreateNew(a.Count * multiplier);
        }

        public static bool operator >(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot compare different types of Money.");
            }
            return a.Total > b.Total;
        }
        public static bool operator <(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot compare different types of Money.");
            }
            return a.Total < b.Total;
        }
        public static bool operator >=(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot compare different types of Money.");
            }
            return a.Total >= b.Total;
        }
        public static bool operator <=(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot compare different types of Money.");
            }
            return a.Total <= b.Total;
        }
        public static bool operator ==(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                return false;
            }
            return a.Total == b.Total;
        }
        public static bool operator !=(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new InvalidOperationException("Cannot compare different types of Money.");
            }
            return a.Total != b.Total;
        }
        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return Total == other.Total;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Total.GetHashCode();
        }
        protected abstract Money CreateNew(int count);

 
    }
}
