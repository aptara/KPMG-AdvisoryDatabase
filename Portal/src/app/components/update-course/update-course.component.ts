import { Component, OnInit } from '@angular/core';
import { trigger, state, style } from '@angular/animations';

@Component({
    selector: 'app-update-course',
    templateUrl: './update-course.component.html',
    styleUrls: ['./update-course.component.scss'],
    animations: [
        trigger('errorState', [
            state('hide', style({
                opacity: 0
            })),

            state('show', style({
                opacity: 1
            }))
        ])
    ],
})

export class UpdateCourseComponent implements OnInit {

    firstDeliveryDate: any = "First Delivery Date";

    special: RegExp = /^[^#$%]+$/;
    courseOwners: any[] = [{ name: 'Furyal' }, { name: 'course Owner - 1' }, { name: 'course Owner - 2' }];
    selectedCourseOwner: any = { name: 'Furyal' };
    programTypes: any[] = [{ name: 'AL@L' }, { name: 'VCW' }, { name: 'Strategic Portfolio' }, { name: 'Degreed' }, { name: 'Credly' }];
    selectedProgramType: any = '';

    deliveryTypes: any[] = [{ name: 'Delivery Type' }, { name: 'Delivery Type - 1' }, { name: 'Delivery Type - 2' }];
    selectedDeliveryType: any = '';

    totalCPECredit: number = 0;
    maximumAttendeeCount: number = 0;
    minimumAttendeeCount: number = 0;
    maximumAttendeeWaitlist: number = 0;

    projectStatus: any[] = [{ label: 'Alpha', value: '1' }, { label: 'Beta', value: '2' }, { label: 'Gold', value: '3' }];
    selectedProjectStatus: any = { label: 'Alpha', value: '1' };

    collaterals: any[] = [{ label: 'Yes', value: '1' }, { label: 'No', value: '0' }];
    selectedCollateral: string = '0';

    web = { label: 'google', url: 'https://www.google.com' }
    constructor() { }

    ngOnInit(): void { }

    addCourse() { }

}
