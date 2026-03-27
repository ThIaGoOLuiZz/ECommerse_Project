import { Component, inject  } from '@angular/core';
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
import { InputMaskModule } from 'primeng/inputmask';

@Component({
  selector: 'app-register',
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
    InputMaskModule
  ],
  templateUrl: './register.html',
  styleUrls: ['./register.scss'],
})
export class Register {
  name: string | undefined;
  email: string | undefined;
  phone: string | undefined;
  userType: number = 1;
  password: string | undefined;
  confirmPassword: string | undefined;
  isSubmited: boolean = false;

  private router = inject(Router);
  private messageService = inject(MessageService);

  constructor(private auth: Auth) {
  }

  onRegister() {
    this.isSubmited = true;
    this.phone = this.phone?.replace(/\D/g, '');
    console.log(this.phone);
    if (this.email && this.password && this.name && this.phone && this.userType && this.confirmPassword) {
      if (this.password !== this.confirmPassword) {
        this.messageService.add({
          severity: 'error',
          summary: 'As senhas não coincidem!',
          life: 2000
        });
        return;
      }
      this.auth.register(this.name, this.email, this.phone, this.password, this.userType).subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Registro realizado com sucesso!',
            life: 2000
          });
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error('Register failed:', error);
          this.messageService.add({
            severity: 'error',
            summary: error.error.error || 'Falha ao realizar registro!',
            life: 2000
          });
        }
      });
    }
  }
  
  inputEmailValidation(): boolean{
    return (!this.email || this.email.trim() === '') && this.isSubmited;
  }
  inputPasswordValidation(): boolean{
    return (!this.password || this.password.trim() === '') && this.isSubmited;
  }

  inputNameValidation(): boolean{
    return (!this.name || this.name.trim() === '') && this.isSubmited;
  }

  inputPhoneValidation(): boolean{
    return (!this.phone || this.phone.trim() === '') && this.isSubmited;
  }

  inputConfirmPasswordValidation(): boolean{
    return (!this.confirmPassword || this.confirmPassword.trim() === '') && this.isSubmited;
  }
}
