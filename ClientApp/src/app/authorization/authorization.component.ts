import { HttpClient, HttpParams} from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit {

  public authorizes: Acquisition[];
  public authorisestatus: AuthorizeStatus[]; 

  constructor(private router: Router,private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Authorization/GetAuthorizations').subscribe((data: any[]) => {
      console.log(data);
      this.authorizes = data;
    });
    http.get<AuthorizeStatus[]>('/api/Authorization/GetAuthorizeStatus').subscribe(result => {
      this.authorisestatus = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  OnSubmit(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    var acquisition = selectedItem.acquisitionID
    const params = new HttpParams().set('acquisitionID', acquisition);
    this.http.put<number>('/api/Authorization/UpdateAuthorization', null, { params: params }).subscribe(res => {
      //console.log(res);
    })
    this.http.get<Acquisition[]>('/api/Authorization/GetAuthorizations').subscribe((data: any[]) => {
      //console.log(data);
      this.authorizes = data;
    });
    window.location.reload();
  }

  onAssign(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    localStorage.setItem('acquisitionID', selectedItem.acquisitionID);
    this.router.navigateByUrl("/assig-authorize");
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
