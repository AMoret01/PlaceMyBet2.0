export interface IProducto{
    "id" : number,
    "nombre" : string,
    "descripcion" : string,
    "categoria" : string,
    "precio" : number
}

export interface IMotor extends IProducto{
    "categoría motor" : string,
    "Km del vehichulo" : number,
    "año de fabricación": number
}

export interface IInmobiliaria extends IProducto{
    "metros de la vivienda": number,
    "numero de baños": number,
    "numero de habitaciones": number,
    "localidad": string
}

export interface ITecnologia extends IProducto{
    "estado": string
}