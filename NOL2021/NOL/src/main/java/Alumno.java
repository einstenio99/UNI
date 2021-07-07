import java.io.IOException;
import java.io.PrintWriter;
import java.util.Enumeration;
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
//import org.apache.hc.core5.http.HttpHeaders;
//import org.apache.hc.core5.http.io.entity.StringEntity;
import org.json.JSONArray;
import org.json.JSONObject;


/** Servlet implementation class Alumno */
public class Alumno extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/** @see HttpServlet#HttpServlet() */
	public Alumno() { super(); /* TODO Auto-generated constructor stub */ }

	/** @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response) */
	@SuppressWarnings("unchecked")
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String MyDNI = "";
		String asig = "";
		JSONArray arrayAlu = new JSONArray();
		int position = 0;
		JSONObject alu = new JSONObject();
		String dni = "";
		
		if(request.getSession().getAttribute("rol").equals("rolalu")) {
			Enumeration<String> params = request.getParameterNames();
			MyDNI = request.getSession().getAttribute("dni").toString();
			asig = params.nextElement();
		} else {
			MyDNI = request.getParameter("dni");
			asig = request.getParameter("asig");
			arrayAlu =new JSONArray(request.getParameter("alumnos"));
			position = Integer.parseInt(request.getParameter("position"));
			
			alu = arrayAlu.getJSONObject(position);
			dni = alu.getString("alumno");
			MyDNI = dni;
		}
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
				"        <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js\"></script>\n" + 
				"            \n" + 
				"        <!-- FRAMEWORK BOOTSTRAP para el estilo de la pagina-->\n" + 
				"        <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4\" crossorigin=\"anonymous\"></script>\n" + 
				"\n" + 
				"        <!-- BOOTSTRAP css-->\n" + 
				"        <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x\" crossorigin=\"anonymous\">\n" + 
				"\n" + 
				"<script type=\"text/javascript\">\n" + 
				"        function corrector(f){\n" + 
				"            nota = f.nota.value;\n" + 
				"\n" + 
				"           if(nota.length == 0){ alert('Introduzca una nota.'); return false; }" + 
				"            if(nota >= 0 && nota <=10){\n" + 
				"\n" + 	
				"                 return true;\n" + 
				"            }\n" + 
				"            else{\n" + 
				"                alert(\"Introduzca una nota entre 0 y 10.\")\n" + 
				"                return false;\n" + 
				"            }\n" + 
				"\n" + 
				"        }\n" + 
				"\n" + 
				"    function setNota(f) {\n" + 
				"        if (corrector(f)) {\n" + 
				"            $.post(\"OperacionNota?MyDNI=" + MyDNI + "&asig=\" + f.asig.value + \"&nota=\" + f.nota.value)"
				+ ".done(function(response){\n" + 
				"		$(\"#notas\").text(\"Nota: \" + response);" +
				"		$(\"#" + MyDNI + asig + "\").text(response);" +
				"		alert(\"Nota modificada a \" + response);" + 
				"		})" +
				".fail(function(jqxhr, textStatus, error ) {\n" + 
				" alert(\"No intentes modificar el código fuente! >:( \");\n" + 
				"});" +
				"        }\n" + 
				"    }"+
				"    </script>\n" +
				"<!--<script src=\"https://code.jquery.com/jquery-3.6.0.min.js\"></script>-->\n" + 
				"<script>\n" + 
				"		$(document).ready(function(){\n" + 
				"		$.getJSON(\"BuscaFoto?dni="+ MyDNI + "\")\n" + 
				"	.done(function(response){\n" + 
				"		$(\"#fotodni\").attr(\"src\", \"data:image/png;base64,\" + response.img);\n" + 
				"	})\n" + 
				"	.fail(function(jq, status, err){\n" + 
				"		alert(\"Un error ha sucedido: \" + err);\n" + 
				"	});\n" + 
				"});\n" + 
				"</script>"+
				"</head>\n" 
				+ "<body>\n" + 
				"    <div class=\"card\">\n" + 
				"        <div class=\"col-11\" id=\"nombreydni\">";

		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println(tit); 
		HttpSession sesion = request.getSession();
		List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");
		Executor executor = Executor.newInstance();
		BasicCookieStore cookie = new BasicCookieStore();
		cookie.addCookie(cookies.get(0));


		String key = sesion.getAttribute("key").toString();

		/* DESCRIPCION DEL ALUMNO */
		String infoAlum = executor.use(cookie)
				.execute(Request.get("http://" + url + ":9090/CentroEducativo/alumnos/" + MyDNI + "?key=" + key))
				.returnContent().toString();
		JSONObject thisAlum = new JSONObject(infoAlum);

		String nombre = thisAlum.getString("nombre");
		String apellidos = thisAlum.getString("apellidos");

		out.println("<h1>" + apellidos + ", " + nombre + " (" + MyDNI + ")");
		out.println("</h1>");
		out.println(" </div>\n" + 
				"    </div>\n" + 
				"        <div class=\"card\">\n" + 
				"        <p>  \n" + 
				"        <div class=\"row\">\n" + 
				"            <div class=\"col-1\"></div>\n" + 
				"            <div class=\"col-3\" id=\"foto\">");
		out.println("<p><img id=\"fotodni\" src='' alt= 'fotoDNI'></p>");
		out.println("</div>\n" + 
				"            <div class=\"col-8\" id=\"descripcion\">");
		out.println("<h5>");

		String notaAlum = executor.use(cookie)
				.execute(Request.get("http://" + url + ":9090/CentroEducativo/alumnos/" + MyDNI + "/asignaturas/?key=" + key))
				.returnContent().toString();

		JSONArray thisNotas = new JSONArray(notaAlum);

		for(int j = 0; j < thisNotas.length(); j++) {
			JSONObject asignatura = thisNotas.getJSONObject(j);
			String asignaturas = asignatura.getString("asignatura");
			if(j==0) { out.println("[Matriculad@ en: " + asignaturas); }
			else if(j== thisNotas.length()-1) { out.println("y " + asignaturas + "]"); } 
			else { out.println(", " + asignaturas); }
		}
		out.println("</h5>\n" + 
				"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." + 
				"Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor" + 
				"in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident," + 
				"sunt in culpa qui officia deserunt mollit anim id est laborum.</p>\n" + 
				"            </div>\n" + 
				"        </div></div>");

		/* DETALLES DEL ALUMNO */
		out.println("<div class=\"card text-center\">\n" + 
				"            <div class=\"card-header\">\n" + 
				"              <b>Detalles del alumno</b>\n" + 
				"            </div>\n" + 
				"            <div class=\"card-body\">\n");

		out.println("<b>Nombre: </b>" +"<span>"+ apellidos + ", " + nombre+"</span>");
		out.println("<br><b>DNI: </b>" + "<span>"+MyDNI+"</span>");
		out.println("<br><b>Asignatura: </b>" + "<span>"+asig+"</span>");
		for(int i = 0; i < thisNotas.length(); i++) {
			JSONObject temp = thisNotas.getJSONObject(i);
			String nota = temp.get("nota").toString();
			if(nota.length() == 0) { nota = "Sin calificar"; }
			if(temp.get("asignatura").toString().equals(asig)) { out.println("<br><b id=\"notas\" >Nota: " + nota +"</b>"); }

		}
		out.println("</div> </div>");
		String asigDetallesA = executor.use(cookie)
				.execute(Request.get("http://"+url+":9090/CentroEducativo/asignaturas/" + asig +"/?key=" + key))
				.returnContent().toString();
		JSONObject detallesA = new JSONObject(asigDetallesA);

		out.println("<div class=\"card text-center\">\n" + 
				"            <div class=\"card-header\">\n" + 
				"              <b>Detalles de "+detallesA.getString("nombre")+"</b>\n" + 
				"            </div>\n" + 
				"            <div class=\"card-body\">\n");
		out.println("<p style=\"text-align: left;\">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. \n" + 
				"				Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor  \n" + 
				"				in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident,  \n" + 
				"				sunt in culpa qui officia deserunt mollit anim id est laborum</p>");
		out.println("<b>Créditos:</b> " +"<span>"+ detallesA.get("creditos").toString() + "</span>");
		out.println("<br><b>Cuatrimestre:</b> " + "<span>"+detallesA.get("cuatrimestre").toString()+ "</span>");
		out.println("<br><b>Curso:</b> " + "<span>"+detallesA.get("curso").toString() + "</span>");
		out.println("</div>");

		/* CAMBIAR NOTA POR EL PROFESOR */
		if(sesion.getAttribute("rol").equals("rolpro")) {
			out.println("<div class=\"card text-center\">\n" + 
					"            <div class=\"card-header\">\n");

			String asigDetalles = executor.use(cookie)
					.execute(Request.get("http://"+url+":9090/CentroEducativo/asignaturas/" + asig +"/?key=" + key))
					.returnContent().toString();
			JSONObject detalles = new JSONObject(asigDetalles);
			String nombreD = detalles.getString("nombre");
			out.println("<b>Calificar '" + nombreD + "'</b></div>\n" + 
					"            <div class=\"card-body\">\n" + 
					"              <p><b>Modificar nota </b>(MIN 0, MAX 10)</p>\n");

			out.println("<p>\n" + 
					"<form action=\"javascript:;\" method=\"post\" onsubmit=\"void setNota(this)\">\n" + 
					"<input type=\"hidden\" name=\"MyDNI\" value=\"" +MyDNI +"\"/>"	+
					"    <input type=\"hidden\" name=\"asig\" value=" +asig+" />\n" + 
					"    <input type=\"number \" step=\".1 \" placeholder=\"Nota \" name=\"nota\" id=\"nota \">\n" + 
					"    <input type=\"submit\" value=\"Modificar Nota\">\n" + 
					"</form>\n" + 
					"</p>");	
			out.println("<p><form><input type ='button'  style='border-radius: 6px; padding: 6px; margin: 10px; font-weight: bold; color: white; background-color: gray' name = 'anterior' value = 'Anterior' id='anterior'>"
					+ "<input type ='button'  style='border-radius: 6px; padding: 6px; font-weight: bold; color: white; background-color: blue' value = 'Siguiente' name = 'siguiente' id='siguiente'></form>"
					+ "</p></div>\n" 
					+"        <div class=\"card\">\n" + 
					"        <div class=\"row\">\n" + 
					"            <div class=\"text-center\" id=\"cerrar\">"+
					"<button class='btn btn-danger' data-dismiss='modal'>&times;</button>"
					+ "</div></body></html>");

				if(position < arrayAlu.length()-1) {
				out.println("<script>\n"
						+ "    $(document).ready(function() {\n"
						+ "        $('#siguiente').click(function(event) {\n"
						+ "            var posPost =" + position + "+1;"
						+ "            // Si en vez de por post lo queremos hacer por get, cambiamos el $.post por $.get\n"
						+ "            $.get('Alumno', {\n"
						+ "              asig:'" + asig + "',"
						+ "              dni:'"+ dni + "',"
						+ "				 alumnos:'" + arrayAlu + "',"
						+ "				 position: posPost"
						+ "            }, function(responseText) {\n"
						+ "                $('#detalles').html(responseText);\n"
						+ "            });\n"
						+ "        });\n"
						+ "    });\n"
						+ "</script>");
				}
				
				if(position > 0) {
				out.println("<script>\n"
						+ "    $(document).ready(function() {\n"
						+ "        $('#anterior').click(function(event) {\n"
						+ "            var posAnt =" + position + "-1;"
						+ "            // Si en vez de por post lo queremos hacer por get, cambiamos el $.post por $.get\n"
						+ "            $.get('Alumno', {\n"
						+ "              asig:'" + asig + "',"
						+ "              dni:'"+ dni + "',"
						+ "				 alumnos:'" + arrayAlu + "',"
						+ "				 position: posAnt"
						+ "            }, function(responseText) {\n"
						+ "                $('#detalles').html(responseText);\n"
						+ "            });\n"
						+ "        });\n"
						+ "    });\n"
						+ "</script>");
				}
				
			if(position == arrayAlu.length()-1) {
				out.println("<script>\n"
		                  + "$(document).ready(function() {$('#siguiente').hide();}); \n"
		                  +"</script>" );
			}
			
			if (position == 0){
				out.println("<script>\n"
		                  + "$(document).ready(function() {$('#anterior').hide();}); \n"
		                  +"</script>" );
			}
		}
	}

	/** @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response) */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub


	}

}
