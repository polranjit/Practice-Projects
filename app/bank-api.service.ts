import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class BankApiService {
  
  WebServiceUrl :string ='https://localhost:44320/api/Bank/';
  
  
  constructor(private _HttpClientInstance : HttpClient)
   {

  }
  getAccountHolderDetails()
  {
    return this._HttpClientInstance.get(this.WebServiceUrl);
  }
  getAccountHolderDetailsByName(ListByName:any)
  {
    return this._HttpClientInstance.get(this.WebServiceUrl+ListByName);

  }
  getAccountHolderDetailsById(ListByName:any)
  {
    return this._HttpClientInstance.get(this.WebServiceUrl+ListByName);
  }
  AddAccountHolderT0List(addRecord:any)
  {
    return this._HttpClientInstance.post(this.WebServiceUrl,addRecord);
  }
 
}
