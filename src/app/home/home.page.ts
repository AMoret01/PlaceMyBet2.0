import { Component } from '@angular/core';
import { IHogar, IMotor, IInmobiliaria, ITecnologia } from '../interfaces';
import { ToastController } from '@ionic/angular';
import { ProductoService } from '../services/producto.service';
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

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
}
