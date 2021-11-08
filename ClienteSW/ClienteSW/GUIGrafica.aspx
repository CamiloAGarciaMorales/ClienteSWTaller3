<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GUIGrafica.aspx.cs" Inherits="ClienteSW.GUIGrafica" %>

<!doctype html>
<html lang="en">
    <form runat="server">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">

    <title>Menu Principal</title>
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
       <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">

        // Load the Visualization API and the corechart package.
        google.charts.load('current', { 'packages': ['corechart'] });

        // Set a callback to run when the Google Visualization API is loaded.
        google.charts.setOnLoadCallback(drawChart);

        // Callback that creates and populates a data table,
        // instantiates the pie chart, passes in the data and
        // draws it.
        function drawChart() {

            // Create the data table.
            var data = new google.visualization.DataTable();
            var jugador = <%=darCantidadJugadores()%>+0;
            var personajes = <%=darCantidadPersonajes()%>+0;
            var especies = <%=darCantidadEspecies()%>+0;
            /*
             * 
             * [['Tipo','Cantidad'],['Jugadores',13],['Personajes',8],['Especies',7]]
             * */
            data.addColumn('string', 'Tipo');
            data.addColumn('number', 'Cantidad');
            data.addRows([
                ['Jugadores', jugador], ['Personajes',personajes], ['Especies',especies]
            ]);
            
            // Set chart options
            var options = {
                'title': 'Numero de Jugadores, Personajes y Especies',
                'width': 800,
                'height': 600
            };

            // Instantiate and draw our chart, passing in some options.
            var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
  </head>
  <body>
      <!-- Codigo menu barra -->
   <nav class="navbar navbar-expand-md navbar-dark bg-dark" aria-label="Fourth navbar example">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Menu Principal</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample04" aria-controls="navbarsExample04" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarsExample04">
        <ul class="navbar-nav me-auto mb-2 mb-md-0">
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-bs-toggle="dropdown" aria-expanded="false">Jugadores</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li>
                  <asp:LinkButton ID="LbtnCrearJugador" runat="server" OnClick="LbtnCrearJugador_Click">Crear Jugador</asp:LinkButton>
              </li>
              <li><asp:LinkButton ID="LbtnEliminarJugador" runat="server" OnClick="LbtnEliminarJugador_Click">Eliminar Jugador</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtnActualizarJugador" runat="server" OnClick="LbtnActualizarJugador_Click">Actualizar Jugador</asp:LinkButton></li>
            </ul>
          </li>
         <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown02" data-bs-toggle="dropdown" aria-expanded="false">Personajes</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li><asp:LinkButton ID="LbtnCrearPersonaje" runat="server" OnClick="LbtnCrearPersonaje_Click">Crear Personaje</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtinEliminarPersonaje" runat="server" OnClick="LbtinEliminarPersonaje_Click">Eliminar Personaje</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtnActualizarPersonaje" runat="server" OnClick="LbtnActualizarPersonaje_Click">Actualizar Personaje</asp:LinkButton></li>
            </ul>
          </li>
            <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown05" data-bs-toggle="dropdown" aria-expanded="false">Especie</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li>
                  <asp:LinkButton ID="LbtnCrearEspecie" runat="server" OnClick="LbtnCrearEspecie_Click">Crear Especie</asp:LinkButton>
              </li>
            </ul>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown03" data-bs-toggle="dropdown" aria-expanded="false">Listas</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li><asp:LinkButton ID="LbtnirListar" runat="server" OnClick="LbtnirListar_Click">Listar</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtnirGraficar" runat="server" OnClick="LbtnirGraficar_Click">Graficar Jugadores</asp:LinkButton></li>
                <li><asp:LinkButton ID="LbtnGraficarP" runat="server" OnClick="LbtnGraficarP_Click">Listar Personajes</asp:LinkButton></li>
            </ul>
          </li>

        </ul>    
      </div>
    </div>
  </nav>
      <!-- Contenido de la pagina -->
      <main class="container" >
 
      <div id="chart_div"  style="width:650px; margin:0 auto;">
      </div>
   
</main>


  
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>

    <!-- Option 2: Separate Popper and Bootstrap JS -->
    <!--
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-W8fXfP3gkOKtndU4JGtKDvXbO53Wy8SZCQHczT5FMiiqmQfUpWbYdTil/SxwZgAN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.min.js" integrity="sha384-skAcpIdS7UcVUC05LJ9Dxay8AXcDYfBJqt1CJ85S/CFujBsIzCIv+l9liuYLaMQ/" crossorigin="anonymous"></script>
    -->


  </body>
        </form>
</html>
