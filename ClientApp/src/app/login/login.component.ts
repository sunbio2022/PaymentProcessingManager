import { Component, OnInit, NgModule } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  route: any;
  constructor(private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
      acceptTerms: [false, Validators.requiredTrue]
    }, {
      //validator: MustMatch('password', 'confirmPassword')
    });
  }
  get f() { return this.registerForm.controls; }
  display = "none";
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    var formData = JSON.stringify(this.registerForm.value, null, 4);
    console.log(formData);
    var parseFormData = JSON.parse(formData);
    console.log(parseFormData);
    var user = parseFormData['userName'];
    var password = parseFormData['password'];
    if (password == 'password' &&( user == 'admin' || user == 'department')) {
      if (user == 'admin') {
        //var element = document.getElementById('success') as HTMLElement;
        //var myModal = new Modal(element);
        //myModal.show();
        //myModal.hide();
        this.router.navigateByUrl("/acquisition");
      }
      if (user == 'department') {
        //var element = document.getElementById('success') as HTMLElement;
        //var myModal = new Modal(element);
        //myModal.show();
        //myModal.hide();
        this.router.navigateByUrl("/routing");
      }
    }
    else {
      var element = document.getElementById('error') as HTMLElement;
      var myModal = new Modal(element);
      myModal.show();
    }

    // display form values on success
    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value, null, 4));
    //var formData = JSON.stringify(this.registerForm.value, null, 4);
    //console.log(formData);
    //var parseFormData = JSON.parse(formData);

  }
  //onClose() {
  //  var element = document.getElementById('error') as HTMLElement;
  //  var myModal = new Modal(element);
  //  myModal.hide();
  //}
  //onSClose()
  //{
  //  var element = document.getElementById('success') as HTMLElement;
  //  var myModal = new Modal(element);
  //  myModal.hide();
  //}

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
  }
}
