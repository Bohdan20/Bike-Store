import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';


import { AppComponent } from './app.component';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { CompleteConfirmationComponent } from './complete-confirmation/complete-confirmation.component';

import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ChooseModelComponent } from './choose-model/choose-model.component';
import { Sc2ModelComponent } from './choose-model/sc2-model/sc2-model.component';
import { Sc2AccessoriesComponent } from './choose-model/sc2-model/sc2-accessories/sc2-accessories.component';
import { Sc2FinalConfigurationComponent } from './choose-model/sc2-model/sc2-final-configuration/sc2-final-configuration.component';
import { Sc3ModelComponent } from './choose-model/sc3-model/sc3-model.component';
import { Sc3AccessoriesComponent } from './choose-model/sc3-model/sc3-accessories/sc3-accessories.component';
import { Sc3FinalConfigurationComponent } from './choose-model/sc3-model/sc3-final-configuration/sc3-final-configuration.component';
import { SavedConfigurationsComponent } from './saved-configurations/saved-configurations.component';
import { DetailsService } from './services/details.service';
import { AccessoriesService } from './services/accessories.service';
import { ConfigurationService } from './services/configuration.service';
import { AdminService } from './services/admin.service';
import { SavedConfigurationComponent } from './saved-configurations/saved-configuration/saved-configuration.component';
import { FilterPipe } from './pipes/filter.pipe';
import { AdminComponent } from './admin/admin.component';

const routes: Routes = [
  { path: 'signin', component: SigninComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'complete-confirmation', component: CompleteConfirmationComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'choose-model', component: ChooseModelComponent },
  { path: 'sc2-model', component: Sc2ModelComponent },
  { path: 'sc2-accessories', component: Sc2AccessoriesComponent },
  { path: 'final-configuration-sc2', component: Sc2FinalConfigurationComponent },
  { path: 'sc3-model', component: Sc3ModelComponent },
  { path: 'sc3-accessories', component: Sc3AccessoriesComponent },
  { path: 'final-configuration-sc3', component: Sc3FinalConfigurationComponent },
  { path: 'saved-configurations', component: SavedConfigurationsComponent},
  { path: 'admin', component: AdminComponent},
  { path: 'saved-configurations/:id', component: SavedConfigurationComponent},
  { path: '', redirectTo: '/signin', pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    SignupComponent,
    CompleteConfirmationComponent,
    ChooseModelComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    ChooseModelComponent,
    Sc2ModelComponent,
    Sc2AccessoriesComponent,
    Sc2FinalConfigurationComponent,
    Sc3ModelComponent,
    Sc3AccessoriesComponent,
    Sc3FinalConfigurationComponent,
    SavedConfigurationsComponent,
    SavedConfigurationComponent,
    FilterPipe,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    HttpModule,
    HttpClientModule
  ],
  providers: [AuthService, AuthGuard, DetailsService, AccessoriesService, ConfigurationService, AdminService],
  bootstrap: [AppComponent]
})
export class AppModule { }
