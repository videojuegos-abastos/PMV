# Resumen de contenidos PMV

Algunos de los contenidos vistos en clase no se encuentran explícitamente explicados en los apuntes de la asignatura. Esto es más que obvio ya que Unity es una herramienta muy amplia y por eso mismo cuenta con su propia documentación.

En este documento repasaremos los contenidos vistos en clase y adjuntaremos breves explicaciones y enlaces de interés para refrescar la memoria.

## Contenidos

* Objetos y Componentes
* Jerarquía de objetos y componente Transform
* Objetos y componentes básicos

* Escenas

* Físicas: Rigidbody y Colliders
* Mover Objetos

* Instanciar y Destruir Objetos
* Objetos 3D: Materiales

* Cámaras y Cinemachine

* Prefabs

* Animaciones

* UI
* Audio

* Tilemaps





* Package Manager y Unity Asset Store


* Corrutinas

* Unity Events

* Atributos
* Estructura del proyecto y GameManager

* Input System

* Scriptable Objects

* Otros
	- DontDestroyOnLoad
	- InvokeReapiting
	- Time.deltaTime y Time.timeScale



## Objetos y Componentes

Los [objetos](https://docs.unity3d.com/es/530/Manual/GameObjects.html) y los [componentes](https://docs.unity3d.com/es/530/Manual/Components.html) son los pilares fundamentales de cualquier juego de Unity. Hemos de tener clara la diferencia entre unos y otros, no solo al verlos desde el editor, sinó a nivel de script. En todo momento, tenemos que saber si tenemos entre manos uno u otro y entender cómo acceder a las propiedades de cada uno. Además, como sabremos existen varias formas de 'encontrar' un objeto o componente desde un script.

Todo esto está explicado en los propios apuntes ([4. Scripting y Eventos](https://github.com/videojuegos-abastos/PMV/blob/main/te/t4_scripting_y_eventos.md)) y es muy importante ya que sin esta base no vamos a saber manejarnos bien.

[Controlar Objetos utilizando Componentes](https://docs.unity3d.com/es/2018.4/Manual/ControllingGameObjectsComponents.html).


## Jerarquía de objetos y componente Transform

En el editor podemos establecer una jerarquía de objetos de forma que cada objeto puede tener 1 padre y *n* hijos. En nuestros scripts, a través del componente [transform](https://docs.unity3d.com/ScriptReference/Transform.html) (que como sabemos tienen todos los objetos), además de poder acceder a la posición o rotación por ejemplo, podemos acceder a cualquiera de los hijos o al padre de un objeto. Ver [4. Scripting y Eventos](https://github.com/videojuegos-abastos/PMV/blob/main/te/t4_scripting_y_eventos.md)

Además, recordemos que la posición rotación y escala de un objeto, pueden estar en coordenadas del mundo o pueden ser con respecto a su padre. Para eso, tenemos los transform.[localPosition](https://docs.unity3d.com/ScriptReference/Transform-localPosition.html), transform.[localRotation](https://docs.unity3d.com/ScriptReference/Transform-localRotation.html) y transform.[localScale](https://docs.unity3d.com/ScriptReference/Transform-localScale.html).


## Objetos y componentes básicos

Por lo general, habrá objetos y componentes que utilicemos mucho más que otros. En [3. Objetos y Componentes Básicos](https://github.com/videojuegos-abastos/PMV/blob/main/te/t3_objetos_y_componentes_basicos.md), podemos encontrar explicados los que mejor deberíamos manejar.


## Escenas

Una [escena](https://docs.unity3d.com/es/2018.4/Manual/CreatingScenes.html) es una especie de contenedor en el que podemos guardar nuestra jerarquía de objetos con sus respectivos componentes. Podemos verlas como diferentes niveles de un juego o como diferentes pantallas (menú, juego, pausa, etc...). Para poder 'utilizar' nuestras escenas en el juego final, tenemos que añadirlas a la 'Build'.

Cada escena tiene un '[buildIndex](https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-buildIndex.html)' asociado y único. Para hacer cambios de escena desde nuestros scripts utilizaremos la clase estática [SceneManager](https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html).

> Para utilizar la clase SceneManager no nos podemos olvidar del `using UnityEngine.SceneManagement;`


## Físicas: Rigidbody y Colliders

Las físicas son una parte muy importante en los juegos. No solo para las simulaciones físicas, sinó porque en muchas ocasiones utilizamos las colisiones entre dos objetos para lanzar eventos. Por ejemplo si queremos que una bala le quite vida a un enemigo. Podemos detectar la colisión y quitarle vida.

En Unity puede suceder una Colisión o un Evento de Trigger. Las colisiones moverán nuestros objetos en función de sus propiedades físicas, los eventos trigger no.

Para detectar colisiones necesitaremos que los dos objetos tengan un collider (Box collider, Sphere collider, Capsule collider, etc.) y que al menos uno de ellos tenga un Rigidbody.

En los colliders podemos encontrar la propiedad isTrigger, que nos permite especificar si el objeto reaccionará físicamente a los contactos o no.

Si se cumplen estas dos condiciones, desde nuestro código, podemos utilizar las funciones que nos permiten 'enterarnos' de cuando sucede una colisión o trigger event y obtener los objetos que colisionan. 

Doc. Unity: [Collider](https://docs.unity3d.com/ScriptReference/Collider.html), [Rigidbody](https://docs.unity3d.com/ScriptReference/Rigidbody.html) y [Rigidbody 2D](https://docs.unity3d.com/ScriptReference/Rigidbody2D.html).

> Los Componentes Collider y Rigidbody distinguen entre 2D y 3D al igual que sus funciones de callback.

## Mover Objetos

Mover objetos es algo también muy común en los videojuegos. En Unity existen varias formas de hacerlo y dependiendo de diferentes factores nos puede convenir hacerlo de una u otra.

La más básica es modificar directamente la posición del objeto accediendo al [transform.position](https://docs.unity3d.com/ScriptReference/Transform-position.html).

También podríamos utilizar las funciones del componente transform como [Translate()](https://docs.unity3d.com/ScriptReference/Transform.Translate.html).

El problema de esto es que si queremos que nuestro objeto colisione de forma realista con los colliders de la escena, esta forma de hacerlo nos puede dar problemas. Si este es el caso, es mejor utilizar las funciones que nos proporciona el componente Rigidbody. [MovePosition()](https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html) por ejemplo.

Una forma de olvidarnos completamente de cómo mover el objeto sería utilizar los NavMeshAgents ya que a parte de implementar el [pathfinding](https://es.wikipedia.org/wiki/B%C3%BAsqueda_de_ruta), implementan el pathfollowing, que marca cómo el objeto sigue el camino. Además, de esta forma podemos directamente evitar las colisiones contra los muros.


## Instanciar y Destruir Objetos

Comunmente, querremos crear y destruir objetos en nuestro juego. Para crear, utilizaremos la función [Instantiate()](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html), para destruir utilizaremos [Destroy()](https://docs.unity3d.com/ScriptReference/Object.Destroy.html). Es muy recomendable entrar a los enlaces y conocer todos los parámetros que aceptan estas dos funciones.

Hay veces que no es necesario destruir un objeto y nos puede bastar con deshabilitarlo. Podemos deshabilitar un objeto con la función [SetActive()](https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html) o un solo componente accediendo a su propiedad [enabled](https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html).

> Hay que tener ojo con habilitar y desabilitar objetos ya que las funciones Find() no encuentran los objetos inhabilitados.


## Objetos 3D: Materiales

Los objetos 3D son objetos compuestos por un modelo. Estos modelos, no son más que mallas de vértices. Podemos ver todo mejor explicado en [3. Objetos y Componentes Básicos](https://github.com/videojuegos-abastos/PMV/blob/main/te/t3_objetos_y_componentes_basicos.md#objetos-3d).

> El modelo / malla de vértices es la información que ponemos en el componente Mesh Filter de un objeto 3D.

Los objetos 3D pueden tener Materiales. Hay dos tipos de materiales y no hemos de confundirlos. Los 'Material' y los 'Phisic Material'.

Los [Material](https://docs.unity3d.com/es/2019.4/Manual/Materials.html) determinan cómo se verá nuestro objeto.

Por otro lado los [Physic Material](https://docs.unity3d.com/es/530/Manual/class-PhysicMaterial.html) determinan las propiedades físicas de nuestro objeto y por tanto cómo se va a comportar o reaccionar ante eventos físicos como las colisiones. 


## Cámaras y Cinemachine

Explicación de cómo funcionan las cámaras en [3. Objetos y Componentes Básicos](https://github.com/videojuegos-abastos/PMV/blob/main/te/t3_objetos_y_componentes_basicos.md#c%C3%A1maras).

[Cinemachine](https://unity.com/es/unity/features/editor/art-and-design/cinemachine) es un paquete muy útil y comunmente utilizado para controlar el movimiento de las cámaras de nuestro juego. No tenemos por qué conocer cómo funciona ya que no es algo que entre en el temario pero nos puede venir muy bien saber que existe y probarlo.

## Prefabs

Un [Prefab](https://docs.unity3d.com/es/530/Manual/Prefabs.html) es una especie de plantilla de objetos. Podemos crear un prefab de nuestro objeto 'Enemigo' por ejemplo. Al instanciar más de estos prefabs, todos ellos tendran las mismas propiedades que nuestro prefab original. Si modificamos cualquier propiedad en el prefab, también se modificará para todos los otro.

Ojo porque no es lo mismo cambiar algo en el propio prefab que en una instancia de éste. Si modificamos solamente la instancia, tendremos un comportamiento distinto solo en esa instancia.

En nuestro ejemplo del enemigo, podríamos tener el prefab enemigo con sus componentes, scripts y variables asignadas a algo por defecto y en algunos enemigos cambiar la propiedad velocidad por ejemplo para que ese enemigo en concreto se mueva más rápido.

## Animaciones

Hay dos partes con lo que a Animación se refiere en Unity, por un lado las Aimaciones ([Animation](https://docs.unity3d.com/es/530/ScriptReference/Animation.html)) y por otro lado el Controlador de las Animaciones ([Animation Controller](https://docs.unity3d.com/ScriptReference/Animations.AnimatorController.html)).

> Recordemos que en Unity podemos animar cualquier parámetro.

La idea es que una animación es simplemente una serie de modificaciones en uno o más parámetros a lo largo del tiempo. El parámetro `scale` del componente Transform o el parámetro `sprite` del componente SpriteRenderer serían dos ejemplos.

El AnimationController es un componente que se encarga simplemente de controlar qué animación tiene que renderizarse en cada momento. Dejamos un [vídeo](https://www.youtube.com/watch?v=hkaysu1Z-N8) como recurso ya que es mucho más fácil de seguir.

## UI

La UI (User Interface) o Interfaz de usuario, es la interfaz visual que de alguna forma guía al jugador a través del juego. Por lo general suelen ser botones o textos en pantalla que no está dentro del espacio del juego.

Unity tiene varios componentes para crear esta interfaz, a parte de probarlos, tenemos que tener en cuenta que estos objetos, no tienen un componente Transform, sino que tienen un Rect Transform. Jugando con el posicionamiento y el anclado de este componente podemos conseguir que al cambiar el tamaño o resolución de pantalla, nuestros elementos permanezcan como queremos visualmente.

## Audio

Contemplamos dos componentes para el audio en Unity, el `AudioListener` y el `AudioSource`. Como sus nombres indican, uno será el que escucha **todos** los sonidos y otro es un emisor. Solo podrá haber un AudioListener en la escena, que generalmente, aunque no tiene por qué, pondremos en la cámara.

Tendremos tantos AudioSource como queramos, cada uno puede ser un sonido.

Dejamos un [vídeo de introdicción](https://www.youtube.com/watch?v=6OT43pvUyfY) al audio, mencionar que para no estar poniendo y quitando sonidos a objetos, podemos crear un AudioManager, que es lo que se hace en el vídeo. Este AudioManager podemos hacerlo como queramos y complicarlo más o menos para añadir más funcionalidades. El que se crea en el vídeo es un ejemplo básico y que nos puede servir en muchos casos.

Además se utiliza el patrón Singleton para no cortar la música entre escena y escena.

> Por defecto ya nos viene un Audio Listener en la cámara con lo que si ponemos otro, tendremos que quitar éste.





## Package Manager y Unity Asset Store

Desde el Package Manager podemos descargar paquetes como el Cinemachine o los ML-Agents. Estos paquetes son oficiales de Unity, pero existen otros que no están mantenidos por el propio Unity que podemos encontrar en la Unity Asset Store.


## Otros

### Time

Clase estática desde la que podemos acceder a algunos parámetros interesantes como:

* deltaTime: Tiempo transcurrido entre frames.
* timeScale: Escala a la que están sometidos los eventos que dependen del tiempo.

### DontDestroyOnLoad

[DontDestroyOnLoad()](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) es una función para 'decirle' a Unity que no destruya un objeto al cambiar de escena.


### InvokeRepeating

[InvokeRepeating()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html) es una función que nos puede servir para llamar a otra función de forma repetida utilizando el tiempo escalado (Time.timeScale). En muchos casos puede sustituir a los temporizadores o corrutinas.


## Tilemaps

## Corrutinas

[Corutinas](https://docs.unity3d.com/Manual/Coroutines.html).

## Unity Events

Los [Unity Events](https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html) son eventos (muy parecidos a los de C#) pero con algunas ventajas como por ejemplo la serialización en el editor.

> Los botones del UI usan UnityEvents.

## Atributos

[Atributos C#](https://learn.microsoft.com/es-es/dotnet/csharp/tutorials/attributes)

Hemos visto algunos como:

```C#
	[SerializeField]

	[Range(0, 1)]

	[Header]

	[Tooltip]

```

## Estructura del proyecto y GameManager

## Input System

## Scriptable Objects