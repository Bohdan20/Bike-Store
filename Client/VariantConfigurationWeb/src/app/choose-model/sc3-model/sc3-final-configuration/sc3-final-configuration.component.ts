import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';

import { DetailsService } from '../../../services/details.service';
import { AccessoriesService } from '../../../services/accessories.service';
import { ConfigurationService } from '../../../services/configuration.service';
import { DetailsFinalModel } from '../../../models/details-final.model';
import { AccessoriesFinalModel } from '../../../models/accessories-final.model';
import { Host } from '../../../helpers/host.helper';

@Component({
  selector: 'app-sc3-final-configuration',
  templateUrl: './sc3-final-configuration.component.html',
  styleUrls: ['../../../styles/final-configuration.css', '../../../styles/bike.css']
})
export class Sc3FinalConfigurationComponent extends Host implements OnInit, DoCheck {
  details: DetailsFinalModel[];
  accessories: AccessoriesFinalModel[];
  bikeQuantity = 1;
  bikePrice: number;
  totalBikePrice: number;
  totalAccessoriesPrice: number;
  generalPrice: number;
  discountAmount: number;
  discountedPrice: number;
  netPrice = 0;
  comment: string;
  customerName: string;
  saveConfigurationModel = {};
  customArtworks: any;
  quantityErrorMessage: string;
  discountErrorMessage: string;

  constructor(private router: Router,
    private detailsService: DetailsService,
    private accessoriesService: AccessoriesService,
    private configurationService: ConfigurationService) {
      super();
    }

  ngOnInit() {
    this.getDetails();
    this.getAccessories();
    this.getBikePrice();
    this.getAccessoriesPrice();
    this.getCustomArtworks();

    if (this.configurationService.getBikeQuantity()) {
      this.bikeQuantity = this.configurationService.getBikeQuantity();
      this.totalBikePrice = this.bikePrice * this.bikeQuantity;
      this.generalPrice = this.totalBikePrice + this.totalAccessoriesPrice;
    }

    if (this.configurationService.getDiscountAmount()) {
      this.discountAmount = this.configurationService.getDiscountAmount();
      this.discountedPrice = (this.generalPrice * this.discountAmount / 100);
    }

    if (this.configurationService.getCustomerAndComment()) {
      const customerComment = this.configurationService.getCustomerAndComment();

      this.customerName = customerComment.customerName;
      this.comment = customerComment.comment;
    }
  }

  ngDoCheck() {
    this.generalPrice = this.totalBikePrice + this.totalAccessoriesPrice;

    if (this.discountAmount < 0) {
      this.discountErrorMessage = 'Discount can not be less than 0';
    } else if (this.discountAmount > 100) {
      this.discountErrorMessage = 'Discount can not be greater than 100';
    } else {
      this.discountErrorMessage = '';
    }

    if (this.bikeQuantity < 1) {
      this.quantityErrorMessage = 'Quantity can not be less than 1';
    } else {
      this.quantityErrorMessage = '';
      this.totalBikePrice = this.bikePrice * this.bikeQuantity;
      this.generalPrice = this.totalBikePrice + this.totalAccessoriesPrice;
    }

    if ((this.discountAmount >= 0 && this.discountAmount <= 100) || this.discountAmount === undefined) {
      if (this.discountAmount) {
        this.discountedPrice = (this.generalPrice * this.discountAmount / 100);
      } else {
        this.discountedPrice = 0;
      }

      this.netPrice = this.generalPrice - this.discountedPrice;
    }
  }

  getDetails() {
    this.details = this.detailsService.getDetailsForFinalConfiguration();
    this.details = this.details.filter(x => x.detailChoosenOption !== undefined);
  }

  getAccessories() {
    this.accessories = this.accessoriesService.getAccessoriesForFinalConfiguration();
    this.accessories = this.accessories.filter(x => x.accessoryQuantity);
  }

  getBikePrice() {
    this.bikePrice = this.detailsService.getBikePrice();
    this.totalBikePrice = this.bikePrice;
  }

  getAccessoriesPrice() {
    this.totalAccessoriesPrice = this.accessoriesService.getAccessoriesTotalPrice();
  }

  getCustomArtworks() {
    this.customArtworks = this.detailsService.getSelectedCustomArtworks();
  }

  setAccessoriesToDefault() {
    this.accessoriesService.setAccessoriesForFinalConfiguration(null);
    this.accessoriesService.setAccessoriesForOrder(null);
    this.accessoriesService.setAccessoriesTotalPrice(0);
    this.accessoriesService.setAccessoryPrices(null);
    this.accessoriesService.setAccessoryQuantityForEdit(null);
    this.accessoriesService.setIsMediaShelfChoosen(false);
  }

  setDiscountAndQuantityToDefault() {
    this.configurationService.setBikeQuantity(0);
    this.configurationService.setDiscountAmount(0);
  }

  changeModel() {
    this.setDiscountAndQuantityToDefault();
    this.setAccessoriesToDefault();
    this.configurationService.setCustomerAndComment({});
    this.router.navigate(['/choose-model']);
  }

  saveBikeQuantity() {
    this.configurationService.setBikeQuantity(this.bikeQuantity);
  }

  saveDiscountAmount() {
    this.configurationService.setDiscountAmount(this.discountAmount);
  }

  saveCustomerAndComment() {
    this.configurationService.setCustomerAndComment({
      customerName: this.customerName,
      comment: this.comment
    });
  }

  editDetails() {
    this.saveBikeQuantity();
    this.saveDiscountAmount();
    this.saveCustomerAndComment();
    this.router.navigate(['/sc3-model']);
  }

  editAccessories() {
    this.saveBikeQuantity();
    this.saveDiscountAmount();
    this.saveCustomerAndComment();
    this.router.navigate(['/sc3-accessories']);
  }

  incrementBikeQuantity() {
    this.bikeQuantity++;
    this.totalBikePrice = this.bikePrice * this.bikeQuantity;
  }

  decrementBikeQuantity() {
    if (this.bikeQuantity !== 1) {
      this.bikeQuantity--;
      this.totalBikePrice = this.bikePrice * this.bikeQuantity;
    }
  }

  saveConfiguration() {
    this.saveConfigurationModel = {
      GrossPrice: this.generalPrice,
      Discount: this.discountAmount,
      Comment: this.comment,
      CustomerName: this.customerName,
      NetPrice: this.netPrice
    };

    const detailsForOrder = this.detailsService.getDetailsForOrder();
    detailsForOrder.CycleQuantity = this.bikeQuantity;

    const finalCreateOrderModel = Object.assign({}, this.saveConfigurationModel, detailsForOrder,
      this.accessoriesService.getAccessoriesForOrder());

    if (!this.discountErrorMessage && !this.quantityErrorMessage) {
      this.configurationService.createOrder(finalCreateOrderModel).subscribe(data => {
        if (data.statusText === 'OK') {
          this.router.navigate(['/saved-configurations']);
        }
      });
    }

  }
}
