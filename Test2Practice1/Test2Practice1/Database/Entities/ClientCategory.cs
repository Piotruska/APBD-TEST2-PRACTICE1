namespace Test2Practice1.Database.Entities;

public class ClientCategory
{
    public int IdClientCategory{ get; set; }
    public string Name { get; set; }
    public int DicsountPerc{ get; set; }
    
    public virtual ICollection<Client> Clients { get; }
}