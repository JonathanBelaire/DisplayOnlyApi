using Microsoft.AspNetCore.Mvc;

namespace display_only_api.Controllers;

// dataUrl: buildUrl + "/DisplayOnlyAboutWeb.data.gz",
// frameworkUrl: buildUrl + "/DisplayOnlyAboutWeb.framework.js.gz",
// codeUrl: buildUrl + "/DisplayOnlyAboutWeb.wasm.gz",
// streamingAssetsUrl: "StreamingAssets",

[ApiController]
[Route("[controller]")]
public class AboutController : ControllerBase
{
    private readonly ILogger<AboutController> _logger;

    public AboutController(ILogger<AboutController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;
        return Ok();
    }

   
}
