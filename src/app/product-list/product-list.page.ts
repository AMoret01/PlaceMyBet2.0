import { Component } from '@angular/core';
import { IHogar, IMotor, IInmobiliaria, ITecnologia } from '../interfaces';
import { ToastController } from '@ionic/angular';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.page.html',
  styleUrls: ['./product-list.page.scss'],
})
export class ProductListPage {

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
  like: number;
  idUsuario: string = "Alejandro";

  hogares: (IHogar)[] = [];
  motores: (IMotor)[] = [];
  inmuebles: (IInmobiliaria)[] = [];
  tecnologias: (ITecnologia)[] = [];

  constructor(private _toastCtrl: ToastController, private _productoService: ProductoService) {

  }

  ngOnInit() {
    let hogar = this._productoService.getHogares();
    let motor = this._productoService.getMotores();
    let inmobiliaria = this._productoService.getInmuebles();
    let tecnologia = this._productoService.getTecnologias();

    hogar.once("value", snapshot => {
      snapshot.forEach(child =>{
        let value = child.val();
        this.hogares.push(value);
        console.log("He encontrado "+child.val().id);
      })
    })
    motor.once("value", snapshot => {
      snapshot.forEach(child =>{
        let value = child.val();
        this.motores.push(value);
        console.log("He encontrado "+child.val().id);
      })
    })
    inmobiliaria.once("value", snapshot => {
      snapshot.forEach(child =>{
        let value = child.val();
        this.inmuebles.push(value);
        console.log("He encontrado "+child.val().id);
      })
    })
    tecnologia.once("value", snapshot => {
      snapshot.forEach(child =>{
        let value = child.val();
        this.tecnologias.push(value);
        console.log("He encontrado "+child.val().id);
      })
    })
  }

  async presentToast() {
    const toast = await this._toastCtrl.create({
      message: 'El producto se ha insertado correctamente.',
      duration: 1000,
      position: 'bottom'
    });
    toast.present();
  }
  async presentToastLike() {
    const toast = await this._toastCtrl.create({
      message: 'Le ha gustado el producto.',
      duration: 1000,
      position: 'bottom'
    });
    toast.present;
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
  Like() {
    {
      if (this.categoria == this.tecnologia) {
        let tecnologia: ITecnologia = {
          "id": this.tecnologias.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "estado": this.estado,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setTecnologiaLike(tecnologia);

      } else if (this.categoria == this.inmobiliaria) {
        let inmobiliaria: IInmobiliaria = {
          "id": this.inmuebles.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "metrosVivienda": this.metrosVivienda,
          "numeroBanyos": this.numeroBanyos,
          "numeroHabitaciones": this.numeroHabitaciones,
          "localidad": this.localidad,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setInmobiliariaLike(inmobiliaria);

      } else if (this.categoria == this.motor) {
        let motor: IMotor = {
          "id": this.motores.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "categoriaMotor": this.categoriaMotor,
          "KmVehichulo": this.KmVehichulo,
          "anyoFabricacion": this.anyoFabricacion,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setMotorLike(motor);

      } else if (this.categoria == this.hogar) {
        let hogar: IHogar = {
          "id": this.hogares.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setHogarLike(hogar);
      }

    };

    this.presentToastLike();
  }

  insertar() {
    {
      if (this.categoria == this.tecnologia) {
        let tecnologia: ITecnologia = {
          "id": this.tecnologias.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "estado": this.estado,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setTecnologia(tecnologia);

      } else if (this.categoria == this.inmobiliaria) {
        let inmobiliaria: IInmobiliaria = {
          "id": this.inmuebles.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "metrosVivienda": this.metrosVivienda,
          "numeroBanyos": this.numeroBanyos,
          "numeroHabitaciones": this.numeroHabitaciones,
          "localidad": this.localidad,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setInmobiliaria(inmobiliaria);

      } else if (this.categoria == this.motor) {
        let motor: IMotor = {
          "id": this.motores.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "categoriaMotor": this.categoriaMotor,
          "KmVehichulo": this.KmVehichulo,
          "anyoFabricacion": this.anyoFabricacion,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setMotor(motor);

      } else if (this.categoria == this.hogar) {
        let hogar: IHogar = {
          "id": this.hogares.length + 1,
          "nombre": this.nombre,
          "descripcion": this.descripcion,
          "categoria": this.categoria,
          "like": this.like,
          "idUsuario": this.idUsuario,
          "precio": this.precio
        };
        this._productoService.setHogar(hogar);
      }

    };

    this.presentToast();
  }

}
