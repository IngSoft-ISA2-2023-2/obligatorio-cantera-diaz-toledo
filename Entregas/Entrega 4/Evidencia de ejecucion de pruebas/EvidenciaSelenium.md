# Evidencia de Pruebas en Selenium

Utilizamos la herramienta Selenium IDE para llevar a cabo pruebas de ejecución de los escenarios planteados previamente en los issues relacionados con las nuevas funcionalidades.

## Pruebas Agrupadas en Test Suites

Las pruebas se organizaron en distintas test suites, que abordaron los siguientes aspectos:

- **Alta de Producto**
- **Modificación de Producto**
- **Compra de Producto**
- **Eliminación de Producto**

En total, se ejecutaron 13 pruebas, todas funcionando correctamente y pasando la aprobación.

## Uso de Asserts

Al final de cada prueba, se utilizaron comandos `assert` para verificar el estado final de la ejecución. Este enfoque agregó un valor adicional a las pruebas al garantizar que los resultados cumplieran con las expectativas.

## Limitaciones en Escenarios

Es importante destacar que algunos de los escenarios planteados en entregas anteriores no pudieron probarse en Selenium debido a que estaban diseñados para el backend. En consecuencia, resultaba imposible replicar estos escenarios en el frontend.

## Recomendaciones

Recomendamos encarecidamente que el proyecto se ejecute en modo Release para evitar las excepciones de errores que pueden surgir al ejecutarlo en modo debug. Estas excepciones podrían detener la ejecución de las pruebas hasta que se continúe en el proyecto.

## Enlaces de Evidencia

- [Enlace a la evidencia en YouTube](https://youtu.be/cvrcIxczy-w)



![Imagen de Evidencia](https://i.imgur.com/66bKGkd.png)
