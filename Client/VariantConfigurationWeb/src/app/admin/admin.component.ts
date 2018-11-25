import { Component, OnInit } from '@angular/core';

import { AdminService } from '../services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  items: any = [];
  basePrices: any;
  orderConfigurations: any;

  constructor(private adminService: AdminService) { }

  ngOnInit() {
    this.getAllItems();
  }

  getAllItems() {
    this.adminService.getAllItems().subscribe((data) => {

      this.basePrices = data.BasePrices;
      this.orderConfigurations = data.OrderConfigurations;

      for (const prop in data) {
        if (prop !== 'BasePrices' && prop !== 'OrderConfigurations') {
          this.items.push(data[prop]);
        }
      }
    });
  }

  saveItem(id: number, itemType: string, basePrice: number, title: string) {
    this.adminService.editItem(
      {
        Id: id,
        Type: itemType,
        BasePrice: basePrice,
        Title: title
      }).subscribe(res => console.log(res));
  }

  savePrice(id: number, price: number) {
    this.adminService.editPrice(
      {
        Id: id,
        Price: price
      }).subscribe();
  }

}
