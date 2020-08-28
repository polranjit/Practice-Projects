import { Component, OnInit } from '@angular/core';
import { AccountHolderService } from '../account-holder.service';
import {ActivatedRoute, Router } from '@angular/router';
import { AccountHolder } from '../AccountHolder/AccountHolder';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  constructor(
    private _AccountHolderService: AccountHolderService,
    private activatedRoute:ActivatedRoute,
    private router :Router) {}
 
    accountHolder:AccountHolder = new AccountHolder();
  ngOnInit()
   {
    let id = this.activatedRoute.snapshot.paramMap.get('id');

    this._AccountHolderService.GetAccountHoldersById(id).subscribe(element =>{

    this.accountHolder=element;
    }
      )
  }
}
