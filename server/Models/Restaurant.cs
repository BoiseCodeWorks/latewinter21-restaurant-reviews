namespace server.Models
{
  public class Restaurant
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string OwnerId { get; set; }

    //effectively a virtual 
    public Profile Owner { get; set; }
  }
}