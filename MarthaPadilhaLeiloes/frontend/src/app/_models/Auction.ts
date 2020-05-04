import { AuctionItem } from './AuctionItem';

export interface Auction {
    id: number;
    businessCode: number;
    negotiation: number;
    date: Date;
    auctionItems: AuctionItem[];
}
