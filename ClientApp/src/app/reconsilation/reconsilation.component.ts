import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-reconsilation',
  templateUrl: './reconsilation.component.html',
  styleUrls: ['./reconsilation.component.css']
})
export class ReconsilationComponent implements OnInit {
  public acquisition: Acquisition[];
  public departments: Department[];
  public customer: Customer[];
  public serviceRegistry :ServiceRegistry[]

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Acquisition[]>('/api/Routing/GetReconsilation').subscribe((data: any[]) => {
      //console.log(data);
      this.acquisition = data;
    });
    http.get<Department[]>('/api/Routing/GetDepartment').subscribe(result => {
      this.departments = result;
      //console.log(result);
    }, error => console.error(error));
    http.get<Department[]>('/api/Routing/GetCustomer').subscribe(result => {
      this.customer = result;
      //console.log(result);
    }, error => console.error(error));
    http.get<Department[]>('/api/ServiceRegistry/GetServiceRegistry').subscribe(result => {
      this.serviceRegistry = result;
      //console.log(result);
    }, error => console.error(error));
  }
  OnSubmit() {
    this.http.get('/api/Routing/InsertRecord').subscribe(result => {
      //console.log(result);
    });
  }
  OnCancel() {
    //console.log();
  }

  ngOnInit() {
  }

  onCustomer(value: string, role) {
    console.log("the selected value is " + value);
    console.log(role);
  }
  ddl(e) {
    console.log(e.path);
  }
  onSelect(any) {
    console.log(any)
    //console.log(selectedItem);
  //console.log("Selected item Id: ", selectedItem.acquisitionID); // You get the Id of the selected item here
  //alert(selectedItem.burs);
  }
  //onSelect(selectedItem: any) {
  //  var dataObj = JSON.stringify(selectedItem)
  //  console.log(dataObj);
  //  var obj = JSON.parse(dataObj);
  //  console.log(obj)
  //  //alert('row index: ' + args.row.getAttribute('name'));
  //}
  //rowSelected(args) {
  //  alert('row index: ' + args.row.getAttribute('aria-rowindex'));
  //  alert('column index: ' + args.target.getAttribute('aria-colindex'));
  //}
}

interface Acquisition {
  acquisitionID: number;
  transactionID: string;
  paymentMethod: string;
  amount: number
  currency: string;
  transactionDate: string;
  description: string;
  departmentID: number;
}

interface Department {
  id: number;
  name: string;
}

interface Customer { }
interface ServiceRegistry { }
