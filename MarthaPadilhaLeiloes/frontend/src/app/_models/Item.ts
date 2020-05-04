import { AuctionItem } from './AuctionItem';

export interface Item {
    id: number;
    businessCode: number;
    description: string;
    priceReference: number;
    local: string;
    tipoItemId: number;
    auctionItems: AuctionItem[];
}
