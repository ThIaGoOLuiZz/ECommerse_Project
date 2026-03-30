import { Component, OnInit } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { Navbar as NavbarService } from '../../core/services/navbar';
import { MenuModule } from 'primeng/menu';
import { RedirectCommand } from '@angular/router';
import { Auth } from '../../core/services/auth';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { MessageService } from 'primeng/api';


@Component({
  selector: 'app-navbar',
  imports: [MenubarModule, MenuModule, DialogModule, InputTextModule, ButtonModule],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.scss'],
})

export class Navbar implements OnInit {
  modalVisible: boolean = false;
  userMenuItems: MenuItem[] = [];
  isUserLoggedIn: boolean = false;

  constructor(private navbarService: NavbarService, private authService: Auth, private messageService: MessageService) {
    this.isUserLoggedIn = this.authService.getAccessToken() === null ? false : true;
  }

  ngOnInit(): void {
    this.userMenuItems = this.generateItems();
  }

  generateItems(): MenuItem[] {
    if (!this.isUserLoggedIn) {
      return [
        this.navbarService.generateNavbarItems('Login', 'pi pi-user', '/login'),
      ];
    } else {
      return [
        this.navbarService.generateNavbarItems('Administração', 'pi pi-user', '/admin'),
        this.navbarService.generateNavbarItems('Sair', 'pi pi-sign-out', undefined, () => this.showModal()), 
      ];
    }
  }

  logoutUser(): void {
    this.authService.logout();
    this.isUserLoggedIn = false;
    this.userMenuItems = this.generateItems();

    this.messageService.add({
      severity: 'success',
      summary: 'Logout realizado com sucesso!',
      life: 2000
    });

    this.closeModal();
  }

  showModal(): void {
    this.modalVisible = true;
  }

  closeModal(): void {
    this.modalVisible = false;
  }
}
