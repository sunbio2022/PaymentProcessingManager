import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-routing',
  templateUrl: './routing.component.html',
  styleUrls: ['./routing.component.css']
})
export class RoutingComponent implements OnInit {

  public roles: Acquisition[];
  public departments: Department[];
  Description: [
    { description: 'House Tax' },
    { description: 'Water Tax' },
    { description: 'Electricity Bill' },
    { description: 'select' }
  ];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Routing/GetRouting').subscribe((data: any[]) => {
      console.log(data);
      this.roles = data;
    });
    http.get<Department[]>('/api/Routing/GetDepartmentByDescription').subscribe(result => {
      this.departments = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    //this.changeDepartment(this.Description)
  }
    changeDepartment(.target.value) {
      this.http.get<Department[]>('/api/Routing/GetDepartmentByDescription').subscribe((res: any) => {
        this.departments = res['departments'].filter(
          (res: any) => res.Description == Description!.value
        ),
        console.log(this.Description);
      })
    }
}

interface Acquisition {
  transactionID: string;
  paymentMethod: string;
  amount: number
  currency: string;
  transactionDate: Date;
  description: string;
}

interface Department {
  id: number;
  name: string;
}

