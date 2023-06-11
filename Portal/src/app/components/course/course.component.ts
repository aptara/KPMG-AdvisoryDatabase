import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { SelectItem } from 'primeng/api';
import { Message } from "primeng/api";
import { Course } from 'src/app/domain/Course';
import { CourseService } from 'src/app/service/course.service';
import { DropdownDataService } from 'src/app/service/dropdown-data.service';

import { NgxDropdownConfig } from 'ngx-select-dropdown';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-course',
    templateUrl: './course.component.html',
    styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
    public CourseForm: FormGroup;
    URLParamCourseId: number = 0;
    CourseData: any;
    submitted: false;
    CompetencyMasterData: any = [];
    SkillMasterData: any = [];
    IndustryMasterData: any = [];
    ProgramKnowledgeLevelMasterData: any = [];
    AudienceLevelMasterData: any = [];
    ServiceGroupMasterData: any = [];
    ServiceLineMasterData: any = [];
    ServiceNetworkMasterData: any = [];
    FieldOfStudyMasterData: any = [];
    FunctionMasterData: any = [];
    DeliveryTypeMasterData: any = [];
    ProgramTypeMasterData: any = [];
    CourseOwnerMasterData: any = [];
    MaterialMasterData: any = [];

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
        private datePipe: DatePipe
    ) {
        this.route.queryParams.subscribe(params => {
            this.URLParamCourseId = params['id'];
        });

        this.CourseForm = this.formBuilder.group({
            CourseName: ['', [Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            CourseID: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            DeploymentFiscalYear: [''],
            CompetencyMasterID: [''],
            ProgramKnowledgeLevelMasterID: [''],
            CourseOverviewObjective: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            TargetAudience: [''],
            EstimatedCPE: ['', [Validators.required, Validators.pattern(/^[0-9]*$/)]],
            //AudienceLevelMasterID: [''],
            SpecialNoticeMasterID: [''],
            FunctionMasterID: [''],
            CourseSponsor: ['', [Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            WhichSGSLSNSponsorLearning: [''],
            SubjectMatterProfessional: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            Vendor: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            ServiceNowID: ['', [Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            Descriptions: ['', [Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            IsRegulatoryOrLegalRequirement: [''],
            ProgramTypeID: ['', [Validators.required]],
            DeliveryTypeID: ['', [Validators.required]],
            Duration: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            FirstDeliveryDate: ['', [Validators.required]],
            MaximumAttendeeCount: ['', [Validators.pattern(/^[0-9]*$/)]],
            MinimumAttendeeCount: ['', [Validators.pattern(/^[0-9]*$/)]],
            MaximumAttendeeWaitlist: ['', [Validators.pattern(/^[0-9]*$/)]],
            MaterialMasterID: [''],
            Collateral: [''],
            RoomSetUpComments: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            DeploymentFacilitatorConsideration: [''],
            LDIntakeOwner: ['', [Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            ProjectManagerContact: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            InstructionalDesigner: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            LevelofEffortMasterId: [''],
            CourseNotes: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            SkillMasterIDs: [''],
            Industries: [''],
            AudienceLevels: [''],
            FunctionMasterIDs: [''],
            SGSLSNFormGroups: this.formBuilder.array([this.GetSGSNSLFormControl()]),
            FieldOfStudyFormGroup: this.formBuilder.array([this.GetFieldOfStudyFormGroup()]),
            PrerequisiteCourseIDFormGroup: this.formBuilder.array([this.GetPrerequisiteCourseIDFormGroup()]),
            EquivalentCourseIDFormGroup: this.formBuilder.array([this.GetEquivalentCourseIDFormGroup()]),
            AudienceTypeFormGroup: this.formBuilder.array([this.GetAudienceTypeFormGroup()]),
            FOCUSCourseOwnerFormGroup: this.formBuilder.array([this.GetFOCUSCourseOwnerFormGroup()])

        })
    }

    GetSGSNSLFormControl() {
        return this.formBuilder.group({
            ServiceGroup: ['', Validators.required],
            ServiceLine: ['', Validators.required],
            ServiceNetwork: ['', Validators.required],
        })
    }

    GetFieldOfStudyFormGroup() {
        return this.formBuilder.group({
            FieldOfStudy: ['', Validators.required],
            FieldOfStudyCredit: ['', Validators.required],
        });
    }

    GetPrerequisiteCourseIDFormGroup() {
        return this.formBuilder.group({
            PrerequisiteCourseID: ['', Validators.required],
        });
    }

    GetEquivalentCourseIDFormGroup() {
        return this.formBuilder.group({
            EquivalentCourseID: ['', Validators.required],
        });
    }

    GetAudienceTypeFormGroup() {
        return this.formBuilder.group({
            AudienceType: ['', Validators.required],
        });
    }

    GetFOCUSCourseOwnerFormGroup() {
        return this.formBuilder.group({
            FOCUSCourseOwner: ['', Validators.required],
        });
    }

    get SGSLSNFormGroups() {
        return this.CourseForm.controls["SGSLSNFormGroups"] as FormArray;
    }

    get FieldOfStudyFormGroup() {
        return this.CourseForm.controls["FieldOfStudyFormGroup"] as FormArray;
    }

    get PrerequisiteCourseIDFormGroup() {
        return this.CourseForm.controls["PrerequisiteCourseIDFormGroup"] as FormArray;
    }

    get EquivalentCourseIDFormGroup() {
        return this.CourseForm.controls["EquivalentCourseIDFormGroup"] as FormArray;
    }

    get AudienceTypeFormGroup() {
        return this.CourseForm.controls["AudienceTypeFormGroup"] as FormArray;
    }

    get FOCUSCourseOwnerFormGroup() {
        return this.CourseForm.controls["FOCUSCourseOwnerFormGroup"] as FormArray;
    }

    removeFormControl(i: any) {
        this.SGSLSNFormGroups.removeAt(i);
    }

    removeFieldOfStudyFormControl(i: any) {
        this.FieldOfStudyFormGroup.removeAt(i);
    }

    removePrerequisiteCourseIDFormControl(i: any) {
        this.PrerequisiteCourseIDFormGroup.removeAt(i);
    }

    removeEquivalentCourseIDFormControl(i: any) {
        this.EquivalentCourseIDFormGroup.removeAt(i);
    }

    removeAudienceTypeFormControl(i: any) {
        this.AudienceTypeFormGroup.removeAt(i);
    }

    removeFOCUSCourseOwnerFormControl(i: any) {
        this.FOCUSCourseOwnerFormGroup.removeAt(i);
    }

    addSGSLSNCourseChild() {
        if (this.SGSLSNFormGroups.length < 4) {
            this.SGSLSNFormGroups.push(this.GetSGSNSLFormControl());
        }
    }

    addFormFieldOfStudyChildForm() {

        if (this.FieldOfStudyFormGroup.length < 4) {
            this.FieldOfStudyFormGroup.push(this.GetFieldOfStudyFormGroup());
        }
    }

    addPrerequisiteCourseIDChildForm() {
        if (this.PrerequisiteCourseIDFormGroup.length < 2) {
            this.PrerequisiteCourseIDFormGroup.push(this.GetPrerequisiteCourseIDFormGroup());
        }
    }

    addEquivalentCourseIDChildForm() {
        if (this.EquivalentCourseIDFormGroup.length < 2) {
            this.EquivalentCourseIDFormGroup.push(this.GetEquivalentCourseIDFormGroup());
        }
    }

    addAudienceTypeChildForm() {
        if (this.AudienceTypeFormGroup.length < 2) {
            this.AudienceTypeFormGroup.push(this.GetAudienceTypeFormGroup());
        }
    }

    addFOCUSCourseOwnerChildForm() {
        if (this.FOCUSCourseOwnerFormGroup.length < 2) {
            this.FOCUSCourseOwnerFormGroup.push(this.GetFOCUSCourseOwnerFormGroup());
        }
    }

    ngOnInit() {
        this.getDropdownData();
    }

    bindFormData() {
        this.CourseForm.patchValue({
            CourseName: this.CourseData?.CourseName,
            CourseID: this.CourseData?.CourseID,
            DeploymentFiscalYear: this.CourseData?.DeploymentFiscalYear,
            CompetencyMasterID: this.CourseData?.CompetencyMasterID,
            ProgramKnowledgeLevelMasterID: this.CourseData?.ProgramKnowledgeLevelMasterID,
            CourseOverviewObjective: this.CourseData?.CourseOverviewObjective,
            TargetAudience: this.CourseData?.TargetAudience,
            EstimatedCPE: this.CourseData?.EstimatedCPE,
            //AudienceLevelMasterID: this.CourseData?.AudienceLevelMasterID,
            SpecialNoticeMasterID: this.CourseData?.SpecialNoticeMasterID,
            FunctionMasterID: this.CourseData?.FunctionMasterID,
            CourseSponsor: this.CourseData?.CourseSponsor,
            WhichSGSLSNSponsorLearning: this.CourseData?.WhichSGSLSNSponsorLearning,
            SubjectMatterProfessional: this.CourseData?.SubjectMatterProfessional,
            Vendor: this.CourseData?.Vendor,
            ServiceNowID: this.CourseData?.ServiceNowID,
            Descriptions: this.CourseData?.Descriptions,
            IsRegulatoryOrLegalRequirement: this.CourseData?.IsRegulatoryOrLegalRequirement,
            ProgramTypeID: this.CourseData?.ProgramTypeID,
            DeliveryTypeID: this.CourseData?.DeliveryTypeID,
            Duration: this.CourseData?.Duration,
            FirstDeliveryDate: this.datePipe.transform(this.CourseData?.FirstDeliveryDate, 'yyyy-MM-dd'),
            MaximumAttendeeCount: this.CourseData?.MaximumAttendeeCount,
            MinimumAttendeeCount: this.CourseData?.MinimumAttendeeCount,
            MaximumAttendeeWaitlist: this.CourseData?.MaximumAttendeeWaitlist,
            MaterialMasterID: this.CourseData?.MaterialMasterID,
            Collateral: this.CourseData?.Collateral,
            RoomSetUpComments: this.CourseData?.RoomSetUpComments,
            DeploymentFacilitatorConsideration: this.CourseData?.DeploymentFacilitatorConsideration,
            LDIntakeOwner: this.CourseData?.LDIntakeOwner,
            ProjectManagerContact: this.CourseData?.ProjectManagerContact,
            InstructionalDesigner: this.CourseData?.InstructionalDesigner,
            LevelofEffortMasterId: this.CourseData?.LevelofEffortMasterId,
            CourseNotes: this.CourseData?.CourseNotes,
        });
        console.log(this.CourseForm.value)
    }

    getCourseDataForEdit() {
        if (this.URLParamCourseId) {
            return this.courseService.getCourse(this.URLParamCourseId).subscribe((data: any) => {
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
                this.CompetencyMasterData = dropdowndata.CompetencyMasterData
                this.SkillMasterData = dropdowndata.SkillMasterData
                this.IndustryMasterData = dropdowndata.IndustryMasterData
                this.ProgramKnowledgeLevelMasterData = dropdowndata.ProgramKnowledgeLevelMasterData
                this.AudienceLevelMasterData = dropdowndata.AudienceLevelMasterData
                this.ServiceGroupMasterData = dropdowndata.ServiceGroupMasterData
                this.ServiceLineMasterData = dropdowndata.ServiceLineMasterData
                this.ServiceNetworkMasterData = dropdowndata.ServiceNetworkMasterData
                this.FieldOfStudyMasterData = dropdowndata.FieldOfStudyMasterData
                this.FunctionMasterData = dropdowndata.FunctionMasterData
                this.DeliveryTypeMasterData = dropdowndata.DeliveryTypeMasterData
                this.ProgramTypeMasterData = dropdowndata.ProgramTypeMasterData
                this.CourseOwnerMasterData = dropdowndata.CourseOwnerMasterData
                this.MaterialMasterData = dropdowndata.MaterialMasterData
            }
            this.getCourseDataForEdit();
        });
    }

    BindCourseDataForSaveEdit() {
        var CourseData: any = this.CourseForm.value;
        let saveCourse: any = {};
        saveCourse.CourseMasterID = this.URLParamCourseId;
        debugger
        // saveCourse.CompetencyMasterID = this.GetDropdownDataForSave(CourseData.CompetencyMasterID);
        // saveCourse.LevelofEffortMasterId = this.GetDropdownDataForSave(CourseData.LevelofEffortMasterId);
        // saveCourse.FunctionMasterIDs = this.GetDropdownDataForSave(CourseData.FunctionMasterIDs);
        // saveCourse.ProgramKnowledgeLevelMasterID = this.GetDropdownDataForSave(CourseData.ProgramKnowledgeLevelMasterID);
        // saveCourse.IsRegulatoryOrLegalRequirement = this.GetDropdownDataForSave(CourseData.IsRegulatoryOrLegalRequirement);
        // saveCourse.MaterialMasterID = this.GetDropdownDataForSave(CourseData.MaterialMasterID);
        // saveCourse.FOCUSCourseOwnerFormGroup = this.GetDropdownDataForSave(CourseData.FOCUSCourseOwnerFormGroup);
        // saveCourse.SkillMasterIDs = this.GetDropdownDataForSave(CourseData.SkillMasterIDs);
        // saveCourse.Industries = this.GetDropdownDataForSave(CourseData.Industries);
        // saveCourse.AudienceLevels = this.GetDropdownDataForSave(CourseData.AudienceLevels);
        // saveCourse.FunctionMasterID = this.GetDropdownDataForSave(saveCourse.FunctionMasterID);
        //saveCourse.SGSLSNFormGroups = this.GetDropdownDataForSave(saveCourse.SGSLSNFormGroups);
        saveCourse.CourseName = CourseData.CourseName;
        saveCourse.CourseID = CourseData.CourseID;
        saveCourse.DeploymentFiscalYear = CourseData.DeploymentFiscalYear;
        saveCourse.CourseOverviewObjective = CourseData.CourseOverviewObjective;
        saveCourse.TargetAudience = CourseData.TargetAudience;
        saveCourse.EstimatedCPE = CourseData.EstimatedCPE;
        saveCourse.SpecialNoticeMasterID = CourseData.SpecialNoticeMasterID;

        saveCourse.CourseSponsor = CourseData.CourseSponsor;
        saveCourse.WhichSGSLSNSponsorLearning = CourseData.WhichSGSLSNSponsorLearning;
        saveCourse.SubjectMatterProfessional = CourseData.SubjectMatterProfessional;
        saveCourse.Vendor = CourseData.Vendor;
        saveCourse.ServiceNowID = CourseData.ServiceNowID;
        saveCourse.Descriptions = CourseData.Descriptions;

        //saveCourse.ProgramTypeID = CourseData.ProgramTypeID; //TODO - Need to check data
        //saveCourse.DeliveryTypeID = CourseData.DeliveryTypeID; //TODO - Need to check data

        saveCourse.Duration = CourseData.Duration;
        saveCourse.FirstDeliveryDate = CourseData.FirstDeliveryDate;
        saveCourse.MaximumAttendeeCount = CourseData.MaximumAttendeeCount;
        saveCourse.MinimumAttendeeCount = CourseData.MinimumAttendeeCount;
        saveCourse.MaximumAttendeeWaitlist = CourseData.MaximumAttendeeWaitlist;
        saveCourse.RoomSetUpComments = CourseData.RoomSetUpComments;
        saveCourse.DeploymentFacilitatorConsideration = CourseData.DeploymentFacilitatorConsideration;
        saveCourse.LDIntakeOwner = CourseData.LDIntakeOwner;
        saveCourse.ProjectManagerContact = CourseData.ProjectManagerContact;
        saveCourse.InstructionalDesigner = CourseData.InstructionalDesigner;
        saveCourse.CourseNotes = CourseData.CourseNotes;
        console.log(saveCourse)
        return saveCourse;
    }

    GetSingleDropdownDataForSave(value: any) {
        return value.Id
    }

    GetMultiSelectDropdownDataForSave(value: any) {
        let ValueIds = [];
        if (Array.isArray(value)) {

        }
    }


    onSubmitCourse() {
        var SaveData = this.BindCourseDataForSaveEdit();

        if (this.CourseForm.valid && this.CourseForm.dirty) {
            if (this.URLParamCourseId != 0) {
                this.courseService.createCourse(SaveData).subscribe((data: any) => {
                    if (data.Success) {
                        this.router.navigate(['/course-List']);
                    }
                });
            } else {
                this.courseService.updateCourse(this.URLParamCourseId, SaveData).subscribe((data: any) => {
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
