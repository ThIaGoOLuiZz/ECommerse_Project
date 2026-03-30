import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Navbar {
  generateNavbarItems(label?: string, icon?: string, routerLink?: string, command?: () => void): { label?: string; icon?: string; routerLink?: string, command?: () => void } {
    return {label: label, icon: icon, routerLink: routerLink, command: command };
  }


}
