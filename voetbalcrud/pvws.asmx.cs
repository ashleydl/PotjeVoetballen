using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using voetbalcrud.Models;
using System.Configuration;

namespace voetbalcrud
{
    /// <summary>
    /// Summary description for pvws
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
#pragma warning disable IDE1006 // Naming Styles
    public class pvws : System.Web.Services.WebService
#pragma warning restore IDE1006 // Naming Styles
    {

        [WebMethod]
        public string GetAllPlayers()
        { 
 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())
            {
                var items = db.Players.Select(_ => new { _.ID, _.PlayerName }).ToList();
                return serializer.Serialize(items);
            }
        }
    }
}
