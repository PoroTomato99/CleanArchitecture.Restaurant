import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { ShowRestaurantComponent } from './restaurant/show-restaurant/show-restaurant.component';
import { AddEditRestaurantComponent } from './restaurant/add-edit-restaurant/add-edit-restaurant.component';
import {SharedService} from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

  import { from } from 'rxjs';
@NgModule({
  declarations: [
    AppComponent,
    RestaurantComponent,
    ShowRestaurantComponent,
    AddEditRestaurantComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
