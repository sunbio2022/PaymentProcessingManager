import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-assig-authorize',
  templateUrl: './assig-authorize.component.html',
  styleUrls: ['./assig-authorize.component.css']
})
export class AssigAuthorizeComponent implements OnInit {
  public authorisestatus: AuthorizeStatus[];
  constructor(private router: Router, private http: HttpClient) {
    http.get<AuthorizeStatus[]>('/api/Authorization/GetAuthorizeStatus').subscribe(result => {
      this.authorisestatus = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }
  onStatus(status) {
    console.log(status);
    localStorage.setItem('authorizestatus', "");
    localStorage.setItem('authorizestatus', status);
  }
  onSelect() {
    console.log();

    var authorizestatus = localStorage.getItem('authorizestatus');
    var acquisitionIDs = localStorage.getItem('acquisitionID');
    console.log(authorizestatus);
    console.log(acquisitionIDs);
    if (acquisitionIDs != null && authorizestatus != null && authorizestatus !="0") {
      const params = new HttpParams().set('authorizationStatus', authorizestatus).set('acquisitionID', acquisitionIDs);
      console.log(params);
      this.http.put<any>('/api/Authorization/UpdateAuthorizationStatus', null, { params: params }).subscribe(res => {
        //console.log(res);     
      })

      this.router.navigateByUrl("/authorization");
    }
    else {
      alert('please select authorization status');
    }
  }

}

interface AuthorizeStatus {
  authorizeStatusID: number;
  authorizeStatusName: string;
}
