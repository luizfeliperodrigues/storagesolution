import { Auction } from './Auction';
import { TipoItem } from './TipoItem';
import { Comitente } from './Comitente';

export interface Item {
    id: number;
    businessCode: number;
    description: string;
    priceReference: number;
    storedQuantity: number;
    local: string;
    tipoItem: TipoItem;
    comitente: Comitente;
    auctions: Auction[];
}
