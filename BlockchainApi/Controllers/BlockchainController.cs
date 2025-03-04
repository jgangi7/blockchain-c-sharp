using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlockchainApi.Models;

namespace BlockchainApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlockchainController : ControllerBase
    {
        private static Blockchain blockchain = new Blockchain();

        [HttpGet("blocks")]
        public ActionResult<List<Block>> GetBlockchain()
        {
            return blockchain.Chain;
        }

        [HttpPost("mine")]
        public ActionResult<string> MineBlock([FromBody] string data)
        {
            Block newBlock = new Block(blockchain.Chain.Count, blockchain.GetLatestBlock().Hash, data);
            blockchain.AddBlock(newBlock);
            return "Block successfully mined!";
        }

        [HttpGet("validate")]
        public ActionResult<string> ValidateChain()
        {
            return blockchain.IsChainValid() ? "Blockchain is valid!" : "Blockchain is NOT valid!";
        }
    }
} 