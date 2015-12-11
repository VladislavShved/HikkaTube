using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Security;
using DataSource;
using WebUI.Models;

namespace WebApi.Controllers.Api
{
    public class AuthenticationController : ApiController
    {
      private readonly IRepository<User> _userRepository;

      public AuthenticationController(IRepository<User> userRepository)
      {
        _userRepository = userRepository;
      }

      private bool CheckHash(byte[] array1, byte[] array2)
      {
        for (var i = 0; i < 16; i++)
        {
          if (array1[i] != array2[i])
            return false;
        }
        return true;
      }

      [HttpPost]
      public HttpResponseMessage Authenticate([FromBody]LoginModel model)
      {
        var users = _userRepository.GetAll().FirstOrDefault(c => c.Login == model.Login);

        User user = users;
        if (user == null)
        {
          return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(model.Password));

        if (CheckHash(hash, user.PasswordHash))
        {
          var response = new HttpResponseMessage(HttpStatusCode.OK);

          var js = new JavaScriptSerializer();
          var data = js.Serialize(user);
          var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(20), model.IsRemember, data);
          var encryptedTicket = FormsAuthentication.Encrypt(ticket);
          var authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
          HttpContext.Current.Response.SetCookie(authCookies);

          return response;
        }

        return new HttpResponseMessage(HttpStatusCode.BadRequest);
      }

      [HttpDelete]
      public void SignOut()
      {
        FormsAuthentication.SignOut();
      }
    }
}
