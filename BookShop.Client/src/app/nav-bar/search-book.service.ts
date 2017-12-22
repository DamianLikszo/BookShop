import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http/';
import { Observable, Subject } from 'rxjs';
import { MyConfig } from '../my-config'
import { Category } from '../Enums/Category'
import { ExtraCategory } from '../Enums/ExtraCategory'

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';

@Injectable()
export class SearchBookService {

  books = [];
  category = 0;
  extraCategory = 0;
  oldFiltrValue = '';

  booksStream = new Subject();

  constructor(private http: Http, private myConfig: MyConfig) {
  }

  getBooksStream() {
    return Observable.from(this.booksStream.startWith(this.books));
  }

  search(filtrValue = null) {
    let url = this.getUrl(filtrValue);

    this.http.get(url)
      .map((response: Response) => {
        let data = response.json();
        return data;
      })
      .do((books) => {
        this.books = books;
      })
      .subscribe((books) => {
        this.booksStream.next(books);
      })
  }

  searchByMode(mode: string) {
    this.category = Category.None;
    this.extraCategory = ExtraCategory.None;

    switch (mode) {
      case 'audiobook':
        this.category = Category.Audiobooki;
        break;
      case 'ebook':
        this.category = Category.Ebooki;
        break;
      case 'new':
        this.extraCategory = ExtraCategory.New;
        break;
      case 'release':
        this.extraCategory = ExtraCategory.Release;
        break;
      case 'opportunity':
        this.extraCategory = ExtraCategory.Opportunity;
        break;
    }
    this.search();
  }

  private getUrl(filtrValue = null) {
    let aQuery = new Array();
    let url = this.myConfig.webApiUrl + '/api/Books';

    if (filtrValue == null)
      filtrValue = this.oldFiltrValue;

    if (filtrValue != '')
      aQuery['filtrValue'] = filtrValue;
    if (this.category > Category.None)
      aQuery['category'] = this.category;
    if (this.extraCategory > ExtraCategory.None)
      aQuery['extraCategory'] = this.extraCategory;

    for (let key in aQuery) {
      if (aQuery.hasOwnProperty(key)) {
        url += (Object.keys(aQuery).indexOf(key) == 0 ? '?' : '&') + key + '=' + aQuery[key];
      }
    }

    this.oldFiltrValue = filtrValue;

    return url;
  }

}
