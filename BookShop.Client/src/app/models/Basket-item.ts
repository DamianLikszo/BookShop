export class BasketItem {
    title:string;
    carrier:string;
    quantity: number;

    constructor({title, carrier, quantity}) {
        this.title = title;
        this.carrier = carrier;
        this.quantity = quantity;
    }
}