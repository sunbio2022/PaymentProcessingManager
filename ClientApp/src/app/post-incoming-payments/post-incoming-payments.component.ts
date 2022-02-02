import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient  } from '@angular/common/http';

@Component({
  selector: 'app-post-incoming-payments',
  templateUrl: './post-incoming-payments.component.html',
  styleUrls: ['./post-incoming-payments.component.css']
})
export class PostIncomingPaymentsComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit(): void {
  }
  onSubmit(paymentform) {
    console.log(paymentform.value)
    //  const data = JSON.stringify(paymentform.value);
    //  this.http.post('/api/AddData', data).subscribe(result => {
    //    console.warn("result", result)
    //  })
    //  console.warn(data);
  }
  getglaccountFirstWay($event) {

  }
}
