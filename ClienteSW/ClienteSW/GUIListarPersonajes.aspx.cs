
using ClienteSW.Entity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteSW
{
    public partial class ListarPersonajes : System.Web.UI.Page
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Fuerza");
            dt.Columns.Add("Mana");
            dt.Columns.Add("Energia");
            dt.Columns.Add("EspecieId");
            dt.Columns.Add("JugadorId");
            dt.Columns.Add("Fecha Modificacion");
            if (!IsPostBack) { LlenarTabla(); }
            

        }
        public List<Personaje> ListaPersonajes()
        {
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";

            uri = "https://bi-app-postgress.herokuapp.com/app/api/personajes";
            res = webClient.DownloadString(uri);

            JavaScriptSerializer _Serialize = new JavaScriptSerializer();

            var model = _Serialize.Deserialize<List<Personaje>>(res);

            foreach(Personaje personaje in model)
            {
                int pos = res.IndexOf(":{") + 1;
                int posF = res.IndexOf("},\"jugador\":") + 1;
                String jsonEspecie = res.Substring(pos, posF - pos);

                pos = res.IndexOf("\"jugador\":") + 10;
                posF = res.IndexOf("},\"estadoRegistro\"") + 1;

                String jsonJugador = res.Substring(pos, posF - pos);
                res = res.Substring(posF);

                Jugador jugador1;
                Especie especie1;
                jugador1 = JsonConvert.DeserializeObject<Jugador>(jsonJugador);
                especie1 = JsonConvert.DeserializeObject<Especie>(jsonEspecie);

                personaje.Especieid = especie1;
                personaje.Jugadorid = jugador1;
            }
            // var model = JsonConvert.DeserializeObject<List<Personaje>>(res);

            return model;
        }

        public void LlenarTabla()
        {
            List<Personaje> lista = ListaPersonajes();
            foreach (Personaje personaje in lista)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(personaje.Id, personaje.Nombre, personaje.Fuerza, personaje.Mana, personaje.Energia, personaje.Especieid.Id, personaje.Jugadorid.Id, personaje.FechaModificacion);

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void LbtnCrearJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUICrearJugador.aspx");

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

       
    }
}