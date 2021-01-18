import { Injectable } from "@angular/core";

import { IHogar,IInmobiliaria,IMotor,ITecnologia } from '../interfaces';



@Injectable()

export class ProductoService{

    productos: (IHogar | IInmobiliaria | IMotor | ITecnologia)[] = [
        {
          "id" : 1,
          "nombre" : "Chalet",
          "descripcion" : "Chalet de dos plantas con jardín y piscina.",
          "categoria" : "Hogar",
          "precio" : 50000
        },
        {
          "id": 2,
          "nombre": "IPad",
          "descripcion": "Color blanco, marca apple y último modelo.",
          "categoria": "Tecnología",
          "estado": "Usado",
          "precio": 100
        },
        {
          "id": 3,
          "nombre": "V8",
          "descripcion": "Motor muy potente generalmente usado para coches deportivos.",
          "categoria": "Motor",
          "categoriaMotor": "Coche",
          "KmVehichulo": 55000,
          "anyoFabricacion": 2001,
          "precio": 1200
        },
        {
          "id": 4,
          "nombre": "Apartamento",
          "descripcion": "Apartamento en primera línea de playa con unas excelentes vistas al mar.",
          "categoria": "Inmobiliaria",
          "metrosVivienda": 1000,
          "numeroBanyos": 2,
          "numeroHabitaciones": 7,
          "localidad": "Valencia",
          "precio": 125000
        }
      ];
      
    getProductos(): (IHogar | IInmobiliaria | IMotor | ITecnologia)[]{
      return this.productos;
    }

    getProducto(id : number) : (IHogar | IInmobiliaria | IMotor | ITecnologia){
        
      return this.productos.find(x => x.id == id);
    }

}