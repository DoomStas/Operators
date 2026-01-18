using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Operators
{
    public class WalletEnumerator : IEnumerator
    {
        private Money[] _moneyArray;
        private int _walletCount;

        private int _PackageIndex = 0;
        private int _MoneyIndex = -1;

        public WalletEnumerator(Money[] moneyArray, int walletCount)
        {
            _moneyArray = moneyArray;
            _walletCount = walletCount;
        }

        public object Current
        {
            get
            {
               
                return _moneyArray[_PackageIndex].Nominal;
            }
        }
        public bool MoveNext()
        {
         
            if (_PackageIndex >= _walletCount)
            {
                return false;
            }
            _MoneyIndex ++;

            if (_MoneyIndex >= _moneyArray[_PackageIndex].Count)
            {
                _PackageIndex++;
                _MoneyIndex = 0;
                if (_PackageIndex >= _walletCount)
                {
                    return false;
                }
                if (_moneyArray[_PackageIndex].Count == 0)
                { 
                    _MoneyIndex = -1;
                    return MoveNext();
                }
            }

            return true;
        }
        public void Reset()
        {
            _MoneyIndex = -1;
            _PackageIndex = 0;
        }




    }
}
