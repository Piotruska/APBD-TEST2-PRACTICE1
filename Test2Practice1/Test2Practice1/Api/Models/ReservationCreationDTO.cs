namespace Test2Practice1.Api.Models;

public class ReservationCreationDTO
{
    public int idCLient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int NumOfBoats { get; set; }
}