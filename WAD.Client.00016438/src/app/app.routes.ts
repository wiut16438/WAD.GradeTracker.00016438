import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { GradesComponent } from './components/grades/grades.component';
import { StudentFormComponent } from './components/student-form/student-form.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Home Page' },
  { path: 'grades', component: GradesComponent, title: 'Grades Page' },
  { path: 'form', component: StudentFormComponent, title: 'Student Form' },
];
