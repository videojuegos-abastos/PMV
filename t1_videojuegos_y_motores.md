
<link rel="stylesheet" href="img/md_style.css">



# Videojuegos y Motores

En este tema veremos brevemente qué es un videojuego, cómo surgen y su evolución así como los motores de videojuegos que existen actualmente y una justificación de nuestra elección.

## Origen y Evolución de los Videojuegos



## Motores

Un **Motor de Videojuegos** es una herramienta que nos facilita la creación de videojuegos abstrayéndonos de la implementación compleja de aspectos comunes.

En los videojuegos en general, existen ciertos aspectos y técnicas que son comunes a la gran mayoría de estos, un ejemplo de esto puede ser el renderizado 3D, las físicas y colisiones, las animaciones o la reproducción de sonidos.

Todo esto, aunque parezca básico, si cada vez que queremos hacer un videojuego tenemos que implementarlo, nos llevaría mucho tiempo y conocimiento. Como solución a este problema, poco a poco han ido surgiendo herramientas o librerías que nos permiten abstraernos de la programación a bajo nivel de estas técnicas.

La culminación de esto, son los motores de videojuegos, estos nos permiten estructurar y crear nuestros proyectos así como utilizar funcionalidades que si las tuviésemos que implentar por nosotros mismos, probablemente no lo conseguiríamos. Recordemos que estos, los programan expertos que saben perfectamente cómo funcionan las cosas, por lo que además, aplican técnicas de optimización punteras que nosotros ni nos planteamos. Esta es una de las razones por las que a veces, aunque pensemos que un motor de videojuegos, como tiene tantas cosas, va a relentizar nuestro código, acaba siento completamente al contrario.

Existen motores de todo tipo, no solo lo más grandes lo son, estos, están diseñados para abarcar la gran mayoría de géneros de videojuegos, pero hay otros más pequeños que también podemos considerarlos motores. Hay algunos que ni siquiera tienen interfaz gráfica, otros que tienen como objetivo abarcar solo un género y algunos que buscan simplificar las cosas para que no se necesite ni saber programar. Obviamente, en estos últimos, las cosas que podemos hacer están muy limitadas.

Podemos ver una extensa [lista](https://en.wikipedia.org/wiki/List_of_game_engines) con los motores que existen, desde los más básicos hasta los más punteros.


Para el curso de especialización tenemos que elegir uno de estos motores, no hay ninguno mejor que otro, algunos tienen unas ventajas e inconvenientes y otros otras.

Los motores más populares y utilizados a día de hoy son [Unity](https://unity.com/es), [Unreal](https://www.unrealengine.com) y [Godot](https://godotengine.org/).


Nosotros hemos elegido **Unity**. A continuación veremos algunas de las ventajas e inconvenientes que tienen estos motores.

Lo primero a tener en cuenta es que el motor que escojamos tiene que ser de propósito general, cuantas menos limitaciones tenga mejor. Con esto ya descartamos algunos populares como [Game Maker](https://gamemaker.io/es/gamemaker).

---

### Unity


Es imprescindible mirar a las empresas, actualmente Unity es si no el que más, uno de los motores más populares y que más demandan las empresas, esto es un gran punto a favor, ya que nos aseguramos que no es algo obsoleto.

A parte, gracias también a su popularidad, existe una amplia comunidad y muchos tutoriales, con lo que es mucho más fácil resolver nuestras dudas o bugs en foros o encontrar videos que nos ayuden a entender mejor cómo funciona todo.

Eso, sin contar la propia documentación de Unity claro. Al ser una herramienta consolidada, tiene una documentación acabada para la gran mayoría de las funcionalidades, recordemos que son herramientas en constante desarrollo y hay partes que están en proceso de documentación aún. Es el caso de [Unity Netcode](https://docs-multiplayer.unity3d.com/) por ejemplo, que es una nueva solución de Unity para los juegos multijugador.

Unity cuenta con una versión gratuita que podremos usar siempre que no excedamos unas ganancias definidas. [Comparación planes Unity](https://store.unity.com/compare-plans).

![img](img/summary_unity.jpg)

Web: https://unity.com/es


---

### Unreal Engine

Unreal Engine es una herramienta muy utilizada que destaca por su **Alto rendimiento** y sus **Gráficos avanzados** gracias a ([Nanite](https://docs.unrealengine.com/5.0/en-US/nanite-virtualized-geometry-in-unreal-engine/)).

Es ideal para crear juegos **[Triple A](https://es.wikipedia.org/wiki/AAA_(industria_del_videojuego))**, esto es a su vez una ventaja y un inconveniente ya que no es el mejor motor para juegos pequeños. Aunque se necesita pedir acceso, el motor es [Open Source](https://www.unrealengine.com/en-US/ue-on-github) *.

> El vocabulario marcado con asterisco (*) se encuentra explicado en el anexo.

![img](img/summary_unreal.webp)

Web: https://www.unrealengine.com


---

### Godot

Godot es un motor relativamente nuevo caracterizado por que su desarrollo está guiado por la comunidad. Es [Open Source](https://github.com/godotengine/godot) * y podemos hacer fácilmente cambios al código de forma que podemos modificarlo para que se adapte a nuestras necesidades de desarrollo. Es totalmente gratis y sin tasas ya que el código está bajo [licencia MIT](https://es.wikipedia.org/wiki/Licencia_MIT).

Se puede programar en varios lenguajes, entre ellos [GDScript](https://docs.godotengine.org/es/stable/tutorials/scripting/gdscript/gdscript_basics.html) (parecido a python) y C#.

Hasta ahora, no ha sido el mejor motor si lo que queremos son gráficos 3D avanzados pero recientemente se ha publicado la versión 4 beta, con la que se pretende cambiar esto mudando de [OpenGL](https://www.opengl.org/) a [Vulkan](https://www.vulkan.org/).

Tiene una gran comunidad activa que va mejorando el código y la documentación así como la cantidad y calidad de los tutoriales.

![img](img/summary_godot.png)

Web: https://godotengine.org



---

> Cabe destacar que con el tiempo, todas estas consideraciones pueden cambiar. Otros motores destacables y que nos pueden interesar son [Cry Engine](https://www.cryengine.com/), [Lumberyard](https://aws.amazon.com/es/lumberyard/) o [Game Maker](https://gamemaker.io/es/gamemaker)


## Anexo

* [Open Source](https://es.wikipedia.org/wiki/C%C3%B3digo_abierto) o Código Abierto.