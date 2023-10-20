Feature: altaProductoValido
Como empleado de una farmacia
Quiero dar de alta un producto
Para tener un nuevo producto y poder venderlo en la plataforma

@creacionValida
Scenario: Alta de un producto valido generico
	Given un nombre de producto alfanumérico con menos de 30 caracteres
	And una descripción alfanumérico con menos de 70 caracteres
	And un precio decimal
	When presione el botón de alta producto
	Then Veo el mensaje de éxito con el código "201"

Scenario: Alta de un producto valido
	Given que el nombre del producto es "Pasta de dientes"
	And la descripción es "Refresca tu aliento"
	And el precio es 200
	When se presiona el botón de alta producto
	Then el producto se agrega a la farmacia con un código autogenerado numérico de 5 dígitos, único dentro de cada farmacia
	And queda en la lista de productos a vender en la farmacia

Scenario: Alta de un producto con nombre incorrecto
	Given que el nombre del producto es "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
	And la descripción es "Refresca tu aliento"
	And el precio es 200
	When se presiona el botón de alta producto
	Then el producto no se agrega a la farmacia
	And se muestra un mensaje de error que dice "nombre del producto inválido"

Scenario: Alta de un producto con descripción incorrecta
	Given que el nombre del producto es "Pasta de dientes"
	And la descripción es "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
	And el precio es 200
	When se presiona el botón de alta producto
	Then el producto no se agrega a la farmacia
	And se muestra un mensaje de error que dice "descripción del producto inválida"

Scenario: Alta de un producto con precio incorrecto
	Given que el nombre del producto es "Pasta de dientes"
	And la descripción es "Refresca tu aliento"
	And el precio es -10
	When se presiona el botón de alta producto
	Then el producto no se agrega a la farmacia
	And se muestra un mensaje de error que dice "precio del producto inválido"


Scenario: Alta de un producto sin nombre
	Given que la descripción es "Refresca tu aliento"
	And el precio es 200
	When se presiona el botón de alta producto
	Then el producto no se agrega a la farmacia
	And se muestra un mensaje de error que dice "el nombre es requerido"


Scenario: Alta de un producto sin descripción
	Given que el nombre del producto es "Pasta de dientes"
	And el precio es 200
	When se presiona el botón de alta producto
	Then el producto no se agrega a la farmacia
	And se muestra un mensaje de error que dice "la descripción es requerida"


Scenario: Alta de un producto sin precio
	Given que el nombre del producto es "Pasta de dientes"
	And la descripción es "Refresca tu aliento"
	When se presiona el botón de alta producto
	Then el producto no se agrega a la farmacia
	And se muestra un mensaje de error que dice "el precio es requerido"
