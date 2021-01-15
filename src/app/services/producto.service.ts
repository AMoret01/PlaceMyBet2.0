import { Injectable } from "@angular/core";
import { AngularFireDatabase } from "@angular/fire/database";
import { IHogar,IInmobiliaria,IMotor,ITecnologia } from '../interfaces';



@Injectable()

export class ProductoService{

    /*productos: (IHogar | IInmobiliaria | IMotor | ITecnologia)[] = [
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
          "categoria motor": "Coche",
          "Km del vehichulo": 55000,
          "año de fabricacion": 2001,
          "precio": 1200
        },
        {
          "id": 4,
          "nombre": "Apartamento",
          "descripcion": "Apartamento en primera línea de playa con unas excelentes vistas al mar.",
          "categoria": "Inmobiliaria",
          "metros de la vivienda": 1000,
          "numero de baños": 2,
          "numero de habitaciones": 7,
          "localidad": "Valencia",
          "precio": 125000
        }
      ]*/

      constructor(private _db: AngularFireDatabase){

      }

    /*getProductos(): (IHogar | IInmobiliaria | IMotor | ITecnologia)[]{
      return this.productos;
    }*/

    /*getProducto(id : number) : (IHogar | IInmobiliaria | IMotor | ITecnologia){
        
      return this.productos.find(x => x.id == id);
    }*/

    setProducto(producto: (IHogar | IInmobiliaria | IMotor | ITecnologia)){
      let ref = this._db.database.ref("productos");
      ref.push(producto);
    }

}

