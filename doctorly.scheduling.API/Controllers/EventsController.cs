using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace doctorly.scheduling.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(policy: "AdminOnly")]
public class EventsController : ControllerBase
{
    [HttpGet(Name = "GetAllEvents")]
    public IEnumerable<WeatherForecast> Get()
    {
        throw new NotImplementedException();
    }

}
