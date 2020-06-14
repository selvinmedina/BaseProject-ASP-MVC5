using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseProject.Models
{
    public class Helpers
    {
        public bool GetUserLogin()
        {
            bool state = false;
            bool? user = false;
            try
            {
                user = true; //(bool?)HttpContext.Current.Session["UserLoginEsAdmin"];
                if (user ?? false)
                    state = true;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                state = false;
            }
            return state;
        }
    }
}