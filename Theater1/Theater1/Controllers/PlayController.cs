using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Theater1.Dto.PlayDto;

namespace Theater1.Controllers;

[ApiController]
[Route( "Play" )]
public class PlayController : ControllerBase
{
    private readonly IPlayRepositories _playRepositories;

    public PlayController( IPlayRepositories playRepositories )
    {
        _playRepositories = playRepositories;
    }

    [HttpPost( "" )]
    public IActionResult CreatePlay( [FromBody] CreatePlayRequest request )
    {
        Play newPlay = new Play(
            request.Name,
            request.StartDate,
            request.EndDate,
            request.TicketPrice,
            request.About,
            request.IdTheater,
            request.IdComposition );

        _playRepositories.Save( newPlay );

        return Ok( newPlay );
    }
    [HttpGet( "ByPeriod" )]
    public IActionResult GetByPeriod( [FromQuery] DateTime startDate, [FromQuery] DateTime endDate )
    {
        return Ok( _playRepositories.GetByPeriod( startDate, endDate ) );
    }
}