import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';
import { OrderDetailsModel } from '../../models/order-details.model';
import { DetailsFinalModel } from '../../models/details-final.model';
import { DetailsService } from '../../services/details.service';
import { Host } from '../../helpers/host.helper';

@Component({
  selector: 'app-sc3-model',
  templateUrl: './sc3-model.component.html',
  styleUrls: ['../../styles/details.css', '../../styles/bike.css']
})
export class Sc3ModelComponent extends Host implements OnInit {
  modelType = 'SC3';
  artworkBeltGuardId: number;
  artworkBeltGuardColor: string;
  artworkBeltGuardImageUrl: FormData;
  artworkFlywheelId: number;
  artworkFlywheelColor: string;
  artworkFlywheelImageUrl: FormData;
  artworkFrameForkId: number;
  artworkFrameForkColor: string;
  artworkFrameForkImageUrl: FormData;
  paintColorId: number;
  bikePrice = 0;
  previousHandlebarPrice = 0;
  previousPedalPrice = 0;
  previousPowerMeterPrice = 0;
  customBeltGuardPrice: number;
  customFrameForkPrice: number;
  customFlywheelPrice: number;
  customColorPrice: number;
  isColorChoosen = false;
  isFrameForkChoosen = false;
  isBeltGuardChoosen = false;
  isFlywheelChoosen = false;
  isHandlebarTypeChoosen = false;
  isPedalTypeChoosen = false;
  isPowerMeterChoosen = false;
  frameForkImageName: string;
  beltGuardImageName: string;
  flywheelImageName: string;
  isCustomFrameForkSelected = false;
  isCustomBeltGuardSelected = false;
  isCustomFlywheelSelected = false;
  plasticColorTypeId: number = null;
  seatTypeId: number = null;
  sprintShiftTypeId: number = null;
  consoleTypeId: number = null;
  powerMeterTypeId: number = null;
  pedalTypeId: number = null;
  handlebarTypeId: number = null;
  details: any;
  detailsForOrder: OrderDetailsModel;
  finalDetails: DetailsFinalModel[] = [];
  isConsoleChoosen: boolean;
  customSelectedArtworks = [];
  localSum: number;
  isFrameForkSelected = false;
  isBeltGuardSelected = false;
  isFlywheelSelected = false;
  bikeImageSrc: string;
  customColor: string;
  colorName: string;
  isCustomColor: boolean;

  constructor(private router: Router, private detailsService: DetailsService) {
    super();
  }

  ngOnInit() {
    this.getDetails();
    this.getSelectedCustomArtworks();
  }

  getDetails() {
    this.detailsService.getDetails().subscribe(data => {
      this.details = data;
      this.bikePrice = data.BasePriceSC3;
      this.customBeltGuardPrice = data.CustomBeltGuardPrice;
      this.customFrameForkPrice = data.CustomFrameforkPrice;
      this.customFlywheelPrice = data.CustomFlywheelPrice;
      this.customColorPrice = data.CustomColorPrice;

      this.setInitialDetailsData();
    });
  }

  getSelectedCustomArtworks() {
    const selectedCustomArtworks = this.detailsService.getSelectedCustomArtworks();

    if (selectedCustomArtworks) {
      this.isCustomFrameForkSelected = selectedCustomArtworks[0].isCustomArtworkSelected;
      this.isCustomBeltGuardSelected = selectedCustomArtworks[1].isCustomArtworkSelected;
      this.isCustomFlywheelSelected = selectedCustomArtworks[2].isCustomArtworkSelected;

      this.artworkFrameForkImageUrl = selectedCustomArtworks[0].formData;
      this.artworkBeltGuardImageUrl = selectedCustomArtworks[1].formData;
      this.artworkFlywheelImageUrl = selectedCustomArtworks[2].formData;

      this.frameForkImageName = selectedCustomArtworks[0].imageName;
      this.beltGuardImageName = selectedCustomArtworks[1].imageName;
      this.flywheelImageName = selectedCustomArtworks[2].imageName;

      this.artworkFrameForkColor = selectedCustomArtworks[0].color;
      this.artworkBeltGuardColor = selectedCustomArtworks[1].color;
      this.artworkFlywheelColor = selectedCustomArtworks[2].color;
    }

  }

  saveDetailsForEdit() {
    this.detailsService.saveDetails(this.details);
  }

  selectColor(colorId: number) {
    this.paintColorId = colorId;
    for (let i = 0; i < this.details.PaintColors.length; i++) {
      if (this.details.PaintColors[i].Id === colorId) {
        this.bikeImageSrc = this.details.PaintColors[i].BikeImageUrl;
        this.colorName = this.details.PaintColors[i].Title;
      }
    }
  }

  addRemoveColorPrice(isCustomChecked: boolean) {
    if (isCustomChecked) {
      this.bikePrice += this.customColorPrice;
    } else {
      this.bikePrice -= this.customColorPrice;
    }
  }

  setInitialDetailsData() {
    this.setInitialBikePrice();
    this.setInitialPaintColorId();
    this.setInitialFrameForkId();
    this.setInitialBeltGuardId();
    this.setInitialFlywheelId();
    this.setInitialPlasticColorId();
    this.setInitialSeatTypeId();
    this.setInitialHandlebarTypePrice();
    this.setInitialHandlebarTypeId();
    this.setInitialPedalTypePrice();
    this.setInitialPedalTypeId();
    this.setInititalPowerMeterPrice();
    this.setInititalPowerMeterId();
    this.setInititalConsoleTypeId();
    this.setInititalSprintShiftTypeId();

    this.isConsoleChoosen = true;
  }

  setInitialBikePrice() {
    for (const prop in this.details) {
      for (let i = 0; i < this.details[prop].length; i++) {
        if (this.details[prop][i].DefaultSC3 === true) {
          if (this.details[prop][i].BasePrice.Id) {
            this.bikePrice += this.details[prop][i].BasePrice.Price;
          } else {
            this.bikePrice += this.details[prop][i].BasePrice;
          }
        }
      }
    }
  }

  setInitialPaintColorId() {
    for (let i = 0; i < this.details.PaintColors.length; i++) {
      if (this.details.PaintColors[i].DefaultSC3 === true) {
        this.paintColorId = this.details.PaintColors[i].Id;
      }
    }
  }

  setInitialFrameForkId() {
    for (let i = 0; i < this.details.ArtworkFrameForks.length; i++) {
      if (this.details.ArtworkFrameForks[i].DefaultSC3 === true) {
        this.artworkFrameForkId = this.details.ArtworkFrameForks[i].Id;
      }
    }
  }

  setInitialBeltGuardId() {
    for (let i = 0; i < this.details.ArtworkBeltGuards.length; i++) {
      if (this.details.ArtworkBeltGuards[i].DefaultSC3 === true) {
        this.artworkBeltGuardId = this.details.ArtworkBeltGuards[i].Id;
      }
    }
  }

  setInitialFlywheelId() {
    for (let i = 0; i < this.details.ArtworkFlywheels.length; i++) {
      if (this.details.ArtworkFlywheels[i].DefaultSC3 === true) {
        this.artworkFlywheelId = this.details.ArtworkFlywheels[i].Id;
      }
    }
  }

  setInitialPlasticColorId() {
    for (let i = 0; i < this.details.PlasticsColors.length; i++) {
      if (this.details.PlasticsColors[i].DefaultSC3 === true) {
        this.plasticColorTypeId = this.details.PlasticsColors[i].Id;
      }
    }
  }

  setInitialSeatTypeId() {
    for (let i = 0; i < this.details.Seats.length; i++) {
      if (this.details.Seats[i].DefaultSC3 === true) {
        this.seatTypeId = this.details.Seats[i].Id;
      }
    }
  }

  setInitialHandlebarTypePrice() {
    for (let i = 0; i < this.details.Handlebars.length; i++) {
      if (this.details.Handlebars[i].DefaultSC3 === true) {
        this.previousHandlebarPrice = this.details.Handlebars[i].BasePrice;
      }
    }
  }
  setInitialHandlebarTypeId() {
    for (let i = 0; i < this.details.Handlebars.length; i++) {
      if (this.details.Handlebars[i].DefaultSC3 === true) {
        this.handlebarTypeId = this.details.Handlebars[i].Id;
      }
    }
  }

  setInitialPedalTypePrice() {
    for (let i = 0; i < this.details.Pedals.length; i++) {
      if (this.details.Pedals[i].DefaultSC3 === true) {
        this.previousPedalPrice = this.details.Pedals[i].BasePrice;
      }
    }
  }
  setInitialPedalTypeId() {
    for (let i = 0; i < this.details.Pedals.length; i++) {
      if (this.details.Pedals[i].DefaultSC3 === true) {
        this.pedalTypeId = this.details.Pedals[i].Id;
      }
    }
  }

  setInititalPowerMeterPrice() {
    for (let i = 0; i < this.details.PowerMeters.length; i++) {
      if (this.details.PowerMeters[i].DefaultSC3 === true) {
        this.previousPowerMeterPrice = this.details.PowerMeters[i].BasePrice;
      }
    }
  }

  setInititalPowerMeterId() {
    for (let i = 0; i < this.details.PowerMeters.length; i++) {
      if (this.details.PowerMeters[i].DefaultSC3 === true) {
        this.powerMeterTypeId = this.details.PowerMeters[i].Id;
      }
    }
  }

  setInititalConsoleTypeId() {
    for (let i = 0; i < this.details.Consoles.length; i++) {
      if (this.details.Consoles[i].DefaultSC3 === true) {
        this.consoleTypeId = this.details.Consoles[i].Id;
      }
    }
  }

  setInititalSprintShiftTypeId() {
    for (let i = 0; i < this.details.SprintShifts.length; i++) {
      if (this.details.SprintShifts[i].DefaultSC3 === true) {
        this.sprintShiftTypeId = this.details.SprintShifts[i].Id;
      }
    }
  }

  setDetailsForOrder() {
    this.detailsForOrder = {
      CycleQuantity: null,
      ModelType: this.modelType,
      HandlebarTypeId: this.handlebarTypeId,
      PlasticsColorTypeId: this.plasticColorTypeId,
      SprintShiftTypeId: this.sprintShiftTypeId,
      PowerMeterTypeId: this.powerMeterTypeId,
      PedalTypeId: this.pedalTypeId,
      ConsoleTypeId: this.consoleTypeId,
      SeatTypeId: this.seatTypeId,
      ArtworkBeltGuardId: this.artworkBeltGuardId,
      ArtworkBeltGuardColor: this.artworkBeltGuardColor,
      ArtworkBeltGuardImageUrl: this.artworkBeltGuardImageUrl,
      ArtworkFlywheelId: this.artworkFlywheelId,
      ArtworkFlywheelColor: this.artworkFlywheelColor,
      ArtworkFlywheelImageUrl: this.artworkFlywheelImageUrl,
      ArtworkFrameForkId: this.artworkFrameForkId,
      ArtworkFrameForkColor: this.artworkFrameForkColor,
      ArtworkFrameForkImageUrl: this.artworkFrameForkImageUrl,
      PaintColorId: this.customColor ? null : this.paintColorId,
      CustomColor: this.customColor
    };

    this.detailsService.setDetailsForOrder(this.detailsForOrder);
  }

  setChoosenDetailsForFinalConfiguration() {
    for (const prop in this.details) {
      for (let i = 0; i < this.details[prop].length; i++) {
        if (this.details[prop][i].DefaultSC3 === true) {
          this.finalDetails.push({
            detailName: prop,
            detailChoosenOption: this.details[prop][i].Title
          });
        }
      }
    }

    this.detailsService.setDetailsForFinalConfiguration(this.finalDetails);
  }

  setBikePriceForOrder() {
    this.detailsService.setBikePrice(this.bikePrice);
  }

  setSelectedCustomArtworks() {
    this.customSelectedArtworks.push({
      isCustomArtworkSelected: this.isCustomFrameForkSelected,
      formData: this.artworkFrameForkImageUrl,
      imageName: this.frameForkImageName,
      color: this.artworkFrameForkColor
    });
    this.customSelectedArtworks.push({
      isCustomArtworkSelected: this.isCustomBeltGuardSelected,
      formData: this.artworkBeltGuardImageUrl,
      imageName: this.beltGuardImageName,
      color: this.artworkBeltGuardColor
    });
    this.customSelectedArtworks.push({
      isCustomArtworkSelected: this.isCustomFlywheelSelected,
      formData: this.artworkFlywheelImageUrl,
      imageName: this.flywheelImageName,
      color: this.artworkFlywheelColor
    });

    this.detailsService.setSelectedCustomArtworks(this.customSelectedArtworks);
  }

  proceedToAccessories() {
    this.setDetailsForOrder();
    this.setBikePriceForOrder();
    this.setChoosenDetailsForFinalConfiguration();
    this.saveDetailsForEdit();
    this.setSelectedCustomArtworks();
    this.detailsService.setIsConsoleChoosen(this.isConsoleChoosen);

    this.router.navigate(['/sc3-accessories']);
  }

  changeModel() {
    this.router.navigate(['/choose-model']);
  }

  chooseColor() {
    this.isColorChoosen = !this.isColorChoosen;
  }

  chooseFrameFork() {
    this.isFrameForkChoosen = !this.isFrameForkChoosen;
  }

  chooseBeltGuard() {
    this.isBeltGuardChoosen = !this.isBeltGuardChoosen;
  }

  chooseFlywheel() {
    this.isFlywheelChoosen = !this.isFlywheelChoosen;
  }

  choosePlasticColor(id) {
    this.plasticColorTypeId = id;
    for (let i = 0; i < this.details.PlasticsColors.length; i++) {
      this.details.PlasticsColors[i].DefaultSC3 = false;
      if (this.plasticColorTypeId === this.details.PlasticsColors[i].Id) {
        this.details.PlasticsColors[i].DefaultSC3 = true;
      }
    }

  }

  chooseSeatType(id) {
    this.seatTypeId = id;

    if (this.seatTypeId) {
      this.details.Seats[0].DefaultSC3 = true;
      this.bikePrice += this.details.Seats[0].BasePrice;
    } else {
      this.details.Seats[0].DefaultSC3 = false;
      this.bikePrice -= this.details.Seats[0].BasePrice;
    }
  }

  chooseHandlebarType() {
    this.isHandlebarTypeChoosen = !this.isHandlebarTypeChoosen;
  }

  choosePedalType() {
    this.isPedalTypeChoosen = !this.isPedalTypeChoosen;
  }

  choosePowerMeterType() {
    this.isPowerMeterChoosen = !this.isPowerMeterChoosen;
  }

  chooseConsoleType(id) {
    this.consoleTypeId = id;
  }

  chooseSprintShiftType(id) {
    this.sprintShiftTypeId = id;

    if (this.sprintShiftTypeId === 1) {
      this.details.SprintShifts[0].DefaultSC3 = true;
      this.bikePrice += this.details.SprintShifts[0].BasePrice;
    } else {
      this.details.SprintShifts[0].DefaultSC3 = false;
      this.bikePrice -= this.details.SprintShifts[0].BasePrice;
    }
  }

  declinePedalType() {
    this.isPedalTypeChoosen = !this.isPedalTypeChoosen;
    for (let i = 0; i < this.details.Pedals.length; i++) {
      this.details.Pedals[i].DefaultSC3 = false;
    }
    if (this.pedalTypeId) {
      this.bikePrice -= this.previousPedalPrice;
      this.previousPedalPrice = 0;
    }
    this.pedalTypeId = null;
  }

  acceptPedalType() {
    this.isPedalTypeChoosen = !this.isPedalTypeChoosen;
  }

  declineColor() {
    this.isColorChoosen = !this.isColorChoosen;

    this.bikeImageSrc = '';
    this.customColor = '';
    this.colorName = '';
    if (this.isCustomColor) {
      this.bikePrice -= this.customColorPrice;
    }
    this.isCustomColor = false;
  }

  acceptColor() {
    this.isColorChoosen = !this.isColorChoosen;
  }

  declineFrameForkType() {
    this.isFrameForkChoosen = !this.isFrameForkChoosen;
    this.frameForkImageName = null;
    this.artworkFrameForkColor = null;
    this.details.ArtworkFrameForks[0].DefaultSC2 = true;
    this.details.ArtworkFrameForks[1].DefaultSC2 = false;
    this.setInitialBeltGuardId();
    if (this.isCustomFrameForkSelected && this.isFrameForkSelected) {
      this.bikePrice -= this.customFrameForkPrice;
    }
    this.isCustomFrameForkSelected = false;
  }

  acceptFrameForkType() {
    this.isFrameForkChoosen = !this.isFrameForkChoosen;
  }

  declineBeltGuardType() {
    this.isBeltGuardChoosen = !this.isBeltGuardChoosen;
    this.beltGuardImageName = null;
    this.artworkBeltGuardColor = null;
    this.details.ArtworkBeltGuards[0].DefaultSC2 = true;
    this.details.ArtworkBeltGuards[1].DefaultSC2 = false;
    this.setInitialBeltGuardId();
    if (this.isCustomBeltGuardSelected && this.isBeltGuardSelected) {
      this.bikePrice -= this.customFrameForkPrice;
    }
    this.isCustomBeltGuardSelected = false;
  }

  acceptBeltGuardType() {
    this.isBeltGuardChoosen = !this.isBeltGuardChoosen;
  }

  declineFlywheelType() {
    this.isFlywheelChoosen = !this.isFlywheelChoosen;
    this.details.ArtworkFlywheels[0].DefaultSC3 = false;
    this.flywheelImageName = null;
    this.artworkFlywheelColor = null;

    if (this.isCustomFlywheelSelected && this.isFlywheelSelected) {
      this.bikePrice -= this.customFlywheelPrice;
    }
    this.isCustomFlywheelSelected = false;
  }

  acceptFlywheelType() {
    this.isFlywheelChoosen = !this.isFlywheelChoosen;
  }

  declinePowerMeter() {
    this.isPowerMeterChoosen = !this.isPowerMeterChoosen;
  }

  acceptPowerMeter() {
    this.isPowerMeterChoosen = !this.isPowerMeterChoosen;
  }

  declineHandlebarType() {
    this.isHandlebarTypeChoosen = !this.isHandlebarTypeChoosen;
  }

  acceptHandlebarType() {
    this.isHandlebarTypeChoosen = !this.isHandlebarTypeChoosen;
  }

  selectStandartFrameFork(id, index) {
    this.artworkFrameForkId = id;
    if (this.isFrameForkSelected) {
      this.localSum = this.bikePrice - this.customFrameForkPrice;
      this.isFrameForkSelected = false;
    }
    for (let i = 0; i < this.details.ArtworkFrameForks.length; i++) {
      this.details.ArtworkFrameForks[i].DefaultSC3 = false;
    }
    this.details.ArtworkFrameForks[index].DefaultSC3 = true;
    this.isCustomFrameForkSelected = false;

    if (this.bikePrice > this.localSum) {
      this.bikePrice = this.localSum;
    }
  }

  selectCustomFrameFork() {
    this.artworkFrameForkId = null;
    for (let i = 0; i < this.details.ArtworkFrameForks.length; i++) {
      this.details.ArtworkFrameForks[i].DefaultSC3 = false;
    }
    this.isCustomFrameForkSelected = true;

    if (!this.isFrameForkSelected && this.isCustomFrameForkSelected) {
      this.bikePrice += this.customFrameForkPrice;
      this.isFrameForkSelected = true;
    }
  }

  selectStandartBeltGuard(id, index) {
    this.artworkBeltGuardId = id;
    if (this.isBeltGuardSelected) {
      this.localSum = this.bikePrice - this.customBeltGuardPrice;
      this.isBeltGuardSelected = false;
    }
    for (let i = 0; i < this.details.ArtworkBeltGuards.length; i++) {
      this.details.ArtworkBeltGuards[i].DefaultSC3 = false;
    }
    this.details.ArtworkBeltGuards[index].DefaultSC3 = true;
    this.isCustomBeltGuardSelected = false;

    if (this.bikePrice > this.localSum) {
      this.bikePrice = this.localSum;
    }
  }

  selectCustomBeltGuard() {
    this.artworkBeltGuardId = null;
    for (let i = 0; i < this.details.ArtworkBeltGuards.length; i++) {
      this.details.ArtworkBeltGuards[i].DefaultSC3 = false;
    }
    this.isCustomBeltGuardSelected = true;

    if (!this.isBeltGuardSelected && this.isCustomBeltGuardSelected) {
      this.bikePrice += this.customBeltGuardPrice;
      this.isBeltGuardSelected = true;
    }
  }

  selectStandartFlywheel(id, index) {
    this.artworkFlywheelId = id;
    if (this.isFlywheelSelected) {
      this.localSum = this.bikePrice - this.customFlywheelPrice;
      this.isFlywheelSelected = false;
    }
    for (let i = 0; i < this.details.ArtworkFlywheels.length; i++) {
      this.details.ArtworkFlywheels[i].DefaultSC3 = false;
    }
    this.details.ArtworkFlywheels[index].DefaultSC3 = true;
    this.isCustomFlywheelSelected = false;

    if (this.bikePrice > this.localSum) {
      this.bikePrice = this.localSum;
    }
  }

  selectCustomFlywheel() {
    this.artworkFlywheelId = null;
    for (let i = 0; i < this.details.ArtworkFlywheels.length; i++) {
      this.details.ArtworkFlywheels[i].DefaultSC3 = false;
    }
    this.isCustomFlywheelSelected = true;

    if (!this.isFlywheelSelected && this.isCustomFlywheelSelected) {
      this.bikePrice += this.customFlywheelPrice;
      this.isFlywheelSelected = true;
    }
  }

  selectHandlebarType(id, price, index) {
    this.handlebarTypeId = id;
    for (let i = 0; i < this.details.Handlebars.length; i++) {
      this.details.Handlebars[i].DefaultSC3 = false;
    }
    this.details.Handlebars[index].DefaultSC3 = true;
    this.bikePrice -= this.previousHandlebarPrice;
    this.bikePrice += price;
    this.previousHandlebarPrice = price;
  }

  selectPedalType(id, price, index) {
    this.pedalTypeId = id;
    for (let i = 0; i < this.details.Pedals.length; i++) {
      this.details.Pedals[i].DefaultSC3 = false;
    }
    this.details.Pedals[index].DefaultSC3 = true;
    this.bikePrice -= this.previousPedalPrice;
    this.bikePrice += price;
    this.previousPedalPrice = price;
  }

  selectPowerMeterType(id, price, index) {
    this.powerMeterTypeId = id;
    for (let i = 0; i < this.details.PowerMeters.length; i++) {
      this.details.PowerMeters[i].DefaultSC3 = false;
    }
    this.details.PowerMeters[index].DefaultSC3 = true;
    this.bikePrice -= this.previousPowerMeterPrice;
    this.bikePrice += price;
    this.previousPowerMeterPrice = price;
  }

  uploadFrameForkImage(event) {
    const fileList: FileList = event.target.files;
    this.frameForkImageName = fileList[0].name;

    this.detailsService.uploadImage(fileList).subscribe(data => {
      this.artworkFrameForkImageUrl = data['_body'];
    });
  }

  uploadBeltGuardImage(event) {
    const fileList: FileList = event.target.files;
    this.beltGuardImageName = fileList[0].name;

    this.detailsService.uploadImage(fileList).subscribe(data => {
      this.artworkBeltGuardImageUrl = data['_body'];
    });
  }

  uploadFlywheelImage(event) {
    const fileList: FileList = event.target.files;
    this.flywheelImageName = fileList[0].name;

    this.detailsService.uploadImage(fileList).subscribe(data => {
      this.artworkFlywheelImageUrl = data['_body'];
    });
  }
}
