using Test2Practice1.Api.Errors;
using Test2Practice1.Api.Models;
using Test2Practice1.Api.Repositories;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Services;

public class ReservationService : IReservationService
{
    private IReservationsRepository _reservationsRepository;
    private IClientsRepository _clientsRepository;
    private ISailboatRepository _sailboatRepository;
    private IBoatStandardRepository _boatStandardRepository;
    private IUnitOfWork _unitOfWork;

    public ReservationService(IReservationsRepository reservationsRepository, IClientsRepository clientsRepository, ISailboatRepository sailboatRepository, IBoatStandardRepository boatStandardRepository, IUnitOfWork unitOfWork)
    {
        _reservationsRepository = reservationsRepository;
        _clientsRepository = clientsRepository;
        _sailboatRepository = sailboatRepository;
        _boatStandardRepository = boatStandardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerReservationsDTO> GetCustomerReservationsAsync(int idCustomer)
    {
        var client = await _clientsRepository.GetClientAsync(idCustomer);
        EnsureclientExists(client);
        var reservations = await _reservationsRepository.GetCusotmerReservationsAsync(idCustomer);
        
        return new CustomerReservationsDTO()
        {
            Name = client.Name,
            LastName = client.LastName,
            Birthday = client.Birthday,
            Email = client.Email,
            Pesel = client.Pesel,
            Reservations = reservations
        };
    }
    

    public async Task<int> CreateReservationAsync(ReservationCreationDTO reservationCreationDto)
    {
        var reservationToAdd = new Reservation();
        try
        {
            
            var client = await _clientsRepository.GetClientAsync(reservationCreationDto.idCLient);
            EnsureclientExists(client);
            
            
            reservationToAdd.IdClient = reservationCreationDto.idCLient;
            reservationToAdd.DateFrom = reservationCreationDto.DateFrom;
            reservationToAdd.DateTo = reservationCreationDto.DateTo;
            reservationToAdd.IdBoatStandard = reservationCreationDto.IdBoatStandard;
            reservationToAdd.Capasity = 0;
            reservationToAdd.NumOfBoats = reservationCreationDto.NumOfBoats;
            reservationToAdd.Fulfilled = false;
            reservationToAdd.CancelReason = null;
            
            var discount = await _clientsRepository.GetDiscountAsync(reservationCreationDto.idCLient);

            var reservation = await
                _reservationsRepository.GetCusotmerActiveReservationsAsync(reservationCreationDto.idCLient);
            EnsureClientDoenstHaveReservation(reservation);

            var boatstandard = await _boatStandardRepository.GetBoatStandard(reservationCreationDto.IdBoatStandard);
            EnsureBoatStandardExists(boatstandard);

            var listOfBoats =
                await _sailboatRepository.GetOrderedListOfSailBoatsAsync(boatstandard.Level, reservation.DateFrom,
                    reservation.DateTo);
            EnsureAMountOfAvailableBoats(listOfBoats, reservationCreationDto.NumOfBoats);
            
            //here error will be thrown if not anough
            
            var listOfBoatsToBeAssigned = listOfBoats.Take(reservationCreationDto.NumOfBoats);

            double price = 0;
            int Capasity = 0;

            foreach (var boat in listOfBoatsToBeAssigned)
            {
                price = price + boat.Price;
                Capasity = Capasity + boat.Capacity;
            }
            price =- (price * discount);

            reservationToAdd.Price = price;
            reservationToAdd.Capasity = Capasity;
            reservationToAdd.Fulfilled = true;
            
            // add the reservation
            reservationToAdd.IdReservation = await _reservationsRepository.AddReservationAsync(reservationToAdd);
            
            //add the boat_reservation
            await _reservationsRepository.ConnectBoatToReservation(listOfBoatsToBeAssigned, reservationToAdd);


        }
        catch (NotEnoughBoatsExeption e)
        {
            reservationToAdd.CancelReason = "Not enough boats";
            reservationToAdd.IdReservation = await _reservationsRepository.AddReservationAsync(reservationToAdd);
            throw new BadRequestExeption(e.Message);
        }

        return reservationToAdd.IdReservation;
    }

    private void EnsureAMountOfAvailableBoats(List<Sailboat> listOfBoats, int NumOfBoats)
    {
        if (listOfBoats.Count !>= NumOfBoats)
        {
            throw new NotEnoughBoatsExeption("Not enough sailboates");
        }
    }
    
    private void EnsureBoatStandardExists(BoatStandard? boatstandard)
    {
        if (boatstandard == null)
        {
            throw new NotFoundExeption("Boat Standard was not found");
        }
    }
    
    private void EnsureclientExists(Client? client)
    {
        if (client == null)
        {
            throw new NotFoundExeption("Client was not found");
        }
    }
    
    private void EnsureClientDoenstHaveReservation(Reservation? reservation)
    {
        if (reservation != null)
        {
            throw new BadRequestExeption("Client has an active reservation");
        }
    }
}
