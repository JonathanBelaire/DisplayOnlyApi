using Microsoft.AspNetCore.Mvc;

namespace display_only_api.Controllers;

// dataUrl: buildUrl + "/DisplayOnlyUnityWeb.data.gz",
// frameworkUrl: buildUrl + "/DisplayOnlyUnityWeb.framework.js.gz",
// codeUrl: buildUrl + "/DisplayOnlyUnityWeb.wasm.gz",
// streamingAssetsUrl: "StreamingAssets",

[ApiController]
[Route("[controller]")]
public class UnityController : ControllerBase
{
    private readonly ILogger<UnityController> _logger;

    public UnityController(ILogger<UnityController> logger)
    {
        _logger = logger;
    }

    [HttpGet("data")]
    public async Task<IActionResult> GetData()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpGet("framework")]
    public async Task<IActionResult> GetFramework()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpGet("code")]
    public async Task<IActionResult> GetCode()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpGet("streamingData")]
    public async Task<IActionResult> GetStreamingData()
    {
        await Task.CompletedTask;
        return Ok();
    }
}
