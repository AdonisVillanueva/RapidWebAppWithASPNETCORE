// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================

import { fadeInOut } from '../../services/animations';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { Utilities } from '../../services/utilities';

@Component({
    selector: 'makes',
    templateUrl: './makes.component.html',
    styleUrls: ['./makes.component.css'],
    animations: [fadeInOut]
})
export class MakesComponent {

    private isEditMode = false;
    private isNewUser = false;
    private isSaving = false;
    private isChangePassword = false;
    private isEditingSelf = false;
    private showValidationErrors = false;
    private formResetToggle = true;
    private editingMakeName: string;
    private uniqueId: string = Utilities.uniqueId();

    public changesSavedCallback: () => void;
    public changesFailedCallback: () => void;
    public changesCancelledCallback: () => void;

    @Input()
    isViewOnly: boolean;

    @Input()
    isGeneralEditor = false;
}
