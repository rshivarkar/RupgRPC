using Microsoft.AspNetCore.Mvc;
using RupgRPCServer;

namespace RupgRPCClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Greeter.GreeterClient _greeterClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            Greeter.GreeterClient greeterClient)
        {
            _logger = logger;
            _greeterClient = greeterClient;
        }

        [HttpGet(Name = "CallGrpcService")]
        public string Get(CancellationToken cancellationToken)
        {
            var result = _greeterClient.SayHello(new HelloRequest { Name = Faker.StringFaker.Alpha(5) }, null, null, cancellationToken);
            return result.Message;
        }
    }
}