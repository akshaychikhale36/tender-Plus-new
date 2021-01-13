import { Injectable } from '@angular/core';
export const browserWindow = window || {};
export const browserWindowEnv = browserWindow['__env'] || {};
@Injectable({
  providedIn: 'root'
})
export class EnvService {
  public localBaseUrl='https://localhost:5001/';
  constructor() {
    for (const key in browserWindowEnv) {
      if (browserWindowEnv.hasOwnProperty(key)) {
        this[key] = window['__env'][key];
      }
    }
  }
}
