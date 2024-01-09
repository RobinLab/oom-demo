using MemoryOverflowGenerator.Services;

namespace MemoryOverflowGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hello world!");
            //OutOfMemoryTest();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddHostedService<OOMHostedService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        static void OutOfMemoryTest()
        {
            var list = new List<byte[]>();
            while (true)
            {
                try
                {
                    // 每次分配100MB的内存
                    list.Add(new byte[1 * 1024 * 1024 * 1024]);
                    list.Add(new byte[1 * 1024 * 1024 * 1024]);
                    list.Add(new byte[1 * 1024 * 1024 * 1024]);
                    Console.WriteLine("添加内存100M!");
                    Thread.Sleep(1000);
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine("内存已满!" + ex.Message);
                    break;
                }
            }
        }
    }
}
