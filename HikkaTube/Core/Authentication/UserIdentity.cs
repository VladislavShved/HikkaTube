using System.Security.Principal;
using Core.Authentication.Models;

namespace Core.Authentication
{
  public class UserIdentity : IIdentity
  {
    public IIdentity Identity { get; set; }
    public User User { get; set; }

    public UserIdentity(User user)
    {
      Identity = new GenericIdentity(user.Login);
      User = user;
    }

    public string Name
    {
      get { return Identity.Name; }
    }

    public string AuthenticationType
    {
      get { return Identity.AuthenticationType; }
    }

    public bool IsAuthenticated
    {
      get { return Identity.IsAuthenticated; }
    }
  }
}
