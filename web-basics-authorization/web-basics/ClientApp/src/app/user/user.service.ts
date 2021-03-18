import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User} from './user';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url: string = "api/user";
  constructor(private httpClient: HttpClient) { }

  get(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.url);
  }
  //create(email: string, password: string, role: Role): Observable<User> {
  //  console.log("test");
  //  return this.httpClient.post<User>(this.url, { email, password, role });
  //  //return this.httpClient.post<User[]>(this.url);
  //}
  post(user: User): Observable<User> {
    return this.httpClient.post<User>(this.url, user);
  }
  delete(id: number): Observable<{}> {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
  update(user: User): Observable<User> {
    return this.httpClient.put<User>(this.url, user);
  }
}
