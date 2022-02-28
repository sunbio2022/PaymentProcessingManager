import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-profile',
  templateUrl: './customer-profile.component.html',
  styleUrls: ['./customer-profile.component.css']
})
export class CustomerProfileComponent implements OnInit {

  public customer: Customer[];
  public customers: Customer[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Customer[]>('/api/Customer/GetCustomers').subscribe(result => {
      this.customer = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
interface Customer {
  customerID: number;
  customerName: string;
}

interface Customer {
  customerName: string;
  id_number: number;
  payment_method: string;
  bill_type: string;
  amount: number;
  currency: string;
  transaction_date: Date;
}
