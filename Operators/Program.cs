using System.Collections;
namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet1 = new Wallet();
            wallet1 += new Money10(3);
            wallet1 += new Money50(2);
            wallet1 += new Money100(5);


            Console.WriteLine("Choose sorting:");
            Console.WriteLine("1 - Ascending");
            Console.WriteLine("2 - Descending");

            string input = Console.ReadLine();
            SortMode sortMode = SortMode.None;

            if (input == "1")
            {
                sortMode = SortMode.Ascending;
                
            }
            else if (input == "2")
            {
                sortMode = SortMode.Descending;
            }
            else
            {
                Console.WriteLine("Invalid input. No sorting applied.");
            }

            MoneyComparer comparer = new MoneyComparer(sortMode);
            wallet1.Sort(comparer);
            Console.WriteLine("result: ");
            Console.WriteLine(wallet1.Print());

            Console.WriteLine("Money in wallet:");
            foreach (int nominal in wallet1)
            {
                Console.WriteLine(nominal);
            }
            //==================ILIST======================
            IList wallet2 = new Wallet();

            wallet2.Add(new Money10(3));
            wallet2.Add(new Money50(4));
            wallet2.Add(new Money100(5));
            Console.WriteLine("Wallet2: ");
            PrintWallet(wallet2);

            wallet2.Insert(1, new Money50(10));
            Console.WriteLine("Wallet2 after insert: ");
            PrintWallet(wallet2);

            //Contains
            Console.WriteLine("Wallet2 contains Money100(5): " + wallet2.Contains(new Money100(5)));

            //IndexOf
            Console.WriteLine("Index of Money50(10) in Wallet2: " + wallet2.IndexOf(new Money50(10)));

            //Remove
            wallet2.Remove(new Money10(3));
            Console.WriteLine("Wallet2 after removing Money10(3): ");
            PrintWallet(wallet2);

            //RemoveAt
            wallet2.RemoveAt(0);
            Console.WriteLine("Wallet2 after removing at index 0: ");
            PrintWallet(wallet2);

            //IEnumerator
            Console.WriteLine("Iterating over Wallet2 using IEnumerator:");
            foreach (int nominal in wallet2)
            {
                Console.WriteLine(nominal);
            }

        }
        static void PrintWallet(IList wallet)
        {
            for (int i = 0; i < wallet.Count; i++)
            {
                Money money = (Money)wallet[i];
                Console.WriteLine(money.Nominal);
            }
        }
    }
}
