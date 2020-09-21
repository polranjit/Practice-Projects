import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountHolderComponent } from './account-holder/account-holder.component';
import { AccountHolderListComponent } from './account-holder-list/account-holder-list.component';
import { SearchComponent } from './search/search.component';
import { FormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';
import { AddAccountComponent } from './add-account/add-account.component';


@NgModule({
  declarations: [
    AppComponent,
    AccountHolderComponent,
    AccountHolderListComponent,
    SearchComponent,
    DetailsComponent,
    AddAccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
