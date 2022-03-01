import { Component, Inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Modal } from 'bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-incoming-payments',
  templateUrl: './post-incoming-payments.component.html',
  styleUrls: ['./post-incoming-payments.component.css']
})
export class PostIncomingPaymentsComponent implements OnInit {

  public authorizes: Acquisition[];
  public authorisestatus: AuthorizeStatus[];
    Modal: any;

  constructor(private router: Router,private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  http.get<Acquisition[]> ('/api/Authorization/GetPostPayment').subscribe((data: any[]) => {
    console.log(data);
    this.authorizes = data;
  });
  http.get<AuthorizeStatus[]>('/api/Authorization/GetAuthorizeStatus').subscribe(result => {
  this.authorisestatus = result;
  }, error => console.error(error));
  }

  ngOnInit() {
  }
  display= "none";
  onSubmit() {
    var element = document.getElementById('myModal') as HTMLElement;
    var myModal = new Modal(element);
    myModal.show();
  }
  onClose() {
    this.display = "none";
  }
  onSelect(selectedItem: any) {
    console.log(selectedItem.acquisitionID);
    var acquisition = selectedItem.acquisitionID
    const params = new HttpParams().set('acquisitionID', acquisition);
    this.http.put<number>('/api/Acquisition/UpdatePostPayment', null, { params: params }).subscribe(res => {
      //console.log(res);
    })
    this.router.navigateByUrl("/post-incoming-payments");
    this.http.get<Acquisition[]>('/api/Authorization/GetPostPayment').subscribe((data: any[]) => {
      console.log(data);
      this.authorizes = data;
    });


   
  }

  //onSubmit(paymentform) {
  //  console.log(paymentform.value)
  //    const data = JSON.stringify(paymentform.value);
  //    this.http.post('/api/AddData', data).subscribe(result => {
  //      console.warn("result", result)
  //    })
  //    console.warn(data);
  //}
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
