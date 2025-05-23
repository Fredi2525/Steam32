using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enum;

namespace Models.Accounts
{
    public class GameDto
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Cost { get; set; }
        public string PathToGamePlayVideo { get; set; }
        public string PathToMainPicture { get; set; }
        public Platform Platform { get; set; }
        public string Genre { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
