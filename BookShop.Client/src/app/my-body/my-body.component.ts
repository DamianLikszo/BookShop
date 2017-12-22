import { Component, OnInit } from '@angular/core';
import { SearchBookService } from '../nav-bar/search-book.service';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { Testability } from '@angular/core/src/testability/testability';
import { AddCartService } from '../add-cart/add-cart.service'

@Component({
  selector: 'app-my-body',
  templateUrl: './my-body.component.html',
  styleUrls: ['./my-body.component.css']
})

export class MyBodyComponent implements OnInit {

  books;
  modeStream = new Subject();

  constructor(private searchBookService: SearchBookService, private activeRoute: ActivatedRoute, private addCartService: AddCartService ) { }

  ngOnInit() {
    this.books = this.searchBookService.getBooksStream();
    this.activeRoute.params.subscribe(params => {
      let mode = params.mode;
      this.modeStream.next(mode);
      this.searchBookService.searchByMode(mode);
    });
  }

  getModeStream() {
    return Observable.from(this.modeStream.startWith(this.activeRoute.snapshot.params.mode));
  }

  addCart(book) {
    this.addCartService.putBookStream(book);
  }

}
