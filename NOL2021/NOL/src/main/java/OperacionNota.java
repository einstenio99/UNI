

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
import org.apache.hc.core5.http.HttpHeaders;
import org.apache.hc.core5.http.io.entity.StringEntity;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 * Servlet implementation class OperacionNota
 */
public class OperacionNota extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public OperacionNota() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		//El get no lo he usado, se peude usar si quereis pero
	
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		// Recogiendo la info de Alumno hago el PUT, una vez tengo el put hecho, hago un get de la nota y la actualizo en el ajax
		HttpSession s = request.getSession();
		PrintWriter out = response.getWriter();
		String clave = s.getAttribute("key").toString();
		String url = request.getLocalName();
		@SuppressWarnings("unchecked")
		List<Cookie> cookies = (List<Cookie>) s.getAttribute("cookie");
		Executor executor = Executor.newInstance();
		BasicCookieStore cookie = new BasicCookieStore();
		cookie.addCookie(cookies.get(0));
		String MyDNI = request.getParameter("MyDNI").toString();
		String asig = request.getParameter("asig").toString();
		String NotaC = request.getParameter("nota").toString();
		double notaCom = Double.parseDouble(NotaC);
		if(notaCom < 0 || notaCom >10) {
			response.sendError(401);
			return;
		}
		StringEntity notaT = new StringEntity(NotaC);
		executor.use(cookie).execute(Request.put("http://" + url + ":9090/CentroEducativo/alumnos/" + MyDNI + "/asignaturas/" + asig + "/?key=" + clave)
				.body(notaT)
				.setHeader(HttpHeaders.CONTENT_TYPE, "application/json"))
		.returnContent().toString();
		
		
		String det = executor.use(cookie)
				.execute(Request.get("http://" + url + ":9090/CentroEducativo/alumnos/" + MyDNI + "/asignaturas/?key=" + clave))
				.returnContent().toString();
		
		JSONArray thisNotas = new JSONArray(det);
		
		for(int i = 0; i < thisNotas.length(); i++) {
			JSONObject temp = thisNotas.getJSONObject(i);
			String nota = temp.get("nota").toString();
			if(temp.get("asignatura").toString().equals(asig)) { 
				out.print(nota);
				out.close(); 
			}
		}
		
		/*request.setAttribute("acro", asig);
		RequestDispatcher rd= getServletContext().getRequestDispatcher("/Asignaturas");
		rd.forward(request, response);*/

	}

}
