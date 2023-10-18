import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class createProduct implements OnInit {
    form: FormGroup | any;
    constructor(

      )
       {
        this.form = new FormGroup({
          nombre: new FormControl(),
          precio: new FormControl(),
          descripcion: new FormControl(),
        });
      }

  ngOnInit(): void {}



}