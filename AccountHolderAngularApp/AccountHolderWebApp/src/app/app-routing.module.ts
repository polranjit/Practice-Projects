import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountHolderListComponent } from './list/account-holder-list.component';
import { AccountHolderSearchComponent } from './account-holder-search/account-holder-search.component';
import { DetailsComponent } from './details/details.component';
import { AccountHolderComponent } from './account-holder/account-holder.component';
import { AddEditComponent } from './add-edit/add-edit.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';

const routes: Routes = [{ path: 'list', component: AccountHolderListComponent },

{ path: 'search', component: AccountHolderSearchComponent },
{ path: '', component: AppComponent },
{ path: 'home', component: AccountHolderComponent },
{ path: 'back', component: AccountHolderListComponent },
{ path: 'list', component: AccountHolderListComponent },
{ path: 'delete/:id', component: AccountHolderListComponent },
{ path: 'edit/:id', component: AddEditComponent },
{ path: 'add', component: AddEditComponent },
{ path: 'details/:id', component: DetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
