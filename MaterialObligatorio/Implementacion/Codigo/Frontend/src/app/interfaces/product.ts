export class Product {
    nombre: string = "";
    precio: string = "";
    descripcion: string = "";
  
      constructor(
        nombre: string,
        precio: string, 
        descripcion: string,
        )
      {
        this.nombre = nombre;
        this.precio = precio;
        this.descripcion = descripcion;
      }
    
}

export interface Product {
    nombre: string;
    precio: string;
    descripcion: string;
}