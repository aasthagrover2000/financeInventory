using financeInventoryProject.Service;
using financeInventoryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace financeInventoryProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceInventoryController : ControllerBase
{

    private readonly IFinanceService financeService;
    public FinanceInventoryController(IFinanceService financeService) => this.financeService = financeService;

    [HttpGet]
    public async Task<List<FinanceInventory>> Get()
    {
        return await financeService.FinanceInventoryAsync();
    }

    [HttpGet("{financeId:Length(24)}")]
    public async Task<ActionResult<FinanceInventory>> Get(string financeId)
    {
        var financeInventory_x = await financeService.GetFinanceDetailsByIdAsync(financeId);
        if(financeInventory_x is null)
        {
            return NotFound();
        }
        return financeInventory_x;
    }

    [HttpPost]
    public async Task<ActionResult<FinanceInventory>> Post(FinanceInventory financeInventory)
    {
        await financeService.AddFinanceItemAsync(financeInventory);
        return CreatedAtAction(nameof(Get), new { Id = financeInventory.Id }, financeInventory);
    }

    [HttpPut("{financeId:Length(24)}")]
    public async Task<ActionResult<FinanceInventory>> Update(string financeId, FinanceInventory financeInventory)
    {
        var financeInventory_x = await financeService.GetFinanceDetailsByIdAsync(financeId);
        if (financeInventory_x is null)
        {
            return NotFound();
        }
        await financeService.UpdateFinanceItemAsync(financeId, financeInventory);
        return Ok();
    }

    [HttpDelete("{financeId:Length(24)}")]
    public async Task<ActionResult<FinanceInventory>> Delete(string financeId)
    {
        var financeInventory_x = await financeService.GetFinanceDetailsByIdAsync(financeId);
        if (financeInventory_x is null)
        {
            return NotFound();
        }
        await financeService.DeleteFinanceItemAsync(financeId);
        return Ok();
    }

    
}

