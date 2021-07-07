import java.io.IOException;
import java.io.PrintWriter;
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

/** Servlet implementation class calificar */
public class Asignaturas extends HttpServlet {
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
			"        <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js\"></script>\n" + 
			"        <!-- Bootstrap CSS -->\n" + 
			"    	<link rel=\"stylesheet\" href=\"https://cdn.rawgit.com/twbs/bootstrap/v4-dev/dist/css/bootstrap.css\">" +
			"            \n" + 
			"        <!-- jQuery y Bootstrap JS. -->\n" + 
			"    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js\"></script>\n" + 
			"    <script src=\"https://cdn.rawgit.com/twbs/bootstrap/v4-dev/dist/js/bootstrap.js\"></script>" +
			"</head>\n" +
			"<body>\n" +
			"   <div class=\"card\">\n" +
			"      <ul class=\"nav nav-tabs\">"; 

	/** @see HttpServlet#HttpServlet() */
	public Asignaturas() { super(); /* TODO Auto-generated constructor stub */ }

	/** @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response) */
	@SuppressWarnings("unchecked")
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println(tit);

		String url = request.getLocalName();
		String acro = "";
		if(request.getAttribute("acro") != null) { acro = request.getAttribute("acro").toString(); }
		else { acro = request.getParameterNames().nextElement().toString(); }

		HttpSession sesion = request.getSession();
		String rol = sesion.getAttribute("rol").toString();
		List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");
		String key = sesion.getAttribute("key").toString();
		String dni = sesion.getAttribute("dni").toString();

		Executor executor = Executor.newInstance();
		BasicCookieStore cookie = new BasicCookieStore();
		cookie.addCookie(cookies.get(0));

		/* COGEMOS LAS ASIGNATURAS DEL PROFESOR O DEL ALUMNO */
		String asignaturas = "";
		if(rol.equals("rolpro")) { 
			asignaturas = executor.use(cookie)
					.execute(Request.get("http://"+url+":9090/CentroEducativo/profesores/" + dni +"/asignaturas/" + "?key=" + key))
					.returnContent().toString();
		}
		else if(rol.equals("rolalu")) {
			asignaturas = executor.use(cookie)
					.execute(Request.get("http://"+url+":9090/CentroEducativo/alumnos/" + dni +"/asignaturas/" + "?key=" + key))
					.returnContent().toString();
		}
		
		/* CREAMOS LOS NAV-ITEMS */
		JSONArray asig = new JSONArray(asignaturas);
		for(int i = 0; i< asig.length(); i++) {
			JSONObject temp = asig.getJSONObject(i);
			String href = "";
			if (rol.equals("rolpro")) { href = temp.get("acronimo").toString(); }
			else if(rol.equals("rolalu")) { href = temp.get("asignatura").toString(); }

			//Se activa la seleccionada en la ventana anterior
			if(href.equals(acro)) { out.println("<li class=\"nav-item\"> <a href='#" + href + "' class='nav-link active' role='tab' data-toggle='tab'>" + href + "</a></li>"); }
			else { out.println("<li class=\"nav-item\"> <a href='#" + href + "' class='nav-link' role='tab' data-toggle='tab'>" + href + "</a></li>"); }
		}
		out.println("</ul>");

		/* CREAMOS LOS TAB-CONTENT */
		out.println("<div class=\"tab-content\">");
		for(int i = 0; i< asig.length(); i++) {	
			JSONObject temp = asig.getJSONObject(i);
			String href = "";
			if (rol.equals("rolpro")) { href = temp.get("acronimo").toString(); }
			else if(rol.equals("rolalu")) { href = temp.get("asignatura").toString(); }

			//Se activa la seleccionada en la ventana anterior
			if(href.equals(acro)) { out.println("<div class=\"tab-pane active\" id=\""+href+"\" role=\"tabpanel\"\">"); } 	
			else { out.println("<div class=\"tab-pane fade\" id=\""+href+"\" role=\"tabpanel\"\">"); }

			/* CONTENIDO DE LAS PESTAÑAS DEL PROFESOR */
			if(rol.equals("rolpro")) { 
				/* Mostramos los detalles de la asignatura */
				String nombre = temp.getString("nombre");
				String curso = temp.getNumber("curso").toString();
				String cuatrimestre = temp.getString("cuatrimestre");
				String creditos = String.valueOf(temp.getFloat("creditos"));


				out.println("<h3>Detalles de la asignatura " + href + "</h3>"
						+ "<b>Nombre identificativo: </b>" + href + "-" + nombre
						+ "<br><b>Curso: </b>" + curso
						+ "<br><b>Cuatrimestre: </b>" + cuatrimestre
						+ "<br><b>Créditos: </b>" + creditos
						+ "<br><b>Profesor/es: </b>");	

				/* Mostramos todos los profesores de la asignatura */
				String profesAsig = executor.use(cookie)
						.execute(Request.get("http://" + url + ":9090/CentroEducativo/asignaturas/" + href + "/profesores/?key=" + key))
						.returnContent().toString();
				JSONArray arrayProf =new JSONArray(profesAsig);
				for(int j=0; j<arrayProf.length() ;j++) {
					JSONObject prof = arrayProf.getJSONObject(j);
					String nombreP = prof.getString("nombre");
					String apellidosP = prof.getString("apellidos");
					if(j==0) { out.println(nombreP + " " + apellidosP); }
					else if(j== arrayProf.length()-1) { out.println("y " + nombreP + " " + apellidosP); } 
					else { out.println(", " + nombreP + " " + apellidosP); }
				}

				/* Mostramos todos los alumnos matriculados en la asignatura */
				out.println("<hr><h3>Alumn@s</h3>");
				String alumnosAsig = executor.use(cookie)
						.execute(Request.get("http://" + url + ":9090/CentroEducativo/asignaturas/" + href + "/alumnos/?key=" + key))
						.returnContent().toString();
				JSONArray arrayAlu =new JSONArray(alumnosAsig);

				for(int j=0; j<arrayAlu.length() ;j++) {
					JSONObject alu = arrayAlu.getJSONObject(j);
					String dniAlu = alu.getString("alumno");
					String nota = alu.getString("nota");
					if(nota.length() == 0) { nota = "Sin calificar"; }

					String alumnoDatos = executor.use(cookie)
							.execute(Request.get("http://" + url + ":9090/CentroEducativo/alumnos/" + dniAlu + "/?key=" + key))
							.returnContent().toString();
					JSONObject datos = new JSONObject(alumnoDatos);
					String nombreA = datos.getString("nombre");
					String apellidosA = datos.getString("apellidos");

					/* Acceso a la ventana de detalles del alumno (puede cambiar su nota) */
					out.println("<form > <b>Nombre (DNI): </b>" + apellidosA + ", " + nombreA + " (" + dniAlu +  ")" + " <b>Nota: </b>" + "<span id='" + dniAlu + href + "'>" + nota + "</span>"
                            + " <input type ='button' data-toggle='modal' data-target='#detalles' style='font-weight: bold' value = 'Detalles' id = '" + dniAlu + href + j + "'<br></form>");

					String array = arrayAlu.toString();
					String position = String.valueOf(j);
                    out.println("<script>\n"
                            + "    $(document).ready(function() {\n"
                            + "        $('#"+dniAlu + href + j +"').click(function(event) {\n"
                            + "	           // Si en vez de por post lo queremos hacer por get, cambiamos el $.post por $.get\n"
                            + "            $.get('Alumno', {\n"
                            + "              asig:'" + href + "',"
                            + "              dni:'" + dniAlu + "',"
                            + "				 alumnos:'" + array + "',"
                            + "				 position:'" + position + "'"
                            + "            }, function(responseText) {\n"
                            + "                $('#detalles').html(responseText);\n"
                            + "            });\n"
                            + "        });\n"
                            + "    });\n"
                            + "</script>");
				}
				
				out.println("</div>");
			}
			
			/* CONTENIDO DE LAS PESTAÑAS DEL ALUMNO */
			else if(rol.equals("rolalu")) {
				/* Mostramos los detalles de la asignatura */
				String asigDetalles = executor.use(cookie)
						.execute(Request.get("http://"+url+":9090/CentroEducativo/asignaturas/" + href +"/?key=" + key))
						.returnContent().toString();
				JSONObject detalles = new JSONObject(asigDetalles);
				String nombre = detalles.getString("nombre");
				String curso = detalles.getNumber("curso").toString();
				String cuatrimestre = detalles.getString("cuatrimestre");
				String creditos = detalles.get("creditos").toString();


				String nota = temp.getString("nota");
				if(nota.length() == 0) { nota = "Sin calificar"; }
				out.println("<h3>Detalles de la asignatura " + href + "</h3>"
						+ "<b>Nombre identificativo: </b>" + href + "-" + nombre
						+ "<br><b>Nota: </b>" + nota
						+ "<br><b>Curso: </b>" + curso
						+ "<br><b>Cuatrimestre: </b>" + cuatrimestre
						+ "<br><b>Créditos: </b>" + creditos
						+ "<br><b>Profesor/es: </b>");

				/* Mostramos todos los profesores de la asignatura */
				String profesAsig = executor.use(cookie)
						.execute(Request.get("http://" + url + ":9090/CentroEducativo/asignaturas/" + href + "/profesores/?key=" + key))
						.returnContent().toString();
				JSONArray arrayProf =new JSONArray(profesAsig);
				for(int j=0; j<arrayProf.length() ;j++) {
					JSONObject prof = arrayProf.getJSONObject(j);
					String nombreP = prof.getString("nombre");
					String apellidosP = prof.getString("apellidos");
					if(j==0) { out.println(nombreP + " " + apellidosP); }
					else if(j== arrayProf.length()-1) { out.println("y " + nombreP + " " + apellidosP); } 
					else { out.println(", " + nombreP + " " + apellidosP); }

				}
				
				/* Acceso a la ventana de detalles del alumno */
				out.println("<p><form action='Alumno' method='GET'> <input type ='submit' style='font-weight: bold' value = 'Detalles' name = \"" +/*dni +*/ href + "\"<br></form><p>");
				out.println("</div>");
			}
		}
		out.println("</div>");
		out.println("<p><div class='modal' id='detalles'></div></p>");
        out.println("</div></body></html>");
	}


	/** @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response) */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}
}

