import { StatusType } from "./enums/StatusType";

export interface Taxpayer  {
   id:string;
    RncCedula: string;
    Nombre: string;
    Tipo: string;
    Estatus: number;
}
