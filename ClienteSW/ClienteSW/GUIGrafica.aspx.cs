using ClienteSW.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteSW
{
    public partial class GUIGrafica : System.Web.UI.Page
    {
        protected void LbtnCrearJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUICrearJugador.aspx");

        }

        protected string Dardatos()
        {
            DataTable datos = new DataTable();

            datos.Columns.Add(new DataColumn("Jugadores", typeof(string)));
            datos.Columns.Add(new DataColumn("Personajes", typeof(string)));
            datos.Columns.Add(new DataColumn("Especies", typeof(string)));

            datos.Rows.Add(new Object[] { "Jugadores", darCantidadJugadores() });
            datos.Rows.Add(new Object[] { "Personajes", darCantidadPersonajes() });
            datos.Rows.Add(new Object[] { "Especies", darCantidadEspecies() });
            string data;
            data = "[['Tipo','Cantidad']";
            foreach (DataRow dr in datos.Rows)
            {
                data = data + ",[";
                data = data + "'" + dr[0] + "'" + ","+dr[1];
                data =  data+"]";

            }
            data = data + "]";
            return data;
        }
        public static int darCantidadJugadores()
        {
            int cantidad= 0;
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";

            uri = "https://bi-app-postgress.herokuapp.com/app/api/jugadores";
            res = webClient.DownloadString(uri);




            var model = JsonConvert.DeserializeObject<List<Jugador>>(res);

            cantidad = model.Count;
            return cantidad;
        }
        public static int darCantidadEspecies()
        {
            int cantidad = 0;
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";

            uri = "https://bi-app-postgress.herokuapp.com/app/api/especies";
            res = webClient.DownloadString(uri);




            var model = JsonConvert.DeserializeObject<List<Especie>>(res);

            cantidad = model.Count;
            return cantidad;
        }
        public static int darCantidadPersonajes()
        {
            int cantidad = 0;
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";

            uri = "https://bi-app-postgress.herokuapp.com/app/api/personajes";
            res = webClient.DownloadString(uri);




            var model = JsonConvert.DeserializeObject<List<Personaje>>(res);

            cantidad = model.Count;
            return cantidad;
        }
        protected void LbtnEliminarJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIEliminarJugador.aspx");
        }

        protected void LbtnActualizarJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIActualizarJugador.aspx");
        }

        protected void LbtnCrearPersonaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUICrearPersonaje.aspx");
        }

        protected void LbtinEliminarPersonaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIEliminarPersonaje.aspx");
        }

        protected void LbtnActualizarPersonaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIActualizarPersonaje.aspx");
        }

        protected void LbtnirListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIListarJugadores.aspx");
        }

        protected void LbtnirGraficar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIGrafica.aspx");
        }
        protected void LbtnGraficarP_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIListarPersonajes.aspx");
        }

        protected void LbtnCrearEspecie_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUICrearEspecie.aspx");
        }

        
    }
}