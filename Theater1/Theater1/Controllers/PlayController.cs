using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Theater1.Dto.PlayDto;
using Domain.Repositories;
using Infrastructure.Repositories;

namespace Theater1.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class PlaysController : ControllerBase
{
    private readonly IPlayRepositories _playRepository;

    public PlaysController( IPlayRepositories playRepository )
    {
        _playRepository = playRepository;
    }

    [HttpPost]
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

        _playRepository.Save( newPlay );

        return Ok( newPlay );
    }

    [HttpGet( "available" )]
    public IActionResult GetAvailablePlays( [FromQuery] DateTime startDate, [FromQuery] DateTime endDate )
    {
        try
        {
            var response = _playRepository.GetAvailablePlays( startDate, endDate );
            return Ok( response );
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
        catch ( FileNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
        catch ( Exception ex )
        {
            return StatusCode( 500, "Internal server error: " + ex.Message );
        }
    }
}