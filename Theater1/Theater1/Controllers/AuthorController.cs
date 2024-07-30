using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Theater1.Dto.AuthorDto;
using Theater1.Dto.PlayDto;

namespace Theater1.Controllers;

[ApiController]
[Route( "Author" )]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepositories _authorRepositories;

    public AuthorController( IAuthorRepositories authorRepositories )
    {
        _authorRepositories = authorRepositories;
    }

    [HttpPost( "" )]
    public IActionResult CreateAuthor( [FromBody] CreateAuthorRequest request )
    {
        Author newAuthor = new Author(
            request.Name,
            request.DateOfBorth );

        _authorRepositories.Save( newAuthor );

        return Ok( newAuthor );
    }
    [HttpGet( "" )]
    public IActionResult GetAll()
    {
        return Ok( _authorRepositories.GetAll() );
    }
}