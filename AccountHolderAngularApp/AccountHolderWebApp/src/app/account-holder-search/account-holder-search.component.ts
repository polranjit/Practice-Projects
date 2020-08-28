import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChange } from '@angular/core';
import { AccountHolderService } from '../account-holder.service';
@Component({
  selector: 'app-account-holder-search',
  templateUrl: './account-holder-search.component.html',
  styleUrls: ['./account-holder-search.component.css'],
 
})
export class AccountHolderSearchComponent implements OnInit, OnChanges {
  constructor(private _AccountHolderService: AccountHolderService) { }
  InputParameter :string="";
  
  AccountHolders: any = [];
  
  getSelectedValue():string
  {
    return this.SelectedChoice,this.InputParameter;
    console.log(this.SelectedChoice,this.InputParameter);
  }
@Output()
  dataChanged: EventEmitter<string> = new EventEmitter<string>(); // 1.publishing the rvent
  OnSearchClicked()
  { 
    console.log("On Search Clicked"+this.SelectedChoice,this.InputParameter);
    this.MethodChoice(); 
  }

  SelectedChoice:string;
  MethodChoice()
  {
    console.log("In MethodChoice() "+this.SelectedChoice,this.InputParameter);
    if(this.SelectedChoice == "byId")
  { 
    this.GetAccountHoldersById(this.InputParameter);                           
  }
  if(this.SelectedChoice == "byName")
  {
    this.GetAccountHoldersByName(this.InputParameter);                           
  }
  }
  GetAccountHoldersByName(InputParameter : any) {
    console.log("In GetAccountHoldersByName() "+this.InputParameter);
    this.AccountHolders =[];
    this._AccountHolderService.GetAccountHoldersByName(this.InputParameter).subscribe(elements => {
      for (const d of elements as any) {
        this.AccountHolders.push({
          id: d.id, name: d.name, address: d.address,
          birthDate: d.birthDate, contactNo: d.contactNo, anniversaryDate: d.anniversaryDate
        });
      }
    });
    this.dataChanged.emit(this.AccountHolders);
  }
  
  GetAccountHoldersById(InputParameter:any) {
    console.log("In GetAccountHoldersById() "+this.InputParameter);
    this.AccountHolders =[];
    var d = this._AccountHolderService.GetAccountHoldersById(this.InputParameter);
    this._AccountHolderService.GetAccountHoldersById(this.InputParameter).subscribe(elements => {
      
        this.AccountHolders.push(
       elements);
    });
    this.dataChanged.emit(this.AccountHolders);
    
  }
  ngOnInit() 
  {
  }
  ngOnChanges(changes: {[InputParameter: number]: SimpleChange})
  {
    
  }
}
