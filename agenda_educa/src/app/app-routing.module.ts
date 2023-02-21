import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/auth/auth-guard.service';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () =>
      import('./pages/auth/auth.module').then((m) => m.AuthModule),
  },

  {
    path: 'user',
    canActivate: [AuthGuardService],
    loadChildren: () =>
      import('./pages/user/user.module').then((m) => m.UserModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
