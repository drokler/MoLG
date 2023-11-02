import { Injectable } from '@angular/core';
import { Configuration } from 'src/gen';

@Injectable({
  providedIn: 'root',
})
export class ConfigurationFactoryService {
  private _configuration: Configuration;
  constructor() {
    this._configuration = new Configuration({
      basePath: 'http://localhost:5187',
      accessToken: localStorage.getItem('authToken') ?? undefined,
    });
  }

  public get configuration() {
    return this._configuration;
  }

  public set token(value: string | null) {
    if (value) {
      localStorage.setItem('authToken', value);
      this._configuration.config = new Configuration({
        ...this._configuration,
        accessToken: value,
      });
    } else {
      localStorage.removeItem('authToken');
      this._configuration.config = new Configuration({
        ...this._configuration,
        accessToken: undefined,
      });
    }
  }
}
