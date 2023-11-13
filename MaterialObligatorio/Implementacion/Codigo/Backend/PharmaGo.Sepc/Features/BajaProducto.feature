Feature: BajaProducto

Como empleado de una farmacia
Quiero dar de baja un producto
Para tener actualizados los productos de la farmacia en la plataforma

@bajaValida

Scenario: Baja de un producto valido
	Given el id del producto 1
	When se presiona el boton eliminar producto
	Then se muestra en la respuesta el codigo "200"

Scenario: Baja de un producto con id incorrecto
	Given el id del producto 2
	When se presiona el boton eliminar producto
	Then se muestra el mensaje de error "The product to delete does not exist."