import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserLayoutComponent } from './user-layout/user-layout.component';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { UserRoutingModule } from 'src/app/pages/user/user-routing.module';
import { SidenavComponent } from 'src/app/shared/components/sidenav/sidenav.component';

@NgModule({
  declarations: [UserLayoutComponent, SidenavComponent],
  imports: [CommonModule, SharedModule, UserRoutingModule],
})
export class UserLayoutModule {}
