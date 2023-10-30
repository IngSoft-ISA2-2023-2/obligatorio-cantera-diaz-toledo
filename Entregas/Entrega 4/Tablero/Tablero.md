# Justificación de las columnas principales

## Backlog
La columna "Backlog" se utiliza para tareas y actividades que aún no se han iniciado. Incluimos aquí tareas ni relacionadas con el sistema, bugs a reparar, y nuevas funcionalidades.

## In Progress
La columna "In Progress" muestra las tareas no relacionadas con el sistema en las que actualmente estamos trabajando.

Esta columna también la utilizamos para las reparaciones de los bugs de frontend, ya que estos no es posible repararlos con el método TDD.

## Done
La columna "Done" representa todos los elementos que hemos completado con éxito. Aquí van las tareas que han pasado por revisiones y pruebas exitosas.

# Justificación para la columna en el Contexto de TDD

Dentro de nuestro tablero Kanban, hemos introducido una columna llamada TDD. Esta columna está específicamente diseñada para respaldar y facilitar la práctica de TDD (Desarrollo Dirigido por Pruebas). A continuación, explicaremos cómo esta columna se alinea con el enfoque de TDD:

## Columna "TDD" 
Dentro de la columna se desarrollan las tres etapas del TDD. Estas se ejecutan en un ciclo de trabajo que termina una vez el bug ha sido reparado.

La etapa "Red" representa la primera fase en TDD, donde escribimos una prueba que inicialmente falla.Resalta la necesidad de definir primero el comportamiento deseado antes de implementarlo.

La etapa "Green" representa la segunda fase en TDD, donde escribimos la cantidad mínima de código para que la prueba pase. Fomenta escribir la solución más simple que satisface la prueba.

La etapa "Refactor" representa la tercera fase en TDD, donde mejoramos el código existente sin cambiar su comportamiento. Contribuye a mantener un código limpio y de alta calidad a medida que evoluciona el proyecto.

Estas tres etapas ("Red," "Green," y "Refactor") se han incorporado de manera específica para respaldar la metodología de TDD en nuestro flujo de trabajo.

## Integration Testing
- **Descripción:** Aquí se llevan a cabo pruebas de integración para asegurarse de que los diferentes componentes de la aplicación funcionen bien juntos.
- **Justificación:** Las pruebas de integración son cruciales para garantizar que la aplicación sea cohesiva y funcione de manera integral.

# Tablero de Desarrollo para BDD

Este tablero de desarrollo está diseñado para facilitar y optimizar el proceso de Desarrollo Dirigido por Comportamiento (BDD) en nuestro proyecto. El BDD es una metodología que se enfoca en la colaboración entre equipos técnicos y no técnicos, y en la comprensión de los comportamientos esperados del software desde una perspectiva del usuario. El tablero se divide en varias columnas que representan las etapas clave en el ciclo de desarrollo de BDD.

## Requerimientos Definition
- **Descripción:** Aquí se definen los requisitos específicos para las historias de usuario antes de su implementación.
- **Justificación:** El BDD se basa en la comprensión precisa de los requisitos. Definirlos claramente antes de la implementación es esencial para el éxito del proyecto.

## Test Cases Implementation
- **Descripción:** En esta etapa se crean los casos de prueba que validarán que la historia de usuario funciona correctamente.
- **Justificación:** Los casos de prueba son esenciales para garantizar que el software cumple con los comportamientos esperados.

## App Implementation
- **Descripción:** Esta columna es para la implementación real de la funcionalidad de la aplicación basada en las historias de usuario.
- **Justificación:** Aquí es donde se escribe el código para satisfacer los requisitos y comportamientos definidos previamente.

## Refactoring
- **Descripción:** En esta fase, se realiza la refactorización del código, si es necesario, para mejorar su calidad y legibilidad.
- **Justificación:** La refactorización es un paso importante para mantener un código limpio y sostenible a lo largo del tiempo.

## Integration Testing
- **Descripción:** Aquí se llevan a cabo pruebas de integración para asegurarse de que los diferentes componentes de la aplicación funcionen bien juntos.
- **Justificación:** Las pruebas de integración son cruciales para garantizar que la aplicación sea cohesiva y funcione de manera integral.

# Conclusiones

Este tablero debe actualizarse regularmente para reflejar el estado actual del proyecto. Los elementos deben moverse a través de las columnas a medida que avanzan en el ciclo de desarrollo. El equipo debe colaborar estrechamente para definir y comprender los comportamientos esperados y garantizar que se cumplan mediante pruebas efectivas.

El tablero también se puede utilizar como una herramienta de comunicación efectiva para todas las partes interesadas, ya que proporciona una visión general del progreso del proyecto.

Nuestro uso del tablero Kanban y estas columnas específicas, nos ayuda a mantener un seguimiento efectivo de nuestras actividades y garantiza que las reparaciones de bugs, tareas específicas, y creación de nuevas funcionalidades, se desarrollen de manera organizada y eficiente.