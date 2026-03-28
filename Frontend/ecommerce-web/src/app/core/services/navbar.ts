import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Navbar {
  generateNavbarItems(label?: string, icon?: string): { label?: string; icon?: string } {
    return {label: label, icon: icon };
  }
}
