namespace SweetDate.Domain.Entity;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    
    public string Name { get; set; }


    public string Login { get; set; }

    public string Password { get; set; }
    
    public Person Person { get; set; }
}