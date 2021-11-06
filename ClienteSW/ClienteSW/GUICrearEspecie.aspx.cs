using ClienteSW.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteSW
{
    public partial class GUIAgregarEspecie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            String id;
            String nombre;
            double reg = 1;
            DateTime da = DateTime.Now;


            Especie especie;
            String uri;
            HttpClient cliente;
            HttpContent contenido;
            HttpResponseMessage res;
            String espJson = "";

            id = txtId.Text.Trim();
            nombre = txtNombre.Text.Trim();

            try
            {
                especie = new Especie(id, nombre, reg, da);

                espJson = "{'id':'" + id + "','nombre':'" + nombre+ "','estadoRegistro':" + reg + ",'fechaModificacion':'" + da.ToString("yyyy-MM-dd") + "'}";
                espJson = espJson.Replace((char)39, (char)34);

                cliente = new HttpClient();
                uri = "https://bi-app-postgress.herokuapp.com/app/api/especie";
                cliente.BaseAddress = new Uri(uri);
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                contenido = new StringContent(espJson, UTF8Encoding.UTF8, "application/json");
                res = cliente.PostAsync(uri, contenido).Result;


                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se creo el especie" + "');", true);
                txtId.Text = "";
                txtNombre.Text = "";
                txtId.Focus();
            }
            catch (Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se pudo insertar mi pana" + "');", true);
            }

        }


    }
}