import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { HttpTokenInterceptor } from './interceptors/http.token.interceptor';
import { ApiService, AuthGuard, NoAuthGuard, JwtService, TodoService, UserService } from './services/index';

@NgModule({
  imports: [
    CommonModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpTokenInterceptor, multi: true },
    AuthGuard,
    NoAuthGuard,
    ApiService,
    JwtService,
    TodoService,
    UserService,
  ],
  declarations: [],
})
export class CoreModule { }
