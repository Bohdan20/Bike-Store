import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { Router, ActivatedRoute } from '@angular/router';
import { SavedConfigurationModel } from '../../models/saved-configuration.model';

@Component({
  selector: 'app-saved-configuration',
  templateUrl: './saved-configuration.component.html',
  styleUrls: ['./saved-configuration.component.css', '../../styles/bike.css']
})
export class SavedConfigurationComponent implements OnInit {
  configId: any;
  savedConfiguration: SavedConfigurationModel[];
  priceDiscount: any;

  constructor(private configurationService: ConfigurationService, private activatedRouter: ActivatedRoute, private router: Router) {
    this.configId = this.activatedRouter.snapshot.params['id'];
  }

  ngOnInit() {
    this.getConfig();
    this.getPriceDiscount();
  }

  getConfig() {
    this.configurationService.getconfiguration(this.configId).subscribe(data => {
      this.savedConfiguration = data.SavedItems;
      this.priceDiscount = {
        netPrice: data.NetPrice,
        discount: data.Discount
      };
    });
  }

  getPriceDiscount() {
    this.priceDiscount = this.configurationService.getPriceDiscount();
  }

  backToConfigurations() {
    this.router.navigate(['/saved-configurations']);
  }

}
