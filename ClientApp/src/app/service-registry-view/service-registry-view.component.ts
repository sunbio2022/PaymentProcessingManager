import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-service-registry-view',
  templateUrl: './service-registry-view.component.html',
  styleUrls: ['./service-registry-view.component.css']
})
export class ServiceRegistryViewComponent implements OnInit {
  public serviceregistry: Serviceregistry[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Serviceregistry[]>('/api/ServiceRegistry/GetServiceRegistry').subscribe((data: any[]) => {
      console.log(data);
      this.serviceregistry = data;
    });
  }

  ngOnInit() {
  }

}

interface Serviceregistry {
  departmentID: number;
  folderPath: string;
  merchantID: string;
  paymentGatewayID: string;
}
