import { Injectable } from '@angular/core';
import { BASE_URL_GRADE } from '../constants/service';
import { HttpClient } from '@angular/common/http';
import { GradeReadType, GradeUpdateType } from '../models/grade.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GradeService {
  constructor(private http: HttpClient) {}

  getByStudentId(studentId: number): Observable<GradeReadType[]> {
    return this.http.get<GradeReadType[]>(
      `${BASE_URL_GRADE}/student/${studentId}`
    );
  }

  getById(id: number): Observable<GradeReadType> {
    return this.http.get<GradeReadType>(`${BASE_URL_GRADE}/${id}`);
  }

  create(grade: GradeReadType): Observable<GradeReadType> {
    return this.http.post<GradeReadType>(BASE_URL_GRADE, grade);
  }

  update(grade: GradeUpdateType): Observable<GradeUpdateType> {
    return this.http.put<GradeUpdateType>(
      `${BASE_URL_GRADE}/${grade.id}`,
      grade
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${BASE_URL_GRADE}/${id}`);
  }
}
