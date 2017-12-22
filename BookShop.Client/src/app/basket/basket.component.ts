import { Component, OnInit } from '@angular/core';
import { BasketService } from '../basket/basket.service'
import { Observable } from 'rxjs';
import { BasketItem } from '../models/Basket-item'

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styles: []
})
export class BasketComponent implements OnInit {

  items: Observable<BasketItem[]>;

  constructor(private basketService: BasketService ) { }

  ngOnInit() {
    this.items = this.basketService.getBasketsStream();
  }

}
