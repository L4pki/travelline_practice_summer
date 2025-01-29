using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Theater1.Dto.CompositionDto;

namespace Theater1.Controllers;

[ApiController]
[Route( "Composition" )]
public class CompositionController : ControllerBase
{
    private readonly ICompositionRepositories _compositionRepositories;

    public CompositionController( ICompositionRepositories compositionRepositories )
    {
        _compositionRepositories = compositionRepositories;
    }

    [HttpPost( "" )]
    public IActionResult CreateComposition( [FromBody] CreateCompositionRequest request )
    {
        Composition newComposition = new Composition(
            request.Name,
            request.AboutComposition,
            request.AboutActor,
            request.IdAuthor );

        _compositionRepositories.Save( newComposition );

        return Ok( newComposition );
    }
}