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
export class AccessoriesService extends Host {
    accessoriesForOrder: OrderAccessoriesModel;
    finalAccessories: AccessoriesFinalModel[];
    accessoriesQuantity: AccessoryQuantityModel;
    accessoriesPrices: AccessoryPriceModel;
    savedAccessories: any;
    totalAccessoriesPrice: number;
    isMediaShelf: boolean;
    ACCESSORIES_ENDPOINT = this.host + '/api/order/accessories';

    constructor(private http: Http, private authService: AuthService) {
        super();
    }

    getAccessories() {
        const headers = this.authService.createHeaders();
        if (this.savedAccessories) {
            return Observable.create(observer => {
                observer.next(this.savedAccessories);
                observer.complete();
            });
        } else {
            return this.http.get(this.ACCESSORIES_ENDPOINT, { headers: headers })
                .map(res => res.json());
        }
    }

    saveAccessories(accessories: any) {
        this.savedAccessories = accessories;
    }

    setAccessoriesForOrder(accessories: OrderAccessoriesModel) {
        this.accessoriesForOrder = accessories;
    }

    getAccessoriesForOrder(): OrderAccessoriesModel {
        return this.accessoriesForOrder;
    }

    setAccessoriesTotalPrice(totalPrice: number) {
        this.totalAccessoriesPrice = totalPrice;
    }

    getAccessoriesTotalPrice(): number {
        return this.totalAccessoriesPrice;
    }

    setAccessoriesForFinalConfiguration(accessories: AccessoriesFinalModel[]) {
        this.finalAccessories = accessories;
    }

    getAccessoriesForFinalConfiguration(): AccessoriesFinalModel[] {
        return this.finalAccessories;
    }

    setIsMediaShelfChoosen(mediaShelfQuantity) {
        this.isMediaShelf = !!mediaShelfQuantity;
    }

    getIsMediaShelfChoosen(): boolean {
        return this.isMediaShelf;
    }

    setAccessoryQuantityForEdit(accessoryQuantity: AccessoryQuantityModel) {
        this.accessoriesQuantity = accessoryQuantity;
    }

    getAccessoryQuantityForEdit(): AccessoryQuantityModel {
        return this.accessoriesQuantity;
    }

    setAccessoryPrices(accessoryPrices: AccessoryPriceModel) {
        this.accessoriesPrices = accessoryPrices;
    }

    getAccessoryPrices(): AccessoryPriceModel {
        return this.accessoriesPrices;
    }
}

