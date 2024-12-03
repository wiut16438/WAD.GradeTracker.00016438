//Student Id: 00016438

export interface GradeReadType {
  id: number;
  moduleName: string;
  mark: number;
  weighting: number;
  status: string;
  studentId: number;
}

export interface GradeCreateType {
  moduleName: string;
  mark: number;
  weighting: number;
  studentId: number;
}

export interface GradeUpdateType {
  id: number;
  moduleName: string;
  mark?: number;
  weighting?: number;
}
