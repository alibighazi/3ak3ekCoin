using System;
using System.Linq;
using System.Collections.Generic;

namespace _3ak3ekCoin
{
    public class BlockChain
    {
        public IList<Block> Chain = new List<Block>();
        public IList<Transaction> PendingTransactions = new List<Transaction>();
        private readonly int _difficulty = 3;
        private readonly int _blockRewards = 50;
        private readonly int _blockSize = 10;

        public Block GetLastBlock()
        {
            return Chain.Count > 0 ? Chain.Last() : new Block();
        }

        public void AddBlock(Block block)
        {
            if (Chain.Count > 0)
            {
                block.prev = GetLastBlock().hash;
            }
            else
            {
                block.prev = "none";
            }

            Chain.Add(block);
        }

        public void MinePendingTransaction()
        {
            var len = PendingTransactions.Count;

            for (int i = 0; i < len; i += _blockSize)
            {
                var end = i + _blockSize;
                if (i >= len) end = len;

                var transactionSlice = PendingTransactions.Skip(i).Take(end).ToList();
                var newBlock = new Block(transactionSlice, DateTime.Now, Chain.Count);
                var hashVal = GetLastBlock().hash;
                newBlock.prev = hashVal;
                newBlock.MineBlock(_difficulty);
                Chain.Add(newBlock);

            }
        }

    }

}
