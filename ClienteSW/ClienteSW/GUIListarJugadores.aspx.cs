
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
    public partial class GUIListarJugadores : System.Web.UI.Page
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("Id");
            dt.Columns.Add("Cuenta");
            dt.Columns.Add("Contraseña");
            dt.Columns.Add("Apodo");
            dt.Columns.Add("Email");
            dt.Columns.Add("Fehca Modificacion");
            if (!IsPostBack) {
                LlenarTabla();
            }
            
            /**
            dt.Rows.Add(1, "John Hammond", "United States");
            dt.Rows.Add(2, "Mudassar Khan", "India");
            dt.Rows.Add(3, "Suzanne Mathews", "France");
            dt.Rows.Add(4, "Robert Schidner", "Russia");
            */
           
        }

       public List<Jugador> ListaJugadores()
       {
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";

            uri = "https://bi-app-postgress.herokuapp.com/app/api/jugadores";
            res = webClient.DownloadString(uri);

            


            var model = JsonConvert.DeserializeObject<List<Jugador>>(res);

            return model;
        }
        public void LlenarTabla()
        {
           List<Jugador> lista = ListaJugadores();
           foreach (Jugador jugador in lista)
           {
              DataRow row = dt.NewRow();
               dt.Rows.Add(jugador.Id, jugador.Cuenta, jugador.Contrasena, jugador.Apodo, jugador.Email, jugador.FechaModificacion);

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
            Response.Redirect("GUIEliminarJugador.aspx");
        }
        protected void LbtnGraficarP_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIListarPersonajes.aspx");
        }

        protected void txtID_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";
            String id;
            Jugador jugador;

            id = txtID.Text;
            uri = "https://bi-app-postgress.herokuapp.com/app/api/jugador/" + id;
            res = webClient.DownloadString(uri);

            jugador = JsonConvert.DeserializeObject<Jugador>(res);
            dt.Rows.Add(jugador.Id, jugador.Cuenta, jugador.Contrasena, jugador.Apodo, jugador.Email, jugador.FechaModificacion);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        
    }

}