import { Component, OnInit, Input, ViewChild} from '@angular/core';
import { BankApiService } from '../bank-api.service';
import { SearchComponent } from '../search/search.component';
import { AddAccountComponent } from '../add-account/add-account.component';
@Component({
  selector: 'app-account-holder',
  templateUrl: './account-holder.component.html',
  styleUrls: ['./account-holder.component.css']
})
export class AccountHolderComponent implements OnInit
 {
  optionSearch : string;
  Accounts : any=[];
  message :string;
  IdList :Object;
@ViewChild(SearchComponent, { static: false })
private ChildSearchComponent : SearchComponent;

AccountObj:any;

  receiveMessage($event) {
    this.message = $event
    if(this.ChildSearchComponent.optionSearch=="Name")
    {
      this.getAccountHolderListByName(this.message);
    }
    if(this.ChildSearchComponent.optionSearch=="id")
    {
      this.getAccountHolderListById(this.message);
    }
  }
  title = 'Bank';
  constructor(private _ApiServiceInstance : BankApiService){}

  ngOnInit() {
    this.getAccountHolderList();
    // this.getAccountHolderListByName(this.message);
   // this.getAccountHolderListById();
  }

  getAccountHolderListByName(message: string) {
    this._ApiServiceInstance.getAccountHolderDetailsByName(message).subscribe(elements=>
      {
     this.Accounts=[];
      for(const d of elements as any)
          {                               
           this.Accounts.push(
             {
                 id:d.id,accountName:d.accountName,accountHolderAddress:d.accountHolderAddress,
                 accountHolderGender:d.accountHolderGender,mobileNo:d.mobileNo,birthDate:d.birthDate,
                 anniversaryDate:d.anniversaryDate
              })
           };
})     
  }
  getAccountHolderList()
{
 this._ApiServiceInstance.getAccountHolderDetails().subscribe(elements=>
                                        {
                                          
                                          for(const d of elements as any)
                                          {
                                      
                                            this.Accounts.push(
                                            {
                                            id:d.id,accountName:d.accountName,accountHolderAddress:d.accountHolderAddress,
                                            accountHolderGender:d.accountHolderGender,mobileNo:d.mobileNo,birthDate:d.birthDate,
                                            anniversaryDate:d.anniversaryDate
                                          })
                                        };
                                        })  
                                  
}

getAccountHolderListById(message: any)
 {
  
  this._ApiServiceInstance.getAccountHolderDetailsById(message).subscribe(elements=>
    {    
      this.Accounts=[];
     this.IdList=elements;
    this.Accounts.push(this.IdList)
    console.log(this.IdList);
    
})      
}
AddAccountHolder(AccountObj:any)
 {
  
  this._ApiServiceInstance.getAccountHolderDetailsById(AccountObj).subscribe(elements=>
    {    
     
})      
}
}
