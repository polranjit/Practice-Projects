// import { Directive } from '@angular/core';

// @Directive({
//   selector: '[appDeleteConfirmationPopUp]'
// })
// export class DeleteConfirmationPopUpDirective {

//   constructor() { }

// }

import { Directive, Renderer2, ElementRef, HostListener, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Directive({
selector: '[appDeletepopup]'
})
export class DeleteConfirmationPopUpDirective {
@Input()
content;
// @ViewChild('content',{static:false})
// private modalContent:ElementRef;
// ngAfterViewInit()
// {
// console.log("in afterviewinit"+this.modalContent);
// }
constructor(renderer: Renderer2, eleRef: ElementRef,private modalService:NgbModal) {
renderer.setStyle(eleRef.nativeElement, 'box-shadow', '2px 2px 12px #58A362')
}

@Output() appDeletepopup: EventEmitter<any> = new EventEmitter();
@HostListener('click', ['$event'])
onClick(e:Event) {
console.log(this.content);
e.preventDefault();
e.stopPropagation();
this.modalService.open(this.content).result.then(result=>{
console.log(result);
if(result=='Ok click')
{
  console.log("ok")
//this.onDeleteClick(id);
this.appDeletepopup.next(e);
}
}
,(reason)=>{
if(reason='cancel click')
{
console.log("Dismiss");
}
}

);
// if (0) {
// console.log("if");
// e.preventDefault();
// e.stopPropagation();
// } else {
// console.log("else");
// this.onDeleteClick.next(e);
// }
}
}