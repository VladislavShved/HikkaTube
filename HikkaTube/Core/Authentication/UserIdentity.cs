using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DataSource;

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
