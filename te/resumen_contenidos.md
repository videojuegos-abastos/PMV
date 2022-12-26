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


* DontDestroyOnLoad

* UI
* Audio


* Tilemaps
* Corrutinas

* Unity Events
* Animaciones
* Input System
* Atributos
* Estructura del proyecto y GameManager
* Prefabs

* Package Manager y Unity Asset Store

* Scriptable Objects
* Invoke y InvokeReapiting
* Time.deltaTime y Time.timeScale



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

Cinemachine es un paquete muy útil 