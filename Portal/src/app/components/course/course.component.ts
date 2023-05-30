import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { SelectItem } from 'primeng/api';
import { Message } from "primeng/api";
import { Course } from 'src/app/domain/Course';
import { CourseService } from 'src/app/service/course.service';
import { DropdownDataService } from 'src/app/service/dropdown-data.service';
import { DropDownListModule } from '@progress/kendo-angular-dropdowns';

@Component({
    selector: 'app-course',
    templateUrl: './course.component.html',
    styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
    public CourseForm: FormGroup;
    CourseId: number = 0;
    CourseData: Course | undefined;
    courseOwnersData: any[] = [];
    programTypesData: any[] = [];
    deliveryTypesData: any[] = [];
    statusData: any[] = [];
    projectStatusData: any[] = [];
    collaterals: any[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
    web = { label: 'google', url: 'https://www.google.com' }

    public areaList: Array<string> = [
        "Boston",
        "Chicago",
        "Houston",
        "Los Angeles",
        "Miami",
        "New York",
        "Philadelphia",
        "San Francisco",
        "Seattle",
    ];

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
            ServiceGroup: [''],
            ServiceLine: [''],
            ServiceNetwork: [''],
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
        })
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

            CourseOwnerID: this.courseOwnersData.find(x => x.Id === this.CourseData?.CourseOwnerID),
            ProgramTypeID: this.programTypesData.find(x => x.Id === this.CourseData?.ProgramTypeID),
            DeliveryTypeID: this.deliveryTypesData.find(x => x.Id === this.CourseData?.DeliveryTypeID),
            ProjectStatusID: this.projectStatusData.find(x => x.Id === this.CourseData?.ProgramTypeID),
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
                this.courseOwnersData = dropdowndata?.CourseOwnerMasters;
                this.programTypesData = dropdowndata?.ProgramTypeMasters;
                this.deliveryTypesData = dropdowndata?.DeliveryTypeMasters;
                this.statusData = dropdowndata?.StatusMasters;
                this.projectStatusData = dropdowndata?.ProjectStatusMasters;
            }
            this.getCourseDataForEdit();
        });
    }

    BindCourseDataForSaveEdit() {
        var saveCourse: any = this.CourseForm.value;
        debugger
        saveCourse.CourseMasterID = this.CourseId;
        saveCourse.CourseOwnerID = this.courseOwnersData.find(x => x.Id === saveCourse.CourseOwnerID?.Id)?.Id;
        saveCourse.ProgramTypeID = this.programTypesData.find(x => x.Id === saveCourse.ProgramTypeID?.Id)?.Id;
        saveCourse.DeliveryTypeID = this.deliveryTypesData.find(x => x.Id === saveCourse.DeliveryTypeID?.Id)?.Id;
        saveCourse.ProjectStatusID = this.projectStatusData.find(x => x.Id === saveCourse.ProjectStatusID?.Id)?.Id;
        saveCourse.Collateral = this.collaterals.find(x => x.value === saveCourse.Collateral?.value)?.value
        saveCourse.Status = this.statusData.find(x => x.Id === saveCourse.Status?.Id)?.Id;

        console.log(saveCourse)
        return saveCourse;
    }

    onSubmitCourse() {
        var SaveData = this.BindCourseDataForSaveEdit();
        debugger
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
}
