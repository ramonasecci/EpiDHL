using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiDHL.Models
{
    public class Spedizione
    {
        [Key]
        public int Spedizione_ID { get; set; }

        //Data Spedizione
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Data Spedizione")]
        public DateTime Data_Spedizione { get; set; }

        //Codice Spedizione
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Codice Spedizione")]
        public int Cod_Sped {  get; set; }

        //Peso
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Range(1,100000000, ErrorMessage ="Il valore dev'essere compreso tra 1 e 100000000 con max due cifre decimali")]
        public decimal Peso { get; set; }

        //Città destinazione 
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Città destinazione")]
        [StringLength(50,  ErrorMessage = "Deve contenere max 50 caratteri")]
        public string Citta_Dest { get; set; }

        //Indirizzo  
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [StringLength(50, ErrorMessage = "Deve contenere max 50 caratteri")]
        public string Indirizzo { get; set; }

        //Destinatario  
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [StringLength(50, ErrorMessage = "Deve contenere max 50 caratteri")]
        public string Destinatario { get; set; }

        //Costo
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Range(1, 100000000, ErrorMessage = "Il valore dev'essere compreso tra 1 e 100000000 con max due cifre decimali")]
        public decimal Costo { get; set; }

        //Data Prevista
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Data Prevista")]
        public DateTime Data_Prev { get; set; }

        //Cliente ID
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public int Cliente_ID { get; set; }














    }
}