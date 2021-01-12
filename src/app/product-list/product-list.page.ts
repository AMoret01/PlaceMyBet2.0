import { Component } from '@angular/core';
import { IHogar, IMotor, IInmobiliaria, ITecnologia } from '../interfaces';
import { ToastController } from '@ionic/angular';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.page.html',
  styleUrls: ['./product-list.page.scss'],
})
export class ProductListPage{

  motor: string = "Motor";
  inmobiliaria: string = "Inmobiliaria";
  tecnologia: string = "Tecnologia";
  hogar: string = "Hogar";

  placeHolder: string = "";
  opcion: string = "";

  MotorOculto: boolean = true
  TecnologiaOculto: boolean = true
  InmobiliariaOculto: boolean = true
  HogarOculto: boolean = true
  id: number;
  nombre: string;
  descripcion: string;
  categoria: string;
  precio: number;
  estado: string;
  metros_vivienda: number;
  numero_baños: number;
  numero_habitaciones: number;
  localidad: string;
  categoria_motor: string;
  Km_vehichulo: number;
  año_fabricación: number;

  hogares: (IHogar)[] = [];
  motores: (IMotor)[] = [];
  inmuebles: (IInmobiliaria)[] = [];
  tecnologias: (ITecnologia)[] = [];
  
  constructor(private _toastCtrl: ToastController, private _productoService : ProductoService) {

  }

  ngOnInit(){
    this.hogares = this._productoService.getProductos();
  }

  async presentToast() {
    const toast = await this._toastCtrl.create({
      message: 'El producto se ha insertado correctamente.',
      duration: 1000,
      position: 'bottom'
    });
    toast.present();
  }
  Visible(): void {
    if (this.categoria == this.tecnologia) {
      this.TecnologiaOculto = false
      this.MotorOculto = true
      this.InmobiliariaOculto = true
    } else if (this.categoria == this.inmobiliaria) {
      this.TecnologiaOculto = true
      this.MotorOculto = true
      this.InmobiliariaOculto = false
    } else if (this.categoria == this.motor) {
      this.TecnologiaOculto = true
      this.MotorOculto = false
      this.InmobiliariaOculto = true
    } else if (this.categoria == this.hogar) {
      this.TecnologiaOculto = true
      this.MotorOculto = true
      this.InmobiliariaOculto = true
    }
  }

  insertar() {
    {
      if (this.categoria == this.tecnologia) {
        let tecnologia: ITecnologia = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "estado": this.estado,
          "precio": this.precio
        };
        this.tecnologias.push(tecnologia);

      } else if (this.categoria == this.inmobiliaria) {
        let inmobiliaria: IInmobiliaria = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "metros de la vivienda": this.metros_vivienda,
          "numero de baños": this.numero_baños,
          "numero de habitaciones": this.numero_habitaciones,
          "localidad": this.localidad,
          "precio": this.precio
        };
        this.inmuebles.push(inmobiliaria);

      } else if (this.categoria == this.motor) {
        let motor: IMotor = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "categoría motor": this.categoria_motor,
          "Km del vehichulo": this.Km_vehichulo,
          "año de fabricación": this.año_fabricación,
          "precio": this.precio
        };
        this.motores.push(motor);

      } else if (this.categoria == this.hogar) {
        let hogar: IHogar = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "precio": this.precio
        };
        this.hogares.push(hogar);
      }

    };

    this.presentToast();
  }

}
