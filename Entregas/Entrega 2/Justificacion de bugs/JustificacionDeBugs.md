# Justificación de bugs elegidos a reparar

Los siguientes bugs fueron los elegidos para ser reparados:

1. Navegación entre usuario anónimo y demas roles

Link al reporte del issue: https://github.com/IngSoft-ISA2-2023-2/obligatorio-cantera-diaz-toledo/issues/12

Este bug es únicamente de frontend, por lo tanto no se reparó con TDD. Lo elegimos ya que es un bug que tiene severidad crítico. Esto es porque la interfaz original no proporciona una forma de loguearse como administrador, dueño o empleado, ni tampoco proporciona una forma de volver al inicio una vez que se está logueado.

2. Error en incremento de stock al aceptar solicitud de stock

Link al reporte del issue: https://github.com/IngSoft-ISA2-2023-2/obligatorio-cantera-diaz-toledo/issues/24

Este bug fue elegido para ser reparado con TDD. Fue elegido, ya que es el que tiene mayor severidad de los bugs de backend. Es muy importante reparar este bug, porque con esta falla de funcionalidad no podemos tener un sistema que maneje bien los stock de los medicamentos disponibles.

Se encontró que no era un bug, sino mas bien un error a la hora de definir las issues, ya que cada droga cuenta con dos atributos stock y Quantity, estos nombres sin una buena documentación pueden llevar a confusiones, como nos ocurrió a nosotros. De igual manera, se agregó una prueba para verificar que el stock de la droga se actualice correctamente.

3. Validación incorrecta al actualizar invitación 

Link al reporte del issue: https://github.com/IngSoft-ISA2-2023-2/obligatorio-cantera-diaz-toledo/issues/23

Este bug fue elegido para ser reparado con TDD. Lo elegimos, ya que no quedaba ningún bug de backend que tuviera severidad mayor, y de los bugs con severidad leve, fue el que consideramos de mayor importancia reparar, porque es una funcionalidad del sistema que se utiliza bastante.