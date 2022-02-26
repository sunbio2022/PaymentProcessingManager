import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-serviceregistry',
  templateUrl: './serviceregistry.component.html',
  styleUrls: ['./serviceregistry.component.css']
})
export class ServiceregistryComponent implements OnInit {
  public departments: Department[];
  public paymentgateway: PaymentGateway[];
  selectedObject;
  form: FormGroup;

  constructor(public fb: FormBuilder,
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
  }
  handleChange(index) {
    console.log(this.paymentgateway[index]);
    this.selectedObject = this.paymentgateway[index];
  }
  deptChange(index) {
    console.log(this.departments[index]);
    this.selectedObject = this.departments[index];
  }

  submitForm() {
    var formData: any = new FormData();
    formData.append("paymentgateaway", this.form.get('paymentgateaway').value);
    formData.append("department", this.form.get('department').value);
    formData.append("merchantID", this.form.get('merchantID').value);
    //formData.append("folderpath", this.form.get('folderpath').value);
    this.http.post('/api/ServiceRegistry/SaveServiceRegistry', formData).subscribe(
      (response) => console.log(response),
      (error) => console.log(error)
    )
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


