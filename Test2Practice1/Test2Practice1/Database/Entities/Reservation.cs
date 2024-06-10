using System.Data.SqlTypes;

namespace Test2Practice1.Database.Entities;

public class Reservation
{
    public int IdReservation{ get; set; }
    public int IdClient{ get; set; }
    public DateTime DateFrom{ get; set; }
    public DateTime DateTo{ get; set; }
    public int IdBoatStandard{ get; set; }
    public int Capasity{ get; set; }
    public int NumOfBoats{ get; set; }
    public bool Fulfilled { get; set; } //?
    public double? Price { get; set; }
    public string? CancelReason { get; set; }
    
    public virtual Client Client { get; }
    public virtual BoatStandard BoatStandard { get; }
    public virtual ICollection<Sailboat_Reservation> SailboatReservations { get; }
}