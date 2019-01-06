Sokoban_PEC3_MCN
Clon de sokoban para la asignatura modding y creacion de niveles.

Posee un editor de niveles mediante el load y unload asyncronos de una escena desde un fichero .txt

Se ha realizado un editor de niveles den este formato por la facilidad a la hora de editar los mismos (no se necesitara el motor de juego para poder editarlo y seria mas accesible para todos los usuarios.

Los niveles deberan de ir en orden en el documento "Levels.txt" dentro de la carpeta "Resources del proyecto", cada uno separado por un ";" del siguiente para que el software los distinga. Para añadir elementos al nivel se tendra que utilizar de la siguiente manera:

0 : Paredes, superficie infranqueable por cajas y jugador.

P : personaje, utilizar uno por partida, el jugador lo controlara mediante WASD.

O : Caja, el jugador puede moverlas, y tendra que llevarlas a los objetivos para poder superar el nivel.

X: Objetivo, superficie por la cual se podra caminar y en la que tendran que depositarse las cajas para superar el nivel.

Cada nivel tendra un boton de "RESET" en la parte superior derecha de la pantalla para reiniciar el nivel a su estado inicial.