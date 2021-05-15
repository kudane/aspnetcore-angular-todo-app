import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/index';

import { TodoResolver } from './todo-resolver.service';
import { TodoRoutingModule } from './todo-routing.module';
import { TodoComponent } from './todo.component';

@NgModule({
  imports: [
    SharedModule,
    TodoRoutingModule,
  ],
  declarations: [
    TodoComponent,
  ],
  providers: [
    TodoResolver,
  ]
})
export class TodoModule { }
