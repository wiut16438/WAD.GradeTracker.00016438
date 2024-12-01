import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  StudentCreateType,
  StudentReadType,
  StudentUpdateType,
} from '../models/student.model';
import { BASE_URL_STUDENT } from './../constants/service';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private BASE_URL: string = BASE_URL_STUDENT;

  constructor(private http: HttpClient) {}

  getAll(): Observable<StudentReadType[]> {
    return this.http.get<StudentReadType[]>(this.BASE_URL);
  }

  getById(id: number): Observable<StudentReadType> {
    return this.http.get<StudentReadType>(`${this.BASE_URL}/${id}`);
  }

  create(student: StudentCreateType): Observable<StudentCreateType> {
    return this.http.post<StudentCreateType>(this.BASE_URL, student);
  }

  update(student: StudentUpdateType): Observable<StudentUpdateType> {
    return this.http.put<StudentUpdateType>(
      `${this.BASE_URL}/${student.id}`,
      student
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.BASE_URL}/${id}`);
  }
}
