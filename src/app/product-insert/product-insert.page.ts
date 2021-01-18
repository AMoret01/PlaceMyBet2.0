import { Component } from '@angular/core';
import { IHogar, IMotor, IInmobiliaria, ITecnologia } from '../interfaces';
import { ToastController } from '@ionic/angular';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-product-insert',
  templateUrl: './product-insert.page.html',
  styleUrls: ['./product-insert.page.scss'],
})
export class ProductInsertPage {

  motor: string = "Motor";
  inmobiliaria: string = "Inmobiliaria";
  tecnologia: string = "Tecnología";
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

  hogares: (IHogar)[]=[];
  motores: (IMotor)[]=[];
  inmuebles: (IInmobiliaria)[];
  tecnologias: (ITecnologia)[]=[];
  producto: (IHogar | IInmobiliaria | IMotor | ITecnologia)[]=[];


  
  constructor(private _toastCtrl: ToastController, private _productoService : ProductoService) {

  }

  ngOnInit(){
    //this.producto = this._productoService.getProductos();
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

  async presentToast() {
    const toast = await this._toastCtrl.create({
      message: 'El producto se ha insertado correctamente.',
      duration: 1000,
      position: 'bottom'
    });
    toast.present();
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
        this._productoService.setProducto(tecnologia);

      } else if (this.categoria == this.inmobiliaria) {
        let inmobiliaria: IInmobiliaria = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "metrosVivienda": this.metrosVivienda,
          "numeroBanyos": this.numeroBanyos,
          "numeroHabitaciones": this.numeroHabitaciones,
          "localidad": this.localidad,
          "precio": this.precio
        };
        this._productoService.setProducto(inmobiliaria);

      } else if (this.categoria == this.motor) {
        let motor: IMotor = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "categoriaMotor": this.categoriaMotor,
          "KmVehichulo": this.KmVehichulo,
          "anyoFabricacion": this.anyoFabricacion,
          "precio": this.precio
        };
        this._productoService.setProducto(motor);

      } else if (this.categoria == this.hogar) {
        let hogar: IHogar = {
          "id": this.id,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "precio": this.precio
        };
        this._productoService.setProducto(hogar);
      }

    };

    this.presentToast();
  }

}
