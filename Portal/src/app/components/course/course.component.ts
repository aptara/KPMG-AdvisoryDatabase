import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms'
import { SelectItem } from 'primeng/api';
import { Message } from "primeng/api";

@Component({
    selector: 'app-course',
    templateUrl: './course.component.html',
    styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
    public CourseForm: FormGroup;
    constructor(
        private formBuilder: FormBuilder
    ) {
        this.CourseForm = this.formBuilder.group({
            CourseMasterID: [''],
            CourseName: [''],
            LDIntakeOwner: [''],
            ProjectManagerContact: [''],
            BusinessSponsor: [''],
            Descriptions: [''],
            InstructionalDesigner: [''],
            CourseOwnerID: [''],
            ProgramTypeID: [''],
            DeliveryTypeID: [''],
            TotalCPECredit: [''],
            CourseNotes: [''],
            Materials: [''],
            RoomSetUpComments: [''],
            CourseID: [''],
            Overview: [''],
            Objectives: [''],
            MaximumAttendeeCount: [''],
            MinimumAttendeeCount: [''],
            MaximumAttendeeWaitlist: [''],
            PrerequisiteCourseID: [''],
            EquivalentCourseID: [''],
            FirstDeliveryDate: [''],
            LevelofEffort: [''],
            Vendor: [''],
            ProjectStatusID: [''],
            Duration: [''],
            Collateral: [''],
            FocusDomain: [''],
            FocusRetired: [''],
            FocusDiscFrom: [''],
            FocusDisplayedToLearner: [''],
            CourseRecordURL: [''],
            ServiceNowID: [''],
            SubjectMatterProfessional: [''],
            CreatedBy: [''],
            CreatedOn: [''],
            LastUpdatedBy: [''],
            LastUpdatedOn: [''],
            IsDeleted: [''],
        })
    }

    submitted = true;
    diagnostic = "";
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



    ngOnInit(): void {
    }

    onSubmitCourse() {
        debugger
        console.log(this.CourseForm.value);
    }

}
