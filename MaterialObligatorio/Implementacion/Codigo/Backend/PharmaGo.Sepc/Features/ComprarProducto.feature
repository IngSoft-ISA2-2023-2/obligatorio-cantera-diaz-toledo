Feature: ComprarProducto

Como usuario anónimo
Quiero comprar un producto
Para tener el producto que necesito

@compraValida
Scenario: Comprar un producto valido
	Given el id del producto 1
	And el id de la farmacia 1
	When se presiona el boton comprar producto
	Then se muestra en la respuesta el codigo "200"

Scenario: Comprar un producto que no existe en la farmacia
	Given el id del producto 2
	And el id de la farmacia 1
	When se presiona el boton comprar producto
	Then se muestra el mensaje de error "Product not found in Pharmacy Farmacia1"

Scenario: Comprar un producto de una farmacia inexistente
	Given el id del producto 1
	And el id de la farmacia 2
	When se presiona el boton comprar producto
	Then se muestra el mensaje de error "Pharmacy 2 not found"

Scenario: Comprar un producto sin id de farmacia
	Given el id del producto 1
	When se presiona el boton comprar producto
	Then se muestra el mensaje de error "Pharmacy Id is a mandatory field"