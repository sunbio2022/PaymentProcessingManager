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

  constructor(private router:Router,private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
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
    this.registerForm = this.formBuilder.group({
      PaymentGatewayID: ['', [Validators.required, Validators.min(1)]],
      DepartmentID: ['', [Validators.required, Validators.min(1)]],
      MerchantID: ['', Validators.required],
      FolderPath: ['', Validators.required]
    }, {
      //validator: MustMatch('password', 'confirmPassword')
    });
  }

  get f() { return this.registerForm.controls; }

  onSubmit(serviceregistryform) {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    const headers = {
      'Accept': '*/*', 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, HEAD', 'Content-Type': 'application/json',
      'Access-Control-Allow-Headers': 'X-Requested-With,content-type'
    }
    const data = JSON.stringify(this.registerForm.value, null, 4);
    this.http.post<any>('/api/ServiceRegistry/AddServiceRegistry', data, { headers }).subscribe(res => {
      console.log(res);
      this.router.navigateByUrl("/service-registry-view");
    })
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
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


