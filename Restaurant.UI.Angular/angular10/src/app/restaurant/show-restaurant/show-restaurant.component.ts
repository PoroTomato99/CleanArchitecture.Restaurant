import { Component, IterableDiffers, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-show-restaurant',
  templateUrl: './show-restaurant.component.html',
  styleUrls: ['./show-restaurant.component.css']
})
export class ShowRestaurantComponent implements OnInit {

  constructor(private service:SharedService) { }

  RestaurantList : any = [];
  ngOnInit(): void {
    this.refreshRestaurantList()
  }

  refreshRestaurantList(){
    this.service.getRestaurantList().subscribe(
      (Response) => {
        this.RestaurantList = Response;

        for(let val in this.RestaurantList){
          for(let val2 in this.RestaurantList[val]){
            for(let val3 in this.RestaurantList[val][val2]){
              let openTime = this.RestaurantList[val][val2][val3];
              if(val3 =='OpenHour'){
                //console.log(openTime);
                
              }
            }
          }
        }
      }
    );
  }
}
