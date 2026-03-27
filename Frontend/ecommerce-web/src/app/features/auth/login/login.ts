import { Component, inject, input  } from '@angular/core';
import { CardModule } from 'primeng/card';
import { FormsModule } from '@angular/forms';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { IftaLabelModule } from 'primeng/iftalabel';
import { InputIconModule } from 'primeng/inputicon';
import { DividerModule } from 'primeng/divider';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { RouterLink } from "@angular/router";
import { Auth } from '../../../core/services/auth';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MessageModule } from 'primeng/message';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

@Component({
  selector: 'app-login',
  imports: [
    CardModule,
    FloatLabelModule,
    InputTextModule,
    FormsModule,
    IconFieldModule,
    IftaLabelModule,
    InputIconModule,
    DividerModule,
    PasswordModule,
    ButtonModule,
    RouterLink,
    CommonModule,
    MessageModule,
    ProgressSpinnerModule
],
  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class Login {
  email: string | undefined;
  password: string | undefined;
  isSubmited: boolean = false;
  emailTouched: boolean = false;
  passwordTouched: boolean = false;
  isLoading = false;

  private router = inject(Router);
  private messageService = inject(MessageService);

  constructor(private auth: Auth) {
    this.email = '';
    this.password = '';
  }

  onLogin() {
    this.isSubmited = true;
    this.isLoading = true;

    if (this.email && this.password) {
      this.auth.login(this.email, this.password).subscribe({
        next: () => {
          this.isLoading = false;
          this.messageService.add({
            severity: 'success',
            summary: 'Login realizado com sucesso!',
            life: 2000
          });
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error('Login failed:', error);
          this.isLoading = false;
          this.messageService.add({
            severity: 'error',
            summary: 'Falha ao realizar login!',
            life: 2000
          });
        }
      });
    }
  }

inputEmailValidation(): boolean {
  return (!this.email || this.email.trim() === '') && (this.isSubmited || this.emailTouched);
}
inputPasswordValidation(): boolean {
  return (!this.password || this.password.trim() === '') && (this.isSubmited || this.passwordTouched);
}
}
