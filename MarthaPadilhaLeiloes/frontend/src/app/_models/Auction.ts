import { AuctionItem } from './AuctionItem';
import { Item } from './Item';

export interface Auction {
    id: number;
    businessCode: number;
    negotiation: number;
    date: Date;
    items: Item[];
}
