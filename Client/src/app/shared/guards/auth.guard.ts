// src/app/auth/auth-guard.service.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { LocalStorageService } from '../services/storage.service';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private storageService: LocalStorageService, private router: Router) {}

  canActivate(): boolean {
    if (!this.storageService.getCurrentUserFromStorage()) {
        this.router.navigateByUrl("");
        return false;
    }
    return true;
  }
}