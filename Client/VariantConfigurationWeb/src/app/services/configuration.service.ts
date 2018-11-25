import { Http, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { AuthService } from './auth.service';
import { Host } from '../helpers/host.helper';

@Injectable()
export class ConfigurationService extends Host {
    CREATE_ORDER_ENDPOINT = this.host + '/api/order/create';
    GET_CONFIGURATIONS_ENDPOINT = this.host + '/api/order/configurations';
    CREATE_SALES_ORDER_ENDPOINT = this.host + '/api/order/check';
    SAVED_ORDER_ENDPOINT = this.host + '/api/order/savedorder';
    bikeQuantity: number;
    discountAmount: number;
    priceDiscount: any;
    customerComment: any;

    constructor(private http: Http, private authService: AuthService) {
        super();
    }

    createOrder(model: any) {
        const headers = this.authService.createHeaders();
        return this.http.post(this.CREATE_ORDER_ENDPOINT, model, { headers: headers });
    }

    getConfigurations() {
        const headers = this.authService.createHeaders();
        return this.http.get(this.GET_CONFIGURATIONS_ENDPOINT, { headers: headers })
            .map(res => res.json());
    }

    createSalesOrder(id: number) {
        const headers = this.authService.createHeaders();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        const options = new RequestOptions({ headers: headers});

        return this.http.post(this.CREATE_SALES_ORDER_ENDPOINT + '?id=' + id, null , options);
    }

    getconfiguration(id: number) {
        const headers = this.authService.createHeaders();
        return this.http.get(this.SAVED_ORDER_ENDPOINT, {
            params : {
                id: id
            }, headers: headers
        }).map(res => res.json());
    }

    setBikeQuantity(bikeQuantity: number) {
        this.bikeQuantity = bikeQuantity;
    }

    getBikeQuantity(): number {
        return this.bikeQuantity;
    }

    setDiscountAmount(discountAmount: number) {
        this.discountAmount = discountAmount;
    }

    getDiscountAmount(): number {
        return this.discountAmount;
    }

    setPriceDiscount(obj: any) {
        this.priceDiscount = obj;
    }

    getPriceDiscount(): any {
        return this.priceDiscount;
    }

    setCustomerAndComment(customerComment: any) {
        this.customerComment = customerComment;
    }

    getCustomerAndComment() {
        return this.customerComment;
    }
}
