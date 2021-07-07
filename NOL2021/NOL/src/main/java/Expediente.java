

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.Locale;

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
 * Servlet implementation class Expediente
 */
public class Expediente extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Expediente() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
    @SuppressWarnings("unchecked")
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		HttpSession sesion = request.getSession();
		String dni = sesion.getAttribute("dni").toString();
		String key = sesion.getAttribute("key").toString();
		List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");
		String url = request.getLocalName();
		
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
				"			   \n" + 
				"			}\n" + 
				"			\n" + 
				"			#inicios{\n" + 
				"			    margin-left: 2%;\n" + 
				"			}\n" + 
				"			#textoini{\n" +
				"               font-size: 150%;\n"+
				"			    margin-left: 2%;\n" + 
				"			}\n" +
				"			#textotabla{\n" +
				"               font-size: 135%;\n"+
				"			}\n" + 
				"			\n" + 
				"			#nombres{\n" + 
				"			    background-color: rgb(204, 237, 241);\n" + 
				"			    border-radius: 15px;\n" + 
				"			}\n" + 
				"			\n" + 
				"			#pie{margin-left: 2%;}\n" + 
				"	html{\n" + 
				"        width: 21cm;\n" + 
				"        height: 29.7cm;\n" + 
				"        margin: 5mm; \n" +
				"		 margin-left: auto;\n" + 
				"    	 margin-right: auto;\n"+
				"		 background-color: lightgrey;\n"+
				"		 border-radius: 15px; \n"+
				"   }" +
				"		</style>\n" +
				"<script>\n" + 
				"		$(document).ready(function(){\n" + 
				"		$.getJSON(\"BuscaFoto?dni="+ sesion.getAttribute("dni") + "\")\n" + 
				"	.done(function(response){\n" + 
				"		$(\"#fotodni\").attr(\"src\", \"data:image/png;base64,\" + response.img);\n" + 
				"	})\n" + 
				"	.fail(function(jq, status, err){\n" + 
				"		var error = jq.response.replace(\",\", \"\\n\");\n" + 
				"		alert(\"Un error ha sucedido: \" + err);\n" + 
				"	});\n" + 
				"});\n" + 
				"</script>" +
				"</head>\n" + 
				"\n"; 		
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println(tit);

		
		BasicCookieStore cookie = new BasicCookieStore();
		cookie.addCookie(cookies.get(0));
		Executor executor = Executor.newInstance();
		String t = executor.use(cookie)
				.execute(Request.get("http://"+url+":9090/CentroEducativo/alumnos/" + dni + "?key=" + key))
				.returnContent().toString();
		
		JSONObject alumno = new JSONObject(t);
		
		String asignaturas = executor.use(cookie)
				.execute(Request.get("http://"+url+":9090/CentroEducativo/alumnos/" + dni + "/asignaturas/?key=" + key))
				.returnContent().toString();

		JSONArray array =new JSONArray(asignaturas);
		
		out.println("<body style=\"border-radius: 15px;\">\n" +
				"<br>\n"+
				"        <div class=\"row\" id=\"intro\">\n" + 
				"            <h1><b>DEW-Centro Educativo. </b></h1>\n" + 
				"            <h3><b>Certificado sin validez académica.</b></h3>\n" +
				"</div>\n" +
				"        <div class=\"row\">\n" + 
				"            <div class=\"col-8\" id=\"textoini\">\n" + 
				"<b style=\"font-size: 115%;\">DEW - Centro Educativo </b> certifica que D/Dª <b style=\"font-size: 115%;\">" + alumno.getString("nombre") +" "
				+ alumno.getString("apellidos") + "</b>, con DNI " + alumno.getString("dni") +
				", matriculado/a en el curso 2020/21, ha obtenido las calificaciones que se muestran en la siguiente tabla."
				+ "</div>\n"
				+ "		<div class=\"col-3\">\n"
				+ "		<img id=\"fotodni\" src='' alt= 'fotoDNI' width='210' style='border-radius: 15px; margin: 2mm;'>\n"
				+ "		</div> \n"
				+ "</div>\n"
				+ "<br>\n"
				+ "<br>\n"
				+"<table class=\"table\" id='textotabla'>\n"
				+"  <thead>\n" + 
				"    <tr>\n" + 
				"      <th scope=\"col\">Acrónimo</th>\n" + 
				"      <th scope=\"col\">Asignatura</th>\n" + 
				"      <th scope=\"col\">Calificación</th>\n" + 
				"    </tr>\n" + 
				"  </thead>\n" + 
				"  <tbody>" 
				); 
		for(int i=0; i<array.length() ;i++) {
			JSONObject asig = array.getJSONObject(i);
			String acronimo = asig.getString("asignatura");
			String nota = asig.getString("nota");
			if(nota.length() == 0) {nota = "Sin calificar";}
			String asigDetalles = executor.use(cookie)
					.execute(Request.get("http://"+url+":9090/CentroEducativo/asignaturas/" + acronimo +"/?key=" + key))
					.returnContent().toString();
			JSONObject detalles = new JSONObject(asigDetalles);
			String nombreD = detalles.getString("nombre");
			out.println("<tr>\n" + 
					"      <td>"+acronimo+"</td>\n" + 
					"      <td>"+nombreD+"</td>\n" + 
					"      <td>"+nota+"</td>\n" + 
					"    </tr>\n");
			
		}
		DateTimeFormatter esDateFormatLargo =
			    DateTimeFormatter
			      .ofPattern("EEEE, dd 'de' MMMM 'de' yyyy")
			      .withLocale(new Locale("es", "ES"));
		LocalDate fecha0 = LocalDate.now();
		String fecha = fecha0.format(esDateFormatLargo);
		out.println("  </tbody>\n" + 
				"</table>\n");
		out.println("<br>\n");
		out.println("<div class=\"container\">\n"
				+ "<div class=\"row justify-content-end\">\n");
		out.println("<div class=\"col-5\">\n" + 
				"</div>\n" + 
				"    <div class=\"col-6\">\n" + 
				"      En Valencia, a " +fecha+"\n" + 
				"    </div>\n"
				+ "</div>\n"
				+ "</div>\n");
		out.println("<br>\n");
		out.println("<div class=\"container\">\n"
				+ "<div class=\"row justify-content-end\">\n");
		out.println("<div class=\"col-5\">\n" + 
				"</div>\n" + 
				"    <div class=\"col-6\">\n" + 
				"<img src='firma.png' alt= 'firma' width='210'>\n"+
				"    </div>\n"
				+ "</div>\n"
				+ "</div>\n");
		out.println("<div class=\"container\">\n"
				+ "<div class=\"row justify-content-end\">\n");
		out.println("<div class=\"col-5\">\n" + 
				"</div>\n" + 
				"    <div class=\"col-6\">\n" + 
				"      <p>\nFirmado por el secretario"
				+ "<br>\n"
				+ "    Stefan Vasile Michis</p>" + 
				"    </div>\n" 
				+ "</div>\n"
				+ "</div>\n");
		out.println("</body>\n");
		out.println("</html>\n");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		
	}

}
