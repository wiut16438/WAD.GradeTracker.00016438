import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { GradesComponent } from './components/grades/grades.component';
import { StudentFormComponent } from './components/student-form/student-form.component';
import { StudentEditComponent } from './components/student-edit/student-edit.component';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { GradeFormComponent } from './components/grade-form/grade-form.component';
import { GradeEditComponent } from './components/grade-edit/grade-edit.component';

export const routes: Routes = [
  { path: '', redirectTo: '/students', pathMatch: 'full' },
  { path: 'students', component: HomeComponent, title: 'Home Page' },
  {
    path: 'students/:id/grades',
    component: GradesComponent,
    title: 'Grades Page',
  },
  {
    path: 'students/:id/grades/add',
    component: GradeFormComponent,
    title: 'Add Grade',
  },
  {
    path: 'students/grades/edit/:id',
    component: GradeEditComponent,
    title: 'Edit Grade',
  },
  {
    path: 'students/add',
    component: StudentFormComponent,
    title: 'Student Form',
  },
  {
    path: 'students/edit/:id',
    component: StudentEditComponent,
    title: 'Student Edit Form',
  },
  { path: '**', component: NotfoundComponent, title: '404 - Not Found' },
];
