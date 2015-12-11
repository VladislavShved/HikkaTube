using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Authentication
{
  public class UserPrincipal : IPrincipal
  {
    private readonly UserIdentity _userIdentity;

    public UserPrincipal(UserIdentity userIdentity)
    {
      _userIdentity = userIdentity;
    }

    public bool IsInRole(string role)
    {
      return true;
    }

    public IIdentity Identity
    {
      get { return _userIdentity; }
    }
  }
}
