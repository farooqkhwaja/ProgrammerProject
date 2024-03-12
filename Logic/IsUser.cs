
namespace Logic;

public class IsUser
{
    private string _username;
    private string _password;
    private static List<IsUser> users = new List<IsUser>()
    {
        new IsUser("sediq" , "12345"),
        new IsUser("larry", "1234"),
        new IsUser("hashmat", "123"),
    };
    
    public IsUser(string username, string password)
    {
        this._username = username;
        this._password = password;
        users.Add(this);
    }
    public static IsUser FindUser(string username, string password) 
    {
        foreach (IsUser user in users)
        {
            if(user._username == username && user._password == password)
            {
                return user;
            }
        }
        return null;
    }
   
   
}
