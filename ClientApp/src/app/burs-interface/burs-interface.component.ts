import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-burs-interface',
  templateUrl: './burs-interface.component.html',
  styleUrls: ['./burs-interface.component.css']
})
export class BursInterfaceComponent implements OnInit {
  public departments: Department[];
  public customer: Customer[];
  public serviceRegistry: ServiceRegistry[]
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Department[]>('/api/Routing/GetCustomer').subscribe(result => {
      this.customer = result;
      //console.log(result);
    }, error => console.error(error));
    http.get<Department[]>('/api/ServiceRegistry/GetServiceRegistry').subscribe(result => {
      this.serviceRegistry = result;
      //console.log(result);
    }, error => console.error(error));}

  ngOnInit() {
  }
 
  //localStorage.setItem('account', parseFormData['subject']);
  onSelect() {
    console.log();

    var customers = localStorage.getItem('customer');
    var accounts = localStorage.getItem('account');
    var acquisitionIDs = localStorage.getItem('acquisitionID');
    console.log(customers);
    console.log(accounts);
    console.log(acquisitionIDs);
    if (customers != null && accounts != null && acquisitionIDs != null) {
      const params = new HttpParams().set('customer', customers).set('account', accounts).set('acquisitionID', acquisitionIDs);
      console.log(params);
      //+ 'customers/' + customer + '/accounts/' + account +'/acquisitionIDs/+acquisitionID', {}
      this.http.put<any>('/api/Acquisition/UpdateCustomerandAccount',null, { params: params }).subscribe(res => {
        //console.log(res);     
      })

      this.router.navigateByUrl("/reconsilation");
    }
    else {
      alert('please select Customer and Account');
    }
  }

  onCustomer(deviceValue) {
    console.log(deviceValue);
    localStorage.setItem('customer', "");
    localStorage.setItem('customer', deviceValue);
  }
  onAccount(deviceValue) {
    console.log(deviceValue);
    localStorage.setItem('account', "");
    localStorage.setItem('account', deviceValue);
  }

}

interface Department {
  id: number;
  name: string;
}

interface Customer { }
interface ServiceRegistry { }
