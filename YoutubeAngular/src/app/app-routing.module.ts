import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegistirComponent } from './components/registir/registir.component';
import { ResultsComponent } from './components/results/results.component';
import { WatchComponent } from './components/watch/watch.component';

const routes: Routes = [
  {
    path : "",
    component : HomeComponent
  },
  {
    path : "login",
    component: LoginComponent
  },
  {
    path : "registir",
    component: RegistirComponent
  },
  {
    path : "watch/:id",
    component : WatchComponent
  },
  {
    path: "results",
    component : ResultsComponent
  },
  {
    path: "channel",
    loadChildren : () => import('./modules/channel/channel.module').then((m) => m.ChannelModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
