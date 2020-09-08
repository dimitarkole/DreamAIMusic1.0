import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import User from '../../components/shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private routeProfileController: string = 'Profile';

  constructor(private http: HttpClient) { }

  MyProfile() {
    return this.http.get<User>(`${this.routeProfileController}/MyProfile`);
  }
}
