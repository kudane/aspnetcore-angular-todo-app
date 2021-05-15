import { Injectable, } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';

import { TodoService } from '../core';
import { catchError, map } from 'rxjs/operators';
import { TodoRouteParams } from './models/todo-route-params.model';
import { ShowTodoByLowerCaseEnum } from './models/show-todo-by.model';

@Injectable()
export class TodoResolver implements Resolve<TodoRouteParams> {
  constructor(private router: Router, private todoService: TodoService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
    const showBy = route.paramMap.get('showBy').toLowerCase() as ShowTodoByLowerCaseEnum;

    if (showBy === ShowTodoByLowerCaseEnum.Active) {
      return this.todoService
        .getActiveList()
        .pipe(
          map(todos => ({ todos, showBy } as TodoRouteParams)),
          catchError((err) => this.router.navigateByUrl('/'))
        );
    }

    if (showBy === ShowTodoByLowerCaseEnum.Completed) {
      return this.todoService
        .getCompleteList()
        .pipe(
          map(todos => ({ todos, showBy } as TodoRouteParams)),
          catchError((err) => this.router.navigateByUrl('/'))
        );
    }

    this.router.navigateByUrl('/');
    return EMPTY;
  }
}
