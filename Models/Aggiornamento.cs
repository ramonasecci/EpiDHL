using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiDHL.Models
{
    public class Aggiornamento
    {
        [Key]
        public int Aggiornamento_ID { get; set; }

        //Stato
        [Required(ErrorMessage ="Campo Obbligatorio")]
        [StringLength(50, ErrorMessage ="Accetta max 50 caratteri")]
        public string Stato { get; set; }

        //Luogo 
        [Required(ErrorMessage ="Campo Obbligatorio")]
        [StringLength(50, ErrorMessage = "Accetta max 50 caratteri")]
        public string Luogo { get; set; }

        //Descrizione
        [DataType(DataType.MultilineText)]
        public string Descrizione { get; set; }

        //Data aggiornamento 
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Data Aggiornamento")]
        [DataType(DataType.Date)]
        public DateTime Data_Agg {  get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "ID Spedizione")]
        public int Spedizione_ID { get; set;}

    }
}