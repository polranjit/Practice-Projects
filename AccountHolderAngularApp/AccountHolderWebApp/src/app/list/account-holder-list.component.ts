import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AccountHolderService } from '../account-holder.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AccountHolder } from '../AccountHolder/AccountHolder';
import { AccountHolderComponent } from '../account-holder/account-holder.component';
@Component({
  selector: 'app-account-holder-list',
  templateUrl: './account-holder-list.component.html',
  styleUrls: ['./account-holder-list.component.css']
})
export class AccountHolderListComponent implements OnInit {
 
  constructor(
    private _AccountHolderService: AccountHolderService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private _accountHolder:AccountHolderComponent) { }
  accountHolder: AccountHolder = new AccountHolder();
  @Input()
  AccountHoldersList:any[]; 

  
  AccountHoldersDetails(id:string)
  { 
    this._AccountHolderService.GetAccountHoldersById(id);
  }
  updateAccount(id : Number)
  {
      console.log("Edit ID="+id);
      
      this.router.navigate(['/edit/id'],{queryParams:{id:id}});
     
  }
  addAccountHolder()
  {
    this.router.navigate(['/add']);
}
deleteAccount(id:string)
{
  console.log("Delete Account");
  this._AccountHolderService.DeleteAccountHolder(id).subscribe(element => { 
    this._accountHolder.AccountHolders=[];
   this._accountHolder.GetAccountHoldersList();
   
  }); 
 
}
  ngOnInit() { 
  
  }
}
