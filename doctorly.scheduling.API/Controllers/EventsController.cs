
using doctorly.scheduling.Domain.Aggregates;

namespace doctorly.scheduling.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(policy: "AdminOnly")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    [HttpGet(Name = "GetAllEvents")]
    public IEnumerable<WeatherForecast> Get()
    {
        throw new NotImplementedException();
    }

    // Create event
    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(string title, string description, DateTime startTime, DateTime endTime)
    {
        var newEvent = await _eventService.CreateEventAsync(title, description, startTime, endTime);
        return CreatedAtAction(nameof(GetEvent), new { id = newEvent.Id }, newEvent);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var @event = await _eventService.GetEventAsync(id);
        if (@event == null)
        {
            return NotFound();
        }
        return @event;
    }
}
