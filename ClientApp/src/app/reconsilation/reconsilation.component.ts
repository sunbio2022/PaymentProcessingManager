import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-reconsilation',
  templateUrl: './reconsilation.component.html',
  styleUrls: ['./reconsilation.component.css']
})
export class ReconsilationComponent implements OnInit {
  public roles: Acquisition[];
  public departments: Department[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Routing/GetRouting').subscribe((data: any[]) => {
      console.log(data);
      this.roles = data;
    });
    http.get<Department[]>('/api/Routing/GetDepartment').subscribe(result => {
      this.departments = result;
      console.log(result);
    }, error => console.error(error));
  }
  OnSubmit() {
    this.http.get('/api/Routing/InsertRecord').subscribe(result => {
      console.log(result);
    });
  }
  OnCancel() {
    console.log();
  }

  ngOnInit() {
  }
}

interface Acquisition {
  acquisitionID: number;
  transactionID: string;
  paymentMethod: string;
  amount: number
  currency: string;
  transactionDate: Date;
  description: string;
  departmentID: number;
}

interface Department {
  id: number;
  name: string;
}
