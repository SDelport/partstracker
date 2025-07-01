import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Part } from '../models/part';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class PartService {
  private baseUrl = 'https://localhost:61884/api/parts';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Part[]> {
    return this.http.get<Part[]>(`${this.baseUrl}`);
  }

  get(id: string): Observable<Part> {
    return this.http.get<Part>(`${this.baseUrl}/${id}`);
  }

  create(part: Part): Observable<Part> {
    return this.http.post<Part>(this.baseUrl, part)
      .pipe(catchError(this.handleError));
  }

  update(id: string, part: Part): Observable<Part> {
    return this.http.put<Part>(`${this.baseUrl}/${id}`, part)
      .pipe(catchError(this.handleError));
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 400 && error.error?.errors) {
      return throwError(() => error.error.errors); 
    }
    return throwError(() => 'An unknown error occurred.');
  }
}