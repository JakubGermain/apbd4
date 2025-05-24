using Exercise9_apbd.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercise9_apbd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPservice _service;

    public PatientController(IPservice service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var result = await _service.GetPrescriptionByIdAsync(id);
        if (result == null)
            return NotFound($"Patient with id {id} not found.");

        return Ok(result);
    }
}