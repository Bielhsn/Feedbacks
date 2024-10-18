using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PredictionController : ControllerBase
{
    private readonly Model _model;

    public PredictionController(Model model)
    {
        _model = model;
    }

    [HttpPost]
    public IActionResult Predict([FromBody] ModelInput input)
    {
        var prediction = _model.Predict(input);
        return Ok(prediction);
    }
}