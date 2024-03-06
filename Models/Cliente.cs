using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiDHL.Models
{
    public class Cliente
    {
        [Key]
        public int Cliente_ID { get; set; }

        //Azienda
        [Display(Name ="Azienda")]
        [Required(ErrorMessage ="Campo obbligatorio")]
        public bool Azienda { get; set; }

        //Codice Fiscale
        [Display(Name ="Codice Fiscale")]
        [StringLength(16, MinimumLength =16, ErrorMessage ="Il codice fiscale deve avere 16 caratteri")]
        public string Cod_Fisc {  get; set; }

        //Partita Iva
        [Display(Name = "Partita Iva")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "La partita iva deve avere 11 cifre")]
        public string PI { get; set; }

        //E-mail
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(255, MinimumLength = 3, ErrorMessage ="Inserisci almeno 3 caratteri")]
        public string Email { get; set; }

        //Cellulare
        [Display(Name = "Telefono/Cellulare")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Inserisci almeno 7 cifre")]
        public string Tel {  get; set; }

        //Nome
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Inserisci un max di 50 caratteri")]
        public string Nome { get; set; }

        //Cognome
        [Display(Name = "Cognome")]
        [StringLength(50, ErrorMessage = "Inserisci un max di 50 caratteri")]
        public string Cognome { get; set; }



    }
}