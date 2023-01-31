import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./guards/auth.guard";
import { MainLayoutComponent } from "./shared/components/main-layout/main-layout.component";
import { LoginPageComponent } from "./login-page/login-page.component";
import { HomePageComponent } from "./home-page/home-page.component";

const routes: Routes = [
  { path:'', component: MainLayoutComponent, children: [
      { path: '', redirectTo: '/', pathMatch: 'full'},
      { path: '', component: HomePageComponent },
      { path: 'login', component: LoginPageComponent},
      { path: 'admin',
        canActivate: [AuthGuard],
        loadChildren: () => import('./admin/admin.module').then(x => x.AdminModule)}
      //{ path: 'admin', component: AdministrationComponent, canActivate: [AuthGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule{}
