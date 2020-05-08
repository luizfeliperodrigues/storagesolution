import { AuctionItem } from './AuctionItem';
import { Auction } from './Auction';

export interface Item {
    id: number;
    businessCode: number;
    description: string;
    priceReference: number;
    local: string;
    tipoItemId: number;
    auctions: Auction[];
}
