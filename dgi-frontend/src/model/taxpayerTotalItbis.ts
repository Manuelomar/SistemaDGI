import { TaxReceipt } from "./TaxReceipt";

export interface TaxpayerTotalItbis {
    RncCedula: string;
    NCF: string;
    Monto: number;
    totalItbis: number;
    taxReceipt: TaxReceipt[];
}