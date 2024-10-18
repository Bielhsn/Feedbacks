using Microsoft.AspNetCore.Mvc;

public class SomeController : ControllerBase
{
    private readonly ExternalApiService _externalApiService;

    public SomeController(ExternalApiService externalApiService)
    {
        _externalApiService = externalApiService;
    }

    [HttpGet("external-data")]
    public async Task<IActionResult> GetExternalData()
    {
        var data = await _externalApiService.GetDataFromExternalApiAsync("/data-endpoint");
        return Ok(data);
    }
}
