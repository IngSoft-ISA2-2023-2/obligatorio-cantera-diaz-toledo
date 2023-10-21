# Proceso de Ingeniería de Software con BDD

## 1. Planificación Inicial

- **Reunión de Inicio del Proyecto:** El equipo se reúne para discutir los objetivos del proyecto, los requisitos iniciales y para definir las historias de usuario relacionadas con el alta, baja y modificación de productos.

## 2. Definición de Historias de Usuario

- **Creación de Historias de Usuario:** El equipo identifica las historias de usuario específicas relacionadas con el alta, baja y modificación de productos. Cada historia debe ser escrita de manera clara y precisa, siguiendo la sintaxis de BDD.

**Ejemplo de Historias de Usuario:**
- `Como un usuario, quiero poder dar de alta un producto para que pueda ser incluido en el catálogo.`
- `Como un usuario, quiero poder dar de baja un producto para que no esté disponible en el catálogo.`
- `Como un usuario, quiero poder modificar un producto para actualizar su información.`

## 3. Definición de Comportamientos (Gherkin)

- **Definición de Escenarios BDD:** Para cada historia de usuario, el equipo define escenarios BDD utilizando la sintaxis de Gherkin. Estos escenarios describen los comportamientos esperados.

**Ejemplo de Escenario BDD (Alta de Producto):**

Feature: Alta de Producto

Scenario: El usuario da de alta un producto válido
  Given el usuario se encuentra en la página de alta de productos
  When el usuario completa el formulario con información válida
  And presiona el botón "Guardar"
  Then el producto se agrega al catálogo


## 4. Desarrollo Backend

- **Definición de Pruebas Automatizadas:** Para cada escenario BDD, se escriben pruebas automatizadas en el backend utilizando un marco de pruebas como Cucumber o Behave. Estas pruebas verifican que el comportamiento definido se cumple.

- **Implementación del Backend:** El equipo de desarrollo backend implementa las funciones y la lógica necesarias para que los escenarios se cumplan.

## 5. Desarrollo Frontend

- **Diseño de Interfaz de Usuario:** El equipo de diseño crea las interfaces de usuario necesarias para permitir a los usuarios realizar el alta, baja y modificación de productos.

- **Desarrollo de Interfaz de Usuario:** El equipo de desarrollo frontend implementa las interfaces de usuario de acuerdo a los diseños y las integra con el backend.

## 6. Pruebas de Integración

- **Ejecución de Pruebas de Integración:** Se ejecutan pruebas de integración para asegurarse de que el frontend y el backend funcionen juntos de manera cohesiva.

## 7. Pruebas de Aceptación (BDD)

- **Ejecución de Pruebas BDD:** Se ejecutan las pruebas BDD definidas en el paso 3 para cada historia de usuario. Esto incluye escenarios de alta, baja y modificación de productos.

## 8. Refactorización y Corrección de Errores

- Si se encuentran errores o problemas durante las pruebas, el equipo realiza las correcciones necesarias en el frontend o el backend y vuelve a ejecutar las pruebas.

## 9. Seguimiento y Mantenimiento

- Se realiza un seguimiento continuo para asegurarse de que el producto funcione correctamente en producción y se brinda mantenimiento según sea necesario.


