

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalTime;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.hc.client5.http.cookie.BasicCookieStore;
import org.apache.hc.client5.http.cookie.Cookie;
import org.apache.hc.client5.http.fluent.Executor;
import org.apache.hc.client5.http.fluent.Request;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 * Servlet implementation class InicioAlu
 */
public class InicioAlu extends HttpServlet {
	private static final long serialVersionUID = 1L;
	String tit = "<!DOCTYPE html>\n" + 
			"<html lang=\"es\">\n" + 
			"<head>\n" + 
			"    <meta charset=\"UTF-8\">\n" + 
			"    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n" + 
			"    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" + 
			"    <title>NOL</title>\n" + 
			"\n" + 
			"        <!--JQUERY-->\n" + 
			"        <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\n" + 
			"            \n" + 
			"        <!-- FRAMEWORK BOOTSTRAP para el estilo de la pagina-->\n" + 
			"        <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js\"></script>\n" + 
			"\n" + 
			"        <!-- BOOTSTRAP css-->\n" + 
			"        <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css\" rel=\"stylesheet\">\n" + 
			"\n" + 
			"		<style>\n" + 
			"			#intro{\n" + 
			"			    color: white;\n" + 
			"			    background-color: grey;\n" + 
			"			    text-align: center;\n" + 
			"			    border-radius: 15px;\n" + 
			"			    margin-left: 10px;\n" + 
			"			    margin-right: 10px;\n" + 
			"			    margin-top: 10px;\n" + 
			"			   \n" + 
			"			}\n" + 
			"			\n" + 
			"			#inicios{\n" + 
			"			    margin-left: 2%;\n" + 
			"			}\n" + 
			"			\n" + 
			"			#nombres{\n" + 
			"			    background-color: rgb(204, 237, 241);\n" + 
			"			    border-radius: 15px;\n" + 
			"			}\n" + 
			"			\n" + 
			"			#pie{margin-left: 2%;}\n" + 
			"    #logout{\n" + 
			"        margin: 15%;\n" + 
			"        margin-right: 25%;\n" + 
			"        background-color: red;\n" + 
			"        border-color: rgb(255, 172, 172);\n" + 
			"    }\n" + 
			"\n" + 
			"    #logout:hover{\n" + 
			"        background-color: rgb(255, 172, 172);\n" + 
			"        border-color: red;\n" + 
			"        color:red\n" + 
			"        \n" + 
			"    }\n" + 
			"		</style>\n" + 
			"<script>\n" + 
			"    function cerrarSesion(){\n" + 
			"        $.ajax({\n" + 
			"        type: \"GET\",\n" + 
			"        url: window.location,\n" + 
			"        dataType: 'json',\n" + 
			"        async: true,\n" + 
			"        username:'"+LocalTime.now()+"',\n" + 
			"        password:'"+LocalTime.now()+"',\n" + 
			"        data: '{ \"comment\" }'\n" + 
			"    })\n" + 
			//El fallo significa que hemos tenido exito. y redirigimos al Servlet de cerrar sesi??n y a la p??gina de inicio
			"    .fail(function(){\n" +
			"    $(document).ready(function() {\n" +
            "            $.get('CerrarSesion', {\n" +
            "            }, function(responseText) {\n" +
            "            });\n" +
            "        });\n" +
			"    window.location.replace('index.html');\n" +
			"    });\n" + 
			"}" +
			"</script>" +
			"</head>";
	
	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public InicioAlu() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	@SuppressWarnings("unchecked")
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub	
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println(tit);

		HttpSession sesion = request.getSession();
		String dni = sesion.getAttribute("dni").toString();
		String key = sesion.getAttribute("key").toString();
		List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");
		String url = request.getLocalName();

		
		BasicCookieStore cookie = new BasicCookieStore();
		cookie.addCookie(cookies.get(0));
		Executor executor = Executor.newInstance();
		String t = executor.use(cookie)
				.execute(Request.get("http://"+url+":9090/CentroEducativo/alumnos/" + dni + "?key=" + key))
				.returnContent().toString();

		JSONObject alumno = new JSONObject(t);
		out.println("<body>\n" + 
				"        <div class=\"row\" id=\"intro\">\n" + 
				"            <div class='col-md-5 offset-md-3'>\n" + 
				"            <h1><b>Notas OnLine. </b>Asignaturas del/la alumn@ " + alumno.get("nombre").toString() + " " + alumno.get("apellidos").toString()+"</h1></div>\n" +
				"            <div class='col-md-2 offset-md-2'>\n" + 
				"            <button type='button' onclick='void cerrarSesion();' id='logout' class='btn btn-primary'>Cerrar Sesi??n</button></div>\n" +
				"            <div class='col-md-5 offset-md-3'>\n" + 
				"            <b>En esta p&aacute;gina se muestran las asignaturas en las que est&aacute;s matriculad@, adem??s, podr??s ver tu expediente si lo deseas.</b>\n" + 
				"            <br><b>Al pulsar en una podr&aacute;s acceder a tu calificaci&oacute;n o bien podr??s acceder a tu expediente pulsando en el ??ltimo bot??n.</b></div>\n" + 
				"        </div>\n" + 
				"        <br>  \n" + 
				"        <div class=\"row\">\n" + 
				"            <div class=\"col-7\" id=\"inicios\">\n" + 
				"                <div class=\"row\" id=\"asignaturas\">");

		sesion.setAttribute("rol", "rolalu");
		String asigNom = "asignatura";
		String asignaturas = executor.use(cookie)
				.execute(Request.get("http://"+url+":9090/CentroEducativo/alumnos/" + dni + "/asignaturas/?key=" + key))
				.returnContent().toString();

		JSONArray array =new JSONArray(asignaturas);
		for(int i=0; i<array.length() ;i++) {
			JSONObject asig = array.getJSONObject(i);
			String acronimo = asig.getString(asigNom);
			
			String asigDetalles = executor.use(cookie)
					.execute(Request.get("http://"+url+":9090/CentroEducativo/asignaturas/" + acronimo +"/?key=" + key))
					.returnContent().toString();
			JSONObject detalles = new JSONObject(asigDetalles);
			String nombreD = detalles.getString("nombre");
			
			out.println("<form  action='Asignaturas' method='GET'> "
					+ "<h2><b>" + "<input type ='submit' style='border: 0ch;' value = '" + nombreD + "' name='" + acronimo + "'></form>" + "</b></h2>");
		}
		out.println("<p><form action='Expediente' method='GET'>"
				+ "<h2><b>" + "<input style='color:black' type ='submit' style='border: 0ch;' value = 'Consultar Expediente'></form>" + "</b></h2></p>"
				);
		out.println("</div>\n" + 
				"            </div>\n" + 
				"            <div class=\"col-4\" id=\"nombres\">\n" + 
				"                <h3>Grupo 3TI12_g04</h3>\n" + 
				"                <ol>\n" + 
				"                    <li>Camarena Conde, Jorge</li>\n" + 
				"                    <li>Germes Sisternas, Adri&aacute;n</li>\n" + 
				"                    <li>Michis, Stefan Vasile</li>\n" + 
				"                    <li>Pru??onosa Soler, Guillem</li>\n" + 
				"                    <li>Serrano Lopez, Laura</li>\n" + 
				"                    <li>&Uacute;beda Campos, V&iacute;ctor</li>\n" + 
				"                </ol>\n" + 
				"            </div>\n" + 
				"        </div>\n" + 
				"        <br>\n" + 
				"        <hr>\n" + 
				"        <br>\n" + 
				"        <div id=\"pie\">\n" + 
				"           <p>Trabajo en grupo realizado para la asignatura Desarrollo Web. Curso 2020-2021 (aka el curso de despu&eacute;s del COVID-19, en toda la frente)</p>\n" + 
				"        </div>  \n" + 
				"       \n" + 
				"</body>\n" + 
				"</html> \n" + 
				"");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
