import { Component } from '@angular/core';
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
    ButtonModule
],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  email: string | undefined;
  password: string | undefined;
}
