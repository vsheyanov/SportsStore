using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SportsStore.Models;

namespace SportsStore.Pages.Helpers
{
    public enum SessionKey
    {
        CART,
        RETURN_URL
    }

    public class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[getNameFor(key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object value = session[getNameFor(key)];
            if (value != null && value is T)
            {
                return (T)value;
            } else
            {
                return default(T);
            }
        }

        public static Cart GetCart (HttpSessionState session)
        {
            Cart userCart = Get<Cart>(session, SessionKey.CART);
            if (userCart == null)
            {
                userCart = new Cart();
                Set(session, SessionKey.CART, userCart);
            }
            return userCart;
        }

        private static string getNameFor(SessionKey key)
        {
            return Enum.GetName(typeof(SessionKey), key);
        }
    }   
}