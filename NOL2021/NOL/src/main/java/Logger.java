

import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import java.time.LocalDateTime;
import java.io.FileWriter;
import java.io.File;

/**
 * Servlet Filter implementation class Logger
 */
public class Logger implements Filter {

    /**
     * Default constructor. 
     */
    public Logger() {
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
		HttpServletRequest req = (HttpServletRequest) request;
		ServletContext context = req.getServletContext();
        String pathToLog = context.getRealPath("/WEB-INF");
        File log1 = new File(pathToLog + "/log.txt");
		log1.createNewFile();
		FileWriter log01 = new FileWriter(pathToLog + "/log.txt", true);
		String uri = req.getRequestURI();
		String ip = req.getLocalAddr();
		String user = (String) req.getSession().getAttribute("dni");
		String servl = req.getServletContext().getServletContextName();
		String method = req.getMethod();
		String date =  LocalDateTime.now().toString();
		String log_1 = date + " " + user + " " + ip + " " + uri + " " + servl + " " + method + "\n";
		log01.append(log_1);
		log01.close();
		HttpSession session = req.getSession();
		session.setAttribute("log", pathToLog + "/log.txt");
		chain.doFilter(request, response);
	}

	/**
	 * @see Filter#init(FilterConfig)
	 */
	public void init(FilterConfig fConfig) throws ServletException {
		// TODO Auto-generated method stub
	}

}
