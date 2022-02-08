import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public users: User[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>('/api/Users/getUsersList').subscribe((data: any[]) => {
      console.log(data);
      this.users = data;
    });
  }

  ngOnInit() {
  }
}
interface User {
  id: number;
  UserName: string;
  Email: string;
  password:string;
  RoleName: string;
  DepartmentName: string;
}
