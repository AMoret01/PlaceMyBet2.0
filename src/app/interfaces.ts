export interface IHogar{
    "id" : number,
    "nombre" : string,
    "descripcion" : string,
    "categoria" : string,
    "like" : number,
    "idUsuario" : string,
    "precio" : number
}

export interface IMotor extends IHogar{
    "categoriaMotor" : string,
    "KmVehichulo" : number,
    "anyoFabricacion": number
}

export interface IInmobiliaria extends IHogar{
    "metrosVivienda": number,
    "numeroBanyos": number,
    "numeroHabitaciones": number,
    "localidad": string
}

export interface ITecnologia extends IHogar{
    "estado": string
}