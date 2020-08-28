import { Component, OnInit } from '@angular/core';
import { AccountHolderService } from '../account-holder.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountHolder } from '../AccountHolder/AccountHolder';
import { AccountHolderComponent } from '../account-holder/account-holder.component';
import { NgbModule, NgbDateAdapter, NgbDateParserFormatter, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { DateAdapterService } from '../date-adapter.service';
import { DateformatterService } from '../dateformatter.service';
@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css'],

})
export class AddEditComponent implements OnInit {

  constructor(
    private _AccountHolderService: AccountHolderService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private ngbDatePicker:NgbModule
   
   
    // private _accountHolder:AccountHolderComponent
    )
    { 
      this.minDate = {year:1991 , month: 1 ,day :1};
    }
    id : string;
    minDate;
  
  accountHolder: AccountHolder = new AccountHolder();

  ngOnInit() {

    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id != null) {
      this._AccountHolderService.GetAccountHoldersById(this.id).subscribe(element => {
        this.accountHolder = element;
        console.log(this.accountHolder);
      })
    
    }
    else{
      console.log(this.accountHolder);
    }
  }
  OnClickSave() {
    if(this.id==null)
    {
      this.Add();
      //this.router.navigate(['/']);
    }
    else
    {
     this.Edit();
    // this.router.navigate(['/']);
    }
  }
  Edit()
  {
    console.log("In Add-edit :UpdateAccount()")
    this._AccountHolderService.UpdateAccountHolder(this.accountHolder).subscribe(element => {
      this.accountHolder = element;
    }); 
  }
  Add()
  {
    this._AccountHolderService.AddAccountHolder(this.accountHolder).subscribe(element => {
      this.accountHolder = element;

      //this._accountHolder.AccountHolders=[];
     // this._accountHolder.GetAccountHoldersList();
    }); 

  }
}
