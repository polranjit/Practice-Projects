import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BankApiService } from '../bank-api.service';
import { AccountHolderComponent } from '../account-holder/account-holder.component';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  optionSearch:string;
name :string="";
@Output() 
messageEvent = new EventEmitter<string>();
sendMessage() {
  this.messageEvent.emit(this.name)  
  
}
// constructor(private _ApiServiceInstance : BankApiService){}
constructor(){}

// optionSearch : string;
// CorrectChoice()
// {
//   if(this.optionSearch == "id")
// { 
//   this._accountHolder.getAccountHolderListById(this.name);                     
// }
// if(this.optionSearch == "Name")
// {
//   this._accountHolder.getAccountHolderListByName(this.name)
// }
// }
  ngOnInit() {
  }

}
