//Student Id: 00016438

import { GradeReadType } from './grade.model';

export interface StudentReadType {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  course: string;
  level: number;
  grades: GradeReadType[];
}

export interface StudentCreateType {
  firstName: string;
  lastName: string;
  email: string;
  course: string;
  level: number;
}

export interface StudentUpdateType {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  course: string;
  level?: number;
}
