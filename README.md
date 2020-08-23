# ProyectoSlime
## Proyecto final - Taller 6 / Scripting
por:
<br>Julian Jaramillo Vargas - 00038586 - Julian.JaramilloV@upb.edu.co
<br>Nicolás Escobar Espinosa – 000366591 – Nicolas.EscobarE@upb.edu.co
<br>Santiago Cortes – 000368733 – Santiago.Cortes@upb.edu.co
<br>Juan Camilo Calvache Giraldo - 000085476 - juan.calvache@upb.edu.co

### Instrucciones de juego
##### Objetivo
La finalidad del juego es ayudar a la caja color azul, a desplazarse a un punto del mapa sin que algún obstaculo colisione con ella, para limpiar el escenario solo se posee un tiempo que al llegar a cero la ciratura comenzará a caminar indiscriminadamente pueda o no pasar. Actualmente solo exiten 7 niveles jugables  que se desbloquean conforme el juego avanza.

##### Controles
El juego en el estado actual solamente posee 4 botones que serán el centro de su funcionamiento:
<br>Joystick: Al lado izquierdo se encuentra el joystick con el cual el personaje principal se puede desplazar por el entorno.
<br>Boton Vacio: Este botón es el que permite interacionar con los objetos en el escenario para poder resolver el puzzle.
<br>Restar: Reinicia el nivel desde el inicio.
<br>Go: Inicia el juego antes que el reloj llegue a cero de ser necesario.

##### Elementos de juego
Estos elementos proximamente serán remplazados pos modelos 3D que representen cada uno, por ahora son cajas o cubos que permiten probar el loop central del juego:
<br>Caja azul: Personaje aliado que debe alcanzar el punto final para poder superar el nivel.
<br>Caja café: Caja de madera que impide el paso, para solucionarlo debes acercarte pulzar el boton accion, sostenerlo mientras te mueves, y empujarla o arrastrarla hasta algún pozo.
<br>Pozo: Hueco negro que impide tu paso o el de la caja azul, para solucionarlo debes llevar la caja café hasta el pozo.
<br>Caja gris: Caja de metal que impide el paso, para solucionarlo debes acercase y pulzar el boton de acción hasta que desaparezca.
<br>Esfera: Cirulo que activa un mecanismo para bajar el muro que es un rectángulo azul tipo puerta, para activarlo simplemente debes acercarte a la esfera y oprimir el boton acción.
<br>Caja roja: Enemigo que si detecta la caja azul se pierde el nivel, se puede desviar de su punto actual o obstruir su visión con una caja de madera al frente.
<br>Rectángulo naranja: Lugar donde debe estar el enemigo, para llevarlo hasta esta ubicación se debe acercar a este retángulo y oprimir el boton de acción.

### Bugs
Estos errores son falencia que aparecieron durante el desarrollo o diseño del juego, en el estado actual del juego estos son los posibles fallos:
<br>El menu principal de selección de niveles puede que no se ajuste a la resolución de la pantalla del teléfono, puedo o no ocurrir y no hay manera de evitarlo.

#### Bugs tipo C
Estos errores son visuales que no alteran el flujo del juego.

#### Bugs tipo B
Errores menores que pueden llegar a alterar la experiencia y el flujo del juego, pero se pueden ignorar.
<br>Hay ocasiones en las que el personaje gana mas velocidad y se desplaza mas en una dierccion, esto pasa cuando tiene la caja agarrada. Actualmente no hay solución alguna al error ni manera de evitarlo.
<br>Al momento de terminar un nivel, si se coloca a repetir el mismo nivel se irán desbloqueando los niveles siguientes sin necesidad de pasar el anterior al desbloqueado, osea que si se repite el primer nivel muchas veces, se puede llegar a desbloquear el primer mundo tutorial por completo; al ser un exploit no se puede evitar por ahora pero se puede no hacer.

#### Bugs tipo A
Este tipo de error cancela completamente el flujo del juego impidiendo continuar en el estado actual del juego, algunas veces este error con reiniciar la app es suficiente pero no es seguro.
<br>Aveces la caja se queda adherida al personaje aun cuando lo sueltas, para solucionarlo se debe reiniciar el nivel completo.
<nr>Se tuvo un problema con el raycast en el cual a veces se detectaba la caja y luego no (se volvía un luz intermitente y no pérmitia poner la caja como obstáculo), este problema parece aparecer en algunos dispositivos y en otros no, esto imposibilita terminar el juego y no hay manera de evitarlo.

### Documentación
Todos los archivos que evidencian el proceso de diseño y desarrollo del juego se encuentran alojados den la siguiente carpeta de google drive, tambien dentro de la carpeta se podrá acceder a cada versión contruida o "Build" del juego las cuales se deben probar en un dispositivo movil android(Mínimo android 4.4).
<br>Link de acceso:
<br>https://drive.google.com/drive/folders/1iaPnqDLhX-hQOxncur0PhAk0RiJ7sHmB?usp=sharing


### Declaración de terceros
El proyecto acontinuación posee una colección de elemetos artisticos, esteticos, funcionales, etc; que facilita el fujo de trabajo y que permiten obtener un producto con acabados finales mucho mas estéticos. Al no tener una inversión monetaria o de tiempo, se hace uso de elementos artísticos que no pertenecen legalmente a algún integrante del grupo, pero que su autor original permite utilizar con finalidades lúdicas, académicas e incluso, comerciales; el requerimento que aquí se cumple es devolver los respectivos créditos a cada autor de su producto.

#### Plugins
##### Joystick Pack
El plugin "Joystick Pack" es una ayuda adicional, es simplemente un conjunto de librerías que permiten agregar un imput gráfico para dispositivos móviles con pantallas táctiles; el paquete agregado desde la assets store de unity contiene tanto los elementos programativos como algunos gráficos que facilitan el diseño alrededor del movimiento con imput gráfica.
<br>Links de acceso:
<br>https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#releases

#### Códigos
##### Look At
En taller V fuimos instruidos en el uso del pathfinder y por ende se necesita el uso de un código para poder sincronizar el movimiento de entidades con su respectivo conjunto de animaciones, para ello se hace uso de un código nombrado "Look At" que el docente Giovanny Espinal permitió utilziar y enseñó como implementar.
<br>Links de acceso:
<br>https://www.youtube.com/watch?v=Msk1xjk7mh8&list=PLguibfbvxzV-06RsENp-Q16Y4ck3JWzkM&index=17

#### Assets
Para poder centrarse en el desarrollo principal del juego y su diseño mecánico se permitió hacer uso de elementos gráficos libres, por la cantidad de los mismos se va a agregar una librería completa construida por el equipo previo a la concepción inicial del juego, el acceso a la misma en un único enlace a la plataforma de assets libre itch.io. Se debe aclarar que ahora mismo y con el estado actual del juego, ademas del nuevo alcance, no se haga uso de la colleción completa de los assets gráficos.
<br>Links de acceso:
<br>https://itch.io/c/1042533/proyecto-slime
