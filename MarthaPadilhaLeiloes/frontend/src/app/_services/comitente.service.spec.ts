/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ComitenteService } from './comitente.service';

describe('Service: Comitente', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ComitenteService]
    });
  });

  it('should ...', inject([ComitenteService], (service: ComitenteService) => {
    expect(service).toBeTruthy();
  }));
});
