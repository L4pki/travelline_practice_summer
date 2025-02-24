﻿using Microsoft.AspNetCore.Mvc;
using Domain.Repositories;
using Domain.Entities;
using Theater1.Dto.TheaterDto;

namespace Theater1.Controllers;

[ApiController]
[Route( "Theaters" )]
public class TheaterController : ControllerBase
{
    private readonly ITheaterRepositories _theaterRepositories;

    public TheaterController( ITheaterRepositories theaterRepositories )
    {
        _theaterRepositories = theaterRepositories;
    }

    [HttpPost( "" )]
    public IActionResult CreateTheater( [FromBody] CreateTheaterRequest request )
    {
        if ( !ModelState.IsValid )
        {
            return BadRequest( ModelState );
        }

        Theater newTheater = new Theater(
            request.Name,
            request.Address,
            request.About,
            request.OpenSince,
            request.StartTime,
            request.EndTime,
            request.Phone );

        _theaterRepositories.Save( newTheater );

        return Ok( newTheater );
    }

    [HttpPut( "{id:int}" )]
    public IActionResult ModifyTheater( [FromRoute] int id, [FromBody] ModifyTheaterRequest request )
    {
        if ( !ModelState.IsValid )
        {
            return BadRequest( ModelState );
        }

        Theater theater = _theaterRepositories.GetById( id );
        if ( theater == null )
        {
            return NotFound();
        }

        theater.Name = request.Name;
        theater.About = request.About;
        theater.StartTime = request.StartTime;
        theater.EndTime = request.EndTime;
        theater.Phone = request.Phone;

        _theaterRepositories.Update( theater );

        return Ok( theater );
    }

    [HttpDelete( "{id:int}" )]
    public IActionResult DeleteTheater( int id )
    {
        var theater = _theaterRepositories.GetById( id );
        if ( theater == null )
        {
            return NotFound();
        }

        _theaterRepositories.Delete( id );

        return NoContent();
    }
}