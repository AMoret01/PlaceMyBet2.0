import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {

 id: number;

  constructor(private _activatedRoute: ActivatedRoute, private _productoService : ProductoService) { }

  ngOnInit() {

    this.id = +this._activatedRoute.snapshot.paramMap.get('id');
    console.log("He recibido un "+this.id);

    let res = this._productoService.getProducto(this.id);
    console.log("El nombre es "+res.nombre);

  }
}
