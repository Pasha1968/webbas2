import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { User } from './user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }
  userEmail: string;
  userRole: number;
  userPassword: string;
  user: User = {
    id: 0,
    email: '',
    role: 0,
    password: ''
  }
  users: User[];
  ngOnInit() {
    this.userService.get().subscribe(data => {
      this.users = data;
    });
  }
  createUser() {
    this.user.email = this.userEmail;
    this.user.role = +this.userRole;
    this.user.password = this.userPassword;
    console.log(this.user);
    this.userService.post(this.user).subscribe(() => {
      this.userService.get().subscribe(data => {
        this.users = data;
      });
    })
  }
  deleteUser(id: number) {
    this.userService.delete(id).subscribe(() => {
      this.userService.get().subscribe(data => {
        this.users = data;
      });
    });
  }

}
