
using ClienteSW.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteSW
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebClient webClient;
                webClient = new WebClient();
                String uri = "";
                String res = "";

                uri = "https://bi-app-postgress.herokuapp.com/app/api/jugadores";
                res = webClient.DownloadString(uri);
                var model = JsonConvert.DeserializeObject<List<Jugador>>(res);

                List<string> listJugadores = new List<string>();
                foreach(Jugador jugador in model)
                {
                    listJugadores.Add(jugador.Id + ". " + jugador.Apodo);
                }

                uri = "https://bi-app-postgress.herokuapp.com/app/api/especies";
                res = webClient.DownloadString(uri);
                var model2 = JsonConvert.DeserializeObject<List<Especie>>(res);
                List<string> listEspecies = new List<string>();

                foreach (Especie especie in model2)
                {
                    listEspecies.Add(especie.Id + ". " + especie.Nombre);
                }



           

                ListJuga.DataSource = listJugadores;
                ListEspe.DataSource = listEspecies;
                ListEspe.DataBind();
                ListJuga.DataBind();
            }
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
            String nom;
            double fue;
            double mana;
            double ener;
            Especie esp;
            Jugador jug;
            double reg = 1;
            DateTime da = DateTime.Now;


            Personaje perso;
            String uri;
            HttpClient cliente;
            HttpContent contenido;
            HttpResponseMessage res;
            String perJson = "";

            id = txtId.Text.Trim();
            nom = txtNombre.Text.Trim();
            fue = Convert.ToDouble(txtFuerza.Text.Trim());
            mana = Convert.ToDouble(txtMana.Text.Trim());
            ener = Convert.ToDouble(txtEnergia.Text.Trim());
            jug = getJugador(ListJuga.SelectedItem.Value.Split('.')[0]);
            esp = getEspecie(ListEspe.SelectedItem.Value.Split('.')[0]);

            try
            {
                perso = new Personaje(id, nom, fue, mana, ener, esp, jug, reg, da);

                perJson = "{'id':'" + id + 
                    "','nombre':'" + nom + 
                    "','fuerza':'" + fue + 
                    "','mana':'" + mana + 
                    "','energia':'" + ener +
                    "','especie':{"+
                        "'id':'"+ esp.Id+
                        "','nombre':'"+esp.Nombre +
                        "','estadoRegistro':"+esp.EstadoRegistro+
                        ",'fechaModificacion':'"+ esp.FechaModificacion.ToString("yyyy-MM-dd") + "'},"+
                    "'jugador':{"+
                        "'id':'"+jug.Id+
                        "','cuenta':'"+jug.Cuenta+
                        "','contrasena':'"+jug.Contrasena+
                        "','apodo':'"+jug.Apodo+
                        "','email':'"+jug.Email+
                        "','estadoRegistro':"+jug.EstRegistro+
                        ",'fechaModificacion':'"+jug.FechaModificacion.ToString("yyyy-MM-dd") + "'}"+ 
                    ",'estadoRegistro':" + reg + 
                    ",'fechaModificacion':'" +
                      da.ToString("yyyy-MM-dd") + "'}";
                perJson = perJson.Replace((char)39, (char)34);

                cliente = new HttpClient();
                uri = "https://bi-app-postgress.herokuapp.com/app/api/personaje";
                cliente.BaseAddress = new Uri(uri);
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                contenido = new StringContent(perJson, UTF8Encoding.UTF8, "application/json");
                res = cliente.PostAsync(uri, contenido).Result;
                ClientScript.RegisterStartupScript(this.GetType(), "Felicidades Shinji", "alert('" + "Se creo el Personaje" + "');", true);
                txtId.Text = "";
                txtNombre.Text = ""; 
                txtFuerza.Text = "";
                txtMana.Text = "";
                txtEnergia.Text = "";
                txtId.Focus();
            }
            catch(Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se pudo insertar el personaje" + "');", true);
            }
        }
        public Jugador getJugador(String id)
        {
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";
            Jugador jugador;
            uri = "https://bi-app-postgress.herokuapp.com/app/api/jugador/" + id;
            res = webClient.DownloadString(uri);

            jugador = JsonConvert.DeserializeObject<Jugador>(res);
            return jugador;
        }

        public Especie getEspecie(String id)
        {
            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";
            Especie especie;
            uri = "https://bi-app-postgress.herokuapp.com/app/api/especie/" + id;
            res = webClient.DownloadString(uri);

            especie = JsonConvert.DeserializeObject<Especie>(res);
            return especie;
        }

    } 
}