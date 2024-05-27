using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected readonly ISender Sender;

    public BaseController(ISender sender)
    {
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
    }
}