Feature: Producto

Como empleado de una farmacia
Quiero dar de alta un producto
Para tener un nuevo producto y poder venderlo en la plataforma

@creacionValida

Scenario: Alta de un producto valido
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	And el precio 200
	When se presiona el boton "alta producto"
	Then se muestra en la respuesta el codigo "200"

Scenario: Alta de un producto con nombre incorrecto
	Given el nombre del producto "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
	And la descripcion "Refresca tu aliento"
	And el precio 200
	When se presiona el boton "alta producto"
	Then se muestra el mensaje de error "Invalid Name"

Scenario: Alta de un producto con descripción incorrecta
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
	And el precio 200
	When se presiona el boton "alta producto"
	Then se muestra el mensaje de error "Invalid Description"

Scenario: Alta de un producto con precio incorrecto
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	And el precio -10
	When se presiona el boton "alta producto"
	Then se muestra el mensaje de error "Invalid Price"


Scenario: Alta de un producto sin nombre
	Given la descripcion "Refresca tu aliento"
	And el precio 200
	When se presiona el boton "alta producto"
	Then se muestra el mensaje de error "Empty Name"


Scenario: Alta de un producto sin descripción
	Given el nombre del producto "Pasta de dientes"
	And el precio 200
	When se presiona el boton "alta producto"
	Then se muestra el mensaje de error "Empty Description"


Scenario: Alta de un producto sin precio
	Given el nombre del producto "Pasta de dientes"
	And la descripcion "Refresca tu aliento"
	When se presiona el boton "alta producto"
	Then se muestra el mensaje de error "Empty Price"
