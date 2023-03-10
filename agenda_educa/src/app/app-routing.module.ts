import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { LoginGuardService } from './services/auth/login-guard.service';
import { HomeComponent } from './pages/public/home/home.component';

const routes: Routes = [
  {path: '',  component: HomeComponent},
  {
    path: 'login',
    canActivate: [LoginGuardService],
    loadChildren: () =>
      import('./pages/auth/auth.module').then((m) => m.AuthModule),
  },

  {
    path: 'user',
    canActivate: [AuthGuardService],
    loadChildren: () =>
      import('./pages/user/user.module').then((m) => m.UserModule),
  },
  {path: 'page/not-found', component: PageNotFoundComponent},
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
