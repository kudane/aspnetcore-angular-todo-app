import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/index';

import { SigninRoutingModule } from './signin-routing.module';
import { SigninComponent } from './signin.component';

@NgModule({
  imports: [
    SharedModule,
    SigninRoutingModule,
  ],
  declarations: [
    SigninComponent,
  ],
  providers: [
  ]
})
export class SigninModule { }
