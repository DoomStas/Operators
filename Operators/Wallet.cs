using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Wallet : IList
    {
        private Money[] _moneyArray;
        private int _count;

        public Wallet()
        {
            _moneyArray = new Money[10];
            _count = 0;
        }
         public Wallet(int capacity = 10)
         { 
            _moneyArray = new Money[capacity];
            _count = 0;
        }

        public Wallet (Money[] moneyArray)
        {
            _moneyArray = new Money[moneyArray.Length];
            for (int i = 0; i < moneyArray.Length; i++)
            {
                _moneyArray[i] = moneyArray[i];
            }
            _count = moneyArray.Length;

        }

        private void EnsureCapacity()
        {
            if (_count < _moneyArray.Length)
            {
                return;
            }
            
            Money[] newArray = new Money[_moneyArray.Length * 2];
            for (int i = 0; i < _moneyArray.Length; i++)
            {
                newArray[i] = _moneyArray[i];
            }
            _moneyArray = newArray;
            
        }
        // ++++++++++++++++++ILIST+++++++++++++++++++++

        public int Add(object value)
        {
            EnsureCapacity();
            _moneyArray[_count] = (Money)value;
            _count++;
            return _count - 1;
        }

        public void Insert(int index, object value)
        {
            EnsureCapacity();
            for (int i = _count; i > index; i--)
            {
                _moneyArray[i] = _moneyArray[i - 1];
            }
            _moneyArray[index] = (Money)value;
            _count++;
        }

        public void Remove(object value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _moneyArray[i] = _moneyArray[i + 1];
            }
            _moneyArray[_count - 1] = null;
            _count--;
        }

        public bool Contains(object value)
        {
            return IndexOf(value) >= 0;
        }

        public int IndexOf(object value)
        {
            if (value is not Money)
            { 
                return -1;
            }
            for (int i = 0; i < _count; i++)
            {
                if (_moneyArray[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public object this[int index]
        {
            get { return _moneyArray[index]; }
            set { _moneyArray[index] = (Money)value; }
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _moneyArray[i] = null;
            }
            _count = 0;
        }

        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < _count; i++)
            {
                array.SetValue(_moneyArray[i], index + i);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new WalletEnumerator(_moneyArray, _count);
        }


        public bool IsFixedSize => false;
        public bool IsReadOnly => false;
        public int Count => _count;
        public bool IsSynchronized => false;
        public object SyncRoot => this;
        // ++++++++++++++++++ILIST+++++++++++++++++++++


        public static Wallet operator +(Wallet wallet, Money money)
        {
            for (int i = 0; i < wallet._count; i++)
            {
                if (wallet._moneyArray[i].GetType() == money.GetType())
                {
                    wallet._moneyArray[i] += money;
                    return wallet;
                }
            }

            wallet.EnsureCapacity();

            wallet._moneyArray[wallet._count] = money;
            wallet._count++;
            return wallet;

        }

        public static Wallet operator +(Wallet a, Wallet b)
        {
            Wallet result = new Wallet(a._count + b._count);

            for (int i = 0; i < a._count; i++)
            {
                result += a._moneyArray[i];
            }
            for (int i = 0; i < b._count; i++)
            {
                result += b._moneyArray[i];
            }
            return result;
        }

        public void Sort(IComparer comparer)
        { 
            
            Array.Sort(_moneyArray, 0, _count, comparer);

        }

        public string Print()
        { 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _count; i++)
            {
                for (int j = 0; j < _moneyArray[i].Count; j++)
                {
                    sb.AppendLine(_moneyArray[i].Nominal.ToString());
                }
            }
            return sb.ToString();
        }
        public int GetTotal()
        {
            int sum = 0;
            for (int i = 0; i < _count; i++)
            {
                sum += _moneyArray[i].Total;
            }
            return sum;
        }

        public static bool operator >(Wallet a, Wallet b)
        {
            return a.GetTotal() > b.GetTotal();
        }
        public static bool operator <(Wallet a, Wallet b)
        {
            return a.GetTotal() < b.GetTotal();
        }

   
    }
}
