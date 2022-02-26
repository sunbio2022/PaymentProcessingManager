import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-report',
  templateUrl: './customer-report.component.html',
  styleUrls: ['./customer-report.component.css']
})



export class CustomerReportComponent implements OnInit {
  public customers: Customer_Report[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Customer_Report[]>('/api/Customer/GetCustomers').subscribe((data: any[]) => {
      console.log(data);
      this.customers = data;
    });
  }

  ngOnInit() {
  }
}


interface Customer_Report {
  transaction_date: string;
  name: string;
  department: string;
  sales_account: number;
  bank_account: number;
  dr_amount: number;
  cr_amount: number;
  

}

