//Student Id: 00016438

import { Component, inject } from '@angular/core';
import { StudentService } from '../../services/student.service';
import { Router, RouterModule } from '@angular/router';
import { StudentReadType } from '../../models/student.model';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule, HttpClientModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  studentService = inject(StudentService);

  students: StudentReadType[] = [];

  constructor(private router: Router) {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getAll().subscribe((data) => {
      this.students = data;
    });
  }

  deleteStudent(id: number): void {
    this.studentService.delete(id).subscribe(() => {
      this.students = this.students.filter((s) => s.id !== id);
    });
  }

  addStudent(): void {
    this.router.navigate(['students/add']);
  }
}
