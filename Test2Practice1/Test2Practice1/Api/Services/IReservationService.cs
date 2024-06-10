using Test2Practice1.Api.Models;

namespace Test2Practice1.Api.Services;

public interface IReservationService
{
    public Task<CustomerReservationsDTO> GetCustomerReservationsAsync(int idCustomer);
    
    public Task<int> CreateReservationAsync(ReservationCreationDTO reservationCreationDto);
}