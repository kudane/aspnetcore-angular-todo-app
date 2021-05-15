import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ApiService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private formatErrors(error: any) {
    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http.get(`${this.baseUrl}${path}`, { params }).pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http.post(`${this.baseUrl}${path}`, JSON.stringify(body)).pipe(catchError(this.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http.put(`${this.baseUrl}${path}`, JSON.stringify(body)).pipe(catchError(this.formatErrors));
  }

  delete(path: string, params: HttpParams): Observable<any> {
    return this.http.delete(`${this.baseUrl}${path}`, { params }).pipe(catchError(this.formatErrors));
  }
}
