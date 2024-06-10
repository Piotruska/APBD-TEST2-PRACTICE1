namespace Test2Practice1.Database.Entities;

public class BoatStandard
{
    public int IdBoatStandard { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    
    public virtual ICollection<Reservation> Reservations { get; }
    public virtual ICollection<Sailboat> Sailboats { get; }
}