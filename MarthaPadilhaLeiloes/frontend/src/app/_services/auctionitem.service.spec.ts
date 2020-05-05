/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AuctionitemService } from './auctionitem.service';

describe('Service: Auctionitem', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuctionitemService]
    });
  });

  it('should ...', inject([AuctionitemService], (service: AuctionitemService) => {
    expect(service).toBeTruthy();
  }));
});
