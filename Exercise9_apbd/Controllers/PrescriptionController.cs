using Microsoft.AspNetCore.Mvc;
using Exercise9_apbd.DTOs;
using Exercise9_apbd.Services;

namespace Exercise9_apbd.Controllers;
using Exercise9_apbd.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPservice _prescriptionService;

    public PrescriptionController(IPservice prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _prescriptionService.CreatePrescriptionAsync(request);

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return CreatedAtAction(nameof(GetPrescription), new { id = result.PrescriptionId }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrescription(int id)
    {
        var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
        if (prescription == null)
            return NotFound();

        return Ok(prescription);
    }
}
