import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { SelectItem } from 'primeng/api';
import { Message } from "primeng/api";
import { Course } from 'src/app/domain/Course';
import { CourseService } from 'src/app/service/course.service';
import { DropdownDataService } from 'src/app/service/dropdown-data.service';

import { NgxDropdownConfig } from 'ngx-select-dropdown';

@Component({
    selector: 'app-course',
    templateUrl: './course.component.html',
    styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
    public CourseForm: FormGroup;
    public ServiceGroupLineNetworkFormGroup: FormGroup;
    public FieldOfFieldOfStudyFormGroup: FormGroup;
    CourseId: number = 0;
    CourseData: Course | undefined;
    submitted: false;
    CourseOwnerMasters: any = [];
    ProgramTypeMasters: any = [];
    DeliveryTypeMasters: any = [];
    ProjectStatusMasters: any = [];
    StatusMasters: any = [];
    CompetencyMasters: any = [];
    ServiceGroupMasters: any = [];
    ServiceLineMasters: any = [];
    ServiceNetworkMasters: any = [];
    AudienceLevelMasters: any = [];
    FieldOfFieldOfStudyMaster: any = [];
    ProgramKnowledgeLevelMasterData: any = [];
    CourseFunctionMasters: any = [];

    IsRegulatoryOrLegalRequirementDropdownData: any[] = [{ DisplayName: 'Yes', Id: true }, { DisplayName: 'No', Id: false }];
    collaterals: any[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
    web = { label: 'google', url: 'https://www.google.com' }
    config: NgxDropdownConfig = {
        displayKey: "DisplayName",
        search: true,
        height: '200px',
        placeholder: '',
        customComparator: function (a: any, b: any): number {
            //throw new Error('Function not implemented.');
            return 0;
        },
        limitTo: 0,
        moreText: 'More',
        noResultsFound: '',
        searchPlaceholder: '',
        searchOnKey: '',
        clearOnSelection: false,
        inputDirection: ''
    }

    constructor(
        private formBuilder: FormBuilder,
        private dropdownService: DropdownDataService,
        private route: ActivatedRoute,
        public courseService: CourseService,
        private router: Router,
    ) {
        this.route.queryParams.subscribe(params => {
            this.CourseId = params['id'];
        });

        this.CourseForm = this.formBuilder.group({
            CourseID: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            CourseName: ['', [Validators.required, Validators.pattern('^[A-Za-z0-9- ]+$')]],
            LDIntakeOwner: ['', [Validators.required, Validators.pattern('^[A-Za-z0-9- ]+$')]],
            ServiceNowID: ['', [Validators.required, Validators.pattern('^[A-Za-z0-9- ]+$')]],
            BusinessSponsor: ['', [Validators.required, Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Descriptions: ['', [Validators.required, Validators.pattern('^[A-Za-z0-9- ]+$')]],
            ProgramTypeID: ['', Validators.required],
            DeliveryTypeID: ['', Validators.required],
            TotalCPECredit: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],

            ProjectManagerContact: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            InstructionalDesigner: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            CourseOwnerID: [''],
            CourseNotes: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Materials: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            RoomSetUpComments: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Overview: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Objectives: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            MaximumAttendeeCount: ['', [Validators.pattern('^[0-9]+$')]],
            MinimumAttendeeCount: ['', [Validators.pattern('^[0-9]+$')]],
            MaximumAttendeeWaitlist: ['', [Validators.pattern('^[0-9]+$')]],
            PrerequisiteCourseID: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            EquivalentCourseID: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            FirstDeliveryDate: ['', Validators.required],
            LevelofEffort: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Vendor: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            ProjectStatusID: [''],
            Duration: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Collateral: [''],
            // FocusDomain: [''],
            // FocusRetired: [''],
            // FocusDiscFrom: [''],
            //FocusDisplayedToLearner: [''],
            CourseRecordURL: [''],
            SubjectMatterProfessional: ['', [Validators.pattern('^[A-Za-z0-9- ]+$')]],
            Status: [''],

            ServiceGroupLineNetwork: [''],
            SubjectMatterProfessionals: [''],
            IsRegulatoryOrLegalRequirement: [''],
            Competency: [''],
            Audience: [''],
            AudienceLevel: [''],
            FieldOfStudy: [''],
            DeploymentFiscalYear: [''],
            StartDate: [''],
            Function: [''],
            DevelopmentYear: [''],
            Price: [''],
            Currency: [''],
            DisplayCallCenter: [''],
            AudienceType: [''],
            ProgramKnowledgeLevel: [''],
            TargetAudience: [''],
            SpecialNotice: [''],
            AddFormControl: this.formBuilder.array([]),
            AddFormFieldOfStudyChild: this.formBuilder.array([])
        })

        this.ServiceGroupLineNetworkFormGroup = this.formBuilder.group({
            ServiceGroup: ['', Validators.required],
            ServiceLine: ['', Validators.required],
            ServiceNetwork: ['', Validators.required],
        })

        this.FieldOfFieldOfStudyFormGroup = this.formBuilder.group({
            FieldOfStudy: ['', Validators.required],
            FieldOfStudyCredit: ['', Validators.required],
        });

        this.addNewCourseChild();
        this.addFormFieldOfStudyChildForm();
    }

    get AddFormControl() {
        return this.CourseForm.controls["AddFormControl"] as FormArray;
    }

    removeFormControl(i: any) {
        this.AddFormControl.removeAt(i);
    }

    addNewCourseChild() {
        if (this.AddFormControl.length < 4) {
            this.AddFormControl.push(this.ServiceGroupLineNetworkFormGroup);
        }
    }

    get AddFormFieldOfStudyChild() {
        return this.CourseForm.controls["AddFormFieldOfStudyChild"] as FormArray;
    }

    removeFieldOfStudyFormControl(i: any) {
        this.AddFormFieldOfStudyChild.removeAt(i);
    }

    addFormFieldOfStudyChildForm() {
        if (this.AddFormFieldOfStudyChild.length < 4) {
            this.AddFormFieldOfStudyChild.push(this.FieldOfFieldOfStudyFormGroup);
        }
    }


    ngOnInit() {
        this.getDropdownData();
    }

    bindFormData() {
        this.CourseForm.setValue({
            CourseName: this.CourseData?.CourseName,
            LDIntakeOwner: this.CourseData?.LDIntakeOwner,
            ProjectManagerContact: this.CourseData?.ProjectManagerContact,
            BusinessSponsor: this.CourseData?.BusinessSponsor,
            Descriptions: this.CourseData?.Descriptions,
            InstructionalDesigner: this.CourseData?.InstructionalDesigner,
            TotalCPECredit: this.CourseData?.TotalCPECredit,
            CourseNotes: this.CourseData?.CourseNotes,
            Materials: this.CourseData?.Materials,
            RoomSetUpComments: this.CourseData?.RoomSetUpComments,
            CourseID: this.CourseData?.CourseID,
            Overview: this.CourseData?.Overview,
            Objectives: this.CourseData?.Objectives,
            MaximumAttendeeCount: this.CourseData?.MaximumAttendeeCount,
            MinimumAttendeeCount: this.CourseData?.MinimumAttendeeCount,
            MaximumAttendeeWaitlist: this.CourseData?.MaximumAttendeeWaitlist,
            PrerequisiteCourseID: this.CourseData?.PrerequisiteCourseID,
            EquivalentCourseID: this.CourseData?.EquivalentCourseID,
            FirstDeliveryDate: this.CourseData?.FirstDeliveryDate,
            LevelofEffort: this.CourseData?.LevelofEffort,
            Vendor: this.CourseData?.Vendor,
            Duration: this.CourseData?.Duration,
            // FocusDomain: this.CourseData?.FocusDomain,
            // FocusRetired: this.CourseData?.FocusRetired,
            // FocusDiscFrom: this.CourseData?.FocusDiscFrom,
            // FocusDisplayedToLearner: this.CourseData?.FocusDisplayedToLearner,
            CourseRecordURL: this.CourseData?.CourseRecordURL,
            ServiceNowID: this.CourseData?.ServiceNowID,
            SubjectMatterProfessional: this.CourseData?.SubjectMatterProfessional,
            Status: this.CourseData?.Status,

            CourseOwnerID: this.CourseData?.CourseOwnerID,
            ProgramTypeID: this.CourseData?.ProgramTypeID,
            DeliveryTypeID: this.CourseData?.DeliveryTypeID,
            ProjectStatusID: this.CourseData?.ProgramTypeID,
            Collateral: this.collaterals.find(x => x.value === this.CourseData?.Collateral),
            ServiceGroupLineNetwork: 0,
            SubjectMatterProfessionals: 0,
            IsRegulatoryOrLegalRequirement: 0,
            Competency: 0,
            Audience: 0,
            ServiceGroup: 0,
            ServiceLine: 0,
            ServiceNetwork: 0,
            AudienceLevel: 0,
            FieldOfStudy: 0,
            DeploymentFiscalYear: 0,
            StartDate: 0,
            Function: 0,
            DevelopmentYear: 0,
            Price: 0,
            Currency: 0,
            DisplayCallCenter: 0,
            AudienceType: 0,
            ProgramKnowledgeLevel: 0,
            TargetAudience: 0,
            SpecialNotice: 0,
        });

        console.log(this.CourseForm.value)
    }

    getCourseDataForEdit() {
        if (this.CourseId) {
            return this.courseService.getCourse(this.CourseId).subscribe((data: any) => {
                if (data.Success) {
                    this.CourseData = data.Data;
                    this.bindFormData();
                }
            });
        }
        return {};
    }

    getDropdownData() {
        return this.dropdownService.getAllCourses().subscribe((data: any) => {
            if (data.Success) {
                console.log(data.Data)
                var dropdowndata: any = data?.Data
                this.CourseOwnerMasters = dropdowndata.CourseOwnerMasters
                this.ProgramTypeMasters = dropdowndata.ProgramTypeMasters
                this.DeliveryTypeMasters = dropdowndata.DeliveryTypeMasters
                this.ProjectStatusMasters = dropdowndata.ProjectStatusMasters
                this.StatusMasters = dropdowndata.StatusMasters
                this.CompetencyMasters = dropdowndata.CompetencyMasters
                this.ServiceGroupMasters = dropdowndata.ServiceGroupMasters
                this.ServiceLineMasters = dropdowndata.ServiceLineMasters
                this.ServiceNetworkMasters = dropdowndata.ServiceNetworkMasters
                this.AudienceLevelMasters = dropdowndata.AudienceLevelMasters
                this.FieldOfFieldOfStudyMaster = dropdowndata.FieldOfFieldOfStudyMaster
                this.ProgramKnowledgeLevelMasterData = dropdowndata.ProgramKnowledgeLevelMaster
                this.CourseFunctionMasters = dropdowndata.CourseFunctionMasters
            }
            this.getCourseDataForEdit();
        });
    }

    BindCourseDataForSaveEdit() {
        var saveCourse: any = this.CourseForm.value;
        debugger
        saveCourse.CourseMasterID = this.CourseId;
        saveCourse.CourseOwnerID = saveCourse.CourseOwnerID;
        saveCourse.ProgramTypeID = saveCourse.ProgramTypeID;
        saveCourse.DeliveryTypeID = saveCourse.DeliveryTypeID;
        saveCourse.ProjectStatusID = saveCourse.ProjectStatusID;
        saveCourse.Collateral = saveCourse.Collateral?.value
        saveCourse.Status = saveCourse.Status?.Id;

        console.log(saveCourse)
        return saveCourse;
    }

    onSubmitCourse() {
        var SaveData = this.BindCourseDataForSaveEdit();

        if (this.CourseForm.valid && this.CourseForm.dirty) {
            if (this.CourseId != 0) {
                this.courseService.createCourse(SaveData).subscribe((data: any) => {
                    if (data.Success) {
                        this.router.navigate(['/course-List']);
                    }
                });
            } else {
                this.courseService.updateCourse(this.CourseId, SaveData).subscribe((data: any) => {
                    if (data.Success) {
                        this.router.navigate(['/course-List']);
                    }
                });
            }
        }
    }



    clearForm() {
        this.CourseForm.reset();
        this.submitted = false;
    }


    onCancel() {
        // Clear the form
        this.clearForm();
    }

}
