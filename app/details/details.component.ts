import { Component, OnInit } from '@angular/core';
import { BankApiService } from '../bank-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { element } from 'protractor';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _service: BankApiService
  ) {}
  
AccountHolder:object;
  ngOnInit()
   {
    let id = this._route.snapshot.paramMap.get('id');

    this._service.getAccountHolderDetailsById(id).subscribe(element =>{

    this.AccountHolder=element;
    }
      )
  }

}
