export interface User {
  id: number;
  email: string;
  password: string;
  role: number;
}
export enum Roles {
  Admin,
  User,
  Moder
}
