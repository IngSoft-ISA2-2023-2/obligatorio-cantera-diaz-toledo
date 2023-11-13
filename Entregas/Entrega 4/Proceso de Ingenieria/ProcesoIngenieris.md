# Proceso de ingeniería

Para esta entrega redefinimos el proceso de ingeniería ya que nos pidieron que redefinamos el proceso de ingeniería basado en las necesidades para reparar bugs, más BDD y más el test exploratorio (funcional) de los bugs y las nuevas funcionalidades. 

Realizamos también un stand-up semanal. Consideramos que uno por semana es suficiente ya que el trabajo puede ser realizado de manera individual y nos ponemos al día una vez a la semana. Igualmente si surge algún imprevisto podemos realizar algúna reunión extra.

El proceso se adapta a cambios de requisitos o prioridades facilménte, lo que permite una gestión ágil.

## Reparación de los bugs de backend

La reparación de bugs de backend, debía ser realizada con TDD por lo cual este proceso de ingeniería fue basado en este requerimiento. Para ello cada bug para por las tres etapas de TDD, primero red en la que se crea el caso de preba que no pasa, luego green en la que se genera el mínimo código para que la prueba pase, y por ultimo refactor en la que se mejora el código generado.

## Reparación de los bugs de frontend

La reparación de los bugs de forntend no es posible realizarla con TDD, por lo que esta reparación se realiza directamente en un paso. Para esto se cambia el código que corresponda en el frontend.

## Proceso de Ingeniería de Software con BDD

### 1. Planificación Inicial

- **Reunión de Inicio del Proyecto:** El equipo se reúne para discutir los objetivos del proyecto, los requisitos iniciales y para definir las historias de usuario relacionadas con el alta, baja y modificación de productos, y la compra de productos.

### 2. Definición de Historias de Usuario

- **Creación de Historias de Usuario:** El equipo identifica las historias de usuario específicas relacionadas con los requerimientos. Cada historia debe ser escrita de manera clara y precisa, siguiendo la sintaxis de BDD.

**Ejemplo de Historias de Usuario:**
- `Como un usuario, quiero poder dar de alta un producto para que pueda ser incluido en el catálogo.`
- `Como un usuario, quiero poder dar de baja un producto para que no esté disponible en el catálogo.`

### 3. Definición de Comportamientos (Gherkin)

- **Definición de Escenarios BDD:** Para cada historia de usuario, el equipo define escenarios BDD utilizando la sintaxis de Gherkin. Estos escenarios describen los comportamientos esperados.

**Ejemplo de Escenario BDD (Alta de Producto):**

```cucumber
Scenario: Alta de un producto valido
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	And el precio 200
	When se presiona el boton alta producto
	Then se muestra en la respuesta el codigo "200"
```

### 4. Desarrollo Backend

- **Definición de Pruebas Automatizadas:** Para cada escenario BDD, se escriben pruebas automatizadas en el backend utilizando un marco de pruebas como Cucumber o Behave. Estas pruebas verifican que el comportamiento definido se cumple.

- **Implementación del Backend:** El equipo de desarrollo backend implementa las funciones y la lógica necesarias para que los escenarios se cumplan.

### 5. Desarrollo Frontend

- **Diseño de Interfaz de Usuario:** El equipo de diseño crea las interfaces de usuario necesarias para permitir a los usuarios realizar el alta, baja y modificación de productos.

- **Desarrollo de Interfaz de Usuario:** El equipo de desarrollo frontend implementa las interfaces de usuario de acuerdo a los diseños y las integra con el backend.

### 6. Pruebas de Integración

- **Ejecución de Pruebas de Integración:** Se ejecutan pruebas de integración para asegurarse de que el frontend y el backend funcionen juntos de manera cohesiva.

### 7. Pruebas de Aceptación (BDD)

- **Ejecución de Pruebas BDD:** Se ejecutan las pruebas BDD definidas en el paso 3 para cada historia de usuario. Esto incluye escenarios de alta, baja y modificación de productos.

### 8. Refactorización y Corrección de Errores

- Si se encuentran errores o problemas durante las pruebas, el equipo realiza las correcciones necesarias en el frontend o el backend y vuelve a ejecutar las pruebas.

### 9. Seguimiento y Mantenimiento

- Se realiza un seguimiento continuo para asegurarse de que el producto funcione correctamente en producción y se brinda mantenimiento según sea necesario.

## Tareas no relacionadas con el sistema

El proceso de ingeniería de estas tareas es de un solo paso. Estas tareas se realizan independientemente de la reparación de los bugs y la creación de las nuevas funcionalidades.