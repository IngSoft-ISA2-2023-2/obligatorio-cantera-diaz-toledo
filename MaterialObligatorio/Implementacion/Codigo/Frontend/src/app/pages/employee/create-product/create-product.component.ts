import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { ProductRequest } from 'src/app/interfaces/product';
import { ProductService } from 'src/app/services/product.service';
@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class createProduct implements OnInit {
    form: FormGroup | any;

    get nombre(): AbstractControl | null {
      return this.form.get('nombre');
    }

    get precio(): AbstractControl | null {
      return this.form.get('precio');
    }

    get descripcion(): AbstractControl | null { 
      return this.form.get('descripcion');
    }

    //mostrar en console log los datos del formulario


    constructor(
      private productService: ProductService,
    )
     {
      this.form = new FormGroup({
        nombre: new FormControl(),
        precio: new FormControl(),
        descripcion: new FormControl(),
      });
    }
  
    submit(): void {
      if (this.form.valid) {
        console.log(this.form.value); // Esto imprimirá los datos del formulario en la consola.
      } else {
        console.log('Formulario no válido. Por favor, complete todos los campos requeridos.');
      }
    }

    goAlta(): void {
      let nombre = this.form.get('nombre')?.value;
      let precio = this.form.get('precio')?.value;
      let descripcion = this.form.get('descripcion')?.value;
      
      let product = new ProductRequest(nombre, precio, descripcion, "");
      this.productService.createProduct(product).subscribe((p: any) => {
      });
    }

  ngOnInit(): void {}



}