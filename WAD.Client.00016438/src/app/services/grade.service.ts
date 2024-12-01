import { Injectable } from '@angular/core';
import { BASE_URL_GRADE } from '../constants/service';
import { HttpClient } from '@angular/common/http';
import { GradeReadType, GradeUpdateType } from '../models/grade.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GradeService {
  private BASE_URL: string = BASE_URL_GRADE;

  constructor(private http: HttpClient) {}

  getByStudentId(studentId: number): Observable<GradeReadType[]> {
    return this.http.get<GradeReadType[]>(
      `${this.BASE_URL}/student/${studentId}`
    );
  }

  create(grade: GradeReadType): Observable<GradeReadType> {
    return this.http.post<GradeReadType>(this.BASE_URL, grade);
  }

  update(grade: GradeUpdateType): Observable<GradeUpdateType> {
    return this.http.put<GradeUpdateType>(
      `${this.BASE_URL}/${grade.id}`,
      grade
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.BASE_URL}/${id}`);
  }
}
