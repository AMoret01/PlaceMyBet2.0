import { Component } from '@angular/core';

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

  constructor() {}

  Visible(): void {
    if(this.opcion == this.tecnologia)
    {
      this.TecnologiaOculto = false
      this.MotorOculto = true
      this.InmobiliariaOculto = true
    } else if (this.opcion == this.inmobiliaria)
    {
      this.TecnologiaOculto = true
      this.MotorOculto = true
      this.InmobiliariaOculto = false
    }else if (this.opcion == this.motor)
    {
      this.TecnologiaOculto = true
      this.MotorOculto = false
      this.InmobiliariaOculto = true
    }
  }
}
