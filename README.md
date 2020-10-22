# Slimescape
## Proyecto final - Taller 6 / Scripting
por:
<br>Julian Jaramillo Vargas - 00038586 - Julian.JaramilloV@upb.edu.co
<br>Nicolás Escobar Espinosa – 000366591 – Nicolas.EscobarE@upb.edu.co
<br>Santiago Cortes – 000368733 – Santiago.Cortes@upb.edu.co
<br>Juan Camilo Calvache Giraldo - 000085476 - juan.calvache@upb.edu.co

### Instrucciones de juego
##### Objetivo
La finalidad del juego es ayudar los mounstros amigos tuyos, a desplazarse a un punto del mapa sin que algún obstaculo colisione con ellos, para limpiar el escenario solo se posee un tiempo que al llegar a cero la ciratura comenzará a caminar indiscriminadamente pueda o no pasar. Actualmente solo exiten 20 niveles jugables  que se desbloquean conforme el juego avanza.

##### Controles
El juego en el estado actual solamente posee 4 botones que serán el centro de su funcionamiento:
<br>Joystick: Al lado izquierdo se encuentra el joystick con el cual el personaje principal se puede desplazar por el entorno.
<br>Boton Vacio: Este botón es el que permite interacionar con los objetos en el escenario para poder resolver el puzzle.
<br>Pause: Menú donde puedes desde reiniciar el juegos, hasta esperar, reposar, o simplemente salir del juego.
<br>Go: Inicia el juego antes que el reloj llegue a cero de ser necesario.

##### Elementos de juego
Estos elementos proximamente serán remplazados pos modelos 3D que representen cada uno, por ahora son cajas o cubos que permiten probar el loop central del juego:
<br>Mounstros (Dragones, Esqueletos, Murcielagos): Personaje aliado que debe alcanzar el punto final para poder superar el nivel.
<br>Caja : Caja de madera que impide el paso, para solucionarlo debes acercarte pulzar el boton accion, sostenerlo mientras te mueves, y empujarla o arrastrarla hasta algún pozo.
<br>Pozo: Hueco con fuego que impide tu paso o el dela amigo, para solucionarlo debes llevar la caja hasta el pozo.
<br>Caja grande: Caja de metal que impide el paso, para solucionarlo debes acercase y pulzar el boton de acción hasta que desaparezca.
<br>Llave: Llave que activa un mecanismo para bajar el portón, para activarlo simplemente debes acercarte a la llave y oprimir el boton acción.
<br>Humano: Enemigo que si detecta al mounstro se pierde el nivel, se puede desviar de su punto actual o obstruir su visión con una caja de madera al frente.
<br>Ollas: Elementos de distracción que llama la atención del humano, el se va a desplazar hasta donde hayas oprimido el botón acción.

### Bugs
Estos errores son falencia que aparecieron durante el desarrollo o diseño del juego, en el estado actual del juego estos son los posibles fallos:

#### Bugs tipo C
Estos errores son visuales que no alteran el flujo del juego.

#### Bugs tipo B
Errores menores que pueden llegar a alterar la experiencia y el flujo del juego, pero se pueden ignorar.

#### Bugs tipo A
Este tipo de error cancela completamente el flujo del juego impidiendo continuar en el estado actual del juego, algunas veces este error con reiniciar la app es suficiente pero no es seguro.

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

##### Dotween
Plugin que permite realizar transiciones y animaciones fluidas tanto para objetos en el escenario como para elementos en el UI.
<br>Links de acceso:
<br>http://dotween.demigiant.com/

#### Assets
Para poder centrarse en el desarrollo principal del juego y su diseño mecánico se permitió hacer uso de elementos gráficos libres, por la cantidad de los mismos se va a agregar una librería completa construida por el equipo previo a la concepción inicial del juego, el acceso a la misma en un único enlace a la plataforma de assets libre itch.io. Se debe aclarar que ahora mismo y con el estado actual del juego, ademas del nuevo alcance, no se haga uso de la colleción completa de los assets gráficos.
<br>Links de acceso:
<br>https://itch.io/c/1042533/proyecto-slime

La gran mayoria de sonidos fueron investigados a fondo desde la plataforma freesound, se deja abajo el perfil de descarga y la plataforma desde la cual se obtuvo todo el registro musical del juego:
<br>Links de acceso:
<br>https://freesound.org/people/Nicolas_Escobar_Espinosa/
<br>Links de acceso:
<br>https://www.teknoaxe.com/Home.php

El doblaje de voz fue realizado por la increible Ilne Moreno, se deja acceso a sus redes sociales:
<br>Links de acceso:
<br>https://www.instagram.com/_.ilene/?hl=es-la


