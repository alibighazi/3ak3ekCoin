using System.Collections.Generic;

namespace _3ak3ekCoin
{
    class Program
    {

        static void Main(string[] args)
        {

            var blockChain = new BlockChain();

            blockChain.PendingTransactions.Add(new Transaction("ghazi", "kamel", 20));

            blockChain.MinePendingTransaction();

            var output = blockChain.Chain;


        }
    }

}
