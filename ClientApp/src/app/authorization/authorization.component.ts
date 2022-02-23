import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit {

  public authorizes: Acquisition[];
  public authorisestatus: AuthorizeStatus[]; 

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Authorization/GetAcquisitions').subscribe((data: any[]) => {
      console.log(data);
      this.authorizes = data;
    });
    http.get<AuthorizeStatus[]>('/api/Authorization/GetAuthorizeStatus').subscribe(result => {
      this.authorisestatus = result;
    }, error => console.error(error));
  }

  ngOnInit() {
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

interface AuthorizeStatus {
  authorizeStatusID: number;
  authorizeStatusName: string;
}
