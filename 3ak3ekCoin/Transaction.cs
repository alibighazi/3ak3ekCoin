using System;
using System.Collections.Generic;
using System.Text;

namespace _3ak3ekCoin
{
    public class Transaction
    {
        private readonly string _sender;
        private readonly string _reciver;
        public readonly string hash;
        private readonly DateTime _time;
        private readonly double _amt;

        public Transaction(string sender, string reciver, double amt)
        {
            _time = new DateTime();
            _sender = sender;
            _reciver = reciver;
            _amt = amt;
            hash = CalculateHash();

        }

        private string CalculateHash()
        {
            var str = _sender + _reciver + _amt.ToString() + _time.ToString();
            return Helper.ComputeSha256Hash(str);
        }
    }

}
