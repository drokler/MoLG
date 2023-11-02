import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { CompanyListComponent } from './company-list/company-list.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'companies', component: CompanyListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
