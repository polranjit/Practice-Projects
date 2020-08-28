import { Injectable } from '@angular/core';
import { NgbDateAdapter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
  providedIn: 'root'
})
export class DateAdapterService extends NgbDateAdapter<Date> {
  
  fromModel(value: Date): NgbDateStruct {


    let result: NgbDateStruct = null;
    if (value) {
    
      result = {
        day : value.getUTCDay(),
        month :value.getUTCMonth(),
        year : value.getUTCFullYear()
      };
    }
    return result;
  }

  toModel(value: NgbDateStruct): Date {

    let result: Date = null;
    if (value) {
    // result = date.day + this.DELIMITER + date.month + this.DELIMITER + date.year;
      result = new Date (value.year, value.month-1, value.day);
    }
    return result;
  }

}
