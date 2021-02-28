using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _3ak3ekCoin
{
    public class Block
    {
        private readonly DateTime _time;
        public string prev = string.Empty;
        public string hash;
        private readonly IList<Transaction> _trasactions = new List<Transaction>();
        private readonly int _index;
        private int _nonse;
        public Block() { }

        public Block(IList<Transaction> trasactions, DateTime time, int index)
        {
            _time = time;
            _trasactions = trasactions;
            _index = index;
            hash = CalculateHash();

        }

        public void MineBlock(int difficulty)
        {
            var arr = new string[difficulty];
            for (int i = 0; i < difficulty; i++)
            {
                arr[i] = i.ToString();
            }

            var hashPuzzle = string.Join("", arr);
            while (string.Join("", hash.Skip(0).Take(difficulty)) != hashPuzzle)
            {
                _nonse += 1;
                hash = CalculateHash();
#if DEBUG
                System.Console.WriteLine("Nonse : " + _nonse);
                System.Console.WriteLine("hash attempt : " + hash);
                System.Console.WriteLine("hash we want start with : " + hashPuzzle);
#endif
            }

        }

        private string CalculateHash()
        {
            var transactionHashBuilder = new StringBuilder();
            foreach (var trasaction in _trasactions)
            {
                transactionHashBuilder.Append(trasaction.hash);
            }

            var str = _time.ToString() + transactionHashBuilder.ToString() + prev + _index.ToString() + _nonse.ToString();
            return Helper.ComputeSha256Hash(str);
        }
    }

}
