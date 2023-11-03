import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Configuration } from 'src/gen';
import { AuthComponent } from './auth/auth.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { ConfigurationFactoryService } from './services/configuration-factory.service';
import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyDetailComponent } from './company-detail/company-detail.component';
import { MatTableModule } from '@angular/material/table';
import { MatExpansionModule } from '@angular/material/expansion';
import { NgxMapLibreGLModule } from '@maplibre/ngx-maplibre-gl';
import { MapEditorComponent } from './map-editor/map-editor.component';
import { LocationListComponent } from './location-list/location-list.component';
import { LocationDetailComponent } from './location-detail/location-detail.component';
import { LocationCreateDialogComponent } from './location-create-dialog/location-create-dialog.component';
export const configurationProvider = {
  provide: Configuration,
  useFactory: (factory: ConfigurationFactoryService) => factory.configuration,
  deps: [ConfigurationFactoryService],
};

@NgModule({
  declarations: [AppComponent, AuthComponent, CompanyListComponent, CompanyDetailComponent, MapEditorComponent, LocationListComponent, LocationDetailComponent, LocationCreateDialogComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    MatTableModule,
    MatExpansionModule,
    MatSelectModule,
    NgxMapLibreGLModule

  ],
  providers: [configurationProvider],
  bootstrap: [AppComponent],
})
export class AppModule {}
