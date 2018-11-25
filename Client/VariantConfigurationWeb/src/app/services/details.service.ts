import { Http, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

import { OrderDetailsModel } from '../models/order-details.model';
import { DetailsFinalModel } from '../models/details-final.model';
import { Observable } from 'rxjs/Observable';
import { AuthService } from './auth.service';
import { Host } from '../helpers/host.helper';

@Injectable()
export class DetailsService extends Host {
    savedDetails: any;
    detailsForOrder: OrderDetailsModel;
    bikePrice: number;
    finalDetails: DetailsFinalModel[];
    customSelectedArtworks;
    isConsoleChosen: boolean;
    DETAILS_ENDPOINT = this.host + '/api/order/details';
    UPLOAD_IMAGE_ENDPOINT = this.host + '/api/order/upload';

    constructor(private http: Http, private authService: AuthService) {
        super();
    }

    getDetails() {
        const headers = this.authService.createHeaders();
        if (this.savedDetails) {
            return Observable.create(observer => {
                observer.next(this.savedDetails);
                observer.complete();
            });
        } else {
            return this.http.get(this.DETAILS_ENDPOINT, { headers: headers })
                .map(res => res.json());
        }
    }

    setDetailsForOrder(details: OrderDetailsModel) {
        this.detailsForOrder = details;
    }

    getDetailsForOrder(): OrderDetailsModel {
        return this.detailsForOrder;
    }

    setDetailsForFinalConfiguration(details: DetailsFinalModel[]) {
        this.finalDetails = details;
    }

    getDetailsForFinalConfiguration() {
        return this.finalDetails;
    }

    setBikePrice(bikePrice: number) {
        this.bikePrice = bikePrice;
    }

    getBikePrice() {
        return this.bikePrice;
    }

    saveDetails(details: any) {
        this.savedDetails = details;
    }

    setSelectedCustomArtworks(artworks: any) {
        this.customSelectedArtworks = artworks;
    }

    getSelectedCustomArtworks() {
        if (this.customSelectedArtworks) {
            return this.customSelectedArtworks;
        }
    }

    setIsConsoleChoosen(isConsoleChoosen: boolean) {
        this.isConsoleChosen = isConsoleChoosen;
    }

    getIsConsoleChoosen() {
        return this.isConsoleChosen;
    }

    uploadImage(fileList: FileList) {
        if (fileList.length > 0) {
            const file: File = fileList[0];
            const formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            const headers = this.authService.createHeaders();
            headers.append('Accept', 'application/json');
            const options = new RequestOptions({ headers: headers });

            return this.http.post(this.UPLOAD_IMAGE_ENDPOINT, formData, options);
        }
    }
}
