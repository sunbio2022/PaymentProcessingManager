import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-post-incoming-payments',
  templateUrl: './post-incoming-payments.component.html',
  styleUrls: ['./post-incoming-payments.component.css']
})
export class PostIncomingPaymentsComponent implements OnInit {
  keyword = 'name';

  data = [
    {
      glaccount: 1,
      shorttext: 'Dakota Gaylord PhD',
      longtext: '14554 Smith Mews',
      chartaccounts: '14554 Smith Mews',
      companycode: '14554 Smith Mews'
    },
    {
      glaccount: 2,
      shorttext: 'Maria Legros',
      longtext: '002 Pagac Drives',
      chartaccounts: '002 Pagac Drives',
      companycode: '002 Pagac Drives'
    },
    {
      glaccount: 3,
      smalltext: 'Brandyn Fritsch',
      longtext: '8542 Lowe Mountain',
      chartaccounts: '8542 Lowe Mountain',
      companycode: '8542 Lowe Mountain'
    },
    {
      glaccount: 4,
      shorttext: 'Brandyn Fritsch',
      longtext: '8542 Lowe Mountain',
      chartaccounts: '8542 Lowe Mountain',
      companycode: '8542 Lowe Mountain'
    },
    {
      glaccount: 5,
      shorttext: 'Glenna Ward V',
      longtext: '1260 Oda Summit',
      chartaccounts: '1260 Oda Summit',
      companycode: '1260 Oda Summit',
    }
  ];

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
  $getglaccountFirstWay($event) {

  }
}
