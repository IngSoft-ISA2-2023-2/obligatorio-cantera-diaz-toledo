export interface Product {
  id: number;
  nombre: string;
  precio: number;
  descripcion: string;
  pharmacy: {
    id: number;
    name: string;  
  };
}

export class ProductRequest {
  nombre: string;
  precio: number;
  descripcion: string;
  pharmacyName: string = "";

  constructor(nombre: string, precio: number, descripcion: string, pharmacyName: string){
    this.nombre = nombre;
    this.precio = precio;
    this.descripcion = descripcion;
    this.pharmacyName = pharmacyName;
  }
}