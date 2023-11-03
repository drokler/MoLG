import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { MapEditorComponent } from './map-editor/map-editor.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'companies', component: CompanyListComponent },
  { path: 'map-editor', component: MapEditorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
