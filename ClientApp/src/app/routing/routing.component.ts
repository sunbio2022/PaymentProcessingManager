import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';
import { Router } from '@angular/router';

@Component({
  selector: 'app-routing',
  templateUrl: './routing.component.html',
  styleUrls: ['./routing.component.css']
})
export class RoutingComponent implements OnInit {

  public roles: Acquisition[];
  public departments: Department[];

  constructor(private router: Router,private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Routing/GetRouting').subscribe((data: any[]) => {
      console.log(data);
      this.roles = data;
    });
    http.get<Department[]>('/api/Routing/GetDepartment').subscribe(result => {
      this.departments = result;
      console.log(result);
    }, error => console.error(error));
  }
  onAssign(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    localStorage.setItem('acquisitionID', selectedItem.acquisitionID);
    //var acquisitionID = selectedItem.acquisitionID;
    this.router.navigateByUrl("/assign-department");
  }


  OnSubmit(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    var acquisition = selectedItem.acquisitionID
    const params = new HttpParams().set('acquisitionID', acquisition);
    this.http.put<number>('/api/Routing/UpdateRouting', null, { params: params }).subscribe(res => {
      //console.log(res);
    })
    this.http.get<Acquisition[]>('/api/Routing/GetRouting').subscribe((data: any[]) => {
      //console.log(data);
      this.roles = data;
    });
    window.location.reload();
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

