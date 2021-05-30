import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-show-restaurant',
  templateUrl: './show-restaurant.component.html',
  styleUrls: ['./show-restaurant.component.css']
})
export class ShowRestaurantComponent implements OnInit {

  constructor(private service:SharedService) { }

  RestaurantList: any = [];
  ngOnInit(): void {
    this.refreshRestaurantList()
  }

  refreshRestaurantList(){
    this.service.getRestaurantList().subscribe(data => {
      this.RestaurantList = data;
    });
  }
}
