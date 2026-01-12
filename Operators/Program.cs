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

            if (input == "1")
            {
                wallet1.Sort(SortMode.Ascending);
            }
            else if (input == "2")
            {
                wallet1.Sort(SortMode.Descending);
            }
            else
            {
                Console.WriteLine("Invalid input. No sorting applied.");
            }

            
            Console.WriteLine("result: ");
            Console.WriteLine(wallet1.Print());


        }
    }
}
