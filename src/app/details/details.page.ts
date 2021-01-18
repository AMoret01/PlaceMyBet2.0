import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IHogar,IInmobiliaria,IMotor,ITecnologia } from '../interfaces';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {

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
  
  hogares: (IHogar)[];
  motores: (IMotor)[];
  inmuebles: (IInmobiliaria)[];
  tecnologias: (ITecnologia)[];
 
  producto: (IHogar | IInmobiliaria | IMotor | ITecnologia);
 
   constructor(private _activatedRoute: ActivatedRoute, private _productoService : ProductoService) { }
 
   ngOnInit() {
 
     this.id = +this._activatedRoute.snapshot.paramMap.get('id');
     console.log("He recibido un "+this.id);
 
     this.producto = this._productoService.getProducto(this.id);
 
   }
 }
