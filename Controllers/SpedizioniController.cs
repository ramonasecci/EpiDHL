using EpiDHL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiDHL.Controllers
{
   
    public class SpedizioniController : Controller
    {

        [Authorize]
        // GET: Spedizioni
        public ActionResult Index()
        {
            List<Spedizione> spedizioni = new List<Spedizione>();
            try
            {
                DB.conn.Open();
                var command = new SqlCommand("SELECT * FROM Spedizioni", DB.conn);
                var reader = command.ExecuteReader();

                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var sped = new Spedizione();
                        sped.Spedizione_ID = (int)reader["Spedizione_ID"];
                        sped.Data_Spedizione = (DateTime)reader["Data_Spedizione"];
                        sped.Cod_Sped = (int)reader["Cod_Sped"];
                        sped.Peso = (decimal)reader["Peso"];
                        sped.Citta_Dest = reader["Citta_Dest"].ToString();
                        sped.Indirizzo = reader["Indirizzo"].ToString();
                        sped.Destinatario = reader["Destinatario"].ToString();
                        sped.Costo = (decimal)reader["Costo"];
                        sped.Data_Prev = (DateTime)reader["Data_Prev"];
                        sped.Cliente_ID = (int)reader["Cliente_ID"];
                        spedizioni.Add(sped);
                    }
                    reader.Close();
                }

            }
            catch
            {

            }
            finally
            {
                DB.conn.Close();

            }
            
            
            
            return View(spedizioni);
            
        }

        [Authorize]
        // GET: Spedizioni
        public ActionResult AddAggiornamento(int id)
        { 
            ViewBag.id = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAggiornamento(Aggiornamento aggiornamento)
        {
            int spedId = 0;
            try
            {
                DB.conn.Open();
                var command = new SqlCommand(@"INSERT INTO Aggiornamenti
                                       (Stato, Luogo, Descrizione, Data_Agg, Spedizione_ID)
                                    VALUES (@stato,@luogo,@descrizione,@data_agg,@sped_id)", DB.conn);
                command.Parameters.AddWithValue("@stato", aggiornamento.Stato);
                command.Parameters.AddWithValue("@luogo", aggiornamento.Luogo);
                command.Parameters.AddWithValue("@descrizione", aggiornamento.Descrizione);
                command.Parameters.AddWithValue("@data_agg", aggiornamento.Data_Agg);
                command.Parameters.AddWithValue("@sped_id", aggiornamento.Spedizione_ID);
                command.ExecuteNonQuery();
                spedId = aggiornamento.Spedizione_ID;

                if (spedId != 0)
                {
                    return RedirectToAction("Details", "Spedizioni", new { id = spedId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione in modo appropriato
                TempData["ErrorMessage"] = "Si è verificato un errore durante l'aggiunta dell'aggiornamento.";
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                DB.conn.Close();
            }
        }


        [HttpGet]
        public ActionResult Track()
        {

            var models = new ModelComb
            {
                Cliente1 = new Cliente(),
                Spedizione1 = new Spedizione(),
            };
            return View(models);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Track(ModelComb modelComb)
        {
            int idSped = 0;
            try
            {

                
            
                {
                    DB.conn.Open();

                    using (SqlCommand command = new SqlCommand(@"SELECT * 
                                                           FROM Spedizioni as s 
                                                           JOIN Clienti as c ON s.Cliente_ID = c.Cliente_ID 
                                                           WHERE s.Cod_Sped=@cod_sped AND c.Cod_Fisc=@cod_fisc", DB.conn))
                    {
                        command.Parameters.AddWithValue("@cod_sped",modelComb.Spedizione1.Cod_Sped );
                        command.Parameters.AddWithValue("@cod_fisc",modelComb.Cliente1.Cod_Fisc );
                        var reader = command.ExecuteReader();


                        if (reader.HasRows)
                            {
                                reader.Read();
                                idSped = (int)reader["Spedizione_ID"];
                                string indirizzo = reader["Indirizzo"].ToString();
                            if(idSped != 0)
                            {
                                return RedirectToAction("Details", new { id = idSped });

                            }
                            else
                            {
                                return RedirectToAction("Track", "Spedizioni");
                            }
                                
                            }
                        
                    }
                }

                TempData["ErrorMex"] = true;
                return View();
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione in modo appropriato, ad esempio, registrando l'errore o visualizzando un messaggio all'utente.
                TempData["ErrorMessage"] = "Si è verificato un errore durante l'elaborazione della richiesta.";
                // Log dell'eccezione
                Console.WriteLine(ex.Message);
                return View();
            }
            finally { DB.conn.Close(); }
        }


        public ActionResult Details(int id)
        {
            var sped = new Spedizione();
            try
            {
                DB.conn.Open();
                var command = new SqlCommand(@"SELECT *
                                               FROM Spedizioni
                                               WHERE Spedizione_ID=@id", DB.conn);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    sped.Spedizione_ID = (int)reader["Spedizione_ID"];
                    sped.Data_Spedizione = (DateTime)reader["Data_Spedizione"];
                    sped.Cod_Sped = (int)reader["Cod_Sped"];
                    sped.Peso = (decimal)reader["Peso"];
                    sped.Citta_Dest = reader["Citta_Dest"].ToString();
                    sped.Indirizzo = reader["Indirizzo"].ToString();
                    sped.Destinatario = reader["Destinatario"].ToString();
                    sped.Costo = (decimal)reader["Costo"];
                    sped.Data_Prev = (DateTime)reader["Data_Prev"];
                    sped.Cliente_ID = (int)reader["Cliente_ID"];
                }
            }
            catch
            {
            }
            finally { DB.conn.Close(); }
            return View(sped);

        }





    }
}