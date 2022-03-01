import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reconsilation',
  templateUrl: './reconsilation.component.html',
  styleUrls: ['./reconsilation.component.css']
})
export class ReconsilationComponent implements OnInit {
  public acquisition: Acquisition[];
  public departments: Department[];
  public customer: Customer[];
  public serviceRegistry :ServiceRegistry[]

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Routing/GetReconsilation').subscribe((data: any[]) => {
      //console.log(data);
      this.acquisition = data;
    });
    http.get<Department[]>('/api/Routing/GetDepartment').subscribe(result => {
      this.departments = result;
      //console.log(result);
    }, error => console.error(error));
    http.get<Department[]>('/api/Routing/GetCustomer').subscribe(result => {
      this.customer = result;
      //console.log(result);
    }, error => console.error(error));
    http.get<Department[]>('/api/ServiceRegistry/GetServiceRegistry').subscribe(result => {
      this.serviceRegistry = result;
      //console.log(result);
    }, error => console.error(error));
  }
  OnSubmit() {
    this.http.get('/api/Routing/InsertRecord').subscribe(result => {
      //console.log(result);
    });
  }
  OnCancel() {
    //console.log();
  }

  ngOnInit() {
  }

  onCustomer(value: string, role) {
    console.log("the selected value is " + value);
    console.log(role);
  }
  ddl(e) {
    console.log(e.path);
  }
  onMove(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    var acquisition= selectedItem.acquisitionID
    const params = new HttpParams().set('acquisitionID', acquisition);
    this.http.put<number>('/api/Acquisition/UpdateReconsilation', null, { params: params }).subscribe(res => {
      //console.log(res);
    })
    this.http.get<Acquisition[]>('/api/Routing/GetReconsilation').subscribe((data: any[]) => {
      //console.log(data);
      this.acquisition = data;
    });
  }

  onSelect(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    localStorage.setItem('acquisitionID', selectedItem.acquisitionID);
    var acquisitionID = selectedItem.acquisitionID;
    this.router.navigateByUrl("/burs-interface");


    //console.log(any)
    //console.log(selectedItem);
  //console.log("Selected item Id: ", selectedItem.acquisitionID); // You get the Id of the selected item here
  //alert(selectedItem.burs);
  }
 
}

interface Acquisition {
  acquisitionID: number;
  transactionID: string;
  paymentMethod: string;
  amount: number
  currency: string;
  transactionDate: string;
  description: string;
  departmentID: number;
}

interface Department {
  id: number;
  name: string;
}

interface Customer { }
interface ServiceRegistry { }
