import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css']
})
export class AddAccountComponent implements OnInit {

  constructor() { }

AccountObj:any={};
AddNewAccount(Account)
{
  this.AccountObj=
  {
    "accountName":Account.accountName,
    "accountHolderAddress":Account.accountHolderAddress,
    "accountHolderGender":Account.accountHolderGender,
    "mobileNo":Account.mobileNo,
    "birthDate":Account.birthDate,
    "anniversaryDate":Account.anniversaryDate
  }
}
  ngOnInit() {
  }

}
