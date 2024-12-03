import { Component, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { StudentService } from '../../services/student.service';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule],
  templateUrl: './student-form.component.html',
  styleUrl: './student-form.component.css',
})
export class StudentFormComponent {
  studentService = inject(StudentService);
  router = inject(Router);

  addForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    course: new FormControl('', Validators.required),
    level: new FormControl(3, Validators.required),
  });

  addStudent() {
    if (this.addForm.valid) {
      this.studentService
        .create({
          firstName: this.addForm.value.firstName?.trim() ?? '',
          lastName: this.addForm.value.lastName?.trim() ?? '',
          email: this.addForm.value.email?.trim() ?? '',
          course: this.addForm.value.course ?? '',
          level: this.addForm.value.level ?? 3,
        })
        .subscribe(() => {
          this.router.navigate(['']);
        });
      alert('Added Successfully');
    } else {
      alert('Form is invalid');
    }
  }
}
