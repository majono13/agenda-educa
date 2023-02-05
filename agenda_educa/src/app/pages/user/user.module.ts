import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';

//Modulos
import { UserRoutingModule } from './user-routing.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, UserRoutingModule],
})
export class UserModule {}
