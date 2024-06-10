using System.Data.SqlTypes;

namespace Test2Practice1.Database.Entities;

public class Sailboat
{
    public int IdSailboat{ get; set; }
    public string Name { get; set; }
    public int Capacity{ get; set; }
    public string Description{ get; set; }
    public int IdBoatStandard{ get; set; }
    public double Price{ get; set; }
    
    public virtual ICollection<Sailboat_Reservation> SailboatReservations { get; }
    public virtual BoatStandard BoatStandard { get; }
    
}