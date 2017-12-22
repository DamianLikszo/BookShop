import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Book } from '../models/Book'

@Injectable()
export class AddCartService {

  constructor() { }

  bookStream = new Subject<Book>();

  getBookStream() {
    return Observable.from(this.bookStream.startWith(new Book()));
  }

  putBookStream(book) {
    this.bookStream.next(book);
  }

}
