# Pipeline

Modificamos el pipeline que ya teniamos. Aparte de que automatiza el build del backend, los test del backend, y el build del frontend, ahora tambien automatiza la ejecucion de las pruebas del backend correspondientes a las nuevas funcionalidades que realizamos con bdd para esta entrega.

En caso de que el action falle, no se va a poder realizar el merge a la rama develop o a la rama main. De esta forma, trabajamos tranquilos de que gitflow se está cumpliendo correctamente, ya que las versiones del sistema que se encuentran en las ramas develop y main son estables, correctas y de calidad.

# Action

Agregamos un workflow bdd. Dentro, se encuentra un job para compilar la aplicación, y ejecutar los test de las nuevas funcionalidades.