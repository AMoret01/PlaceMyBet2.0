import { Injectable } from "@angular/core";
import { IHogar } from "../interfaces";



@Injectable()

export class ProductoService{

    productos: IHogar[]= [
        {
          "id" : 1,
          "nombre" : "Chalet",
          "descripcion" : "Chalet de dos plantas con jardín y piscina.",
          "categoria" : "Hogar",
          "precio" : 50000
        }
      ]

    getProductos(): IHogar[]{
        return this.productos;
    }

    getProducto(id : number) : IHogar{
        
      return this.productos.find(x => x.id == id);
    }

}

