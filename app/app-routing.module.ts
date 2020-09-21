import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
 import { AccountHolderComponent } from './account-holder/account-holder.component';
 import { AccountHolderListComponent } from './account-holder-list/account-holder-list.component';
import { DetailsComponent } from './details/details.component';
import { AppComponent } from './app.component';
import { AddAccountComponent } from './add-account/add-account.component';

const routes: Routes =
 [
  {path :"", component : AccountHolderComponent},
  {path :"detail/:id", component : DetailsComponent},
  {path :"back", component :AccountHolderListComponent},
  {path:"add", component:AddAccountComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
