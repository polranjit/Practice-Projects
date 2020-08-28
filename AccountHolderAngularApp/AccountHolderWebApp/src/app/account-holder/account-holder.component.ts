import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AccountHolderService } from '../account-holder.service';
import { AccountHolder } from '../AccountHolder/AccountHolder';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-account-holder',
  templateUrl: './account-holder.component.html',
  styleUrls: ['./account-holder.component.css']
})
export class AccountHolderComponent implements OnInit {
  constructor(
    private _AccountHolderService: AccountHolderService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }
  AccountHolders: any = [];
  accountHolder: AccountHolder = new AccountHolder();
  id:string;
  OnDataChanged(accountHolders:any[]) {
    
    this.AccountHolders = accountHolders;
  }
  GetAccountHoldersList() {
    this._AccountHolderService.GetAccountHolders().subscribe(elements => {
      for (const d of elements as any) {
        this.AccountHolders.push({
          id: d.id, name: d.name, address: d.address,
          birthDate: d.birthDate, contactNo: d.contactNo, anniversaryDate: d.anniversaryDate
        });
      }
    });
  }
  onClickAdd()
  {
    this.router.navigate(['/add']);
  }
  onClickList()
  {
    this.GetAccountHoldersList();
  }
ngOnInit() {
 this.GetAccountHoldersList();
}

}
