import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';

//Modulos
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/shared/modules/shared.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, UserRoutingModule, SharedModule],
})
export class UserModule {}
