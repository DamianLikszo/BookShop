import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routerModule } from './app.routing';


import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MyBodyComponent } from './my-body/my-body.component';
import { AddCartComponent } from './add-cart/add-cart.component';

import { SearchBookService } from './nav-bar/search-book.service';
import { AddCartService } from './add-cart/add-cart.service'
import { GetCarriresService } from './add-cart/get-carrires.service'
import { BasketService } from './basket/basket.service';
import { BasketComponent } from './basket/basket.component'
import { MyConfig } from './my-config';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    MyBodyComponent,
    AddCartComponent,
    BasketComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    routerModule
  ],
  providers: [ 
    SearchBookService,
    AddCartService,
    GetCarriresService,
    BasketService,
    MyConfig
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
