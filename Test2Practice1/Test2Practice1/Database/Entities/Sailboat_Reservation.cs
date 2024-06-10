namespace Test2Practice1.Database.Entities;

public class Sailboat_Reservation
{
    public int IdSailboat{ get; set; }
    public int IdReservation{ get; set; }
    
    public virtual Sailboat Sailboat { get; }
    public virtual Reservation Reservation { get; }
}