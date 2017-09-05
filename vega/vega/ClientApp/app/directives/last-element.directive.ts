// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================

import { Directive, Input, Output, EventEmitter } from '@angular/core';


@Directive({
    selector: '[lastElement]'
})
export class LastElementDirective {
    @Input()
    set lastElement(isLastElement: boolean) {

        if (isLastElement) {
            setTimeout(() => {
                this.lastFunction.emit();
            });
        }
    }

    @Output()
    lastFunction = new EventEmitter();
}