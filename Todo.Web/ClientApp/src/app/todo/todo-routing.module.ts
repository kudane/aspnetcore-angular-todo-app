import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../core';
import { TodoResolver } from './todo-resolver.service';
import { TodoComponent } from './todo.component';

const routes: Routes = [
  {
    path: 'todo',
    canActivate: [AuthGuard],
    children: [
      {
        path: ':showBy',
        component: TodoComponent,
        
        resolve: {
          params: TodoResolver
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TodoRoutingModule { }
