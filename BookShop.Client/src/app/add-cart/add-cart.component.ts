import { Component, OnInit } from '@angular/core';
import { AddCartService } from './add-cart.service'
import { GetCarriresService } from './get-carrires.service'
import { BasketService } from '../basket/basket.service'
import { BasketItem } from '../models/Basket-item';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';

declare var jQuery: any;

@Component({
  selector: 'app-add-cart',
  templateUrl: './add-cart.component.html',
  styles: []
})
export class AddCartComponent implements OnInit {

  carrires
  baskerItem: BasketItem
  bookTitle = "";

  cardForm: FormGroup = new FormGroup({
    title: new FormControl({ value: '', disabled: true }),
    carrier: new FormControl('', Validators.required),
    quantity: new FormControl(1, Validators.min(1))
  });

  constructor(private addCartService: AddCartService,
    private getCarriersService: GetCarriresService,
    private basketService: BasketService,
    private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.carrires = this.getCarriersService.getCarriresStream();

    this.addCartService.getBookStream().subscribe(value => {
      this.bookTitle = value.Title;
      this.cardForm.patchValue({ title: this.bookTitle });
    })

    this.getCarriersService.getCarriresStream().subscribe(value => {
      if (value.length > 0)
        this.cardForm.patchValue({ carrier: value[0] });
    });
  }

  save() {
    let basketitem: BasketItem = new BasketItem(this.cardForm.value);
    basketitem.title = this.bookTitle;
    this.basketService.add(basketitem);
    jQuery('#myCart').modal('hide');
  }

}
