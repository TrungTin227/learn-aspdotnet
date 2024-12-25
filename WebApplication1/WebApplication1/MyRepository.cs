namespace WebApplication1
{
    public class MyRepository : IRepository
    {
        private readonly ILogger<MyRepository> logger;

        public MyRepository(ILogger<MyRepository> logger)
        {
            this.logger = logger;
            logger.LogInformation("MyRepository created");
        }
        public string GetById(string id)
        {
            return $"The id is {id}";
        }
    }
}
