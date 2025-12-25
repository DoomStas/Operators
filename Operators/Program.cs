namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet1 = new Wallet();
            wallet1 += new Money10(3);
            wallet1 += new Money50(2);

            Wallet wallet2 = new Wallet();
            wallet2 += new Money20(1);
            wallet2 += new Money100(1);

            Console.WriteLine($"Wallet 1 Total: {wallet1.GetTotal()}");
            Console.WriteLine($"Wallet 2 Total: {wallet2.GetTotal()}");

            if (wallet1 > wallet2)
            {
                Console.WriteLine("Wallet 1 has more money than Wallet 2.");
            }
            else
            {
                Console.WriteLine("Wallet 2 has more money than Wallet 1.");
            }

        }
    }
}
