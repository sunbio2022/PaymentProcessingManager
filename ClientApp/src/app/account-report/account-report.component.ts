import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Params } from '@angular/router';

@Component({
  selector: 'app-account-report',
  templateUrl: './account-report.component.html',
  styleUrls: ['./account-report.component.css']
})
export class AccountReportComponent implements OnInit {

  public serviceRegistries: ServiceRegistry[]
  public acquisition: Acquisition[];
  selected: any;
  id: number;
  route: any;
  merchantID: any;
  filter: Acquisition[];
  filteredacquisitions : Acquisition[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ServiceRegistry[]>('/api/Account/GetServiceRegistry').subscribe((data: any[]) => {
      console.log(data);
      this.serviceRegistries = data;
    });
  }

  ngOnInit() {
  }
  onSelected() {
    this.http.get<Acquisition[]>('/api/Account/GetServiceRegistryByMerchantID').subscribe(res => {
      //this.acquisition = res['acquisition'].filter(
      //  (res: any) => res.merchantID == merchantID!.value),
      //  console.log(this.acquisition);
        console.log(res);
        this.acquisition = res;
      });
    //});
    //this.http.get<Acquisition[]>('/api/Account/GetServiceRegistryByMerchantID').subscribe(res => {
    //  this.acquisition = res;
    //  this.filteredacquisitions = this.acquisition.filter(res => res.serviceRegistryID ==serviceRegistryID!.value);
    //  console.log(this.filteredacquisitions);
    //});
  }
}
interface ServiceRegistry {
  serviceRegistryID: number;
  merchantID: string;
}

interface Acquisition {
  serviceRegistryID: number;
  transactionDate: string;
  customer: string;
  department: string;
  sales_account: number;
  bank_account: number;
  dr_amount: number;
  cr_amount: number;
}
