Feature: ModificarProducto

Como empleado de una farmacia
Quiero poder modificar un producto
Para tener actualizados los productos de la farmacia en la plataforma

@tag1
Scenario: Modificar un producto valido
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	And el precio 200
	And el id del producto 1
	When se presiona el boton modificar producto
	Then se muestra en la respuesta el codigo "200"

Scenario: Modificar un producto sin producto
	Given el id del producto 1
	When se presiona el boton modificar producto
	Then se muestra el mensaje de error "The updated product is invalid."

Scenario: Modificar un producto que no existe
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	And el precio 200
	And el id del producto 2
	When se presiona el boton modificar producto
	Then se muestra el mensaje de error "The product to update does not exist."

Scenario: Modificar un producto con nombre incorrecto
	Given el nombre del producto "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
	And la descripcion "Refresca tu aliento"
	And el precio 200
	And el id del producto 1
	When se presiona el boton modificar producto
	Then se muestra el mensaje de error "Invalid Name"

Scenario: Modificar un producto con descripción incorrecta
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
	And el precio 200
	And el id del producto 1
	When se presiona el boton modificar producto
	Then se muestra el mensaje de error "Invalid Description"

Scenario: Modificar un producto con precio incorrecto
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	And el precio -10
	And el id del producto 1
	When se presiona el boton modificar producto
	Then se muestra el mensaje de error "Invalid Price"