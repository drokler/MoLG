import { Component, OnInit } from '@angular/core';
import { ServiceFactoryService } from '../services/service-factory.service';
import { AuthApi, AuthDto, FetchError } from 'src/gen';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfigurationFactoryService } from '../services/configuration-factory.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent {
  private service: AuthApi;
  public authForm: FormGroup;

  public get login() {
    return this.authForm.get('login');
  }
  public get password() {
    return this.authForm.get('password');
  }

  constructor(
    private readonly serviceFactory: ServiceFactoryService,
    private readonly configurationFacotry: ConfigurationFactoryService,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private readonly router: Router
  ) {
    this.service = serviceFactory.activate(AuthApi);
    this.authForm = fb.group({
      login: [null, [Validators.required, Validators.minLength(3)]],
      password: [null, [Validators.required, Validators.minLength(6)]],
    });
  }

  public async onSubmit(): Promise<void> {
    const authDto = this.authForm.value as AuthDto;
    try {
      const result = await this.service.apiAuthPost({ authDto });
      if (!result.token) {
        this.snackBar.open('Ошибка авторизации', 'Скрыть', { duration: 2000 });
        return;
      }
      this.configurationFacotry.token = result.token;
      this.router.navigate(['/']);
    } catch (error) {
      if (error instanceof FetchError) {
        this.snackBar.open('Ошибка подключения', 'Скрыть', { duration: 2000 });
      }
    }
  }
}
