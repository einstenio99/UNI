

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import java.util.Base64;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
//import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.hc.client5.http.classic.methods.HttpPost;
import org.apache.hc.client5.http.cookie.BasicCookieStore;
import org.apache.hc.client5.http.impl.classic.CloseableHttpClient;
import org.apache.hc.client5.http.impl.classic.CloseableHttpResponse;
import org.apache.hc.client5.http.impl.classic.HttpClients;
import org.apache.hc.core5.http.HttpHeaders;
import org.apache.hc.core5.http.ParseException;
import org.apache.hc.core5.http.io.entity.EntityUtils;
import org.apache.hc.core5.http.io.entity.StringEntity;
import org.json.JSONObject;

/**
 * Servlet Filter implementation class AuthFilter
 */
public class AuthFilter implements Filter {
	Map<String, String[]> users = new HashMap<>();
	/**
	 * Default constructor. 
	 */
	public AuthFilter() {
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see Filter#destroy()
	 */
	public void destroy() {
		// TODO Auto-generated method stub
	}

	/**
	 * @see Filter#doFilter(ServletRequest, ServletResponse, FilterChain)
	 */
	public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
		// TODO Auto-generated method stub
		// place your code here
		String [] temp = {"", ""};
		BasicCookieStore cookie = new BasicCookieStore();
		HttpServletRequest req = (HttpServletRequest) request;
		//HttpServletResponse rep = (HttpServletResponse) response;
		HttpSession session = req.getSession(true);

		String user = req.getRemoteUser();

		String pass = req.getHeader("Authorization").substring(6);
		
		byte[] decodedBytes = Base64.getDecoder().decode(pass);
		String passDecoded = new String(decodedBytes).substring(10);

		if(!users.containsKey(user)) {
			temp[0] = user;
			temp[1] = passDecoded;
			users.put(user, temp);
		}

		String esteUser = users.get(user)[0];
		String estaPass = users.get(user)[1];

		if(session.isNew() || session.getAttribute("key") == null) {
			session.setAttribute("dni", esteUser);
			session.setAttribute("pass", estaPass);
			JSONObject id = new JSONObject();
			id.put("dni", esteUser);
			id.put("password", estaPass);
			StringEntity entity = new StringEntity(id.toString());
			String url = request.getLocalName();
		

			try (CloseableHttpClient httpclient = HttpClients.custom().setDefaultCookieStore(cookie).build()){
				HttpPost post = new HttpPost("http://"+ url +":9090/CentroEducativo/login");
				post.setEntity(entity);
				post.setHeader(HttpHeaders.CONTENT_TYPE, "application/json");
				CloseableHttpResponse resp = httpclient.execute(post);
				session.setAttribute("cookie", cookie.getCookies());
				String t = EntityUtils.toString(resp.getEntity());        		        		

				httpclient.close();

				session.setAttribute("key", t);

			}       	
			catch (ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		// pass the request along the filter chain
		chain.doFilter(request, response);
	}

	/**
	 * @see Filter#init(FilterConfig)
	 */
	public void init(FilterConfig fConfig) throws ServletException {
		// TODO Auto-generated method stub
	}

}
