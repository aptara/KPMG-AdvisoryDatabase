import { Component, OnInit } from '@angular/core';
import { trigger, state, style } from '@angular/animations';

import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-add-course',
    templateUrl: './add-course.component.html',
    styleUrls: ['./add-course.component.scss'],
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

export class AddCourseComponent implements OnInit {

    public isFormSubmitted: boolean = false;
    addcourse: FormGroup | any;






    firstDeliveryDate: any = "First Delivery Date";

    special: RegExp = /^[^#$%]+$/;
    courseOwners: any[] = [{ name: 'Furyal' }, { name: 'course Owner - 1' }, { name: 'course Owner - 2' }];
    selectedCourseOwner: any = { name: 'Furyal' };
    programTypes: any[] = [{ name: 'AL@L' }, { name: 'VCW' }, { name: 'Strategic Portfolio' }, { name: 'Degreed' }, { name: 'Credly' }];
    selectedProgramType: any = '';

    deliveryTypes: any[] = [{ name: 'Delivery Type' }, { name: 'Delivery Type - 1' }, { name: 'Delivery Type - 2' }];
    selectedDeliveryType: any = '';

    status: any[] = [{ name: 'nformation Gathering' }, { name: 'nformation Validation' }, { name: 'Project Initiated' }, { name: 'Focus Course Created' }, { name: 'Assigned to PM' }];
    selectedStatus: any = '';

    totalCPECredit: number = 0;
    maximumAttendeeCount: number = 0;
    minimumAttendeeCount: number = 0;
    maximumAttendeeWaitlist: number = 0;

    projectStatus: any[] = [{ label: 'Alpha', value: '1' }, { label: 'Beta', value: '2' }, { label: 'Gold', value: '3' }];
    selectedProjectStatus: any = { label: 'Alpha', value: '1' };

    collaterals: any[] = [{ label: 'Yes', value: '1' }, { label: 'No', value: '0' }];
    selectedCollateral: string = '0';

    web = { label: 'google', url: 'https://www.google.com' }
    constructor(private formBuilder: FormBuilder) {
        this.addcourse = this.formBuilder.group({
            'courseId': ['', Validators.required, Validators.pattern('^[0-9]*$')],
            'coursename': ['', Validators.required],
            'ldintake': ['', Validators.required],
            'project-manager-contact': ['', Validators.required],
            'instructional-designer': ['', Validators.required],
            'courseowner': ['', Validators.required],
            'business-sponsor': ['', Validators.required],
            'programtype': ['', Validators.required],
            'deliverytype': ['', Validators.required],
            'business-description': ['', Validators.required],
            'materials': ['', Validators.required],
            'totalcpecredit': ['', Validators.required],
            'course-note': ['', Validators.required],
            'room-set-up-comments': ['', Validators.required],
            'overview': ['', Validators.required],
            'objectives': ['', Validators.required],
            'maximum-attendee-count': ['', Validators.required],
            'minimum-attendee-count': ['', Validators.required],
            'maximumAttendeeWaitlist': ['', Validators.required],
            'prerequisite-course-id': ['', Validators.required],
            'firstdeliverydate': ['', Validators.required],
            'level-of-effort': ['', Validators.required],
            'vendor': ['', Validators.required],
            'status': ['', Validators.required],
            'duration': ['', Validators.required],
            'project-status': ['', Validators.required],
            'Collateral': ['', Validators.required],
            'new-domain': ['', Validators.required],
            'disc-from': ['', Validators.required],
            'displayed-to-learner': ['', Validators.required],
            'serviceid': ['', Validators.required],
            'subject-matter-professional': ['', Validators.required],
            'equivalent-course-id': ['', Validators.required]

        });
    }

    ngOnInit(): void { }

    addCourse() {
        if (this.addcourse.valid) {
            // Handle form submission
        } else {
            // Mark all fields as touched to show error messages
            this.addcourse.markAllAsTouched();
        }
    }


}
