//Student Id: 00016438

import { Component, inject, OnInit } from '@angular/core';
import { GradeService } from '../../services/grade.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { GradeReadType } from '../../models/grade.model';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-grades',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterModule],
  templateUrl: './grades.component.html',
  styleUrl: './grades.component.css',
})
export class GradesComponent implements OnInit {
  private gradeService = inject(GradeService);
  private route = inject(ActivatedRoute);

  grades: GradeReadType[] = [];
  studentId!: number;
  errorMessage: string = '';

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.studentId = +params['id'];
      this.getGrades(this.studentId);
    });
  }

  getGrades(studentId: number) {
    this.gradeService.getByStudentId(studentId).subscribe({
      next: (grades) => {
        this.grades = grades;
      },
      error: () => {
        this.errorMessage = 'No grades available';
      },
    });
  }

  deleteGrade(id: number) {
    this.gradeService.delete(id).subscribe({
      next: () => {
        this.grades = this.grades.filter((s) => s.id !== id);
        alert('Grade successfully deleted');
      },
      error: () => {
        alert('Failed to delete the grade. Please try again');
      },
    });
  }
}
