import { Component } from '@angular/core';
import { NgbDateAdapter, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { DateAdapterService } from './date-adapter.service';
import { DateformatterService } from './dateformatter.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    {provide: NgbDateAdapter, useClass: DateAdapterService},
    {provide: NgbDateParserFormatter, useClass: DateformatterService}
  ]
})
export class AppComponent {
  title = 'AccountHolderWebApp';

  
}
