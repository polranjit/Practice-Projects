import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountHolder } from './AccountHolder/AccountHolder';


const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': 'http://localhost:4200', // -->Add this line
    'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,OPTIONS',
    'Access-Control-Allow-Headers': '*',
    'Content-Type': 'application/json',
    'Accept': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class AccountHolderService {


  constructor(private _HttpClientInstance: HttpClient) { }

  WebsServiceUrl: string = 'https://localhost:44389/api/AccountHolder/';

  AddAccountHolder(accountHolder: AccountHolder): Observable<AccountHolder>
  {

    return this._HttpClientInstance.post<AccountHolder>(this.WebsServiceUrl, accountHolder);
  }
  GetAccountHolders() {
    return this._HttpClientInstance.get<AccountHolder[]>(this.WebsServiceUrl);
  }
  GetAccountHoldersByName(name: string) {
    return this._HttpClientInstance.get<AccountHolder[]>(this.WebsServiceUrl + name);
  }
  GetAccountHoldersById(id: string): Observable<AccountHolder> {
    return this._HttpClientInstance.get<AccountHolder>(this.WebsServiceUrl + id);
  }
  UpdateAccountHolder(accountHolder: AccountHolder): Observable<AccountHolder> {

    return this._HttpClientInstance.put<AccountHolder>(this.WebsServiceUrl, accountHolder);
  }
  DeleteAccountHolder(id: any) {
    return this._HttpClientInstance.delete(this.WebsServiceUrl+id);
  }
}
