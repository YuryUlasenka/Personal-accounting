import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { WeatherPageComponent } from './weather-page/weather-page.component';
import { UsersPageComponent } from './users-page/users-page.component';
import { AdminPageComponent } from "./admin-page/admin-page.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

@NgModule({
  declarations: [
    WeatherPageComponent,
    UsersPageComponent,
    AdminPageComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    RouterModule.forChild([
      { path: '', component: AdminPageComponent, children:[
          //{path: '', redirectTo:'/admin/', pathMatch: 'full'},
          {path: 'users', component: UsersPageComponent},
          {path: 'weather', component: WeatherPageComponent}
        ]
      }
    ])
  ],
  exports: [
    RouterModule
  ]
})
export class AdminModule{}
