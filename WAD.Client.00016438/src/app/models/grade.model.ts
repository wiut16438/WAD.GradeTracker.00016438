export interface GradeReadType {
  id: string;
  moduleName: string;
  mark: number;
  weighting: number;
  status: string;
  studentId: number;
}

export interface GradeUpdateType {
  id: string;
  moduleName: string;
  mark?: number;
  weighting?: number;
}
