import { Component, OnInit } from '@angular/core';
import { SearchBookService } from './search-book.service';
import { BasketService } from '../basket/basket.service'
import { FormGroup, FormControl } from '@angular/forms';

import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/debounceTime';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  searchForm: FormGroup;
  basketItems: number = 0;

  constructor(private searchBookService: SearchBookService, private basketService: BasketService) {
  }

  ngOnInit() {
    this.searchForm = new FormGroup({
      'query': new FormControl('')
    })

    this.searchForm.get('query').valueChanges
      .distinctUntilChanged()
      .debounceTime(400)
      .subscribe(value => {
        this.searchBookService.search(value);
      });

      this.basketService.getBasketsStream().subscribe(aItems => {
        this.basketItems = aItems.length;
      })
  }

}
