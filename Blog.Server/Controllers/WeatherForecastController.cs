using Blog.Server.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMongoClient _mongoClient;
        private IMongoCollection<Comments> _commentsCollection;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMongoClient client)
        {
            _logger = logger;
            _mongoClient = client;
            var database = client.GetDatabase("blog");
            _commentsCollection = database.GetCollection<Comments>("comment"); 
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Comments> Get()
        {
            return _commentsCollection.Find(c=>c.Email != null).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comments model)
        {
            try
            {
                Console.WriteLine(model.Name);
                return Ok(_commentsCollection.InsertOneAsync(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
        }
    }
}
