# Repositorio

Creamos un equipo dentro del assigment "Obligatorio", con el cual creamos un repositorio con los tres integrantes del grupo. El equipo se llama "Cantera-Diaz-Toledo", nuestros apellidos para reconocerlo fácilmente.

## Estructura repositorio

En la raíz del repositorio se encuentran dos carpetas principales: "Entregas" y "MaterialObligatorio".

- Entregas: En esta carpeta se van a encontrar las entregas que realicemos a lo largo del proyecto. Dentro de la carpeta "Entregas" iremos agregando una carpeta nueva correspondiente a cada entrega. Por lo tanto, comenzará con una sola carpeta llamada "Entrega1", luego cuando se realice la entrega 2, se creará una carpeta con el nombre "Entrega2", y asi sucesivamente. Dentro de cada carpeta de entrega, se encontrarán carpetas con sus respectivos archivos markdown que contendrán la información requerida para la entrega correspondiente.

- Material Obligatorio: Esta carpeta nos olvidamos de agregarla en develop por lo que la agregamos en la rama release-entrega1 y luego la mergearemos con develop. En esta carpeta se encuentra el código fuente provisto por los profesores, y la documentación del mismo. A lo largo del proyecto, le iremos haciendo cambios a este código, ya que iremos arreglando bugs, agregando features nuevas, cambiando el diseño del sistema, etc.

A su vez, el repositorio cuenta con un proyecto llamado "Obligatorio-Cantera-Diaz-Toledo", el cual tiene el tablero Kanban que vamos a utilizar a lo largo de todas las entregas. Este tablero irá cambiando en cada entrega según las necesidades del momento.

## Releases de entregas

Decidimos que al finalizar cada entrega haremos un release, así tendremos un registro de cada entrega por separado. Por lo tanto tendremos una rama llamada release-entregaX por cada entrega realizada.

## Versionado

Decidimos utilizar gitflow para el versionado del proyecto. Esto lo haremos creando una rama por entrega, y todas las ramas que se creen a partir de la rama release-entregaX, seran ramas de features. Una vez terminado el desarrollo de una feature, se mergeara a la rama release-entregaX, de la cual haremos un release al finalizar la entrega, y luego esta rama se mergeará a develop. Una vez terminado todo el proyecto, se mergeará la rama develop a la rama main.

### ¿Por qué elegimos GitFlow sobre Trunk based development?

- Al crear una rama por entrega, no es posible utilizar Trunked based development, ya que este consiste en crear ramas a partir de main y mergearlas a main. No nos parece conveniente mergear a main, ya que main es la rama de producción y nuestro obligatorio consiste en realizar distintas tareas a lo largo de las entregas que se van complementando para finalizar en un producto que está en condiciones de ser puesto en producción. Por lo tanto, en etapas anteriores no es posible que el producto esté en producción. A su vez, mergear a main requiere de poder desactivar las features que no estan finalizadas a los usuarios finales, y esto es un trabajo muy extenso, ya que lleva un tiempo de investigación importante para poder implementarlo.

- El equipo posee solo 3 integrantes, y no está pensado escalar el proyecto a un equipo con muchos integrantes. Las tareas a realizar seran mayormente de arreglos, correcciones y mejoras en el código, por lo tanto, es poco probable que se creen conflictos al mergear las ramas.

