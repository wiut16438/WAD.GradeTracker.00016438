//Student Id: 00016438

import { Component, inject, OnInit } from '@angular/core';
import { GradeService } from '../../services/grade.service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-grade-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './grade-form.component.html',
  styleUrl: './grade-form.component.css',
})
export class GradeFormComponent implements OnInit {
  gradeService = inject(GradeService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  studentId!: number;

  gradeForm = new FormGroup({
    moduleName: new FormControl('', Validators.required),
    mark: new FormControl(null, [
      Validators.required,
      Validators.min(0),
      Validators.max(100),
    ]),
    weighting: new FormControl(null, [
      Validators.required,
      Validators.min(0),
      Validators.max(100),
    ]),
  });

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.studentId = +params['id'];
    });
  }

  addGrade() {
    if (this.gradeForm.valid) {
      const grade = {
        moduleName: this.gradeForm.value.moduleName ?? '',
        mark: this.gradeForm.value.mark ?? 0,
        weighting: this.gradeForm.value.weighting ?? 0,
        studentId: this.studentId,
      };
      this.gradeService.create(grade).subscribe({
        next: () => {
          alert('Grade added successfully!');
          this.router.navigate(['/students', this.studentId, 'grades']);
        },
        error: () => {
          alert('Failed to add grade. Please try again.');
        },
      });
    } else {
      alert('Form is invalid. Please correct the errors.');
    }
  }
}
