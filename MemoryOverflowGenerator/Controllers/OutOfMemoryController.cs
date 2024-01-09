using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflowGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutOfMemoryController : ControllerBase
    {
        private static List<byte[]> _memory = new List<byte[]>();
        private readonly ILogger<WeatherForecastController> _logger;

        private const int LENGTH = 1 * 1024 * 1024 * 1024;
        private const int COUNT = 5;
        public OutOfMemoryController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public long AddMemory()
        {
            for(var i = 0; i < COUNT; i++)
                _memory.Add(new byte[LENGTH]);
            var sum = _memory.Select(m => m.LongLength).DefaultIfEmpty().Sum();
            return sum;
        }
    }
}
