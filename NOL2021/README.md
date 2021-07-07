# <span style = "color: #0070C0"> MEMORIA APLICACIÓN NOL </span>
Se ha implantado un sistema de Notas On-line **NOL** que permite gestionar las calificaciones de los alumnos. 
- **Los alumnos:** pueden consultar sus calificaciones en las asignaturas que están matriculados
- **Los profesores:** pueden asignar puntuaciones para cada alumno matriculado en sus asignaturas

Para ello se han utilizado:
- **Logs** como filtro controlable
- **Operaciones básicas** de consulta y modificación
- Versiones **AJAX** e interacciones ágiles
- Autenticación básica **(BASIC)**
- Acabado uniforme de las páginas basado en **Bootstrap**
- Creación de **documento imprimible**

En esta aplicación interactuan 3 niveles:  
**1. Interfaz de usuario:** se lleva a cabo mediante las páginas de hipertexto devueltas por el servidor web y mostradas por el navegador del cliente.  
**2. Aplicación:** NOL, contiene la lógica para atender las solicitudes interactuando con la información disponible.  
**3. Datos:** CentroEducativo (modelo REST), mantiene los datos persistentes que ofrece al nivel de aplicación mediante el protocolo HTTP.

<a name="top"></a>
## <span style = "color: #0070C0"> Índice de contenidos </span>
1. [Información del equipo](#item1)
2. [Partes del código y/o configuración significativas](#item2)
3. [Interacción del código JavaScript con los servlets por AJAX](#item3)
4. [¿Cómo se insertan las informaciones en las páginas?](#item4)
5. [Anotaciones de accesos (logs)](#item5)
6. [¿Cómo podría desplegarse la aplicación en un ordenador distinto?](#item6)
7. [Anexo: Actas Hito 1](#item7)  
    7.1. [Acta Sesión 0](#item7.1)  
    7.2. [Acta Sesión 1](#item7.2)  
8. [Anexo: Actas y Documentación Hito 2](#item8)  
    8.1. [Acta Sesión 2](#item8.1)  
    8.2. [Acta Sesión 3](#item8.2)  
    8.3. [Documentación Escenario de consulta para una alumna](#item8.3)  
    8.4. [Documentación Escenario de consulta y modificación para un profesor](#item8.4)  
9. [Anexo: Actas Entrega Final](#item9)  
    9.1. [Acta Sesión 4](#item9.1)  
    9.2. [Acta Sesión 5](#item9.2)  
    9.3. [Acta Propuesta de Alumno a Evaluar](#item9.3) 

<a name="item1"></a>
## <span style = "color: #0070C0"> 1. Información del equipo </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>

**Turno de laboratorio:** Miércoles 2 (11:30h)

**Identificador del grupo:** 3TI12_g04

**Miembros del grupo:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Máquina de portal en la que se ha dejado instalada la aplicación:**  
El servidor usado como prototipo es el de nuestro secretario Stefan <code>dew-stemic-2021.dsic.cloud</code>.  
La página de acceso será: http://dew-stemic-2021.dsic.cloud:8080/NOL/
 
Para acceder a dicho servidor y arrancar o detener las aplicaciones debemos:

**Arrancar los servicios/aplicaciones**

1. Arrancar la máquina dew del portal de dsic accediendo a *https://portal-ng.dsic.cloud/virtual-machines/* y arrancándola.

2. Acceder a la máquina de portal utilizando el comando ssh (aunque hay más de una forma de acceder, el secretario hacía uso de esta):
    
        ssh user@dew-stemic-2021.dsic.cloud

    - Es posible que nos salga este mensaje (sale en la primera conexión que hagamos): 
        <pre>
        The authenticity of host 'dew-stemic-2021.dsic.cloud (192.168.106.155)' can't be established.
        ECDSA key fingerprint is SHA256:Yeh69+xM/bexVHnDwbgh3HNNCW4NnLPst5uWkjsgDn0.
        Are you sure you want to continue connecting (yes/no/[fingerprint])?
        </pre>
    - Respondemos con <code>yes</code> y una vez nos autentiquemos con la contraseña, estaremos dentro de la máquina de portal.

3. Arrancar el servicio CentroEducativo, en caso de que no lo tengamos en esa máquina deberemos subir el archivo que está localizado en poliformat (se puede usar el comando scp o bien acceder directamente a la máquina con el archivo rdp y descargar el servicio desde allí). El comando para "arrancar" CentroEducativo es el siguiente (debemos localizarnos previamente en el directorio que contenga el archivo .jar que contiene a CentroEducativo):

        java -jar es.upv.etsinf.ti.centroeducativo-0.2.0.jar 

    - Si todo funciona correctamente se nos devolverá al final el siguiente mensaje:
        <pre>
        Started MainApp in 23.516 seconds (JVM running for 25.141)
        </pre>
4. Subir al servidor tomcat el archivo .WAR que deseemos (igual que en el caso anterior deberemos estar previamente en el mismo directorio que el archivo a subir):

    - El servidor tomcat está en la misma máquina que el servicio CentroEducativo, no obstante, no tiene por qué ser así.

    - Deberemos indicar el directorio de la máquina donde queramos guardar el archivo, en este caso, tomcat/webapps (indicado al final de la instrucción después de ":").
    
    - Como en los puntos anteriores hay más de una forma de proceder, en este caso utilizaremos el comando scp:
        <pre>
        scp MiPaginaWeb.war user@dew-stemic-2021.dsic.cloud:tomcat/webapps
        </pre>
    - Se nos pedirá la contraseña y una vez nos autentiquemos se subirá el archivo y se nos mostrará el siguiente mensaje:
        <pre>
        MiPaginaWeb.war                                  100%  297KB   3.8MB/s   00:00    
    </pre>
5. Arrancar el servidor tomcat:

    - Como estaba mencionado anteriormente nuestro servidor está en la misma máquina de portal, por ende, deberemos crear otra conexión ssh en otro terminal (repetir el paso 2).
    <pre>
        tomcat/bin/startup.sh
    </pre>
    - Se nos devolverá la siguiente confirmación:
        <pre>
        Using CATALINA_BASE:   /home/user/tomcat
        Using CATALINA_HOME:   /home/user/tomcat
        Using CATALINA_TMPDIR: /home/user/tomcat/temp
        Using JRE_HOME:        /usr
        Using CLASSPATH:       /home/user/tomcat/bin/bootstrap.jar:/home/user/tomcat/bin/tomcat-juli.jar
        Using CATALINA_OPTS:   
        Tomcat started.
        </pre>
6. Acceder a nuestro servicio web, en este caso:

        http://dew-stemic-2021.dsic.cloud:8080/MiPaginaWeb

**Detener los servicios/aplicaciones**

El orden, en este caso, es irrelevante

1. Apagar el servidor tomcat:

        tomcat/bin/shutdown.sh

    - Se nos devolverá la siguiente confirmación:
        <pre>
        Using CATALINA_BASE:   /home/user/tomcat
        Using CATALINA_HOME:   /home/user/tomcat
        Using CATALINA_TMPDIR: /home/user/tomcat/temp
        Using JRE_HOME:        /usr
        Using CLASSPATH:       /home/user/tomcat/bin/bootstrap.jar:/home/user/tomcat/bin/tomcat-juli.jar
        Using CATALINA_OPTS:
    </pre>
2. Apagar el servicio CentroEducativo:

    - Nos servirá con pulsar "Ctrl + C" en el terminal donde lo arrancamos.


<a name="item2"></a>
## <span style = "color: #0070C0"> 2. Partes del código y/o configuración significativas </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>

### Filtro de Inicio de Sesión
Cada vez que se acceda a una página visible por el usuario se accederá a un filtro se comprobará si hay una sesión iniciada en CentroEducativo, en caso de que no, se enviará una peticion de "login" a dicho servicio (esta petición no falla debido a que se comprueba previamente en el servidor tomcat las credenciales del usuario). A la hora de enviar la petición se crea un objeto *JSON* con las credenciales, se añaden a la sesión y pedimos una llave, cuando la obtengamos, la añadimos a la sesión y añadiremos también la cookie. 

Se puede observar también que en todo nuestro código hacemos uso de la biblioteca *fluent* de Apache HttpComponents pero en el filtro no, esto es debido a que añadimos la gestión explícita de cookies en la petición es necesaria para las peticiones AJAX, (no hacen uso del navegador, quien es quien nos gestiona las cookies). La biblioteca *fluent* no nos permite añadir una cookie "personalizada" en la creación de la petición que nos permita ser guardada para peticiones futuras, solo nos permite utilizar una cookie ya existente, como se muestra en el código de una petición fluent a CentroEducativo.

```java
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
                e.printStackTrace();
            }
        }
```

### Peticiones *fluent* a CentroEducativo

Estas peticiones son muy simples y fáciles de comprender y utilizar, por eso hicimos uso de ellas, recogemos el dni, llave y cookie para hacer la/s petición/es y recogemos la información en un string que viene formateado como objeto o vector *JSON* y a partir de dicho objeto o vector utilizamos o mostramos la información según la necesidad, en el ejemplo de abajo, la información del vector "asig" la mostraremos en pantalla como las asignaturas que tiene disponibles un usuario.

```java
    HttpSession sesion = request.getSession();
    String url = request.getLocalName();
    String dni = sesion.getAttribute("dni").toString();
    String key = sesion.getAttribute("key").toString();

    List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");
    BasicCookieStore cookie = new BasicCookieStore();
    cookie.addCookie(cookies.get(0));

    String asignaturas = executor.use(cookie)
                .execute(Request.get("http://"+url+":9090/CentroEducativo/profesores/" + dni + "/asignaturas/?key=" + key))
                .returnContent().toString();
    JSONArray asig = new JSONArray(asignaturas);
```
### Interpretación de las respuestas de CentroEducativo
Continuando justo donde el punto anterior acabó a través de la petición a CentroEducativo hemos recibido un objeto JSON con las asignaturas, en este caso, como la recepción es un vector hemos decidido utilizar la biblioteca java-json en vez de gson por la facilidad de tratamiento del vector.
```java
	JSONArray array =new JSONArray(asignaturas);
		for(int i=0; i<array.length() ;i++) {
			JSONObject asig = array.getJSONObject(i);
			String acronimo = asig.getString(asigNom);
			out.println("<form  action='Asignaturas' method='GET'> "
					+ "<h2><b>" + "<input type ='submit' style='border: 0ch;' value = '" + acronimo + "' name='acronimo'></form>" + "</b></h2>");
		}
```

### Diferenciación de Roles
Para ahorrar cantidad de servlets hemos hecho uso de los roles de los usuarios tal que si un usuario es alumno se le muestra una información diferente a la que tendría si es profesor:

```java
    HttpSession sesion = request.getSession();
    String rol = sesion.getAttribute("rol").toString();
    if(rol.equals("rolpro")) {
        ....
    } else if(rol.equals("rolalu")){
        ....
    }
``` 

### Listado de alumnos
Para cada asignatura se mostrará un listado de los alumnos en esa asignatura. Se podrán ver detalles de los alumnos y modificar su nota pulsando el botón Detalles.
```java
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

                    / Acceso a la ventana de detalles del alumno (puede cambiar su nota) */
                    out.println("<form action='Alumno' method='GET'> <b>Nombre (DNI): </b>" + apellidosA + ", " + nombreA + " (" + dniAlu +  ")" + " <b>Nota: </b>" + nota
                            + " <input type ='submit' style='font-weight: bold' value = 'Detalles' name = "" + dniAlu + href + ""<br></form>");
```
### Modificar nota
El servlet OperacionNota recibe estos datos y hace 2 peticiones a CentroEducativo, una para modificar la nota y la otra para recibir las notas del alumno escogiendo la de la asignatura en concreto para modificar el elemento con id "notas" posteriormente. Una vez se haya hecho la segunda llamada a CentroEducativo el servlet pondrá como respuesta a la petición por ajax la nota en formato .txt .

```java
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
```

<a name="item3"></a>
## <span style = "color: #0070C0"> 3. Interacción del código JavaScript con los servlets por AJAX </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>

### Servlet InicioAlu e InicioProf
- **Cerrar Sesión:**
Petición AJAX **al servlet CerrarSesion**, mediante la operación invocada por GET, sin argumentos adicionales.
```java
function cerrarSesion(){
    $.ajax({
        type: "GET",
        url: window.location, 
        dataType: 'json', 
        async: true,
        username: LocalTime.now(), 
        password: LocalTime.now(), 
        data: '{ "comment" }' 
    })
    //El fallo significa que hemos tenido exito. y redirigimos al Servlet de cerrar sesión y a la página de inicio
    .fail(function(){
        $(document).ready(function() { 
            $.get('CerrarSesion', { }, function(responseText) { });
        });
        window.location.replace('index.html');
    }); 
}
```
### Servlet Asignaturas
- **Página de detalles:**
Petición AJAX **al servlet Alumno**, mediante la operación invocada por GET, con los argumentos adicionales { asig, dni, alumnos, position }.
```java
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
               + "	        alumnos:'" + array + "',"
               + "		position:'" + position + "'"
               + "            }, function(responseText) {\n"
               + "                $('#detalles').html(responseText);\n"
               + "            });\n"
               + "        });\n"
               + "    });\n"
               + "</script>");
```

### Servlet Alumno

- **Modificar nota:**
Petición AJAX **al servlet OperacionNota**, mediante la operación invocada por POST, con los argumentos adicionales { MyDNI, asig, nota }.
```java
function setNota(f){
//f es llamada por un form que contiene la información de la asignatura y de la nota previa 
	if(corrector(f)){ //comprueba si la nota es un entero positivo menor de 10.0
		$.post("OperacionNota?MyDNI=" + MyDNI + "&asig=" + f.asig.value + "&nota" + f.nota.value)
		.done(function(response){
		$("#notas").text("Nota: " + response)
		alert("Nota modificada a " + response);
		})
		.fail(function(jq, status, err){
		var error = jq.response.replace(",", "\n");
		alert("Un error ha sucedido: " + err);
		});
	}
}
```
- **Interfaz ágil profesor (anterior y siguiente):**
Petición AJAX **al servlet Alumno**, mediante la operación invocada por GET, con los argumentos adicionales { asig, dni, alumnos, position }.
```java
if(position < arrayAlu.length()-1) {
	out.println("<script>\n"
			+ "    $(document).ready(function() {\n"
			+ "        $('#siguiente').click(function(event) {\n"
			+ "            var posPost =" + position + "+1;"
			+ "            // Si en vez de por post lo queremos hacer por get, cambiamos el $.post por $.get\n"
			+ "            $.get('Alumno', {\n"
			+ "              asig:'" + asig + "',"
			+ "              dni:'"+ dni + "',"
			+ "		 alumnos:'" + arrayAlu + "',"
			+ "		 position: posPost"
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
			+ "		 alumnos:'" + arrayAlu + "',"
			+ "		 position: posAnt"
			+ "            }, function(responseText) {\n"
			+ "                $('#detalles').html(responseText);\n"
		    + "            });\n"
			+ "        });\n"
			+ "    });\n"
			+ "</script>");	
```

<a name="item4"></a>
## <span style = "color: #0070C0"> 4. ¿Cómo se insertan las informaciones en las páginas? </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>

La herramienta principal para poder mostrar información por pantalla es usando los objetos <code>Printwriter</code> los cuales muestran tanto cadenas de texto como otro tipo de objetos como enteros o propiedades de objetos *JSON*. 

```java
        String tit = "<!DOCTYPE html>\n" + 
            "<html lang=\"es\">\n" + 
            "<head>\n" + 
            "    <meta charset=\"UTF-8\">\n" + 
            "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n" + 
            "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n"; 
        PrintWriter out = response.getWriter();
        out.println(tit);
```

Como debemos mostrar mucha información que recogemos de CentroEducativo como propiedades de objetos *JSON* nuestro proceso es recoger la información y imprimirla con este método, por ejemplo mpara mostrar información de la asignatura hacemos la llamada necesaria a CentroEducativo y después una vez tengamos el objeto *JSON*:

```java
    String href = temp.getString("acronimo");
    String nombre = temp.getString("nombre");
    String curso = temp.getNumber("curso").toString();
    String cuatrimestre = temp.getString("cuatrimestre");
    String creditos = String.valueOf(temp.getFloat("creditos"));
    String id = href.toString() + "tab";

    out.println("<div class=\"tab-pane\" id=\""+href+"\" role=\"tabpanel\" aria-labelledby=\""+id+"\">"
        + "<h3>Asignatura</h3>"
        + "<b>Nombre identificativo: </b>" + href + "-" + nombre
        + "<b> Curso: </b>" + curso
        + "<b> Cuatrimestre: </b>" + cuatrimestre
        + "<b> Créditos: </b>" + creditos
        + "<br><b>Profesor/es: </b>");
```  

Cabe mencionar que, tanto en los cambios dinámicos de la página como todos los scripts de JavaScript y JQuery utilizados como deben estar implantados en el cliente se deben escribir en la página y por ende se escriben con el mismo método:

<a name="item5"></a>
## <span style = "color: #0070C0"> 5. Anotaciones de accesos (logs) </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>

Igual que en el hito primero, guardamos las anotaciones de accesos en la máquina donde se ejecute el servidor tomcat y, para no tener problemas con los permisos, guardaremos el archivo dentro de la carpeta donde esté el proyecto web, es decir, en el siguiente directorio:
<pre>
    /tomcat/webapps/El_Nombre_Del_Proyecto/WEB-INF/log.txt
</pre>

El proceso que tenemos en nuestro proyecto para almacenar las anotaciones pasa por un filtro que criba todos los servlets que sean accesibles por http. Estos estarán indicados en el archivo web.xml:

    <filter>
        <display-name>Logger</display-name>
        <filter-name>Logger</filter-name>
        <filter-class>Logger</filter-class>
    </filter>
    <filter-mapping>
    <filter-name>Logger</filter-name>
        <servlet-name>InicioAlu</servlet-name>
        <servlet-name>InicioProf</servlet-name>
        <servlet-name>Alumno</servlet-name>
        <servlet-name>Asignaturas</servlet-name>
    </filter-mapping>        

El filtro creará el archivo en caso de que no exista y si existe, lo actualizará con la anotación actual que estará compuesta por: 
    
- La fecha actual
- El usuario que esté accediendo al documento
- La dirección IP de dicho usuario
- La uri del acceso
- El nombre del servlet que esta procesando la petición del usuario
- El método de acceso

```java
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        HttpServletRequest req = (HttpServletRequest) request;
        ServletContext context = req.getServletContext();
        String pathToLog = context.getRealPath("/WEB-INF");
        File log1 = new File(pathToLog + "/log.txt");
        log1.createNewFile();  //Creo el archivo si no existe
        FileWriter log01 = new FileWriter(pathToLog + "/log.txt", true); //Abro el archivo a escribir
        String uri = req.getRequestURI();
        String ip = req.getLocalAddr();
        String user = (String) req.getSession().getAttribute("dni");
        String servl = req.getServletContext().getServletContextName();
        String method = req.getMethod();
        String date =  LocalDateTime.now().toString();
        String log_1 = date + " " + user + " " + ip + " " + uri + " " + servl + " " + method + "\n";
        log01.append(log_1); //Escribo la anotación
        log01.close();
        chain.doFilter(request, response);
    }
```

<a name="item6"></a>
## <span style = "color: #0070C0"> 6. ¿Cómo podría desplegarse la aplicación en un ordenador distinto? </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>

**¿Cómo podría desplegarse la aplicación en un ordenador distinto al utilizado por el nivel de datos (es decir, el servicio CentroEducativo)?**

En nuestro proyecto, todas las peticiones a centro educativo se completan con  <code>String url =  request.getLocalName()</code> de manera que la petición a CentroEducativo es: <code>http://" + url + ":9090/CentroEducativo/...</code>. 

Esto es debido a que el acceso a NOL se hacía a una dirección concreta que contenía nuestro usuario, de esta manera, según qué alumno accediera al servicio NOL, las peticiones a CentroEducativo se harían con su nombre de usuario de manera autiomatizada, agilizando el funcionamiento. 

**¿Y si el acceso a NOL es por *localhost*?**

En ese caso, deberemos escribiremos en la variable url de todos los servlets que hagan acceso a CentroEducativo el nombre del servicio donde esté localizado CentroEducativo tal que <code>String url = "Nombre_del_Servicio"</code>.

**¿Cómo se consigue que una usuaria pueda acceder a la aplicación web desarrollada con un identificador y una contraseña diferentes a los empleados en CentroEducativo?**   

El primer paso a realizar sería incluir a dicha alumna en el fichero <code>tomcat-users.xml</code>, con el fin de que pueda pasar el login correspondiente con su propio usuario.   

Además, debemos de utilizar un hashmap de manera que la key sea un string, el valor un array con las credenciales  <code><nombre_usuario, [dni, password]></code>, y la usuaria
pueda adquirir su token de sesión en la correspondiente base de datos.

---
---

<a name="item7"></a>
## <span style = "color: #0070C0"> 7. Anexo: Actas Hito 1 </span> <span style = "font-size:10pt;">
<a name="item7.1"></a>
## <span style = "color: #0070C0"> 7.1. Acta Sesión 0 </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Sesión 0 - Presentación y organización

### 0. Información de la reunión

**Fecha:** Miércoles, 21 de abril de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Aspectos relevantes del trabajo en grupo**  
Se ha consensuado toda la información relevante con respecto al trabajo en grupo.  
- **Comentarios sobre la expresión y síntesis**  
 Asimismo, se ha realizado la exposición de 5 minutos de cada asistente sobre los aspectos esenciales para el trabajo en equipo, cuyo objetivo ha sido conocer la facilidad de expresión y síntesis de los compañeros (facilidades y/o dificultades).
- **Nuevas tareas a preparar**  
Por último, se ha acordado la fecha de realización de las tareas a preparar para la siguiente sesión.

### 2. Aspectos relevantes del trabajo en grupo
- **Medio de contacto:** Aplicación de mensajería *Whatsapp*
- **Sistema homogenéneo de comunicación:** Plataforma Microsoft *Teams*
- **Disponibilidad periódica en el calendario:** Sesiones de laboratorio de los Miércoles a las 11:30 y reuniones extra los Domingos entre las 10:00 y la 13:00
- **Depósito de materiales:** Plataforma de desarrollo colaborativo *GitHub*
- **Criterio para evitar colisiones en el depósito:** Comunicación entre los integrantes del grupo y el uso de la herramienta GitHub la cual implementa Git, 
un software de control de versiones (fusión y conflictos) para gestionar contribuciones entre múltiples autores distribuidos (desarrolladores).

- **Reglas a cumplir:**
    - Presentarse a todas y cada una de las reuniones salvo aviso previo.
    - Comprometerse a una participación homogénea durante todo el proyecto.
    - Comprometerse a finalizar el trabajo con un resultado de calidad.
    - Respeto mútuo entre todos y cada uno de los integrantes de este grupo.

- **Situaciones en las que se puede proponer la expulsión  de algún miembro:** 
     No cumplir con al menos una de las reglas mecionadas en el apartado anterior durante un porcentaje alto del proyecto en las próximas semanas haciendo especial hincapié en las reglas segunda y cuarta.

- **Expectativas de calificación:**
    - Camarena Conde, Jorge -> Notable alto
    - Germes Sisternas, Adrian -> Notable alto
    - Michis, Stefan Vasile -> Notable alto
    - Pruñonosa Soler, Guillem -> Bien
    - Serrano López, Laura -> Sobresaliente
    - Úbeda Campos, Víctor -> Notable

    => Después de debatir las expectativas, hemos llegado al acuerdo de realizar un proyecto que aspire al notable alto. 

- **Pasos a seguir en caso de conflicto:**
    1. Informar de la disconformidad por parte del integrante disconforme de manera inmediata.
    2. Exploración de la propuesta por todos los miembros del grupo.
    3. Según el tamaño del posible cambio se debe llegar a una conclusión ese mismo día o en los próximos días posteriores.
    4. En caso de que el conflicto no venga dado por un apartado del proyecto sino por uno ajeno será la gravedad de dicho conflicto la que indique si el conflicto se deba resolver por las 2 (o más) personas participantes en este o por el grupo completo.
    
- **Secretari@:** Stefan Vasile Michis

### 3. Comentarios sobre la expresión y síntesis
Las agrupaciones han sido repartidas de la siguiente manera:

| Agrupación 1 - Apartados Comunicación, Objetivos, Resolución de Problemas | Agrupación 2 - Apartados Expectativas, BrainStoriming | Agrupación 3 - Apartados Conflictos, Gestión de Conflictos |
|:-------------------------------------------------------------------------:|:-----------------------------------------------------:|:----------------------------------------------------------:|
| Camarena Conde, Jorge                                                     | Germes Sisternas, Adrian                              | Michis, Stefan Vasile                                      |
| Pruñonosa Soler, Guillem                                                  | Serrano López, Laura                                  | Úbeda Campos, Víctor                                       |

Las siguientes tablas resumen los comentarios recibidos por el alumn@:

#### Camarena Conde, Jorge  

| <span style = "color: #00B050">Facilidades</style> | <span style = "color: #C00000">Dificultades</style> | <span style = "color: #808080">Comentado por:</style> |
|:-------------:|:--------------:|---------------------------:|
| Información clara y concisa | Explicación larga | Pruñonosa Soler, Guillem |
| Buena comunicacion | Mensaje ligeramente extenso | Germes Sisternas, Adrian |
| Mensaje conciso | Mensaje Largo | Michis, Stefan Vasile |
| Sabe centrarse en lo importante | - | Serrano López, Laura |
| Buena síntesis y expresión | Mucho tiempo de explicación | Úbeda Campos, Víctor |

#### Germes Sisternas, Adrian  
| <span style = "color: #00B050">Facilidades</style> | <span style = "color: #C00000">Dificultades</style> | <span style = "color: #808080">Comentado por:</style> |
|:-------------:|:--------------:|---------------------------:|
| Mensaje claro | - | Camarena Conde, Jorge |
| Bien Resumido | Mensaje Largo | Michis, Stefan Vasile |
| Habilidad explicativa | Falta ejemplos | Pruñonosa Soler, Guillem |
| Habla con fluidez | Explicación extensa | Serrano López, Laura |
| Facilidad de expresión | No sintetiza lo suficiente | Úbeda Campos, Víctor |

#### Michis, Stefan Vasile  
| <span style = "color: #00B050">Facilidades</style> | <span style = "color: #C00000">Dificultades</style> | <span style = "color: #808080">Comentado por:</style> |
|:-------------:|:--------------:|---------------------------:|
| Buena explicación | Poca sintesís | Camarena Conde, Jorge |
| Aportación ideas propias | Demasiados ejemplos | Pruñonosa Soler, Guillem |
| Buena capacidad de expresion | Mensaje extenso | Germes Sisternas, Adrian |
| Utiliza ejemplos | Poco resumido | Serrano López, Laura |
| Buena expresión | No sintetiza lo suficiente | Úbeda Campos, Víctor |

#### Pruñonosa Soler, Guillem  
| <span style = "color: #00B050">Facilidades</style> | <span style = "color: #C00000">Dificultades</style> | <span style = "color: #808080">Comentado por:</style> |
|:-------------:|:--------------:|---------------------------:|
| Mensaje claro | Parones | Camarena Conde, Jorge |
| Comunicacion clara | Uso de muletillas en pausas | Germes Sisternas, Adrian |
| Mensaje Claro | Un poco de bloqueo | Michis, Stefan Vasile |
| Utiliza ejemplos | Uso de la muletilla 'eh' | Serrano López, Laura |
| Buena expresión | No sintetiza lo suficiente | Úbeda Campos, Víctor |

#### Serrano López, Laura  
| <span style = "color: #00B050">Facilidades</style> | <span style = "color: #C00000">Dificultades</style> | <span style = "color: #808080">Comentado por:</style> |
|:-------------:|:--------------:|---------------------------:|
| Muy clara y concisa | - | Camarena Conde, Jorge |
| Buena capacidad de resumir | Explicacion rápida | Germes Sisternas, Adrian |
| Buena expresión | Muy rápido | Michis, Stefan Vasile |
| Explicación clara y concisa |Falta algun ejemplo| Pruñonosa Soler, Guillem |
| Buena expresión | Poco tiempo de explicación | Úbeda Campos, Víctor |

#### Úbeda Campos, Víctor  
| <span style = "color: #00B050">Facilidades</style> | <span style = "color: #C00000">Dificultades</style> | <span style = "color: #808080">Comentado por:</style> |
|:-------------:|:--------------:|---------------------------:|
| Conciso | Muletilla 'eh' | Camarena Conde, Jorge |
| Mensaje claro | Muy conciso | Germes Sisternas, Adrian |
| Mensaje con claridad | Muy resumido | Michis, Stefan Vasile |
| Aportacion ideas propias | Falta de conceptos | Pruñonosa Soler, Guillem |
| Buena síntesis | - | Serrano López, Laura |

### 4. Nuevas tareas a preparar

**Las tareas a preparar para la siguiente sesión son:**
- Creación en Eclipse de un proyecto web dinamico   
- Publicación del proyecto en la Máquina Virtual del portal  

**Fecha acordada para la realización:** Domingo 25 de Abril a las 10:00

---

<a name="item7.2"></a>
## <span style = "color: #0070C0"> 7.2. Acta Sesión 1 </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Sesión 1 - Experimentación básica

### 0. Información de la reunión

**Fecha:** Miércoles, 28 de abril de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Uso de formularios para interactuar con los servlets log**  
Se ha creado una serie de servlets log y estudiado cómo utilizar los formularios que interactuarán con los servlets log de la aplicación final.
- **Documentación necesaria para el usuario**  
Tras la realización y estudio de los servlets se ha generado una documentación de interes sobre su uso dirigida al usuario.  
- **Órdenes "Curl" (Invocaciones con detalles HTTP)**  
 También se ha estudiado una secuencia de órdenes para interactuar con la aplicación CentroEducativo. 
- **Interacciones con un servidor REST**
Además, se ha contado con la extensión RESTED para Firefox como alternativa para interactuar con la aplicación. 
- **Nuevas tareas a preparar**  
Por último, se ha acordado la fecha de realización de las tareas a preparar para la siguiente sesión.

### 2. Uso de formularios para interactuar con los servlets log
Se ha diseñado tres prototipos incrementales de log (log0, log1 y log2), los cuales han sido puestos a prueba mediante un formulario.

#### Servlet Log0

Este log tiene únicamente como función imprimir la información por pantalla en un documento html. Recogemos la toda la información en unos Strings recogiendo información del Servlet y de quién hace la petición (Request). Para obtener la fecha utilizamos el objeto <code>LocalDateTime</code> . Una vez tengamos concatenada toda la información creamos una sesión con la que guardaremos toda la información, esa sesión será sobreescrita cada vez que se envie el formulario y será lo que se escriba en el documento .html que verá el usuario.

#### Servlet Log1

Además de imprimir por pantalla la información por pantalla, este servlet guarda la información en un archivo llamado <code>logs.txt</code>. Para poder crear/modificar este archivo
utilizamos los metodos de las librerías File y FileWriter, en este servlet creamos el archivo <code>logs.txt</code> en un directorio que este dentro del servlet (en Log2 esto no será así). Podemos recoger la dirección en la que se encuentra el servlet con <code>this.getServletContext().getRealPath("/")</code>, a esta dirección añadimos o bien un directorio interior en el que deseemos guardar el servlet o bien añadimos directamente el String<code>logs.txt</code> para crearlo en ese mismo directorio. Una vez tenemos la dirección procedemos a crear/modificar el archivo. El método <code>.createFile()</code> permite comprobar si existe el archivo en dicha dirección, en caso de que no exista dicho archivo, se crea, sino, no sucede nada. FileWriter permite modificar archivos, debemos crear un objeto FileWriter con el archivo anterior y con el parametro <code>true</code> para que nos sea permitido sobreescribir el archivo. Utilizaremos el método <code>append</code> para sobreescribir.

#### Servlet Log2

La única diferencia que reside en este log es la forma de obtener la dirección en la que crear/modificar el archivo, en vez de escribirlo directamente en el código, recurrimos a <code>web.xml</code> para saber cuál es nuestra dirección. Para ello, debe hacer un parámetro en <code>web.xml</code> que nos indique cuál es el nombre del archivo y cuál es su dirección:

	  		<context-param>
    			<param-name>contextName</param-name>
    			<param-value>logs.txt</param-value>
  			</context-param>
    		<context-param>
    			<param-name>contextPath</param-name>
    			<param-value>/home/user/Escritorio/</param-value>
  			</context-param>


En este caso accedemos a un directorio que no necesita permisos de administrador para ser accedido, en caso de que intentemos acceder a un directorio que si que los necesite, en la máquina que tengamos el servidor tomcar deberemos ejecutar el script <code>startup.sh</code> con permisos de administrador, de esta forma todos los directorios serán accesibles para el servidor. 

En nuestro caso recogeremos 2 variables del <code>web.xml</code> utlizando <code>request.getInitParameter(*nombre_del_parámetro*)</code>, las sumaremos y obtendremos nuestra dirección.

### 3. Documentación necesaria para el usuario

#### Consulta de logs
Para la consulta de cualquier log simplemente es necesario un usuario y una contraseña. En este caso, cualquier par no nulo de estos valores es válido pues no está implementada la autenticación.
#### Ubicación de los ficheros generados
En el caso de Log1, la ubicación del fichero generado estará en la misma ruta de ejecución del proyecto no obstante, la ubicación del fichero generado en Log2 estará indicada en web.xml como la suma de *contextName* y *contextPath*. Ambas ubicaciones serán indicadas al generar los Logs.

### 4. Órdenes "Curl" (Invocaciones con detalles HTTP)
Con el objetivo de familiarizarse con la aplicación CentroEducativo, puesta en marcha ejecutando el comando <code>java -jar es.upv.etsinf.ti.centroeducativo-0.2.0.jar</code>, y con la ayuda de las órdenes CURL, se han emitido una serie de peticiones HTTP y observado las respuestas recibidas.  

Como ayuda, se ha empleado la documentación de la API accesible desde la página <code>/Centro/Educativo/swagger-ui.html</code>, donde se puede seleccionar una operación, consultar los detalles de la misma e incluso invocarla.

#### Inicio sesión usuario: devuelve una 'key' que sirve como 'token' que debe ser usado a lo largo de la sesión en la utilización de los métodos, como demostración de que se trata de un usuario ya identificado. ####

- Operación invocada por POST, codificando en el cuerpo del mensaje un objeto JSON con el dni y la clave del usuario.

curl -s --data '{"dni":"23456733H","password":"123456"}' \ -X POST -H "content-type: application/json" http://dew-login-2021.dsic.cloud:9090/CentroEducativo/login \ -H "accept: application/json" -c cucu -b cucu
 
    Respuesta: jtegljko24tb962ta4ehot2fn8


#### Inicio sesión administrador: devuelve una 'key' que sirve como 'token' que debe ser usado a lo largo de la sesión en la utilización de los métodos, como demostración de que se trata de un administrador ya identificado. ####

- Operación invocada por POST, codificando en el cuerpo del mensaje un objeto JSON con el dni y la clave del administrador.

curl -s --data '{"dni":"111111111","password":"654321"}' \ -X POST -H "content-type: application/json" http://dew-login-2021.dsic.cloud:9090/CentroEducativo/login \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: f13hgbri16dbv8oimm3077aom0


#### Consultar lista de alumnos: devuelve un vector JSON en el que aparece una entrada por cada alumno encontrado. Se muestra la información de dicho alumno. ####

- Operación invocada por GET, sin argumentos adicionales.

curl -s -X GET 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/alumnos?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: [{"dni":"12345678W","nombre":"Pepe","apellidos":"Garcia Sanchez"},{"dni":"23456387R","nombre":"Maria","apellidos":"Fernandez Gómez"},{"dni":"34567891F","nombre":"Miguel","apellidos":"Hernandez Llopis"},{"dni":"93847525G","nombre":"Laura","apellidos":"Benitez Torres"},{"dni":"37264096W","nombre":"Minerva","apellidos":"Alonso Pérez"}]


#### Consultar alumnos y sus asignaturas: devuelve un vector JSON en el que aparece una entrada por cada alumno encontrado. Se muestra la información de dicho alumno y las asignaturas en las que está matriculado. ####

- Operación invocada por GET, sin argumentos adicionales.

curl -s -X GET 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/alumnosyasignaturas?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: [{"apellidos":"Garcia Sanchez","password":"123456","nombre":"Pepe","asignaturas":["DEW","DCU","IAP"],"dni":"12345678W"},{"apellidos":"Fernandez Gómez","password":"123456","nombre":"Maria","asignaturas":["DCU","DEW"],"dni":"23456387R"},{"apellidos":"Hernandez Llopis","password":"123456","nombre":"Miguel","asignaturas":["DCU","IAP"],"dni":"34567891F"},{"apellidos":"Benitez Torres","password":"123456","nombre":"Laura","asignaturas":["DEW","IAP"],"dni":"93847525G"},{"apellidos":"Alonso Pérez","password":"123456","nombre":"Minerva","asignaturas":[],"dni":"37264096W"}]


#### Añadir alumno: devuelve un mensaje 'OK'. Agrega un alumno a la base de datos del centro educativo. ####

- Operación invocada por POST, codificando en el cuerpo del mensaje un objeto JSON con el apellido, dni, nombre y password del alumno.

curl -s --data '{"apellidos": "Prueba", "dni": "99999999X", "nombre": "Prueba","password": "pass"}' \ -X POST -H "content-type: application/json" 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/alumnos?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: OK


#### Matricular alumno en una asignatura: devuelve un mensaje 'OK'. Matricula al alumno en la asignatura. ####

- Operación invocada por POST, codificando en el cuerpo del mensaje el dni del alumno.

curl -s --data '99999999X' \ -X POST -H "content-type: application/json" 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/asignaturas/DEW/alumnos?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: OK


#### Consultar información de una asignatura: devuelve un objeto JSON con la información de la asignatura. ####

- Operación invocada por GET, sin argumentos adicionales.

curl -s -X GET 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/asignaturas/DEW?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: {"acronimo":"DEW","nombre":"Desarrollo Web","curso":3,"cuatrimestre":"B","creditos":4.5}


#### Consultar lista de alumnos de una asignatura: devuelve un vector JSON en el que aparece una entrada por cada alumno matriculado en la asignatura. Se muestra el dni de dicho alumno y su nota. ####

- Operación invocada por GET, sin argumentos adicionales.

curl -s -X GET 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/asignaturas/DEW/alumnos?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: [{"alumno":"12345678W","nota":""},{"alumno":"23456387R","nota":""},{"alumno":"93847525G","nota":""},{"alumno":"99995566X","nota":"0.0"}]


#### Eliminar alumno: devuelve un mensaje 'OK'. Elimina al alumno de la base de datos del centro educativo. ####

- Operación invocada por DELETE, sin argumentos adicionales.

curl -s -X DELETE 'http://dew-login-2021.dsic.cloud:9090/CentroEducativo/alumnos/99999999X?key='f13hgbri16dbv8oimm3077aom0 \ -H "accept: application/json" -c cucu -b cucu

    Respuesta: OK

### 5. Interacciones con un servidor REST

Como alternativa a las órdenes CURL, se ha contado con la extensión RESTED para Firefox. Mediante esta extensión se puede interactuar con la API REST, seleccionando método, contenido de cabeceras, etc. A continuación, se muestran dos imágenes de como se puede interactuar con CentroEducativo desde la extensión RESTED.

En la primera imagén se muestra una la operación "login", por POST, codificando en el cuerpo del mensaje un objeto JSON con el dni y clave del actor. La respuesta recibida es una confirmación con código HTTP 200. Además, devuelve una 'key' que sirve como 'token' de acceso para poder realizar consultas o modificaciones sobre Centro Educativo.

![rest1](http://personales.alumno.upv.es/jorcacon/data/rested1.png)

En esta segunda imagen se ha realizado una consulta invocada por GET, con la 'key' obtenida en el login, para obtener los alumnos que pertenecen al Centro Educativo. Como se puede observar, RESTED devuelve un objeto JSON mostrando un listado con los alumnos pertenecientes al Centro Educativo.

![rest2](http://personales.alumno.upv.es/jorcacon/data/rested2.png)

### 6. Nuevas tareas a preparar

**Las tareas a preparar para la siguiente sesión son:**
- Repasar el funcionamiento de la interacción con servicios REST (uso de CURL para operaciones automatizadas)  
- Estudiar el uso de bibliotecas JAVA para realizar interacciones con los servicios REST
- Comprender la autenticación y mantenimiento de sesiones en diferentes niveles del servicio

**Fecha acordada para la realización:** Domingo 02 de Mayo a las 10:00



<a name="item8"></a>
## <span style = "color: #0070C0"> 8. Anexo: Actas y Documentación Hito 2 </span>
<a name="item8.1"></a>
## <span style = "color: #0070C0"> 8.1. Acta Sesión 2 </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Sesión 2 - Primeras interacciones con CentroEducativo

### 0. Información de la reunión

**Fecha:** Miércoles, 05 de Mayo de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Exploración de la API del nivel de datos sobre el plugin de RESTED mediante Firefox**   
Instalación de RESTED en Firefox y comprobación de metodos GET y POST
- **Interaccionar por programa mediante bibliotecas JSON y REST**   
Interacciones mediante TheCatAPI.
- **Estudio de sesiones en los niveles de lógica y de datos**   
Se ha realizado un estudio sobre las sesiones tanto a nivel de logica como a nivel de datos. 
- **Adición automatizada mediante curl**   
Se ha desarrollado un script cuyo objetivo es poblar la base de datos.
- **Autenticación web**  
Hemos creado un proyecto cuya única función es autenticar a los usuarios.
- **Nuevas tareas a preparar**   
Por último, se ha acordado la fecha de realización de las tareas a preparar para la siguiente sesión.


### 2. Exploración de la API del nivel de datos sobre el plugin de RESTED mediante Firefox
Para realizar la exploracion de la API, lo primero que tenemos que hacer es instalar el plugin RESTED en Firefox. Para realizar las comprobaciones de los metodos GET y POST, hemos descargado el fichero <code>es.upv.etsinf.ti.centroeducativo-0.2.0.jar</code> y en su localización hemos ejecutado en terminal el siguinte comando: <code>java -jar es.upv.etsinf.ti.centroeducativo-0.2.0.jar</code>.

Con el .jar en ejecución, vamos a Firefox y al plugin RESTED. Mediante la dirección <code>http://localhost:9090/CentroEducativo/login</code> realizamos un metodo POST para iniciar sesión, tenemos que añadir en el apartado **Headers** Content-Type y application/json en los valores Name y Value respectivamente. Al realizar un metodo POST tendremos que rellenar el apartado **Request Body**, en nuestro caso el Type será JSON y name y value corresponderán al dni y password del usuario al que queremos iniciar sesión. Tras añadir estos valores, pulsamos en Send request para enviar la consulta.

Si lo hemos realizado correctamente, en este caso nos responderá con la clave del usuario que necesitaremos para realizar el resto de consultas posibles, si no es así nos devolverá error.

Una vez iniciada sesión y recibida la clave, podemos realizar los demás metodos cambiando el url y los datos asignados por los correspondientes de cada consulta.

### 3. Interaccionar por programa mediante bibliotecas JSON y REST
Las anteriores herramientas que hemos usado, el plugin RESTED y el comando curl, son simplemente una ayuda en el desarrollo de la interacción con los servicios REST. Por eso ahora
tenemos que pensar en como usar un servicio REST en nuestro programa Java. Para eso debemos centrarnos en el protocolo HTTP y en como se representaran los elementos JSON. Para ello nosotros vamos a hacer uso de la biblioteca HTTPComponents para las peticiones HTTP, y la biblioteca JSON para los JSONs.

En nuestro ejemplo tenemos una API de una página web que devuelve una foto de un gato cuando le enviamos una petición 'GET'. Para enviar esta petición y almacenar la respuesta del servidor APICat en forma de string, usamos este pequeño código que usa métodos de la libreria de HTTPComponents Fluent:

```java
String t = Request.get("https://api.thecatapi.com/v1/images/search").execute().returnContent().toString();
```
Ahora tenemos la respuesta del servidor en String, pero queremos tenerla almacenada en forma de JSON para poder extraer la información necesaria de una manera fácil y organizada.
En este caso sin embargo, el servidor no devuelve exactamente un JSON, sino que devuelve una lista de JSONs, por lo que habrá primero que crear un objeto de arrays de JSONs y luego seleccionar nuestro objeto JSON de esa lista.

```java
JSONArray o = new JSONArray(t);
JSONObject json = o.getJSONObject(0);
```

Finalmente, al tener ya la respuesta del servidor en formato JSON ya podemos hacer lo que queramos con la respuesta. En nuestro caso de ejemplo guardamos en una variable el url de la imagen del gato para enviarlo en nuestra respuesta al cliente navegador.

```java
String dato = json.get("url").toString();
out.println("<img src=" + dato + ">");
```

### 4. Estudio de sesiones en los niveles de lógica y de datos
La autenticación de sesiones en el nivel de datos y en el nivel de lógica no es idéntica, y por lo tanto es necesaria una forma de transitar entre ambas.

Para que los servlets puedan interactuar con el nivel de datos, deben poder encontrar los valores dni, password y key. Para ello se utiliza la API de servlets que permite el acceso a estos datos siemore y cuando haya una sesion abierta con estos atributos.

El codigo utilizado para que ambos niveles se comuniquen incluirá:
- Un atributo "sesion", equivalente a la sesion actual y que permite el acceso a los atributos anteriores
- Los metodos web.auth() y data.auth(), que permiten obtener el resultado de la autenticacion en el nivel de logica y el de datos respectivamente
- Un vector de usuarios "users[]" que permite relacionar ambas autenticaciones

Con estas instrucciones se puede crear un pseudocodigo que permite una comunicacion basica entre ambos niveles:

    if (!sesion.key) {
        if (login = web.auth()) { // usando getRemoteUser() 
        	sesion.dni = users[login].dni;
    		sesion.pass = users[login].password;
    		if (key = data.auth(sesion.dni, sesion.pass)) { // invocando /login por POST
    			sesion.key = key;
    		} 
    		else { error("data.auth");
    		}
    	else { error("web.auth");
    	}
    }
    // Continuar con invocación al servlet correspondiente


### 5. Adición automatizada mediante curl
Debido a que la aplicación no implementa persistencia (su reinicio conlleva la perdida de las operaciones realizadas y el retorno a la situación inicial) es importante la automatización de operaciones para poblar la base de datos. Con este fin, hemos desarrollado el script "poblador.sh" donde insertamos asignaturas, profesores y alumnos en la base de datos.   

Para realizar las inserciones nos hemos identificado con el rol administrativo de <code>dni="111111111" y password="654321"</code>. Posteriormente hemos añadido asignaturas, profesores y alumnos realizando operaciones tipo POST. Para realizar correctamente estas operaciones hay que tener en cuenta que los argumentos adicionales necesarios en cada caso son: <code>Asignaturas = {acronimo, creditos, cuatrimestre, curso, nombre}</code>, <code>Profesores = {apellidos, dni, password}</code>, <code>Alumnos = {apellidos, dni ,password}</code>. 

Un ejemplo de cada caso sería el siguiente:

	#inserción de asignaturas
	curl -s --data '{"acronimo": "RCO", "creditos": 4.5, "cuatrimestre": "A", "curso": 4, 
	"nombre": "Redes corporativas"}' \ -X POST -H "content-type: application/json" 
	'http://'$URL'.dsic.cloud:9090/CentroEducativo/asignaturas?key='$KEY 
	\ -H "accept: application/json" -c cucu -b cucu

	#inserción de profesores
	curl -s --data '{"apellidos": "apellidoPro1A apellidoPro2A", "dni": "87654321A", 
	"nombre": "profesorA","password": "123456"}' \ -X POST -H "content-type: application/json" 
	'http://'$URL'.dsic.cloud:9090/CentroEducativo/profesores?key='$KEY 
	\ -H "accept: application/json" -c cucu -b cucu

	#inserción de alumnos
	curl -s --data '{"apellidos": "apellidoAlu1A apellidoAlu2A", "dni": "12345678A", 
	"nombre": "alumnoA","password": "123456"}' \ -X POST -H "content-type: application/json" 
	'http://'$URL'.dsic.cloud:9090/CentroEducativo/alumnos?key='$KEY 
	\ -H "accept: application/json" -c cucu -b cucu

Las asignaturas, profesores y alumnos introducidos han sido los siguientes:  

	Asignatura 1 = {"acronimo": "RCO", "creditos": 4.5, "cuatrimestre": "A", "curso": 4, "nombre": "Redes corporativas"}
	Asignatura 2 = {"acronimo": "SSR", "creditos": 4.5, "cuatrimestre": "A", "curso": 4, "nombre": "Sistemas y servicios en red"}
	Asignatura 3 = {"acronimo": "SRE", "creditos": 4.5, "cuatrimestre": "A", "curso": 4, "nombre": "Seguridad en redes y sistemas informáticos"}

	Profesor 1 = {"apellidos": "apellidoPro1A apellidoPro2A", "dni": "87654321A", "nombre": "profesorA","password": "123456"}
	Profesor 2 = {"apellidos": "apellidoPro1B apellidoPro2B", "dni": "87654321B", "nombre": "profesorB","password": "123456"}
	Profesor 3 = {"apellidos": "apellidoPro1C apellidoPro2C", "dni": "87654321C", "nombre": "profesorC","password": "123456"}

	Alumno 1 = {"apellidos": "apellidoAlu1A apellidoAlu2A", "dni": "12345678A", "nombre": "alumnoA","password": "123456"}
	Alumno 2 = {"apellidos": "apellidoAlu1B apellidoAlu2B", "dni": "12345678B", "nombre": "alumnoB","password": "123456"}
	Alumno 3 = {"apellidos": "apellidoAlu1C apellidoAlu2C", "dni": "12345678C", "nombre": "alumnoC","password": "123456"}

Finalmente para comprobar que las actualizaciones se han realizado correctamente hemos realizado una consulta tipo GET para listar las asignaturas, profesores y alumnos.

### 6. Autenticación web
Para la autenticación web hemos creado un proyecto que solo tiene como función eso, autenticar. Accederemos a CentroEducativo a través de una autenticación *BASIC* en nuestro servidor tomcat que ya tiene previamente guardados todos los alumnos y profesores y una vez "crucemos ese puente" crearemos un objeto del tipo mappara guardar e indexar todos los usuarios que acceden al servicio desde el servlet, de esta manera, si necesitamos acceder a CentroEducativo podemos hacerlo indexando el map. 

Para la obtención del usuario utilizamos <code>request.getRemoteUser()</code> mientras que para obtener la contraseña nosotros encontramos 2 alternativas: Como para trabajar con un usuario en el servlet recogemos su información desde el map, dicho map tendrá que tener la información de los usuarios, una posibilidad es rellenar la información manualmente como hemos hecho en <code>tomcat-users.xml</code> de manera que cojamos la contraseña del map. Esta tarea, pero, pensábamos que sería demasiado tosca y además, muy poco escalable asi que optamos por una alternativa, el map se generaría según los usuarios que fueran entrando. Como para procesar esta información el usuario tenía que autenticarse correctamente mediante un mensaje http *BASIC* al servidor, al no tener ningún cifrado de seguridad más que la codificación en BASE64 de las credenciales de autenticación y demás, java nos permite decodificar este mensaje fácilmente de esta manera: 

```java
	String pass = request.getHeader("Authorization").substring(6); //recogemos usuario:contraseña codificados
	sun.misc.BASE64Decoder dec = new sun.misc.BASE64Decoder();  
    String passDecoded= new String(dec.decodeBuffer(pass)).substring(10); //decodificamos el mensaje y cogemos solo la contraseña
```  

Una vez tenemos tanto el usuario como la contraseña guardados en el map, comprobamos si tenemos una sesión creada ya con el usuario , contraseña y llave necesarias, en caso de que ya tengamos la sesión nuestro proceso de autenticación ya ha finalizado pero en caso contrario, tendremos que enviar un mensaje http a CentroEducativo para que nos genere una llave. En este caso hemos hecho uso de gson para el tratamiento de los objetos json y la biblioteca HttpComponents de apache para comunicarnos con el servicio REST, en concreto hemos hecho uso de la librería fluent por simplicidad del código. Para comunicarnos en <code>http://dew-milogin-2021.dsic.cloud:9090/CentroEducativo/login</code> debemos enviar un mensaje del tipo POST con un objeto json con nuestras credenciales como bien sabemos ya. La transformación a código java de formularía de la siguiente forma:

```java
	JsonObject id = new JsonObject(); //creamos el objeto json
		id.addProperty("dni", esteUser);
		id.addProperty("password", estaPass);

	StringEntity entity = new StringEntity(id.toString()); //el objeto json lo debemos poner como StringEntity porque  
                                                           //es el tipo de objeto que aceptan las peticiones en httpcomponents
	String t = Request.post("http://dew-milogin-2021.dsic.cloud:9090/CentroEducativo/login") 
	            .body(entity) //ponemos nuestro objeto
	            .setHeader(HttpHeaders.CONTENT_TYPE, "application/json") //decimos el tipo de objeto que es
	            .execute().returnContent().toString(); //ejecutamos y recogemos la respuesta pasándola a String
	session.setAttribute("key", t); //añadimos a la sesión la llave
``` 

### 7. Nuevas tareas a preparar

**Las tareas a preparar para la siguiente sesión son:**
- Revisar los escenarios de interacción de los usuarios 'estudiantes',considerando que las páginas todavía no tienen que incluir fotografías del estudiante al acceder a sus asignaturas y calificaciones
- Revisar los escenarios de interacción de los usuarios 'profesores' 

**Fecha acordada para la realización:** Domingo 09 de Mayo a las 10:00

---

<a name="item8.2"></a>
## <span style = "color: #0070C0"> 8.2. Acta Sesión 3 </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Sesión 3 - Secuencias completas con CentroEducativo

### 0. Información de la reunión

**Fecha:** Miércoles, 12 de Mayo de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Servidor usado y escenarios documentados**  
Identificación del servidor usado como prototipo y archivos de documentación.
- **Cookies**  
Necesidad de las cookies para permitir el funcionamiento de AJAX.
- **Librerias escogidas**  
Librerias escogidas para cuidar el protocolo HTTP y la representación JSON.
- **Páginas Bootstrap**  
Acabado uniforme de las páginas usando Bootstrap.
- **Nuevas tareas a preparar**  
Por último, se ha acordado la fecha de realización de las tareas a preparar para la siguiente sesión.

### 2. Servidor usado y escenarios documentados
Por una parte el servidor usado como prototipo es el de nuestro secretario Stefan <code>dew-stemic-2021.dsic.cloud</code>. 
Las librerias se encuentran importadas en el NOL.war y en el directorio <code>/home/user/tomcat/lib/</code> de la máquina.

Como es importante mantener una copia del material relevante todos disponemos del proyecto actualizado en el repositorio compartido de *Github*.

Por otra parte, los dos **escenarios documentados** son:
1. Consulta por una alumna *(explicado en <code>Escenario_Consulta_Alumna.md</code>)*
2. Profesor que califica y consulta el resultado *(explicado en <code>Escenario_ConsultaModificacion_Profesor.md</code>)*

### 3. Cookies
Es cierto que nuestro navegador gestionaría mejor las cookies que nosotros o que las librerías de por si, pero en el momento que necesitamos hacer peticiones desde un servlet a CentroEducativo sin utilizar un navegador como nuestra base necesitaremos gestionar manualmente las cookies. Para este hito no es estrictamente necesaria la implantación de las cookies pero, para la utilización de AJAX, que hará llamadas a otros servlets ignorando la infraestructura del navegador, este componente será obligatorio. 

Para gestionar las cookies hemos utlizado la bibioteca *HttpComponents* de *Apache* utlizando el método <code>BasicCookieStore()</code> que contiene una lista de las posibles cookies que tendríamos. En el filtro de autenticación usamos la librería *classic* para poder implantar las cookies.

		CloseableHttpClient httpclient = HttpClients.custom().setDefaultCookieStore(cookie).build()
		.....  
		session.setAttribute("cookie", cookie.getCookies(). 

En las demás peticiones, las cuales estarán implantadas por la librería *Fluent*, recibirán las cookies de la sesión y las pondrán en su petición.

		BasicCookieStore cookie = new BasicCookieStore();
		cookie.addCookie(cookies_de_la_sesion.get(0));  

### 4. Librerias escogidas
Las librerias se han escogido para facilitar la construcción de peticiones HTTP y recibir la respuesta, así como codificar y decodificar datos en JSON.
Las librerias utilizadas son las siguientes:

#### Protocolo HTTP ####
- **HttpComponents:** de interés para construir aplicaciones del cliente HTTP como servicios cleinte web.   

        (https://hc.apache.org/), versión 5, de la fundación Apache.
        Comienza por https://hc.apache.org/httpcomponents-client-5.0.x/quickstart.html

#### Representación JSON ####
- **Gson:** es una biblioteca de código abierto para Java que permite la serialización y deserialización entre objetos Java y su representación en notación JSON.

        (https://github.com/google/gson) de Google

- **Json-java:** es una implementación de referencia que demuestra cómo analizar documentos JSON en objetos Java y cómo generar nuevos documentos JSON a partir de las clases de Java.   

        (https://github.com/stleary/JSON-java) de www.json.org

### 5. Páginas Bootstrap
Bootstrap es una biblioteca multiplataforma o conjunto de herramientas de código abierto para diseño de sitios y aplicaciones web. 

Se ha empleado de manera sencilla para cuidar el sistema de navegación (debe ser coherente) y dar un acabado uniforme de todas las páginas.
Como ayuda se ha empleado la información de <code>https://getbootstrap.com/</code>.

Este sistema de navegación será mejorado posteriormente en las siguientes sesiones.

### 6. Nuevas tareas a preparar

**Las tareas a preparar para la siguiente sesión son:**
- Revisar cómo deben gestionarse las fotografías para que su transferencia no haga pública su localización en el servidor.
- Revisar cómo debe utilizarse jQuery/AJAX para agilizar las interacciones con el servidor.   

**Fecha acordada para la realización:** Domingo 16 de Mayo a las 10:00

---

<a name="item8.3"></a>
## <span style = "color: #0070C0"> 8.3. Documentación Escenario de consulta para una alumna </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Documentación - Escenario de consulta para una alumna 

### 0. Descripción

Abordaremos, en este caso, el escenario de ingreso a NOL 2021 de la Alumna María Fernandez Gómez con dni 23456387R. María en este caso de uso podrá ver en que asignaturas estará matriculada y la nota que tiene en dichas asignaturas.

### 1. Página de entrada y enlace a la operación

Comenzamos con la página inicial del portal NOL 2021, en este portal tendremos la opción de autenticarnos como alumno/a o como profesor/a, si intentamos iniciar sesión como alumno/a donde tendría que iniciar sesión un profesor/a, se nos denegará el acceso puesto que el servidor tomcat nos devolverá un error 403 (acceso denegado). 

![Página Inicial de NOL 2021](http://personales.alumno.upv.es/stemic/imgs_ce/nol1.png)

### 2. Autenticación web

Supongamos que María desea iniciar sesión como alumna y que ya está ingresada en el sistema. Cuando pulse el enlace se abrirá una pequeña ventana que corresponderá a una autenticación *BASIC*. Una vez pasada esta autenticación, se procederá a la obtención de una llave con la petición a CentroEducativo y con ello, instanciar la sesión.

![Autenticación BASIC](http://personales.alumno.upv.es/stemic/imgs_ce/nol2.png) 

### 3. Login con CentroEducativo y mantenimiento de la sesión

Como se ha mencionado antes, una vez tenemos la autenticación *BASIC* tendremos que generar una llave y almacenarla en una sesión para su posterior uso. En vez de hacer la consulta de comprobación de la existencia de la llave en el inicio de cada posible servlet que exista, hemos creado un filtro que hace esta función por cada página que pasemos que, además de conservar la llave en la sesión, también guardará las cookies en esta. Para poder hacer esto es necesario la librería *Classic* de *HttpComponents* en las demás situaciones, utilizaremos la librería *Fluent*.

```java
	BasicCookieStore cookie = new BasicCookieStore();
	/*....
	....  Aquí va el código restante de la autenticación, explicado en el Acta de la sesión 2
	....
	....*/
	String url = request.getLocalName();
	try (CloseableHttpClient httpclient = HttpClients.custom().setDefaultCookieStore(cookie).build()){ //añado la cookie al cliente para poder recogerla después
				HttpPost post = new HttpPost("http://"+ url +":9090/CentroEducativo/login");
				post.setEntity(entity);
				post.setHeader(HttpHeaders.CONTENT_TYPE, "application/json");
				CloseableHttpResponse resp = httpclient.execute(post);
				session.setAttribute("cookie", cookie.getCookies());
				String t = EntityUtils.toString(resp.getEntity());        		        		

				httpclient.close();

				session.setAttribute("key", t);

			}       	
```

### 4. Construcción y envío de las peticiones a CentroEducativo

Una vez María se ha autenticado en el servidor tomcat y ha pasado por el filtro para obtener su llave y cookies entrará en la página de inicio. Para que María pueda ver las asignaturas en las que está matriculada se deberá hacer una petición a CentroEducativo para recopilar dicha información: 

```java
	HttpSession sesion = request.getSession();
		String dni = sesion.getAttribute("dni").toString();
		String key = sesion.getAttribute("key").toString();
		List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");

	String asignaturas = executor.use(cookie) //
				.execute(Request.get("http://"+url+":9090/CentroEducativo/alumnos/" + dni + "/asignaturas/?key=" + key))
				.returnContent().toString();
```

Esto nos devolverá un vector de objetos del tipo JSON que deberemos procesar.

### 5. Interpretación de las respuestas de CentroEducativo

Continuando justo donde el punto anterior acabó a través de la petición a CentroEducativo hemos recibido un objeto JSON con las asignaturas, en este caso, como la recepción es un vector hemos decidido utilizar la biblioteca *java-json* en vez de *gson* por la facilidad de tratamiento del vector.

```java
	JSONArray array =new JSONArray(asignaturas);
		for(int i=0; i<array.length() ;i++) {
			JSONObject asig = array.getJSONObject(i);
			String acronimo = asig.getString(asigNom);
			out.println("<form  action='Asignaturas' method='GET'> "
					+ "<h2><b>" + "<input type ='submit' style='border: 0ch;' value = '" + acronimo + "' name='acronimo'></form>" + "</b></h2>");
		}
```

![Página Personal de María](http://personales.alumno.upv.es/stemic/imgs_ce/nol3.png)

Se generará un formulario por cada asignatura matriculada el cual llevará a otra página html que también tendrá las asignaturas pero con la nota de María en cada una de ellas y documentación de las asignaturas además, se podrán ver detalles de María pulsando el botón *Detalles*.

![Nota de María en DEW e Información de la asignatura(la nota es nula porque todas lo son al principio)](http://personales.alumno.upv.es/stemic/imgs_ce/nol4.png) 

![Detalles del perfil de María](http://personales.alumno.upv.es/stemic/imgs_ce/nol5.png) 

### 6. Construcción y retorno de las páginas HTML de respuesta

La construcción de las páginas HTML de respuesta será totalmente por PrintWriter teniendo en cuenta que se deberán hacer cambios en la construcción de dichos documentos para la implementación de JQuery y AJAX. Cabe decir que para una correcta construcción hemos implantado Boostrap en las páginas.

---

<a name="item8.4"></a>
## <span style = "color: #0070C0"> 8.4. Documentación Escenario de consulta y modificación para un profesor </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Documentación - Escenario de consulta y modificación para un profesor

### 0. Descripción

Trataremos en este documento el escenario de funcionamiento de NOL 2021 en el caso de ingreso de un profesor. Para ello usaremos como ejemplo al Profesor Pedro Valderas con  dni 10293756L. Con el fin de poder modificar las notas de sus alumnos el profesor podrá ver en que asignaturas imparte docencia y posteriormente los alumnos matriculados en dichas asignaturas pudiendo añadirles una nota a cada uno de ellos.

### 1. Página de entrada y enlace a la operación

Comenzamos con la página inicial del portal NOL 2021, en este portal tendremos la opción de autenticarnos como alumno/a o como profesor/a, si intentamos iniciar sesión como profesor/a donde tendría que iniciar sesión un alumno/a, se nos denegará el acceso puesto que el servidor tomcat nos devolverá un error 403 (acceso denegado). 

![Página Inicial de NOL 2021](http://personales.alumno.upv.es/jorcacon/data/inicio.png)

### 2. Autenticación web

Supongamos que Pedro desea iniciar sesión como profesor y que ya está ingresada en el sistema. Cuando pulse el enlace se abrirá una pequeña ventana que corresponderá a una autenticación *BASIC*. Una vez pasada esta autenticación, se procederá a la obtención de una llave con la petición a CentroEducativo y con ello, instanciar la sesión.

![Autenticación BASIC](http://personales.alumno.upv.es/jorcacon/data/basic.png) 

### 3. Login con CentroEducativo y mantenimiento de la sesión

Como se ha mencionado antes, una vez tenemos la autenticación *BASIC* tendremos que generar una llave y almacenarla en una sesión para su posterior uso. En vez de hacer la consulta de comprobación de la existencia de la llave en el inicio de cada posible servlet que exista, hemos creado un filtro que hace esta función por cada página que pasemos que, además de conservar la llave en la sesión, también guardará las cookies en esta. Para poder hacer esto es necesario la librería *Classic* de *HttpComponents* en las demás situaciones, utilizaremos la librería *Fluent*.

```java
	BasicCookieStore cookie = new BasicCookieStore();
	/*....
	....  Aquí va el código restante de la autenticación, explicado en el Acta de la sesión 2
	....
	....*/
	String url = request.getLocalName();
	try (CloseableHttpClient httpclient = HttpClients.custom().setDefaultCookieStore(cookie).build()){ //añado la cookie al cliente para poder recogerla después
				HttpPost post = new HttpPost("http://"+ url +":9090/CentroEducativo/login");
				post.setEntity(entity);
				post.setHeader(HttpHeaders.CONTENT_TYPE, "application/json");
				CloseableHttpResponse resp = httpclient.execute(post);
				session.setAttribute("cookie", cookie.getCookies());
				String t = EntityUtils.toString(resp.getEntity());        		        		

				httpclient.close();

				session.setAttribute("key", t);

			}       	
```

### 4. Construcción y envío de las peticiones a CentroEducativo

Una vez Pedro se ha autenticado en el servidor tomcat y ha pasado por el filtro para obtener su llave y cookies entrará en la página de inicio. Para que Pedro pueda ver las asignaturas que imparte se deberá hacer una petición a CentroEducativo para recopilar dicha información: 

```java
	HttpSession sesion = request.getSession();
		String dni = sesion.getAttribute("dni").toString();
		String key = sesion.getAttribute("key").toString();
		List<Cookie> cookies = (List<Cookie>) sesion.getAttribute("cookie");

	String asignaturas = executor.use(cookie) //
				.execute(Request.get("http://"+url+":9090/CentroEducativo/profesores/" + dni + "/asignaturas/?key=" + key))
				.returnContent().toString();
```

Esto nos devolverá un vector de objetos del tipo JSON que deberemos procesar.

### 5. Interpretación de las respuestas de CentroEducativo

Continuando justo donde el punto anterior acabó a través de la petición a CentroEducativo hemos recibido un objeto JSON con las asignaturas, en este caso, como la recepción es un vector hemos decidido utilizar la biblioteca *java-json* en vez de *gson* por la facilidad de tratamiento del vector.

```java
	JSONArray array =new JSONArray(asignaturas);
		for(int i=0; i<array.length() ;i++) {
			JSONObject asig = array.getJSONObject(i);
			String acronimo = asig.getString(asigNom);
			out.println("<form  action='Asignaturas' method='GET'> "
					+ "<h2><b>" + "<input type ='submit' style='border: 0ch;' value = '" + acronimo + "' name='acronimo'></form>" + "</b></h2>");
		}
```

![Página Personal de Pedro](http://personales.alumno.upv.es/jorcacon/data/asignaturas.png)

Se generará un formulario por cada asignatura que imparte y le llevará a otra página html que también tendrá la documentación de las asignaturas.

![Cards de Pedro](http://personales.alumno.upv.es/jorcacon/data/tarjetas.png)

Para cada asignatura se mostrará un listado de los alumnos en esa asignatura:
```java
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

                    / Acceso a la ventana de detalles del alumno (puede cambiar su nota) */
                    out.println("<form action='Alumno' method='GET'> <b>Nombre (DNI): </b>" + apellidosA + ", " + nombreA + " (" + dniAlu +  ")" + " <b>Nota: </b>" + nota
                            + " <input type ='submit' style='font-weight: bold' value = 'Detalles' name = "" + dniAlu + href + ""<br></form>");
```

Se podrán ver detalles de los alumnos y modificar su nota pulsando el botón Detalles.

![Modificar nota1](http://personales.alumno.upv.es/jorcacon/data/nota-bien.png)

Cuando la nota es correctamente actualizada devuelve al profesor a la página anterior.

![Modificar nota2](http://personales.alumno.upv.es/jorcacon/data/foto.png)

En caso de cualquier error, el usuario es informado.

### 6. Construcción y retorno de las páginas HTML de respuesta

La construcción de las páginas HTML de respuesta será totalmente por PrintWriter teniendo en cuenta que se deberán hacer cambios en la construcción de dichos documentos para la implementación de JQuery y AJAX. Cabe decir que para una correcta construcción hemos implantado Boostrap en las páginas.



<a name="item9"></a>
## <span style = "color: #0070C0"> 9. Anexo: Actas Entrega Final </span>
<a name="item9.1"></a>
## <span style = "color: #0070C0"> 9.1. Acta Sesión 4 </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Sesión 4 - Algunas piezas específicas

### 0. Información de la reunión

**Fecha:** Miércoles, 19 de Mayo de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Añadido de imágenes (El probelma de las imágenes y la seguridad)**   
Uso de jquery para buscar las fotos de los alumnos.
- **Alumna consulta expediente con un diseño adecuado para imprimir**   
Creación de una página con un formato apto para su impresión.
- **Modificaciones respecto al caso de uso de modificar una/s nota/s por parte del profesor**   
Modificación de las notas mediante ajax.
- **Profesor califica a múltiples alumnos de una asignatura (interfaz ágil)**  
Interfaz ágil para calificar alumnos por el profesor.
- **Nuevas tareas a preparar**   
Por último, se ha acordado la fecha de realización de las tareas a preparar para la siguiente sesión.

### 2. Añadido de imágenes (El probelma de las imágenes y la seguridad)
A la hora de añadir las imágenes hemos utlizado jquery para hacer una llamada a un servlet llamado *BuscaFoto* que se encarga de buscar la foto en una carpeta almacenada en WEB-INF que contiene tantas fotos como usuarios actualmente en el sistema identificadas por su DNI. La petición al servlet devuelve un objeto JSON con la imágen codificada (y no con un enlace con su nombre) en base 64 de manera que no se pueda saber el DNI de un usuario a partir de la imágen. Respecto al código utlizado hemos plagiado prácticamente el código del documento "Especificación Trabajo Grupo NOL" en el punto 13 que hace referencia a este tema.

### 3. Alumna consulta expediente con un diseño adecuado para imprimir
Para que una alumna pueda ver su expediente debe iniciar sesión en NOL y en el menú tendrá como última opción un botón que permitirá consultar dicho expediente. Cuando acceda verá un documento html formateado para que tenga la apariencia de un "diploma". Se mostrará un texto descriptivo, su foto, las asignaturas en las que está matriculada y las consiguientes notas (en caso de que no tenga estarán marcadas como "Sin calificar").

![Expediente Alumna](http://personales.alumno.upv.es/stemic/imgs_ce/foto_consulta_alu.png) 

### 4. Modificaciones respecto al caso de uso de modificar una/s nota/s por parte del profesor
La primera modificación que hemos hecho es que la modificación de la nota sea hecha con ajax de manera que no haya ningún tipo de redirección una vez esta haya sido modificada, para ello, hemos hecho una llamada por post a *OperacionNota* que recibe como argumentos en dni del usuario , la asignatura en la que cursa el alumno y la nota a modificar en *CentroEducativo*:
```java
function setNota(f){
//f es llamada por un form que contiene la información de la asignatura y de la nota previa 
	if(corrector(f)){ //comprueba si la nota es un entero positivo menor de 10.0
		$.post("OperacionNota?MyDNI=" + MyDNI + "&asig=" + f.asig.value + "&nota" + f.nota.value)
		.done(function(response){
		$("#notas").text("Nota: " + response)
		alert("Nota modificada a " + response);
		})
		.fail(function(jq, status, err){
		var error = jq.response.replace(",", "\n");
		alert("Un error ha sucedido: " + err);
		});
	}
}
```
El servlet *OperacionNota* recibe estos datos y hace 2 peticiones a *CentroEducativo*, una para modificar la nota y la otra para recibir las notas del alumno escogiendo la de la asignatura en concreto para modificar el elemento con id "notas" posteriormente. Una vez se haya hecho la segunda llamada a *CentroEducativo* el servlet pondrá como respuesta a la petición por ajax la nota en formato .txt .
```java
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
```

### 5. Profesor califica a múltiples alumnos de una asignatura (interfaz ágil)

Con el objetivo de que un profesor pueda consultar o modificar la nota obtenida de multiples alumnos de las asignaturas que imparte de manera sencilla, hemos diseñado la siguiente interfaz ágil. Para ello cargamos todos los datos en el navegador, facilitando el recorrido entre los alumnos y volcando las modificaciones al servidor. 

![Vista Profesor](http://personales.alumno.upv.es/jorcacon/data/profesor.png)

El servlet *Asignaturas* es el encargado de listar las asignaturas en las que imparte docencia el profesor.Para cada asignatura se muestra un listado de los alumnos matriculados en ella. Clincando sobre el botón *Detalles* generamos un ventana modal, la cual obtiene los datos mediante una petición ajax al servlet *Alumno*, donde el profesor puede modificar la nota del alumno.  

En la petición ajax, pasamos una serie de parámetros, entre los cuales cabe destacar el array llamado **alumnos** el cual contiene todos los alumnos de la asignatura y la posición en la variable **position** en la que nos encontramos en el momento de la invocación.

```java
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
```
En el servlet *Alumno* con tal de dar funcionalidad a interfaz ágil, creamos los botones anterior y siguiente. Estos botones realizan una llamada al mismo servlet. En el caso de siguiente aumentamos la varible **position** en la que nos encontramos del array y en el caso de anterior la disminuimos.

```java
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
```	
En la llamada ajax al servlet *Alumno* también ocultamos los botones anterior, cuando estamos en el primer alumno de la lista, y botón siguiente cuando no quedan más alumnos por calificar.

```java				
if(position == arrayAlu.length()-1) {
	out.println("<script>\n"
		          + "$(document).ready(function() {$('#siguiente').hide();}); \n"
		          + "</script>" );
}			
			
if (position == 0){
	out.println("<script>\n"
		           + "$(document).ready(function() {$('#anterior').hide();}); \n"
		           +"</script>" );
}			
```

### 6. Nuevas tareas a preparar

**Las tareas a preparar para la siguiente sesión son:**
- Estudiar si los servlets implantan la funcionalidad para la que han sido diseñados
- Revisar que la lógica de los servlets impide a cada usuario acceder a información a la que no debería tener acceso
- Reflexionar sobre el comportamiento de nuestra aplicación cuando haya acessos concurrentes sobre un elemento 

**Fecha acordada para la realización:**  Domingo 23 de Mayo a las 10:00

---

<a name="item9.2"></a>
## <span style = "color: #0070C0"> 9.2. Acta Sesión 5 </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Sesión 5 - Finalizando

### 0. Información de la reunión

**Fecha:** Miércoles, 26 de Mayo de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Implantación de un Log como filtro a todos los servlets accesibles**    
Explicación de la tercera versión del log de antoaciones sobre lo accesos.
- **Comprobaciones de funcionalidad y seguridad**    
Resolución de los problemas de seguridad de la aplicación.
- **Un alumno consulta calificaciones mientras el profesor las introduce**     
Reflexión sobre como sería el código del primer escenario extremo.
- **Dos profesores califican simultáneamente a los mismos alumnos en la misma asignatura**     
Reflexión sobre como sería el código del segundo escenario extremo.
- **Nuevas tareas a preparar**     
Por último, se ha acordado la fecha de realización de las tareas a preparar para la entrega final.

### 2. Implantación de un Log como filtro a todos los servlets accesibles
Esta resolución resultó tener poca dificultad dado que el código *Log3* que queríamos implementar es una modificación ligera de *Log2* donde hemos de utilizar el método <code>HttpServletRequest req = (HttpServletRequest) request;</code> para poder utilizar los métodos de HttpServlet como <code>GetRequestURI()</code>. El código restante es exáctamente igual. Hemos decidido guardar el Log en la carpeta WEB-INF

### 3. Comprobaciones de funcionalidad y seguridad

#### Acceso de un alumno a datos de otro
El primer problema de seguridad era el de que un alumno pudiera acceder a los datos de otro alumno cambiando su dni por otro en la URL.

Este problema lo hemos podido resolver eliminando el paso de parámetros en el formulario. De otra forma conseguimos ese mismo paso de parámetros pero a través de variables de la sesión. 

En otros casos, el problema ha sido resuelto, gracias la utilización de peticiones ajax en vez de cargar una nueva página html, ya que evitamos la necesidad de pasar parámetros a través del formulario.

#### Invocación desde un rol a operaciones de otro
El segundo problema, era que se pudieran hacer invocaciones especificas de un rol, desde otro rol. 

Este problema se ha solucionado, definiendo restricciones de seguridad en el web.xml, mediante <code><security-constraint\></code>, y así restringir el acceso a las páginas a únicamente el rol especificado. 

### 4. Un alumno consulta calificaciones mientras el profesor las introduce
#### ¿Debe ser consciente del cambio?, ¿cuál es el coste?
Un/a alumno/a tiene el derecho a poder ver su nota actual si lo desea y en caso de que se modifique debería ser notificado de ello.

 Hay varias formas de conseguir este objetivo, por ejemplo, se puede enviar un correo automatizado con la nota pero eso está fuera de nuestro alcance. Hay una manera de hacer saber a el/la alumno/a mientras está consultando su nota si ha sido modificada o no.  

 En nuestro servlet tenemos una petición ajax que nos devuelve un objeto JSON con la nota que tiene el alumno en el instante de la petición, si dicha petición la metemos dentro de un intervalo de, por ejemplo, medio segundo, podremos saber con un retardo máximo de ese medio segundo si la nota ha sido modificada o no, por ende, si en una petición del intervalo la nota recibida es diferente a la anterior, se notifica a el/la alumno/a y se actualiza en el documento html. 
 
 Este método obviamente tiene un mayor consumo de recursos pero como la petición recoge un objeto JSON muy pequeño no creemos que añadir el intervalo fuese algo que ralentizase la web en gran medida.

### 5. Dos profesores califican simultáneamente a los mismos alumnos en la misma asignatura
#### ¿Tiene una solución sencilla?

Este escenario no presenta una solución sencilla, sin embargo, hemos pensado en lo que sería una posible solución.

Podríamos crear un filtro para el servlet *OperacionNota*, a través del cual podríamos saber si alguien está modificando una nota en ese preciso momento. Cuando el filtro este activado se mostraría un icono con un mensaje "las notas están siendo modificadas", desaparecerá cuando el filtro no este activo.

Para llevar esto a cabo, sería necesario, un estudio profundo sobre el funcionamiento y uso de los filtros, así como el estudio de sus limitaciones y problemas.

### 6. Nuevas tareas a preparar

**Las tareas a preparar para la entrega final:**
- Redactar el documento explicativo del trabajo realizado, que informe explícitamente sobre el nivel de consecución de cada elemento o versión

**Fecha acordada para la realización:**  Domingo 30 de Mayo a las 10:00 y  Domingo 6 de Junio a las 10:00

---

<a name="item9.3"></a>
## <span style = "color: #0070C0"> 9.3. Acta Propuesta de Alumno a Evaluar </span> <span style = "font-size:10pt;"> [[Ir al índice]](#top) </span>
## Acta Propuesta de Alumno a Evaluar

### 0. Información de la reunión

**Fecha:** Domingo, 23 de Mayo de 2021 

**Hora:** 11:30 

**Identificador del grupo:** 3TI12_g04

**Tipo de reunión:** Online

**Ubicación:** Plataforma Microsoft *Teams* en el equipo ‘DEW – 3TI12_g04’ 

**Asistentes:**   
Camarena Conde, Jorge  
Germes Sisternas, Adrian  
Michis, Stefan Vasile  
Pruñonosa Soler, Guillem  
Serrano López, Laura  
Úbeda Campos, Víctor

**Documento firmado por:**   
        
    Stefan Vasile Michis  
    Secretario

### 1. Resumen
- **Elección del alumno:**  

    Stefan Vasile Michis

- **Login:**

    stemic

- **Correo:** 

    stemic@inf.upv.es

### 2. Elección del alumno
El secretario se presentó como único voluntario  a hacer el examen.
