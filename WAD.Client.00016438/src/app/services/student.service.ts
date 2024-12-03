//Student Id: 00016438

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
  constructor(private http: HttpClient) {}

  getAll(): Observable<StudentReadType[]> {
    return this.http.get<StudentReadType[]>(BASE_URL_STUDENT);
  }

  getById(id: number): Observable<StudentReadType> {
    return this.http.get<StudentReadType>(`${BASE_URL_STUDENT}/${id}`);
  }

  create(student: StudentCreateType): Observable<StudentCreateType> {
    return this.http.post<StudentCreateType>(BASE_URL_STUDENT, student);
  }

  update(student: StudentUpdateType): Observable<void> {
    return this.http.put<void>(`${BASE_URL_STUDENT}/${student.id}`, student);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${BASE_URL_STUDENT}/${id}`);
  }
}
