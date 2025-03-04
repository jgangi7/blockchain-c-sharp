using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace BlockchainApi.Models
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }
        public int Nonce { get; set; }

        public Block(int index, string previousHash, string data)
        {
            Index = index;
            Timestamp = DateTime.UtcNow;
            PreviousHash = previousHash;
            Data = data;
            Nonce = 0;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            string rawData = $"{Index}{Timestamp}{PreviousHash}{Data}{Nonce}";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public void MineBlock(int difficulty)
        {
            string target = new string('0', difficulty);
            while (!Hash.StartsWith(target))
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
} 