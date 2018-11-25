import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccessoriesService } from '../../../services/accessories.service';
import { DetailsService } from '../../../services/details.service';
import { DoCheck } from '@angular/core/src/metadata/lifecycle_hooks';
import { OrderAccessoriesModel } from '../../../models/order-accesories.model';
import { AccessoriesFinalModel } from '../../../models/accessories-final.model';
import { AccessoryQuantityModel } from '../../../models/accessory-quantity.model';
import { AccessoryPriceModel } from '../../../models/accessory-price.model';
import { Host } from '../../../helpers/host.helper';

@Component({
  selector: 'app-sc2-accessories',
  templateUrl: './sc2-accessories.component.html',
  styleUrls: ['../../../styles/accessories.css', '../../../styles/bike.css']
})
export class Sc2AccessoriesComponent extends Host implements OnInit, DoCheck {
  totalAccessoriesPrice = 0;
  accesories: any;
  accessoriesForOrder: OrderAccessoriesModel;
  finalAccessories: AccessoriesFinalModel[];
  isConsoleChoosen: boolean;
  accessoryQuantity: AccessoryQuantityModel;
  accessoryPrices: AccessoryPriceModel;

  constructor(private router: Router,
              private accessoriesService: AccessoriesService,
              private detailsService: DetailsService) {
    super();
  }

  ngOnInit() {
    this.getAccessories();
    this.setInitialAccessoryQuantity();
    this.setInitialAccessoryPrices();

    if (this.accessoriesService.getAccessoryQuantityForEdit()) {
      this.accessoryQuantity = this.accessoriesService.getAccessoryQuantityForEdit();
    }

    if (this.accessoriesService.getAccessoryPrices()) {
      this.accessoryPrices = this.accessoriesService.getAccessoryPrices();
    }

    this.totalAccessoriesPrice = this.calculateTotalPrice();
    this.isConsoleChoosen = this.detailsService.getIsConsoleChoosen();
  }

  ngDoCheck() {
    this.totalAccessoriesPrice = this.calculateTotalPrice();
  }

  calculateTotalPrice(): number {
    if (this.accesories) {
      this.calculateSeparatePrices();
    }
    return this.accessoryPrices.tabletHolderTotalPrice
      + this.accessoryPrices.handlebarPostTotalPrice
      + this.accessoryPrices.aerobarTotalPrice
      + this.accessoryPrices.mediaShelfTotalPrice
      + this.accessoryPrices.phoneHolderTotalPrice
      + this.accessoryPrices.seatPostTotalPrice
      + this.accessoryPrices.stagesDumbbellHolderTotalPrice
      + this.accessoryPrices.sbnpOneToSixtyTotalPrice
      + this.accessoryPrices.sbnpSixtyOneToHundredTotalPrice
      + this.accessoryPrices.sbnpOneToEightyTotalPrice
      + this.accessoryPrices.sbnpOneStagesLogoTotalPrice
      + this.accessoryPrices.sbnpOneToThirtyTotalPrice;
  }

  calculateSeparatePrices() {
    this.accessoryPrices.tabletHolderTotalPrice = this.accesories.TabletHolders[0].BasePrice * this.accessoryQuantity.tabletHolderQuantity;
    this.accessoryPrices.handlebarPostTotalPrice = this.accesories.HandlebarPosts[0].BasePrice *
      this.accessoryQuantity.handlebarPostQuantity;
    this.accessoryPrices.aerobarTotalPrice = this.accesories.Aerobars[0].BasePrice * this.accessoryQuantity.aerobarQuantity;
    this.accessoryPrices.mediaShelfTotalPrice = this.accesories.MediaShelves[0].BasePrice * this.accessoryQuantity.mediaShelfQuantity;
    this.accessoryPrices.phoneHolderTotalPrice = this.accesories.PhoneHolders[0].BasePrice * this.accessoryQuantity.phoneHolderQuantity;
    this.accessoryPrices.seatPostTotalPrice = this.accesories.SeatPosts[0].BasePrice * this.accessoryQuantity.seatPostQuantity;
    this.accessoryPrices.stagesDumbbellHolderTotalPrice = this.accesories.StagesDumbbellHolders[0].BasePrice *
      this.accessoryQuantity.stagesDumbbellHolderQuantity;
    this.accessoryPrices.sbnpOneToSixtyTotalPrice = this.accesories.StagesBikeNumberPlates[0].BasePrice *
      this.accessoryQuantity.sbnpOneToSixtyQuantity;
    this.accessoryPrices.sbnpSixtyOneToHundredTotalPrice = this.accesories.StagesBikeNumberPlates[1].BasePrice *
      this.accessoryQuantity.sbnpSixtyOneToHundredQuantity;
    this.accessoryPrices.sbnpOneToEightyTotalPrice = this.accesories.StagesBikeNumberPlates[2].BasePrice *
      this.accessoryQuantity.sbnpOneToEightyQuantity;
    this.accessoryPrices.sbnpOneStagesLogoTotalPrice = this.accesories.StagesBikeNumberPlates[3].BasePrice *
      this.accessoryQuantity.sbnpOneStagesLogoQuantity;
    this.accessoryPrices.sbnpOneToThirtyTotalPrice = this.accesories.StagesBikeNumberPlates[4].BasePrice *
      this.accessoryQuantity.sbnpOneToThirtyQuantity;
  }

  setInitialAccessoryPrices() {
    this.accessoryPrices = {
      tabletHolderTotalPrice: 0,
      mediaShelfTotalPrice: 0,
      handlebarPostTotalPrice: 0,
      seatPostTotalPrice: 0,
      phoneHolderTotalPrice: 0,
      stagesDumbbellHolderTotalPrice: 0,
      aerobarTotalPrice: 0,
      sbnpOneToSixtyTotalPrice: 0,
      sbnpSixtyOneToHundredTotalPrice: 0,
      sbnpOneToEightyTotalPrice: 0,
      sbnpOneStagesLogoTotalPrice: 0,
      sbnpOneToThirtyTotalPrice: 0
    };
  }

  setInitialAccessoryQuantity() {
    this.accessoryQuantity = {
      aerobarQuantity: 0,
      handlebarPostQuantity: 0,
      mediaShelfQuantity: 0,
      phoneHolderQuantity: 0,
      sbnpOneStagesLogoQuantity: 0,
      sbnpOneToEightyQuantity: 0,
      sbnpOneToSixtyQuantity: 0,
      sbnpOneToThirtyQuantity: 0,
      sbnpSixtyOneToHundredQuantity: 0,
      seatPostQuantity: 0,
      stagesDumbbellHolderQuantity: 0,
      tabletHolderQuantity: 0
    };
  }

  getAccessories() {
    this.accessoriesService.getAccessories().subscribe(data => {
      this.accesories = data;
    });
  }

  setAccessoriesForOrder() {
    this.accessoriesForOrder = {
      TabletHolderId: this.accessoryQuantity.tabletHolderQuantity ? this.accesories.TabletHolders[0].Id : null,
      TabletHolderQuantity: this.accessoryQuantity.tabletHolderQuantity,
      PhoneHolderId: this.accessoryQuantity.phoneHolderQuantity ? this.accesories.PhoneHolders[0].Id : null,
      PhoneHolderQuantity: this.accessoryQuantity.phoneHolderQuantity,
      MediaShelfId: this.accessoryQuantity.mediaShelfQuantity ? this.accesories.MediaShelves[0].Id : null,
      MediaShelfQuantity: this.accessoryQuantity.mediaShelfQuantity,
      SeatPostId: this.accessoryQuantity.seatPostQuantity ? this.accesories.SeatPosts[0].Id : null,
      SeatPostQuantity: this.accessoryQuantity.seatPostQuantity,
      HandlebarPostId: this.accessoryQuantity.handlebarPostQuantity ? this.accesories.HandlebarPosts[0].Id : null,
      HandlebarPostQuantity: this.accessoryQuantity.handlebarPostQuantity,
      StagesDumbbellHolderId: this.accessoryQuantity.stagesDumbbellHolderQuantity ? this.accesories.StagesDumbbellHolders[0].Id : null,
      StagesDumbbellHolderQuantity: this.accessoryQuantity.stagesDumbbellHolderQuantity,
      AerobarId: this.accessoryQuantity.aerobarQuantity ? this.accesories.Aerobars[0].Id : null,
      AerobarQuantity: this.accessoryQuantity.aerobarQuantity,
      PlatesOneToSixtyId: this.accessoryQuantity.sbnpOneToSixtyQuantity ? this.accesories.StagesBikeNumberPlates[0].Id : null,
      PlatesOneToSixtyQuntity: this.accessoryQuantity.sbnpOneToSixtyQuantity,
      PlatesSixtyOneToHundredId: this.accessoryQuantity.sbnpSixtyOneToHundredQuantity ? this.accesories.StagesBikeNumberPlates[1].Id : null,
      PlatesSixtyOneToHundredQuantity: this.accessoryQuantity.sbnpSixtyOneToHundredQuantity,
      PlatesOneToEightyId: this.accessoryQuantity.sbnpOneToEightyQuantity ? this.accesories.StagesBikeNumberPlates[2].Id : null,
      PlatesOneToEightyQuantity: this.accessoryQuantity.sbnpOneToEightyQuantity,
      PlatesFiftyPeacesId: this.accessoryQuantity.sbnpOneStagesLogoQuantity ? this.accesories.StagesBikeNumberPlates[3].Id : null,
      PlatesFiftyPeacesQuantity: this.accessoryQuantity.sbnpOneStagesLogoQuantity,
      PlatesOneToThirtyId: this.accessoryQuantity.sbnpOneToThirtyQuantity ? this.accesories.StagesBikeNumberPlates[4].Id : null,
      PlatesOneToThirtyQuantity: this.accessoryQuantity.sbnpOneToThirtyQuantity,
    };

    this.accessoriesService.setAccessoriesForOrder(this.accessoriesForOrder);
  }

  setChosenAccessoriesForFinalConfiguration() {
    this.finalAccessories = [
      {
        accessoryName: this.accesories.TabletHolders[0].Title,
        accessoryQuantity: this.accessoryQuantity.tabletHolderQuantity
      },
      {
        accessoryName: this.accesories.Aerobars[0].Title,
        accessoryQuantity: this.accessoryQuantity.aerobarQuantity
      },
      {
        accessoryName: this.accesories.PhoneHolders[0].Title,
        accessoryQuantity: this.accessoryQuantity.phoneHolderQuantity
      },
      {
        accessoryName: this.accesories.SeatPosts[0].Title,
        accessoryQuantity: this.accessoryQuantity.seatPostQuantity
      },
      {
        accessoryName: this.accesories.StagesDumbbellHolders[0].Title,
        accessoryQuantity: this.accessoryQuantity.stagesDumbbellHolderQuantity
      },
      {
        accessoryName: this.accesories.MediaShelves[0].Title,
        accessoryQuantity: this.accessoryQuantity.mediaShelfQuantity
      },
      {
        accessoryName: this.accesories.StagesBikeNumberPlates[0].Title,
        accessoryQuantity: this.accessoryQuantity.sbnpOneToSixtyQuantity
      },
      {
        accessoryName: this.accesories.StagesBikeNumberPlates[1].Title,
        accessoryQuantity: this.accessoryQuantity.sbnpSixtyOneToHundredQuantity
      },
      {
        accessoryName: this.accesories.StagesBikeNumberPlates[2].Title,
        accessoryQuantity: this.accessoryQuantity.sbnpOneToEightyQuantity
      },
      {
        accessoryName: this.accesories.StagesBikeNumberPlates[3].Title,
        accessoryQuantity: this.accessoryQuantity.sbnpOneStagesLogoQuantity
      },
      {
        accessoryName: this.accesories.StagesBikeNumberPlates[4].Title,
        accessoryQuantity: this.accessoryQuantity.sbnpOneToThirtyQuantity
      }
    ];

    this.accessoriesService.setAccessoriesForFinalConfiguration(this.finalAccessories);
  }

  setQuantitiesForEdit() {
    this.accessoriesService.setAccessoryQuantityForEdit(this.accessoryQuantity);
  }

  setPricesForEdit() {
    this.accessoriesService.setAccessoryPrices(this.accessoryPrices);
  }

  setTotalAccessoriesPrice() {
    this.accessoriesService.setAccessoriesTotalPrice(this.totalAccessoriesPrice);
  }

  setAccessoriesToDefault() {
    this.accessoriesService.setAccessoriesForFinalConfiguration(null);
    this.accessoriesService.setAccessoriesForOrder(null);
    this.accessoriesService.setAccessoriesTotalPrice(0);
    this.accessoriesService.setAccessoryPrices(null);
    this.accessoriesService.setAccessoryQuantityForEdit(null);
    this.accessoriesService.setIsMediaShelfChoosen(false);
  }

  backToOptions() {
    this.setQuantitiesForEdit();
    this.setPricesForEdit();
    this.router.navigate(['/sc2-model']);
  }

  changeModel() {
    this.setAccessoriesToDefault();
    this.router.navigate(['/choose-model']);
  }

  finalConfigurationSC2() {
    this.setAccessoriesForOrder();
    this.setTotalAccessoriesPrice();
    this.setQuantitiesForEdit();
    this.setPricesForEdit();
    this.setChosenAccessoriesForFinalConfiguration();

    this.router.navigate(['/final-configuration-sc2']);
  }

  decrementTabletHolderQuantity() {
    if (this.accessoryQuantity.tabletHolderQuantity !== 0) {
      this.accessoryQuantity.tabletHolderQuantity--;
      this.accessoryPrices.tabletHolderTotalPrice = this.accessoryQuantity.tabletHolderQuantity *
        this.accesories.TabletHolders[0].BasePrice;
    }
  }

  incrementTabletHolderQuantity() {
    this.accessoryQuantity.tabletHolderQuantity++;
    this.accessoryPrices.tabletHolderTotalPrice = this.accessoryQuantity.tabletHolderQuantity * this.accesories.TabletHolders[0].BasePrice;
  }

  decrementAerobarQuantity() {
    if (this.accessoryQuantity.aerobarQuantity !== 0) {
      this.accessoryQuantity.aerobarQuantity--;
      this.accessoryPrices.aerobarTotalPrice = this.accessoryQuantity.aerobarQuantity * this.accesories.Aerobars[0].BasePrice;
    }
  }

  incrementAerobarQuantity() {
    this.accessoryQuantity.aerobarQuantity++;
    this.accessoryPrices.aerobarTotalPrice = this.accessoryQuantity.aerobarQuantity * this.accesories.Aerobars[0].BasePrice;
  }

  decrementMediaShelfQuantity () {
    if (this.accessoryQuantity.mediaShelfQuantity !== 0) {
      this.accessoryQuantity.mediaShelfQuantity--;
      this.accessoryPrices.mediaShelfTotalPrice = this.accessoryQuantity.mediaShelfQuantity * this.accesories.MediaShelves[0].BasePrice;
    }
  }

  incrementMediaShelfQuantity() {
    this.accessoryQuantity.mediaShelfQuantity++;
    this.accessoryPrices.mediaShelfTotalPrice = this.accessoryQuantity.mediaShelfQuantity * this.accesories.MediaShelves[0].BasePrice;
  }

  decrementStagesDumbbellHolderQuantity() {
    if (this.accessoryQuantity.stagesDumbbellHolderQuantity !== 0) {
      this.accessoryQuantity.stagesDumbbellHolderQuantity--;
      this.accessoryPrices.stagesDumbbellHolderTotalPrice = this.accessoryQuantity.stagesDumbbellHolderQuantity
       * this.accesories.StagesDumbbellHolders[0].BasePrice;
    }
  }

  incrementStagesDumbbellHolderQuantity() {
    this.accessoryQuantity.stagesDumbbellHolderQuantity++;
    this.accessoryPrices.stagesDumbbellHolderTotalPrice = this.accessoryQuantity.stagesDumbbellHolderQuantity
      * this.accesories.StagesDumbbellHolders[0].BasePrice;
  }

  decrementHandlebarPostQuantity() {
    if (this.accessoryQuantity.handlebarPostQuantity !== 0) {
      this.accessoryQuantity.handlebarPostQuantity--;
      this.accessoryPrices.handlebarPostTotalPrice = this.accessoryQuantity.handlebarPostQuantity *
        this.accesories.HandlebarPosts[0].BasePrice;
    }
  }

  incrementHandlebarPostQuantity() {
    this.accessoryQuantity.handlebarPostQuantity++;
    this.accessoryPrices.handlebarPostTotalPrice = this.accessoryQuantity.handlebarPostQuantity *
      this.accesories.HandlebarPosts[0].BasePrice;
  }

  decrementSeatPostQuantity() {
    if (this.accessoryQuantity.seatPostQuantity !== 0) {
      this.accessoryQuantity.seatPostQuantity--;
      this.accessoryPrices.seatPostTotalPrice = this.accessoryQuantity.seatPostQuantity * this.accesories.SeatPosts[0].BasePrice;
    }
  }

  incrementSeatPostQuantity() {
    this.accessoryQuantity.seatPostQuantity++;
    this.accessoryPrices.seatPostTotalPrice = this.accessoryQuantity.seatPostQuantity * this.accesories.SeatPosts[0].BasePrice;
  }

  decrementPhoneHolderQuantity() {
    if (this.accessoryQuantity.phoneHolderQuantity !== 0) {
      this.accessoryQuantity.phoneHolderQuantity--;
      this.accessoryPrices.phoneHolderTotalPrice = this.accessoryQuantity.phoneHolderQuantity * this.accesories.PhoneHolders[0].BasePrice;
    }
  }

  incrementPhoneHolderQuantity() {
    this.accessoryQuantity.phoneHolderQuantity++;
    this.accessoryPrices.phoneHolderTotalPrice = this.accessoryQuantity.phoneHolderQuantity * this.accesories.PhoneHolders[0].BasePrice;
  }

  incrementOneToSixty() {
    this.accessoryQuantity.sbnpOneToSixtyQuantity++;
    this.accessoryPrices.sbnpOneToSixtyTotalPrice = this.accessoryQuantity.sbnpOneToSixtyQuantity *
      this.accesories.StagesBikeNumberPlates[0].BasePrice;
  }

  decrementOneToSixty() {
    if (this.accessoryQuantity.sbnpOneToSixtyQuantity !== 0) {
      this.accessoryQuantity.sbnpOneToSixtyQuantity--;
      this.accessoryPrices.sbnpOneToSixtyTotalPrice = this.accessoryQuantity.sbnpOneToSixtyQuantity *
        this.accesories.StagesBikeNumberPlates[0].BasePrice;
    }
  }

  incrementSixtyToHundred() {
    this.accessoryQuantity.sbnpSixtyOneToHundredQuantity++;
    this.accessoryPrices.sbnpSixtyOneToHundredTotalPrice = this.accessoryQuantity.sbnpSixtyOneToHundredQuantity *
      this.accesories.StagesBikeNumberPlates[1].BasePrice;
  }

  decrementSixtyToHundred() {
    if (this.accessoryQuantity.sbnpSixtyOneToHundredQuantity !== 0) {
      this.accessoryQuantity.sbnpSixtyOneToHundredQuantity--;
      this.accessoryPrices.sbnpSixtyOneToHundredTotalPrice = this.accessoryQuantity.sbnpSixtyOneToHundredQuantity *
        this.accesories.StagesBikeNumberPlates[1].BasePrice;
    }
  }

  incrementOneToEighty() {
    this.accessoryQuantity.sbnpOneToEightyQuantity++;
    this.accessoryPrices.sbnpOneToEightyTotalPrice = this.accessoryQuantity.sbnpOneToEightyQuantity *
      this.accesories.StagesBikeNumberPlates[2].BasePrice;
  }

  decrementOneToEighty() {
    if (this.accessoryQuantity.sbnpOneToEightyQuantity !== 0) {
      this.accessoryQuantity.sbnpOneToEightyQuantity--;
      this.accessoryPrices.sbnpOneToEightyTotalPrice = this.accessoryQuantity.sbnpOneToEightyQuantity *
        this.accesories.StagesBikeNumberPlates[2].BasePrice;
    }
  }

  incrementStagesLogo() {
    this.accessoryQuantity.sbnpOneStagesLogoQuantity++;
    this.accessoryPrices.sbnpOneStagesLogoTotalPrice = this.accessoryQuantity.sbnpOneStagesLogoQuantity *
      this.accesories.StagesBikeNumberPlates[3].BasePrice;
  }

  decrementStagesLogo() {
    if (this.accessoryQuantity.sbnpOneStagesLogoQuantity !== 0) {
      this.accessoryQuantity.sbnpOneStagesLogoQuantity--;
      this.accessoryPrices.sbnpOneStagesLogoTotalPrice = this.accessoryQuantity.sbnpOneStagesLogoQuantity *
        this.accesories.StagesBikeNumberPlates[3].BasePrice;
    }
  }

  incrementOneToThirty() {
    this.accessoryQuantity.sbnpOneToThirtyQuantity++;
    this.accessoryPrices.sbnpOneToThirtyTotalPrice = this.accessoryQuantity.sbnpOneToThirtyQuantity *
      this.accesories.StagesBikeNumberPlates[4].BasePrice;
  }

  decrementOneToThirty() {
    if (this.accessoryQuantity.sbnpOneToThirtyQuantity !== 0) {
      this.accessoryQuantity.sbnpOneToThirtyQuantity--;
      this.accessoryPrices.sbnpOneToThirtyTotalPrice = this.accessoryQuantity.sbnpOneToThirtyQuantity *
        this.accesories.StagesBikeNumberPlates[4].BasePrice;
    }
  }
}
