import { Component } from '@angular/core';
import { IProducto, IMotor, IInmobiliaria, ITecnologia } from '../interfaces';
import { ToastController } from '@ionic/angular';
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  
  motor : string = "Motor";
  inmobiliaria : string = "Inmobiliaria";
  tecnologia : string = "Tecnologia";
  
  placeHolder : string = "";
  opcion : string = "";

  MotorOculto: boolean = true
  TecnologiaOculto: boolean = true
  InmobiliariaOculto: boolean = true
  nombre: string;
  descripcion : string;
  categoria : string;
  precio : number;
  

  productos: (IProducto | IMotor | IInmobiliaria | ITecnologia)[] = [
    {
      "id" : 1,
      "nombre" : "IPad",
      "descripcion" : "Dispositivo de un tamaño más grande que un movil, de color blanco y de la marca IPhone.",
      "categoria" : "Tecnología",
      "estado": "Usado",
      "precio" : 50
    }
  ];

  constructor(private _toastCtrl : ToastController) {}

  Visible(): void {
    if(this.categoria == this.tecnologia)
    {
      this.TecnologiaOculto = false
      this.MotorOculto = true
      this.InmobiliariaOculto = true
    } else if (this.categoria == this.inmobiliaria)
    {
      this.TecnologiaOculto = true
      this.MotorOculto = true
      this.InmobiliariaOculto = false
    }else if (this.categoria == this.motor)
    {
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

  insertar(){

    let producto: IProducto={"id": this.productos.length+1, 
                            "nombre": this.nombre,
                            "descripcion": this.descripcion,
                            "categoria": this.categoria,
                            "precio": this.precio
                                                    };

        this.productos.push(producto);

        this.presentToast();   

  }
}
