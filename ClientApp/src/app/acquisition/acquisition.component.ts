import { Component, OnInit } from '@angular/core';
import { table } from 'console';

@Component({
  selector: 'app-acquisition',
  templateUrl: './acquisition.component.html',
  styleUrls: ['./acquisition.component.css']
})
export class AcquisitionComponent implements OnInit {
  public acquisitions: Acquisition[];

  constructor() { }

  ngOnInit() {
  }
}

interface Acquisition {
  TxnID:number;
  PaymentMethod: string;
  Amount: number
  Currency: string;
  TxnDate: Date;
  Decription: string;
}

