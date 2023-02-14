import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';

//Modulos
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { UserLayoutModule } from 'src/app/layout/user/user-layout.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, UserRoutingModule, SharedModule, UserLayoutModule],
})
export class UserModule {}
