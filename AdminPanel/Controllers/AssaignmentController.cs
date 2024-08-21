using AdminPanel.DTO.Task;
using AdminPanel.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class AssaignmentController: ControllerBase
{
    private readonly IAssaignmentService _assaignmentService;

    public AssaignmentController(IAssaignmentService assaignmentService)
    {
        _assaignmentService = assaignmentService;
    }

    [HttpGet("GetAllAssaignments")]
    public async Task<IActionResult> GetAllAssaignments()
    {
        var result = await _assaignmentService.GetAllAssaignmentsAsync();
        return Ok(result);
    }

    [HttpGet("GetAssaignmentById")]
    public async Task<IActionResult> GetAssaignmentById(int Id)
    {
        var result = await _assaignmentService.GetAssaignmentByIdAsync(Id);
        
        if (result is not null) { return Ok(result); }
        
        return NotFound();
        
    }

    [HttpPost("AddAssaignment")]
    public async Task<IActionResult> AddAssaignment(WriteAssaignment writeAssaignment)
    {
        var result = await _assaignmentService.AddAssaignmentAsync(writeAssaignment);

        if (result is not null)
            return Ok(result);

        return BadRequest();
    }

    [HttpPost("UpdateAssaignment")]
    public async Task<IActionResult> UpdateAssaignment(int id,WriteAssaignment writeAssaignment)
    {
        var result = await _assaignmentService.UpdateAssaignmentAsync(id,writeAssaignment);

        if (result is not null) { return Ok(result); }

        return BadRequest();
    }

    [HttpDelete("DeleteAssaignment")]
    public async Task<IActionResult> DeleteAssaignment(int id)
    {
        var result = await _assaignmentService.DeleteAssaignmentAsync(id);

        if (result is not null) { return Ok(result); }

        return BadRequest();
    }

}