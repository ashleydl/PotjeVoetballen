using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace voetbalcrud.Models
{
    public class Positions
    {
        public PlayerPositionStrength strength { get; set; }
        public Position Description { get; set; }
        public Position PostionID { get; set; }
        public PlayerPositionStrength Player { get; set; }
    }

}