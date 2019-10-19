using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SITE__PIM.Models;
using System.Data.SqlClient; // habilita conexão com sql

namespace SITE__PIM.Controllers
{
    public class ContaController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Conta
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionSting()
        {
            con.ConnectionString = "data source=PC; database= ; integrated security = SSPI;"; // colocar informações do banco de dados
        }
        [HttpPost]
        public ActionResult verificar(Conta acc)
        {
            connectionSting();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from where username='"+acc.Nome+"'and password='"+acc.Senha+"'"; // parte referente a entrada de nome e senha na pagina de login
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();

                return View("Sucesso");
            }
            else
            {
                con.Close();

                return View("Erro");
            }
            
         
        }
    }
}