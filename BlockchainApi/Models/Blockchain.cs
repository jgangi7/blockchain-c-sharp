using System.Collections.Generic;
using System.Linq;

namespace BlockchainApi.Models
{
    public class Blockchain
    {
        public List<Block> Chain { get; private set; }
        private int Difficulty = 2;

        public Blockchain()
        {
            Chain = new List<Block> { CreateGenesisBlock() };
        }

        private Block CreateGenesisBlock()
        {
            return new Block(0, "0", "Genesis Block");
        }

        public Block GetLatestBlock()
        {
            return Chain.Last();
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.MineBlock(Difficulty);
            Chain.Add(newBlock);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash()) return false;
                if (currentBlock.PreviousHash != previousBlock.Hash) return false;
            }
            return true;
        }
    }
} 