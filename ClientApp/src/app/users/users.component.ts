import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private httpService: HttpClient) { }

  user: string[]

  ngOnInit() {
    //this.httpService.get('https://localhost:44396/users').subscribe(
    //  data => {
    //    this.user = data as string[];
    //  }
    //);
  }
}
