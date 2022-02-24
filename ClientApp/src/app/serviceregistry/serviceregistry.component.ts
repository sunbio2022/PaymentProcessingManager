import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-serviceregistry',
  templateUrl: './serviceregistry.component.html',
  styleUrls: ['./serviceregistry.component.css']
})
export class ServiceregistryComponent implements OnInit {
  public departments: Department[];
  public paymentgateway: PaymentGateway[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Department[]>('/api/ServiceRegistry/GetDepartments').subscribe((data: any[]) => {
      console.log(data);
      this.departments = data;
    });
    http.get<PaymentGateway[]>('/api/ServiceRegistry/GetPaymentGateways').subscribe(result => {
      console.log(result);
      this.paymentgateway = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }
  //onSubmit(serviceregistryform) {
  //  const data = JSON.stringify(serviceregistryform.value);
  //  this.http.post('/api/ServiceRegistry/AddServiceRegistry', data).subscribe(res => {
  //    console.log(res);
  //  })
  //}
  upload(files) {
    if (files.length === 0)
      return ;
  }
}

interface Department {
  id: number;
  name: string;
}

interface PaymentGateway {
  paymentGatewayID: number;
  paymentGatewayName: string;
}
