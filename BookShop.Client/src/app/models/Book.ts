import { Author } from './Author'
import { Carrier } from './Carrier'
import { PublishingHouse } from './PublishingHouse'

export class Book {
    DateAdded: Date;
    DateRelease: Date;
    Opportunity: boolean;
    Price: number;
    Title:string;

    Author: Author;
    Category: Carrier;
    PublishingHouse: PublishingHouse;
}