import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  getRestaurantList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Restaurant');
  }

  addRestaurant(val:any){
    return this.http.post(this.APIUrl+'Restaurant',val);
  }

  updateRestaurant(val:any){
    return this.http.put(this.APIUrl+'/Restaurant'+ val, val);
  }

  deleteRestaurant(val:any){
    return this.http.delete(this.APIUrl+'/Restaurant' + val);
  }

  uploadPhoto(val:any){
    return this.http.post(this.APIUrl+'Photos/Restaurant',val);
  }
}
