using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazin.Web.Infrastructure.Abstract;
using System.Web.Security;

namespace Magazin.Web.Infrastructure.Concrete
{
    public class FormAuthProvider: IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            return result;
        }
    }
}