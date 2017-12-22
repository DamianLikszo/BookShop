import { Injectable } from '@angular/core';
import { BasketItem } from '../models/Basket-item'
import { Observable, Subject } from 'rxjs';

@Injectable()
export class BasketService {

  baskets = new Array<BasketItem>();
  private basketsStream = new Subject<Array<BasketItem>>();

  constructor() { }

  add(BasketItem) {
    this.baskets.push(BasketItem);
    this.basketsStream.next(this.baskets);
  }

  getBasketsStream() {
    return Observable.from(this.basketsStream).startWith(this.baskets);
  }

}
