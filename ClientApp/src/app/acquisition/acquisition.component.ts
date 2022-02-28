import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-acquisition',
  templateUrl: './acquisition.component.html',
  styleUrls: ['./acquisition.component.css']
})
export class AcquisitionComponent implements OnInit {
  public acquisitions: Acquisition[];

  constructor(private router: Router,private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Acquisition/GetAcquisition').subscribe((data: any[]) => {
      console.log(data);
      this.acquisitions = data;
    });}

  ngOnInit() {
  }

  onSelect(selectedItem: any) {
    const headers = {
      'Accept': '*/*', 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, HEAD', 'Content-Type': 'application/json',
      'Access-Control-Allow-Headers': 'X-Requested-With,content-type'
    }
    console.log(selectedItem.acquisitionID);
    var userId = selectedItem.acquisitionID;
    const params = new HttpParams().set('id', userId);
    console.log(params);
    this.http.put<number>('/api/Acquisition/UpdateAcquisition', null, { params: params }).subscribe(res => {
      //console.log(res);     
    })
    this.http.get<Acquisition[]>('/api/Acquisition/GetAcquisition').subscribe((data: any[]) => {
      console.log(data);
      this.acquisitions = data;
    });
    this.router.navigateByUrl("/acquisition");
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

