using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaCRM.Models {
    public class Agenda {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAgenda { get; set; }
        public Contato Contato { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Time)]
        public DateTime HorarioInicio { get; set; }
        [DataType(DataType.Time)]
        public DateTime HorarioFim { get; set; }
    }
}