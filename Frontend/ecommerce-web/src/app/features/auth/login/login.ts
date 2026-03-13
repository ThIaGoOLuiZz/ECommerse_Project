import { Component } from '@angular/core';
import { CardModule } from 'primeng/card';
import { FormsModule } from '@angular/forms';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { IftaLabelModule } from 'primeng/iftalabel';
import { InputIconModule } from 'primeng/inputicon';

@Component({
  selector: 'app-login',
  imports: [
    CardModule, 
    FloatLabelModule, 
    InputTextModule, 
    FormsModule,
    IconFieldModule, 
    IftaLabelModule, 
    InputIconModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  value1: string | undefined;
}
