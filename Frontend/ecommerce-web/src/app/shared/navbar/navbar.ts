import { Component, OnInit } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { Navbar as NavbarService } from '../../core/services/navbar';
import { MenuModule } from 'primeng/menu';
import { RedirectCommand } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [MenubarModule, MenuModule],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.scss'],
})

export class Navbar implements OnInit {
  userMenuItems: MenuItem[] = [];

  constructor(private navbarService: NavbarService) {}

  ngOnInit(): void {
    this.userMenuItems = [
      {
        label: 'Login',
        icon: 'pi pi-user',
        routerLink: '/login'
      },
      {
        label: 'Sair',
        icon: 'pi pi-sign-out',
        routerLink: '/logout'
      }
    ];
  }
}
