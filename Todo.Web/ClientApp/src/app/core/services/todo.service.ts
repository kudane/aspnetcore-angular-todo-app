import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { TodoItem } from '../models/todo.model';

@Injectable()
export class TodoService {
  constructor(private apiService: ApiService) { }

  getActiveList(): Observable<TodoItem[]> {
    return this.apiService.get('Todo/ActiveList');
  }

  getCompleteList(): Observable<TodoItem[]> {
    return this.apiService.get('Todo/CompletedList');
  }

  clearAllCompleted(): Observable<TodoItem> {
    return this.apiService.get('Todo/ClearAllCompleted');
  }

  add(title: string): Observable<TodoItem> {
    return this.apiService.post('Todo/Add', { title });
  }

  delete(id: string): Observable<TodoItem> {
    const params = new HttpParams().set('id', id);
    return this.apiService.delete('Todo/Delete', params);
  }

  markAsCompleted(id: string): Observable<TodoItem> {
    const params = new HttpParams().set('id', id);
    return this.apiService.get('Todo/MarkAsCompleted', params);
  }
}
