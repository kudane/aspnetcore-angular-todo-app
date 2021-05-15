import { Component, OnInit } from '@angular/core';
import { TodoItem, TodoService } from '../core';
import { ActivatedRoute } from '@angular/router';
import { TodoRouteParams } from './models/todo-route-params.model';
import { ShowTodoByLowerCaseEnum } from './models/show-todo-by.model';

@Component({
  selector: 'app-todo-component',
  templateUrl: './todo.component.html'
})
export class TodoComponent implements OnInit {
  public todos: TodoItem[];
  public showBy: ShowTodoByLowerCaseEnum;
  public readonly showType = ShowTodoByLowerCaseEnum;

  constructor(
    private route: ActivatedRoute,
    private todoService: TodoService
  ) { }

  ngOnInit() {
    this.route.data.subscribe(
      (data: { params: TodoRouteParams }) => {
        this.showBy = data.params.showBy;
        this.todos = data.params.todos;
      }
    );
  }

  onAdd(title: string): void {
    if (!title) {
      alert('Title Required');
      return;
    }

    this.todoService.add(title).subscribe(
      todo => this.todos.push(todo),
      errors => alert(JSON.stringify(errors))
    );
  }

  onRemove(id: string): void {
    this.todoService.delete(id).subscribe(
      () => this.todos = this.todos.filter(t => t.id != id),
      errors => alert(JSON.stringify(errors))
    );
  }

  onMarkAsCompleted(id: string): void {
    this.todoService.markAsCompleted(id).subscribe(
      () => this.todos = this.todos.filter(t => t.id != id),
      errors => alert(JSON.stringify(errors))
    );
  }
}
