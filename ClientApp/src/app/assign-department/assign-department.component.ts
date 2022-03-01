import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-assign-department',
  templateUrl: './assign-department.component.html',
  styleUrls: ['./assign-department.component.css']
})
export class AssignDepartmentComponent implements OnInit {
  public departments: Department[];
  constructor(private router: Router, private http: HttpClient) {
    http.get<Department[]>('/api/Routing/GetDepartment').subscribe(result => {
      this.departments = result;
      console.log(result);
    }, error => console.error(error));
  }
  ngOnInit() {
  }
  onDepartment(department) {
    console.log(department);
    localStorage.setItem('department', "");
    localStorage.setItem('department', department);
  }


  onSelect() {
    console.log();

    var departments = localStorage.getItem('department');
    var acquisitionIDs = localStorage.getItem('acquisitionID');
    console.log(departments);
    console.log(acquisitionIDs);
    if (acquisitionIDs != null && departments != null) {
      const params = new HttpParams().set('department', departments).set('acquisitionID', acquisitionIDs);
      console.log(params);
      //+ 'customers/' + customer + '/accounts/' + account +'/acquisitionIDs/+acquisitionID', {}
      this.http.put<any>('/api/Routing/UpdateDep', null, { params: params }).subscribe(res => {
        //console.log(res);     
      })

      this.router.navigateByUrl("/routing");
    }
    else {
      alert('please select Customer and Account');
    }
  }

}

interface Department {
  id: number;
  name: string;
}
