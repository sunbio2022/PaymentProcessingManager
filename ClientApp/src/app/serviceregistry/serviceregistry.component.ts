  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-serviceregistry',
  templateUrl: './serviceregistry.component.html',
  styleUrls: ['./serviceregistry.component.css']
})
export class ServiceregistryComponent implements OnInit {
  public departments: Department[];
  public paymentgateway: PaymentGateway[];
  registerForm: FormGroup;
  submitted = false;
  route: any;
    form: FormGroup;
    formBuilder: any;

  constructor(public fb:FormBuilder,
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Department[]>('/api/ServiceRegistry/GetDepartments').subscribe((data: any[]) => {
      console.log(data);
      this.departments = data;
    });
    http.get<PaymentGateway[]>('/api/ServiceRegistry/GetPaymentGateways').subscribe(result => {
      console.log(result);
      this.paymentgateway = result;
    }, error => console.error(error));
    this.form = this.fb.group({
      paymentgateaway: [''],
      department: [''],
      merchantID: [''],
      folderpath: ['']
    })
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      PaymentGatewayID: ['', [Validators.required, Validators.min(1)]],
      DepartmentID: ['', [Validators.required, Validators.min(1)]],
      MerchantID: ['', Validators.required],
      FolderPath: ['', Validators.required]
    }, {
      //validator: MustMatch('password', 'confirmPassword')
    });
  }
  onSubmit(serviceregistryform) {
    const data = JSON.stringify(serviceregistryform.value);
    this.http.post('/api/ServiceRegistry', data).subscribe(res => {
      console.log(res);
    })
    console.warn(data);
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


