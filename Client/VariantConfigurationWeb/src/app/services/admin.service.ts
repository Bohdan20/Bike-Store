import { Http, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { OrderAccessoriesModel } from '../models/order-accesories.model';
import { AccessoriesFinalModel } from '../models/accessories-final.model';
import { AuthService } from './auth.service';
import { AccessoryQuantityModel } from '../models/accessory-quantity.model';
import { AccessoryPriceModel } from '../models/accessory-price.model';
import { Host } from '../helpers/host.helper';

@Injectable()
export class AdminService extends Host {
    GET_ITEMS_ENDPOINT = this.host + 'api/admin/items';
    EDIT_ITEM_ENDPOINT = this.host + 'api/admin/edit';
    EDIT_PRICE_ENDPOINT = this.host + 'api/admin/editprice';
    constructor(private http: Http, private authService: AuthService) {
        super();
    }

    getAllItems() {
        return this.http.get(this.GET_ITEMS_ENDPOINT)
            .map(res => res.json());
    }

    editItem(body: any) {
        return this.http.put(this.EDIT_ITEM_ENDPOINT, body);
    }

    editPrice(body: any) {
        return this.http.put(this.EDIT_PRICE_ENDPOINT, body);
    }
}
