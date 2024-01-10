using MemoryOverflowGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflowGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutOfMemoryController : ControllerBase
    {

        /// <summary>
        /// Ôö¼ÓÄÚ´æ
        /// </summary>
        [HttpPost]
        public long AddMemory([FromBody] MemorySizeDto req)
        {
            //for (var i = 0; i < req.Times; i++)
            //    OOMHostedService.MEMORY.Add(new byte[req.Size]);
            OOMHostedService.Quests.Add(true);
            var sum = OOMHostedService.MEMORY.Select(m => m.LongLength).DefaultIfEmpty().Sum();
            return sum;
        }
    }

    public class MemorySizeDto
    {
        public bool On { get; set; }
    }
}
