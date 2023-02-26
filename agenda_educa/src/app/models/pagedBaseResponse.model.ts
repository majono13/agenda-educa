export interface PagedResponse<T> {
  data: T;
  totalPages: number;
  totalRegisters: number;
}
