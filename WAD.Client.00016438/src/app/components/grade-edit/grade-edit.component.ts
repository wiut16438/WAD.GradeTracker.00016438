//Student Id: 00016438

import { Component, inject, OnInit } from '@angular/core';
import { GradeService } from '../../services/grade.service';
import { ActivatedRoute, Router } from '@angular/router';
import { GradeUpdateType } from '../../models/grade.model';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-grade-edit',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './grade-edit.component.html',
  styleUrl: './grade-edit.component.css',
})
export class GradeEditComponent implements OnInit {
  gradeService = inject(GradeService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  gradeId!: number;
  studentId!: number;

  constructor() {}

  gradeForm = new FormGroup({
    moduleName: new FormControl('', Validators.required),
    mark: new FormControl(0, [
      Validators.required,
      Validators.min(0),
      Validators.max(100),
    ]),
    weighting: new FormControl(0, [
      Validators.required,
      Validators.min(0),
      Validators.max(100),
    ]),
  });

  ngOnInit(): void {
    const localGradeId = this.route.snapshot.paramMap.get('id') ?? '';
    this.gradeId = +localGradeId;

    if (localGradeId) {
      this.gradeService.getById(+localGradeId).subscribe((grade) => {
        this.gradeForm.setValue({
          moduleName: grade.moduleName ?? '',
          mark: grade.mark ?? 0,
          weighting: grade.weighting ?? 0,
        });
      });
    }
  }

  updateGrade() {
    if (this.gradeForm.valid) {
      const updatedGrade: GradeUpdateType = {
        id: this.gradeId,
        moduleName: this.gradeForm.value.moduleName ?? '',
        mark: this.gradeForm.value.mark ?? 0,
        weighting: this.gradeForm.value.weighting ?? 0,
      };

      this.gradeService.update(updatedGrade).subscribe({
        next: () => {
          this.router.navigate(['/students']);
          alert('Grade updated successfully');
        },
        error: () => {
          alert('Failed to update grade. Please try again');
        },
      });
    }
  }
}
