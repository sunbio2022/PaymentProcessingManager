import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PostIncomingPaymentsComponent } from './post-incoming-payments/post-incoming-payments.component';
import { BankAccountComponent } from './bank-account/bank-account.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';
import { AcquisitionComponent } from './acquisition/acquisition.component';
import { RoutingComponent } from './routing/routing.component';
import { AuthorizationComponent } from './authorization/authorization.component';
import { FooterComponent } from './footer/footer.component';
//import { BursInterfaceComponent } from './burs-interface/burs-interface.component';
import { ReconsilationComponent } from './reconsilation/reconsilation.component';
import { ServiceregistryComponent } from './serviceregistry/serviceregistry.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { CustomerReportComponent } from './customer-report/customer-report.component';
import { CustomerProfileComponent } from './customer-profile/customer-profile.component';
import { ServiceRegistryViewComponent } from './service-registry-view/service-registry-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DashboardComponent,
    PostIncomingPaymentsComponent,
    BankAccountComponent,
    RegisterComponent,
    LoginComponent,
    UsersComponent,
    AcquisitionComponent,
    RoutingComponent,
    AuthorizationComponent,
    FooterComponent,
    ReconsilationComponent,
    ServiceregistryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'post-incoming-payments', component: PostIncomingPaymentsComponent },
      { path: 'bank-account', component: BankAccountComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'users', component: UsersComponent },
      { path: 'acquisition', component: AcquisitionComponent },
      { path: 'routing', component: RoutingComponent },
      { path: 'authorization', component: AuthorizationComponent },
      { path: 'reconsilation', component: ReconsilationComponent },
      { path: 'footer', component: FooterComponent },
      { path: 'serviceregistry', component: ServiceregistryComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
