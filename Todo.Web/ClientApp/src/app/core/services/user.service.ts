import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { distinctUntilChanged, map } from 'rxjs/operators';
import { ApiService, JwtService } from '../index.js';
import { User, AuthSucceeded, Credentials } from '../models/index';

@Injectable()
export class UserService {
  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(
    private apiService: ApiService,
    private jwtService: JwtService
  ) { }

  // ตรวจสอบ User เมื่อโหลดแอพครั้งแรก
  // จะล็อคอินอัตโนมัติ ถ้า Token ยังไม่หมดอายุ
  verification() {
    const token = this.jwtService.getToken();
    if (token) {
      this.apiService.get('Auth/VerificationUser')
        .subscribe(
          user => this.setAuth(token, user),
          err => this.purgeAuth()
        );
    } else {
      this.purgeAuth();
    }
  }

  setAuth(token: string, user: User) {
    this.jwtService.saveToken(token);
    this.currentUserSubject.next(user);
    this.isAuthenticatedSubject.next(true);
  }

  // ล็อคเอ้าท์
  purgeAuth() {
    this.jwtService.destroyToken();
    this.currentUserSubject.next(null);
    this.isAuthenticatedSubject.next(false);
  }

  // ล็อคอิน
  attemptAuth(credentials: Credentials): Observable<User> {
    return this.apiService.post('Auth/Signin', credentials)
      .pipe(
        map((data: AuthSucceeded) => {
          this.setAuth(data.token, data.user);
          return data.user;
        })
      );
  }
}
