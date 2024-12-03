import { Component, inject, OnInit } from '@angular/core';
import { StudentService } from '../../services/student.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { StudentUpdateType } from '../../models/student.model';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-student-edit',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule],
  templateUrl: './student-edit.component.html',
  styleUrl: './student-edit.component.css',
})
export class StudentEditComponent implements OnInit {
  studentService = inject(StudentService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  editForm = new FormGroup({
    id: new FormControl<number | null>(null),
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    course: new FormControl('', Validators.required),
    level: new FormControl(3, Validators.required),
  });

  ngOnInit() {
    const studentId = this.route.snapshot.paramMap.get('id');
    if (studentId) {
      this.studentService.getById(+studentId).subscribe((student) => {
        this.editForm.setValue({
          id: student.id,
          firstName: student.firstName,
          lastName: student.lastName,
          email: student.email,
          course: student.course,
          level: student.level,
        });
      });
    }
  }

  updateStudent() {
    if (this.editForm.valid) {
      const updatedStudent: StudentUpdateType = this.editForm
        .value as StudentUpdateType;
      this.studentService.update(updatedStudent).subscribe(() => {
        alert('Updated Successfully');
        this.router.navigate(['students']);
      });
    } else {
      alert('Form is invalid');
    }
  }
}
