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
  metrosVivienda: number;
  numeroBanyos: number;
  numeroHabitaciones: number;
  localidad: string;
  categoriaMotor: string;
  KmVehichulo: number;
  anyoFabricacion: number;

  hogares: (IHogar)[] = [];
  motores: (IMotor)[] = [];
  inmuebles: (IInmobiliaria)[] = [];
  tecnologias: (ITecnologia)[] = [];
  producto: (IHogar | IInmobiliaria | IMotor | ITecnologia)[] = [];
  
  constructor(private _toastCtrl: ToastController, private _productoService : ProductoService) {

  }

  ngOnInit(){
    //this.producto = this._productoService.getProductos();
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
          "metros de la vivienda": this.metrosVivienda,
          "numero de baños": this.numeroBanyos,
          "numero de habitaciones": this.numeroHabitaciones,
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
          "categoria motor": this.categoriaMotor,
          "Km del vehichulo": this.KmVehichulo,
          "año de fabricacion": this.anyoFabricacion,
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
