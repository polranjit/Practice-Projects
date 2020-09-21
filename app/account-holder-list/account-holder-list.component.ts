import { Component, OnInit, OnChanges, Input } from '@angular/core';
//import { BankApiService } from '../bank-api.service';
@Component({
  selector: 'app-account-holder-list',
  templateUrl: './account-holder-list.component.html',
  styleUrls: ['./account-holder-list.component.css']
})
export class AccountHolderListComponent implements OnInit, OnChanges {
//title = 'Bank';
  // constructor(private _ApiServiceInstance : BankApiService){}
  @Input()
  List:any[]; 
  @Input()
  ListByName:any[];
  
  constructor(){}
  
    ngOnInit()
    {
  //  this.getAccountHolderList();
    }

    ngOnChanges(){
        console.log(this.List);
    }

  
  //Accounts : any=[];

 // getAccountHolderList()
// {
//  this._ApiServiceInstance.getAccountHolderDetails().subscribe(elements=>
//                                         {
//                                           for(const d of elements as any)
//                                           {
//                                             this.Accounts.push(
//                                             {
//                                             id:d.id,name:d.accountName,Address:d.accountHolderAddress,
//                                             Gender:d.accountHolderGender,MobNo:d.mobileNo,birthdate:d.birthDate,
//                                             Anniversarydate:d.anniversaryDate
//                                           })
//                                         };
//                                         })  //elements are nothing but the array of json object.
 
// }


}
