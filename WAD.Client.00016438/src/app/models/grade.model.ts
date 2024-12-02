export interface GradeReadType {
  id: number;
  moduleName: string;
  mark: number;
  weighting: number;
  status: string;
  studentId: number;
}

export interface GradeUpdateType {
  id: number;
  moduleName: string;
  mark?: number;
  weighting?: number;
}
