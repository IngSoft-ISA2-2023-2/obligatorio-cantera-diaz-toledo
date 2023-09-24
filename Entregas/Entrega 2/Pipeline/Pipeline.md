# Pipeline

Creamos un pipeline que automatiza el build del backend, los test del backend, y el build del frontend, para asegurarnos que cada vez que alguien realize un push o un pull request a las ramas develop o main, la aplicacion se encuentre estable.

En caso de que el action falle, no se va a poder realizar el merge a la rama develop o a la rama main. De esta forma, trabajamos tranquilos de que gitflow se está cumpliendo correctamente, ya que las versiones del sistema que se encuentran en las ramas develop y main son estables.

# Action

Tenemos dos workflows. Uno para el backend y otro para el forntend. Dentro de cada uno, se encuentra un job para compilar la aplicación, y dentro del workflow del backend también se encuentra otro job para ejecutar los test.

Decidimos separarlos para optimizar el tiempo de ejecución ya que cada job se ejecuta en paralelo y así todo compila más rápido.