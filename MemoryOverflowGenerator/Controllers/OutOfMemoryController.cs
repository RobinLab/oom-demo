using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflowGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutOfMemoryController : ControllerBase
    {
        private static List<byte[]> _memory = new List<byte[]>();

        /// <summary>
        /// Ôö¼ÓÄÚ´æ
        /// </summary>
        [HttpPost]
        public long AddMemory([FromBody] MemorySizeDto req)
        {
            for (var i = 0; i < req.Times; i++)
                _memory.Add(new byte[req.Size]);
            var sum = _memory.Select(m => m.LongLength).DefaultIfEmpty().Sum();
            return sum;
        }
    }

    public class MemorySizeDto
    {
        public int Size { get; set; }
        public int Times { get; set; }
    }
}
