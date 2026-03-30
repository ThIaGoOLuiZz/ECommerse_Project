import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_ROUTES } from '../Utils/api-routes';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpClient) {}

  login(email: string, password: string){
    return this.http.post<any>(API_ROUTES.AUTH.LOGIN, { email, password })
      .pipe(tap(response => {
        localStorage.setItem('userId', response.id);
        localStorage.setItem('token', response.accessToken);
        localStorage.setItem('refreshToken', response.refreshToken);
      }));
  }

  register(name: string, email: string, phone: string, password: string, userType: number){
    return this.http.post<any>(API_ROUTES.USER.CREATE, 
      { name, email, phone, password, userType });
  }

  getAccessToken(): string | null {
    return localStorage.getItem('token');
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refreshToken');
  }

  getUserId(): string | null {
    return localStorage.getItem('userId');
  }

  logout(): void{
    localStorage.removeItem('userId');
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
  }
}
