﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SQLite;

namespace AS2324._3G.Prof.SalesAPI.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("GetClients")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataTable))]
        public JsonResult GetClients()
        {
            DataTable? dtbClients = null;

            string query = "";
            string file = "C:\\Appl\\Scuola\\AS_2023_2024\\3G\\AS2324.3G.Prof.SalesAPI\\AS2324.3G.Prof.SalesAPI\\Database\\northwindITA.db";
            string strConn = "";

            // connessione al DB in SQL Lite (vedi www.connectionstrings.com)
            strConn = @"Data Source=" + file + ";Pooling=false;Synchronous=Full;";

            SQLiteConnection conn = new SQLiteConnection(strConn);
            conn.Open();

            // carico il data table clienti

            // prepara la QUERY
            query = "";
            query = query + "SELECT ";
            query = query + "   IdCliente, NomeSocieta, Indirizzo ";
            query = query + "FROM ";
            query = query + "   Clienti ";

            // crea DataAdapter
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);

            // popola il DataTable con DataAdapter 
            dtbClients = new DataTable();
            da.Fill(dtbClients);

            conn.Close();


            return Json(new { status="OK", output = dtbClients });
            //return Json(dtbClients);
        }
    }
}
