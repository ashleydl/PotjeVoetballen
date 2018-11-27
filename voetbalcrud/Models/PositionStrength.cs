using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace voetbalcrud.Models
{
    [Table("PlayerPositionStrength")]
    public class PositionStrength
    {
        public PlayerPositionStrength Strength { get; set; }
        public Position PositionID { get; set; }
        public List<PositionDescription> PositionDescription { get; set; }
        public PlayerPositionStrength PlayerName { get; set; }
    }

    public class PositionDescription
    {
        public PositionDescription Keep { get; set; }
        public PositionDescription Middenveld { get; set; }
        public PositionDescription Aanval { get; set; }
        public PositionDescription Verdediging { get; set; }
    }
}

