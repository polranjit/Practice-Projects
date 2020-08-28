import { BrowserModule } from '@angular/platform-browser';
import { NgModel, FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountHolderComponent } from './account-holder/account-holder.component';
import { AccountHolderListComponent } from './list/account-holder-list.component';
import { AccountHolderSearchComponent } from './account-holder-search/account-holder-search.component';
import { HttpClientModule } from '@angular/common/http';
import { DetailsComponent } from './details/details.component';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddEditComponent } from './add-edit/add-edit.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DeleteConfirmationPopUpDirective } from './delete-confirmation-pop-up.directive';


@NgModule({
  declarations: [
    AppComponent,
    AccountHolderComponent,
    AccountHolderListComponent,
    AccountHolderSearchComponent,
    DetailsComponent,
    AddEditComponent,
    DeleteConfirmationPopUpDirective,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
