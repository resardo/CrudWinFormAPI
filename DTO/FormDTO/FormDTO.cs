using Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FormDTO
{
    public class FormDTO
    {
        public Guid FormId { get; set; }

        public string Emri { get; set; } = null!;

        public string Mbiemri { get; set; } = null!;

        public DateTime Datelindja { get; set; }

        public string Telefon { get; set; } = null!;

        public string Gjinia { get; set; } = null!;

        public int Ipunesuar { get; set; }

        public string GjendjaMartesore { get; set; } = null!;

        public string Vendlindja { get; set; } = null!;

        public Guid? EmployeeId { get; set; }


    }
}
