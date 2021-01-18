import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IHogar, IInmobiliaria, IMotor, ITecnologia } from '../interfaces';
import { ProductoService } from '../services/producto.service';


@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {

  id: number;
  categoria: string;

  IHogar : IHogar;
  ITecnologia : ITecnologia;
  IInmobiliaria : IInmobiliaria;
  IMotor : IMotor;

  MotorOculto: boolean = true
  TecnologiaOculto: boolean = true
  InmobiliariaOculto: boolean = true
  HogarOculto: boolean = true

  constructor(private _ActivateRoute: ActivatedRoute, private _ProService: ProductoService) { }

  ngOnInit() {
    this.id = +this._ActivateRoute.snapshot.paramMap.get('id');
    this.categoria = this._ActivateRoute.snapshot.paramMap.get('categoria');
    let producto;

    if (this.categoria == "Tecnología") {
      producto = this._ProService.getTecnologiasId(this.id);
      this.ITecnologia = producto;
      this.TecnologiaOculto = false;
      console.log(producto,this.ITecnologia);

    } else if (this.categoria == "Hogar") {
      producto = this._ProService.getHogaresId(this.id);
      this.IHogar = producto;
      this.HogarOculto = false;
      console.log(producto,this.IHogar);

    } else if (this.categoria == "Inmobiliaria") {
      producto = this._ProService.getInmueblesId(this.id);
      this.IInmobiliaria = producto;
      this.InmobiliariaOculto = false;
      console.log(producto,this.IInmobiliaria);

    } else if (this.categoria == "Motor") {
      producto = this._ProService.getInmueblesId(this.id);
      this.IMotor = producto;
      this.MotorOculto = false;
      console.log(producto,this.IMotor);
    }
  }
}