import { Injectable } from "@angular/core";
import { AngularFireDatabase } from "@angular/fire/database";
import { IHogar, IInmobiliaria, IMotor, ITecnologia } from '../interfaces';



@Injectable()

export class ProductoService {

  /*productos: (IHogar | IInmobiliaria | IMotor | ITecnologia)[] = [
      {
        "id" : 1,
        "nombre" : "Chalet",
        "descripcion" : "Chalet de dos plantas con jardín y piscina.",
        "categoria" : "Hogar",
        "precio" : 50000
      },
      {
        "id": 2,
        "nombre": "IPad",
        "descripcion": "Color blanco, marca apple y último modelo.",
        "categoria": "Tecnología",
        "estado": "Usado",
        "precio": 100
      },
      {
        "id": 3,
        "nombre": "V8",
        "descripcion": "Motor muy potente generalmente usado para coches deportivos.",
        "categoria": "Motor",
        "categoriaMotor": "Coche",
        "KmVehichulo": 55000,
        "anyoFabricacion": 2001,
        "precio": 1200
      },
      {
        "id": 4,
        "nombre": "Apartamento",
        "descripcion": "Apartamento en primera línea de playa con unas excelentes vistas al mar.",
        "categoria": "Inmobiliaria",
        "metrosVivienda": 1000,
        "numeroBanyos": 2,
        "numeroHabitaciones": 7,
        "localidad": "Valencia",
        "precio": 125000
      }
    ];*/

  hogares: IHogar[] = [];
  motores: IMotor[] = [];
  inmuebles: IInmobiliaria[] = [];
  tecnologias: ITecnologia[] = [];


  constructor(private _db: AngularFireDatabase) {

  }

  listInmuebles() {
    let ref = this.getInmuebles();
    ref.once("value", snapshot => {
      snapshot.forEach(child => {
        let value = child.val();
        this.inmuebles.push(value);
        console.log("He encontrado " + child.val().id)
      });
    })
  }
  listMotores() {
    let ref = this.getMotores();
    ref.once("value", snapshot => {
      snapshot.forEach(child => {
        let value = child.val();
        this.motores.push(value);
        console.log("He encontrado " + child.val().id)
      });
    })
  }
  listHogares() {
    let ref = this.getHogares();
    ref.once("value", snapshot => {
      snapshot.forEach(child => {
        let value = child.val();
        this.hogares.push(value);
        console.log("He encontrado " + child.val().id)
      });
    })
  }
  listTecnologias() {
    let ref = this.getTecnologias();
    ref.once("value", snapshot => {
      snapshot.forEach(child => {
        let value = child.val();
        this.tecnologias.push(value);
        console.log("He encontrado " + child.val().id)
      });
    })
  }

  returnInmuebles() {
    this.listInmuebles();
    return this.inmuebles;
  }
  returnHogares() {
    this.listHogares();
    return this.hogares;
  }
  returnMotores() {
    this.listMotores();
    return this.motores;
  }
  returnTecnologias() {
    this.listTecnologias();
    return this.tecnologias;
  }

  getHogares(): firebase.default.database.Reference {
    let ref = this._db.database.ref("productos/Hogar");
    return ref;
  }
  getMotores(): firebase.default.database.Reference {
    let ref = this._db.database.ref("productos/Motor");
    return ref;
  }
  getInmuebles(): firebase.default.database.Reference {
    let ref = this._db.database.ref("productos/Inmobiliaria");
    return ref;
  }
  getTecnologias(): firebase.default.database.Reference {
    let ref = this._db.database.ref("productos/Tecnología");
    return ref;
  }

  getHogaresId (id : number) : IHogar {
    return this.hogares.find(x => x.id == id)
  }
  getMotoressId (id : number) : IMotor {
    return this.motores.find(x => x.id == id)
  }
  getTecnologiasId (id : number) : ITecnologia {
    return this.tecnologias.find(x => x.id == id)
  }
  getInmueblesId (id : number) : IInmobiliaria {
    return this.inmuebles.find(x => x.id == id)
  }

  setHogar(hogar: IHogar) {
    let ref = this._db.database.ref("productos/Hogar");
    let res = ref.push(hogar);
    console.log("He insertado " + res.key);
  }
  setInmobiliaria(inmuebles: IInmobiliaria) {
    let ref = this._db.database.ref("productos/Inmobiliaria");
    let res = ref.push(inmuebles);
    console.log("He insertado " + res.key);
  }
  setMotor(motores: IMotor) {
    let ref = this._db.database.ref("productos/Motor");
    let res = ref.push(motores);
    console.log("He insertado " + res.key);
  }
  setTecnologia(tecnologias: ITecnologia) {
    let ref = this._db.database.ref("productos/Tecnología");
    let res = ref.push(tecnologias);
    console.log("He insertado " + res.key);
  }

}

