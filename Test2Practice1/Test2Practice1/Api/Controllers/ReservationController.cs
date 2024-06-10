using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Test2Practice1.Api.Models;
using Test2Practice1.Api.Services;


namespace Test2Practice1.Api.Controllers;

[ApiController]
[Route("api/reservation")]
public class ReservationController : ControllerBase
{
    private IReservationService _reservationService;
    
    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    /// <summary>
    /// Endpoints used to .
    /// </summary>
    /// <returns>...</returns>
    /// HttpGet - Get data
    /// HttpPost - Add data
    /// HttpPut - Update Data
    /// HttpDelete - Selete Data

    [HttpGet("/customer/{idCustomer:int}")]
    public async Task<IActionResult> GetCustomerReservationsAsync(int idCustomer)
    {
        var a = await _reservationService.GetCustomerReservationsAsync(idCustomer);
        return Ok(a);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReservationAsync(ReservationCreationDTO reservationCreationDto)
    {
        var a = await _reservationService.CreateReservationAsync(reservationCreationDto);
        return Ok($"Reservation Created with ID : {a}");
    }

}