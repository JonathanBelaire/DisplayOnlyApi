using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using display_only_api.Tools;

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
    private readonly CancellationToken _token;
    private readonly string _contentType= "application/wasm";
    private readonly string _basePath = "assets/Build";

    public UnityController(ILogger<UnityController> logger)
    {
        _token = CancellationToken.None;
        _logger = logger;
    }

    private async Task<byte[]> ReadFileByPath(string path, bool decompress = false){
        var bytes = await System.IO.File.ReadAllBytesAsync(path, _token);
        if(decompress){
            using(Stream stream = new MemoryStream(bytes)){
                var decompressedBytes = await Utility.Decompress(stream);
                return decompressedBytes;
            }
        }
        return bytes;
        
    } 

    [HttpGet("data")]
    public async Task<IActionResult> GetData()
    {
        Stream stream = new MemoryStream(await ReadFileByPath($"{_basePath}/DisplayOnlyUnityWeb.data.gz", true));

        
        if(stream == null)
            return NotFound(); // returns a NotFoundResult with Status404NotFound response.

        //Response.Headers.ContentEncoding = "gzip";

        return File(stream, "application/data");
        //return File(stream, "application/octet-stream", "{{filename.ext}}"); 
        
    }

    [HttpGet("framework.js")]
    public async Task<IActionResult> GetFramework()
    {
        
        Stream stream = new MemoryStream(await ReadFileByPath($"{_basePath}/DisplayOnlyUnityWeb.framework.js.gz", true));

        if(stream == null)
            return NotFound(); // returns a NotFoundResult with Status404NotFound response.

        //Response.Headers.ContentEncoding = "gzip";

        return File(stream, "text/javascript");
    }

    [HttpGet("code.wasm")]
    public async Task<IActionResult> GetCode()
    {
        Stream stream = new MemoryStream(await ReadFileByPath($"{_basePath}/DisplayOnlyUnityWeb.wasm.gz", true));
        
        if(stream == null)
            return NotFound(); // returns a NotFoundResult with Status404NotFound response.
        //Response.Headers.ContentEncoding = "gzip";

        return File(stream, _contentType);
    }

    [HttpGet("loader.js")]
    public async Task<IActionResult> GetJS()
    {
        Stream stream = new MemoryStream(await ReadFileByPath($"{_basePath}/DisplayOnlyUnityWeb.loader.js"));

        
        if(stream == null)
            return NotFound(); // returns a NotFoundResult with Status404NotFound response.

        

        return File(stream, "text/javascript");
    }
}
