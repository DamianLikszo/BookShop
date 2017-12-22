import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http/';
import { Observable, Subject } from 'rxjs';
import { Carrier } from '../models/Carrier'
import { MyConfig } from '../my-config';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';

@Injectable()
export class GetCarriresService {

  carrires = [];
  carriresStream = new Subject<Array<Carrier>>();

  constructor(private http: Http, private myConfig:MyConfig) {
    this.getCarrires();
   }

  private getCarrires() {
    let url = this.myConfig.webApiUrl + "/api/Carrires";

    this.http.get(url)
      .map((response: Response) => {
        let data = response.json();
        return data;
      })
      .do((carrires) => {
        this.carrires = carrires;
      })
      .subscribe((carrires) => {
        this.carriresStream.next(carrires);
      })
  }

  getCarriresStream() {
    return Observable.from(this.carriresStream.startWith(this.carrires));
  }
}
