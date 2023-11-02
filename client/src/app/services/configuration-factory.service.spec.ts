import { TestBed } from '@angular/core/testing';

import { ConfigurationFactoryService } from './configuration-factory.service';

describe('ConfigurationFactoryService', () => {
  let service: ConfigurationFactoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfigurationFactoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
