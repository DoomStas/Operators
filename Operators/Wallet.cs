using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Wallet
    {
        private Money[] moneyArray = new Money[0];

        public static Wallet operator +(Wallet wallet, Money money)
        {
            for (int i = 0; i < wallet.moneyArray.Length; i++)
            {
                if (wallet.moneyArray[i].GetType() == money.GetType())
                {
                    wallet.moneyArray[i] += money;
                    return wallet;
                }
            }

            Money[] newArray = new Money[wallet.moneyArray.Length + 1];
            for (int i = 0; i < wallet.moneyArray.Length; i++)
            {
                newArray[i] = wallet.moneyArray[i];
            }
            newArray[newArray.Length - 1] = money;
            wallet.moneyArray = newArray;
            return wallet;
        }

        public static Wallet operator +(Wallet a, Wallet b)
        {
            Wallet result = new Wallet();
            for (int i = 0; i < a.moneyArray.Length; i++)
            {
                result += a.moneyArray[i];
            }
            for (int i = 0; i < b.moneyArray.Length; i++)
            {
                result += b.moneyArray[i];
            }
            return result;
        }
        public int GetTotal()
        {
            int sum = 0;
            for (int i = 0; i < moneyArray.Length; i++)
            {
                sum += moneyArray[i].Total;
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
