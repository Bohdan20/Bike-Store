import { Component, OnInit, HostListener } from '@angular/core';
import { ConfigurationService } from '../services/configuration.service';
import { ConfigurationsModel } from '../models/configurations.model';
import { SavedConfigurationModel } from '../models/saved-configuration.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-saved-configurations',
  templateUrl: './saved-configurations.component.html',
  styleUrls: ['./saved-configurations.component.css', '../styles/bike.css']
})
export class SavedConfigurationsComponent implements OnInit {
  configurations: ConfigurationsModel[];
  allConfigurations: ConfigurationsModel[];
  isDropdownShowed = false;
  allConfigurationsSelected = true;
  configId: number;
  priceDiscount: any;
  searchQuery: string;
  searchedConfigurations: ConfigurationsModel[];

  constructor(private configurationService: ConfigurationService, private router: Router) { }

  ngOnInit() {
    this.getConfigurations();
  }

  getConfigurations() {
    this.configurationService.getConfigurations().subscribe(data => {
      this.configurations = data;
      this.allConfigurations = data;
    });
  }

  selectChekedConfigurations() {
    this.configurations = this.configurations.filter((item) => {
      return item.CreateSalesOrder === true;
    });
  }

  selectAllConfigurations() {
    this.configurations = this.allConfigurations;
  }

  showConfig(id: number) {
    for (let i = 0; i < this.configurations.length; i++) {
      if (this.configurations[i].ConfigNumber === id) {
        this.priceDiscount = {
          netPrice: this.configurations[i].NetPrice,
          discount: this.configurations[i].Discount
        };
      }
    }

    this.configurationService.setPriceDiscount(this.priceDiscount);

    this.router.navigate(['saved-configurations', id]);
  }

  createSalesOrder(id: number) {
    this.configurationService.createSalesOrder(id).subscribe(data => {
      if (data.statusText === 'OK') {
        for (let i = 0; i < this.configurations.length; i++) {
          if (this.configurations[i].ConfigNumber === id) {
            this.configurations[i].CreateSalesOrder = true;
          }
        }
      }
    });
  }

  chooseModel() {
    this.router.navigate(['/choose-model']);
  }

  sortByDate() {
    if (new Date(this.configurations[0].Timestamp).getTime() <
      new Date(this.configurations[this.configurations.length - 1].Timestamp).getTime()) {
        this.configurations.sort((a, b) => {
          return new Date(b.Timestamp).getTime() - new Date(a.Timestamp).getTime();
        });
    } else {
      this.configurations.sort((a, b) => {
        return new Date(a.Timestamp).getTime() - new Date(b.Timestamp).getTime();
      });
    }
  }

  sortByProperty(prop: string) {
    if (this.configurations[0][prop] < this.configurations[this.configurations.length - 1][prop]) {
      this.configurations.sort((a, b) => {
        return b[prop] - a[prop];
      });
    } else {
      this.configurations.sort((a, b) => {
        return a[prop] - b[prop];
      });
    }
  }

}
