import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-acquisition',
  templateUrl: './acquisition.component.html',
  styleUrls: ['./acquisition.component.css']
})
export class AcquisitionComponent implements OnInit {
  public acquisitions: Acquisition[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Acquisition/GetAcquisition').subscribe((data: any[]) => {
      console.log(data);
      this.acquisitions = data;
    });}

  ngOnInit() {
  }
}

interface Acquisition {
  acquisitionID:number;
  transactionID: string;
  paymentMethod: string;
  amount: number
  currency: string;
  transactionDate: Date;
  description: string;
}

