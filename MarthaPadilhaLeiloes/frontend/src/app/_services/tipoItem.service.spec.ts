/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TipoItemService } from './tipoItem.service';

describe('Service: TipoItem', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TipoItemService]
    });
  });

  it('should ...', inject([TipoItemService], (service: TipoItemService) => {
    expect(service).toBeTruthy();
  }));
});
