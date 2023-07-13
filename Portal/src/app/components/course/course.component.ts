import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray, AbstractControl, ValidationErrors } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from 'src/app/service/course.service';
import { DropdownDataService } from 'src/app/service/dropdown-data.service';

import { NgxDropdownConfig } from 'ngx-select-dropdown';
import { DatePipe } from '@angular/common';
import { UserService } from 'src/app/service/userservice';
import { CoursePermission } from 'src/app/domain/user';
import { createMask } from '@ngneat/input-mask';



declare var bootbox: any;

@Component({
    selector: 'app-course',
    templateUrl: './course.component.html',
    styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
    @ViewChild('discontinuedInput', { static: true }) discontinuedInput: ElementRef;
    isSaveButtonDisabled: boolean = false;
    discontinuedDate: string;
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
    LevelOfEffortMasterData: any = [];
    SpecialNoticeMasterData: any = [];
    InstructionalDesignerMaster: any = [];
    ProjectManagerContactMaster: any = [];
    LDIntakeOwnerMaster: any = [];
    StatusMasterData: any = [];
    CurrentDate: any;
    isDisabled: boolean = true;
    UserData: any
    IsRegulatoryOrLegalRequirementDropdownData: any[] = [{ DisplayName: 'Yes', Id: true }, { DisplayName: 'No', Id: false }];
    collaterals: any[] = [{ DisplayName: 'Yes', Id: true }, { DisplayName: 'No', Id: false }];
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
        inputDirection: '',
    }
    IsSubmit: boolean = false;
    IsRequiredsgslsnFormControl: boolean = false;
    IsRequiredfOSFormGroup: boolean = false;
    UseData: string | null;
    hasPermission: CoursePermission;
    False: any;
    TimeInputMask = createMask({ mask: '(99:99)|(00:00)', keepStatic: true });


    constructor(
        private formBuilder: FormBuilder,
        private dropdownService: DropdownDataService,
        private route: ActivatedRoute,
        public courseService: CourseService,
        private router: Router,
        private datePipe: DatePipe,
        private userService: UserService
    ) {
        this.CurrentDate = new Date();
        const today = new Date();
        this.discontinuedDate = this.formatDate(today);
        // this.route.queryParams.subscribe(params => {
        //     this.URLParamCourseId = params['id'];
        // });
        this.URLParamCourseId = this.route.snapshot.params['id'];
        this.hasPermission = new CoursePermission();
        this.CourseForm = this.formBuilder.group({
            StatusMasterID: ['Record Creation', [Validators.required]],
            CourseName: ['', [Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            CourseID: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            DeploymentFiscalYear: [{ value: '', disabled: true }],
            DevelopmentYear: ['', [Validators.pattern(/^[0-9]*$/)]],
            CompetencyMasterID: [''],
            ProgramKnowledgeLevelMasterID: [''],
            CourseOverviewObjective: [''],
            TargetAudience: [''],
            EstimatedCPE: [{ value: '', disabled: true }],
            //AudienceLevelMasterID: [''],
            SpecialNoticeMasterID: [''],
            FunctionMasterID: [''],
            CourseSponsor: [''],  //[Validators.required, Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)],
            WhichSGSLSNSponsorLearning: [''],
            SubjectMatterProfessional: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            Vendor: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            ServiceNowID: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]], //Validators.required,
            Descriptions: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]], //Validators.required,
            IsRegulatoryOrLegalRequirement: [''],
            ProgramTypeID: [''], //[Validators.required]
            DeliveryTypeID: [''], // [Validators.required]
            // Duration: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            Duration: ['', [this.validateDurationFormat]],
            FirstDeliveryDate: [''], //[Validators.required]
            MaximumAttendeeCount: ['', [Validators.pattern(/^[0-9]*$/)]],
            MinimumAttendeeCount: ['', [Validators.pattern(/^[0-9]*$/)]],
            MaximumAttendeeWaitlist: ['', [Validators.pattern(/^[0-9]*$/)]],
            MaterialMasterID: [''],
            Collateral: [''],
            RoomSetUpComments: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
            DeploymentFacilitatorConsideration: [''],
            LDIntakeOwner: [''],  //[Validators.required]
            ProjectManagerContact: [''],
            InstructionalDesigner: [''],
            LevelofEffortMasterId: [''],
            CourseNotes: [''],
            SkillMasterIDs: [''],
            Industries: [''],
            AudienceLevels: [''],
            FunctionMasterIDs: [''],
            SGSLSNFormGroups: this.formBuilder.array([this.GetSGSNSLFormControl()]),

            FieldOfStudyFormGroup: this.formBuilder.array([this.GetFieldOfStudyFormGroup()]),
            PrerequisiteCourseIDFormGroup: this.formBuilder.array([this.GetPrerequisiteCourseIDFormGroup('No Prerequisite')]),
            EquivalentCourseIDFormGroup: this.formBuilder.array([this.GetEquivalentCourseIDFormGroup('No Equivalant')]),
            AudienceTypeFormGroup: this.formBuilder.array([this.GetAudienceTypeFormGroup('US Only')]),
            FOCUSCourseOwnerFormGroup: this.formBuilder.array([this.GetFOCUSCourseOwnerFormGroup()]),
            WorkNotes: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]]
            // Discontinued: ['', (this.discontinuedDate)]
        })
    }

    formatDate(date: Date): string {
        const year = date.getFullYear();
        const month = this.padZero(date.getMonth() + 1);
        const day = this.padZero(date.getDate());
        return `${year}-${month}-${day}`;
    }

    padZero(value: number): string {
        return value < 10 ? `0${value}` : value.toString();
    }

    validateDurationFormat(control: AbstractControl): ValidationErrors | null {
        const value = control.value;

        if (value === null || value === '') {
            return null;
        }

        const timeParts = value.split(':');
        const hours = parseInt(timeParts[0], 10);
        const minutes = parseInt(timeParts[1], 10);

        if (isNaN(hours) || isNaN(minutes) || hours < 0 || hours >= 99 || minutes < 0 || minutes > 60) {
            return { invalidDurationFormat: true };
        }

        return null;
    }




    ngOnInit() {

        this.courseService.saveButtonDisabled$.subscribe(disabled => {
            this.isSaveButtonDisabled = disabled;
        });

        this.getDropdownData();
        this.CourseForm.controls.CourseNotes.disable();
        this.hasPermission = this.userService.GetUserPermission();
        if (this.hasPermission.hasPermissionCreateCourse === false && this.hasPermission.hasPermissionUpdateCourse === false && this.hasPermission.hasPermissionReviewCourse === true) {
            this.CourseForm.disable()
        }
        this.userService.WindowAuthentication().subscribe(data => {
            this.UserData = data
        })

    }


    OnChangeFieldOfStudy(fieldOfStudy: any) {
        if (fieldOfStudy.controls.FieldOfStudy.value.length) {
            fieldOfStudy.get('FieldOfStudy').addValidators(Validators.required);
        } else {
            fieldOfStudy.get('FieldOfStudy').clearValidators();
        }
    }

    GetSGSNSLFormControl() {
        return this.formBuilder.group({
            ServiceGroup: [''],
            ServiceLine: [''],
            ServiceNetwork: ['']
        });
    }

    GetFieldOfStudyFormGroup() {
        return this.formBuilder.group({
            FieldOfStudy: [''],
            FieldOfStudyCredit: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetPrerequisiteCourseIDFormGroup(defaultValue: string = '') {
        return this.formBuilder.group({
            PrerequisiteCourseID: [defaultValue, [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetEquivalentCourseIDFormGroup(defaultValue: string = '') {
        return this.formBuilder.group({
            EquivalentCourseID: [defaultValue, [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetAudienceTypeFormGroup(defaultValue: string = '') {
        return this.formBuilder.group({
            AudienceType: [defaultValue, [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }




    GetFOCUSCourseOwnerFormGroup() {
        return this.formBuilder.group({
            CourseOwner: [''], // [Validators.required]
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
        this.ValidatesgslsnFormControl(true);
        if (!this.IsRequiredsgslsnFormControl && this.SGSLSNFormGroups.length < 4) {
            this.SGSLSNFormGroups.push(this.GetSGSNSLFormControl());
        }
    }

    addFormFieldOfStudyChildForm() {
        this.ValidatefOSFormGroup(true);
        if (!this.IsRequiredfOSFormGroup && this.FieldOfStudyFormGroup.length < 4) {
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


    bindFormData() {
        this.CourseForm.patchValue({
            CourseName: this.CourseData?.CourseName,
            CourseID: this.CourseData?.CourseID,
            DeploymentFiscalYear: this.CourseData?.DeploymentFiscalYear,
            DevelopmentYear: this.CourseData?.DevelopmentYear,
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
            Duration: this.CourseData?.Duration,
            FirstDeliveryDate: this.datePipe.transform(this.CourseData?.FirstDeliveryDate),//, 'yyyy-MM-dd'
            MaximumAttendeeCount: this.CourseData?.MaximumAttendeeCount,
            MinimumAttendeeCount: this.CourseData?.MinimumAttendeeCount,
            MaximumAttendeeWaitlist: this.CourseData?.MaximumAttendeeWaitlist,
            Collateral: this.GetDropDownObjectForBindData(this.CourseData?.Collateral, this.collaterals),
            RoomSetUpComments: this.CourseData?.RoomSetUpComments,
            DeploymentFacilitatorConsideration: this.CourseData?.DeploymentFacilitatorConsideration,
            LDIntakeOwner: this.GetDropDownObjectForBindData(this.CourseData?.LDIntakeOwner, this.LDIntakeOwnerMaster),
            ProjectManagerContact: this.GetDropDownObjectForBindData(this.CourseData?.ProjectManagerContact, this.ProjectManagerContactMaster),
            InstructionalDesigner: this.GetDropDownObjectForBindData(this.CourseData?.InstructionalDesigner, this.InstructionalDesignerMaster),
            CourseNotes: this.CourseData?.CourseNotes,
            CompetencyMasterID: this.GetDropDownObjectForBindData(this.CourseData.CompetencyMasterID, this.CompetencyMasterData),
            LevelofEffortMasterId: this.GetDropDownObjectForBindData(this.CourseData.LevelofEffortMasterId, this.LevelOfEffortMasterData),
            ProgramKnowledgeLevelMasterID: this.GetDropDownObjectForBindData(this.CourseData.ProgramKnowledgeLevelMasterID, this.ProgramKnowledgeLevelMasterData),
            IsRegulatoryOrLegalRequirement: this.GetDropDownObjectForBindData(this.CourseData.IsRegulatoryOrLegalRequirement, this.IsRegulatoryOrLegalRequirementDropdownData),
            MaterialMasterID: this.GetDropDownObjectForBindData(this.CourseData.MaterialMasterID, this.MaterialMasterData),
            ProgramTypeID: this.GetDropDownObjectForBindData(this.CourseData.ProgramTypeID, this.ProgramTypeMasterData),
            DeliveryTypeID: this.GetDropDownObjectForBindData(this.CourseData.DeliveryTypeID, this.DeliveryTypeMasterData),
            SkillMasterIDs: this.CourseData.SkillMasterIDs,
            Industries: this.CourseData.Industries,
            AudienceLevels: this.CourseData.AudienceLevels,
            FunctionMasterIDs: this.CourseData.FunctionMasterIDs,
            StatusMasterID: this.GetDropDownObjectForBindData(this.CourseData.StatusMasterID, this.StatusMasterData),
            WorkNotes: this.CourseData?.WorkNotes
        });
        if (this.FieldOfStudyFormGroup?.length == 1 && this.CourseData.FieldOfStudyFormGroup?.length) {
            this.FieldOfStudyFormGroup.clear();
        }
        let totalCPE = 0;
        for (let item of this.CourseData?.FieldOfStudyFormGroup) {
            this.FieldOfStudyFormGroup.push(this.formBuilder.group(item));
            totalCPE = totalCPE + Number(item.FieldOfStudyCredit);
        }
        this.CourseForm.controls?.EstimatedCPE?.setValue(totalCPE);
        if (this.SGSLSNFormGroups?.length == 1 && this.CourseData.SGSLSNFormGroups?.length) {
            this.SGSLSNFormGroups.clear();
        }
        for (let item of this.CourseData?.SGSLSNFormGroups) {
            this.SGSLSNFormGroups.push(this.formBuilder.group(item));
        }

        if (this.PrerequisiteCourseIDFormGroup?.length == 1 && this.CourseData.PrerequisiteCourseIDFormGroup?.length) {
            this.PrerequisiteCourseIDFormGroup.clear();
        }
        for (let item of this.CourseData?.PrerequisiteCourseIDFormGroup) {
            this.PrerequisiteCourseIDFormGroup.push(this.formBuilder.group(item));
        }

        if (this.EquivalentCourseIDFormGroup?.length == 1 && this.CourseData.EquivalentCourseIDFormGroup?.length) {
            this.EquivalentCourseIDFormGroup.clear();
        }
        for (let item of this.CourseData?.EquivalentCourseIDFormGroup) {
            this.EquivalentCourseIDFormGroup.push(this.formBuilder.group(item));
        }

        if (this.AudienceTypeFormGroup?.length == 1 && this.CourseData.AudienceTypeFormGroup?.length) {
            this.AudienceTypeFormGroup.clear();
        }
        for (let item of this.CourseData?.AudienceTypeFormGroup) {
            this.AudienceTypeFormGroup.push(this.formBuilder.group(item));
        }
        if (this.FOCUSCourseOwnerFormGroup?.length == 1 && this.CourseData.FOCUSCourseOwnerFormGroup?.length) {
            this.FOCUSCourseOwnerFormGroup.clear();
        }
        for (let item of this.CourseData?.FOCUSCourseOwnerFormGroup) {
            this.FOCUSCourseOwnerFormGroup.push(this.formBuilder.group({
                CourseOwner: [item],
            }));
        }
        console.log(this.CourseForm.value)
    }

    GetDropDownObjectForBindData(CourseData: any, MasterDataList: any[]) {
        return MasterDataList.find(x => x.Id == CourseData)
    }

    getCourseDataForEdit() {
        if (this.URLParamCourseId) {
            return this.courseService.getCourse(this.URLParamCourseId).subscribe((data: any) => {
                if (data.Success) {
                    this.CourseData = data.Data;

                    this.bindFormData();
                    // Check if the record is locked
                    if (this.CourseData.IsRecordLocked === 'Yes       ') {
                        // bootbox.alert("Respective course is uploaded in Focus. So record is locked.")
                        this.isSaveButtonDisabled = true; // Use '=' for assignment
                    }
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
                this.LevelOfEffortMasterData = dropdowndata.LevelOfEffortMasterData
                this.SpecialNoticeMasterData = dropdowndata.SpecialNoticeMasterData
                this.InstructionalDesignerMaster = dropdowndata.InstructionalDesignerMaster
                this.ProjectManagerContactMaster = dropdowndata.ProjectManagerContactMaster
                this.LDIntakeOwnerMaster = dropdowndata.LDIntakeOwnerMaster
                this.StatusMasterData = dropdowndata.StatusMasterData
            }
            this.getCourseDataForEdit();
        });
    }

    ServiceLineMasterDataOption: any = [];
    OnChangedServiceGroup(data: any, formControl: any) {
        formControl.controls.ServiceLine.reset()
        formControl.controls.ServiceNetwork.reset()
        this.ServiceLineMasterDataOption = this.ServiceLineMasterData.filter((x: { ParentId: any; }) => x.ParentId === data.value.Id)
        if (formControl.controls.ServiceGroup.value.length) {
            formControl.get('ServiceLine').addValidators(Validators.required);
            formControl.get('ServiceNetwork').addValidators(Validators.required);
        } else {
            formControl.get('ServiceLine').clearValidators();
            formControl.get('ServiceNetwork').clearValidators();
        }
    }

    ServiceNetworkMasterDataOption: any = [];
    OnChangedServiceLine(data: any, formControl: any) {
        formControl.controls.ServiceNetwork.reset()
        this.ServiceNetworkMasterDataOption = this.ServiceNetworkMasterData.filter((x: { ParentId: any; }) => x.ParentId === data.value.Id)
        if (formControl.controls.ServiceNetwork.value.length) {
            formControl.get('ServiceNetwork').addValidators(Validators.required);
        } else {
            formControl.get('ServiceNetwork').clearValidators();
        }
    }

    GetServiceLineDropdownOptions(formControl: any) {
        let ServiceGroup = formControl.controls.ServiceGroup.value;
        return this.ServiceLineMasterData.filter((x: { ParentId: any; }) => x.ParentId === ServiceGroup?.Id)
    }

    GetServiceNetworkDropdownOptions(formControl: any) {
        let serviceLine = formControl.controls.ServiceLine.value;
        return this.ServiceNetworkMasterData.filter((x: { ParentId: any; }) => x.ParentId === serviceLine?.Id)
    }

    BindCourseDataForSaveEdit() {
        var CourseData: any = this.CourseForm.value;
        let saveCourse: any = {};
        let UserData: any = localStorage.getItem("UserData");
        saveCourse.CourseMasterID = this.URLParamCourseId;
        saveCourse.CompetencyMasterID = this.GetSingleDropdownDataForSave(CourseData.CompetencyMasterID);
        saveCourse.LevelofEffortMasterId = this.GetSingleDropdownDataForSave(CourseData.LevelofEffortMasterId);
        saveCourse.ProgramKnowledgeLevelMasterID = this.GetSingleDropdownDataForSave(CourseData.ProgramKnowledgeLevelMasterID);
        saveCourse.IsRegulatoryOrLegalRequirement = this.GetSingleDropdownDataForSave(CourseData.IsRegulatoryOrLegalRequirement);
        saveCourse.MaterialMasterID = this.GetSingleDropdownDataForSave(CourseData.MaterialMasterID);
        saveCourse.ProgramTypeID = this.GetSingleDropdownDataForSave(CourseData.ProgramTypeID);
        saveCourse.DeliveryTypeID = this.GetSingleDropdownDataForSave(CourseData.DeliveryTypeID);
        saveCourse.LDIntakeOwner = this.GetSingleDropdownDataForSave(CourseData.LDIntakeOwner);
        saveCourse.ProjectManagerContact = this.GetSingleDropdownDataForSave(CourseData.ProjectManagerContact);
        saveCourse.InstructionalDesigner = this.GetSingleDropdownDataForSave(CourseData.InstructionalDesigner);
        saveCourse.StatusMasterID = this.GetSingleDropdownDataForSave(CourseData.StatusMasterID);
        saveCourse.SkillMasterIDs = CourseData.SkillMasterIDs;
        saveCourse.Industries = CourseData.Industries;
        saveCourse.AudienceLevels = CourseData.AudienceLevels;
        saveCourse.FunctionMasterIDs = CourseData.FunctionMasterIDs;
        saveCourse.FieldOfStudyFormGroup = CourseData.FieldOfStudyFormGroup;
        saveCourse.SGSLSNFormGroups = CourseData.SGSLSNFormGroups;
        saveCourse.PrerequisiteCourseIDFormGroup = CourseData.PrerequisiteCourseIDFormGroup
        saveCourse.EquivalentCourseIDFormGroup = CourseData.EquivalentCourseIDFormGroup
        saveCourse.AudienceTypeFormGroup = CourseData.AudienceTypeFormGroup
        saveCourse.FOCUSCourseOwnerFormGroup = this.GetAlphaNumaricDataForSave(CourseData.FOCUSCourseOwnerFormGroup)
        saveCourse.CourseName = CourseData.CourseName;
        saveCourse.CourseID = CourseData.CourseID;
        saveCourse.DeploymentFiscalYear = CourseData.DeploymentFiscalYear;
        saveCourse.DevelopmentYear = CourseData.DevelopmentYear;
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
        saveCourse.Duration = CourseData.Duration;
        saveCourse.FirstDeliveryDate = CourseData.FirstDeliveryDate;
        saveCourse.MaximumAttendeeCount = CourseData.MaximumAttendeeCount;
        saveCourse.MinimumAttendeeCount = CourseData.MinimumAttendeeCount;
        saveCourse.MaximumAttendeeWaitlist = CourseData.MaximumAttendeeWaitlist;
        saveCourse.RoomSetUpComments = CourseData.RoomSetUpComments;
        saveCourse.DeploymentFacilitatorConsideration = CourseData.DeploymentFacilitatorConsideration;
        saveCourse.CourseNotes = CourseData.CourseNotes;
        saveCourse.Collateral = CourseData.Collateral?.Id;
        saveCourse.LastUpdatedBy = 1 //TODO - UserData.Id
        saveCourse.CreatedBy = 1 //TODO - UserData.Id
        console.log(saveCourse)
        return saveCourse;
    }

    GetSingleDropdownDataForSave(value: any) {
        return value?.Id
    }

    GetAlphaNumaricDataForSave(value: any) {
        let arrayList: any = [];
        value.forEach((x: any) => {
            arrayList.push(x.CourseOwner);
        });
        return arrayList;
    }

    GetMultiSelectDropdownDataForSave(value: any) {
        let ValueIds = [];
        if (Array.isArray(value)) {

        }
    }

    OnChangesFieldOfStudyCredit(event: any) {
        let totalCPE: number = 0;
        if (this.CourseForm?.get("FieldOfStudyFormGroup")?.value) {
            for (let control of this.CourseForm?.get("FieldOfStudyFormGroup")?.value) {
                totalCPE = totalCPE + Number(control.FieldOfStudyCredit)
            }
        }
        this.CourseForm.controls?.EstimatedCPE?.setValue(totalCPE);
    }


    controlFieldMapping: { [key: string]: string } = {
        CourseName: 'Course Name',
        StatusMasterID: ' Project Status'
        //AudienceTypeFormGroup: 'Audience Type',
        // CourseSponsor: 'Course Sponsor',
        // ServiceNowID: 'Service Now ID',
        // Descriptions: 'Please provide a description/the business need related to this request',
        // ProgramTypeID: 'Program Type ',
        // DeliveryTypeID: 'Delivery Type',
        // FirstDeliveryDate: 'First Delivery Date',
        // LDIntakeOwner: 'L&D Intake Owner ',
        // FOCUSCourseOwnerFormGroup: 'Course Owner',
        // FieldOfStudyFormGroup: 'Field of Study  & Field of Study Credit ',
        //SGSLSNFormGroups: 'Service Group/Service Line/Service Network '

    };

    findInvalidControls1(): string[] {
        const invalidFields: string[] = [];
        const controls = this.CourseForm.controls;

        for (const controlName in controls) {
            if (controls.hasOwnProperty(controlName)) {
                if (controls[controlName].invalid) {
                    const fieldName = this.controlFieldMapping[controlName] || controlName;
                    invalidFields.push(fieldName);
                }
            }
        }

        return invalidFields;
    }


    onSubmitCourse() {
        this.IsSubmit = true;
        var SaveData = this.BindCourseDataForSaveEdit();
        if (!this.CourseForm.invalid) {
            if (this.URLParamCourseId == undefined || this.URLParamCourseId == 0) {
                bootbox.confirm('Are you sure you want to Add Course?', (result: boolean) => {
                    if (result) {
                        this.courseService.createCourse(SaveData).subscribe((data: any) => {
                            if (data.Success) {
                                this.router.navigate(['/course-List']);
                            }

                        });

                    }
                    return;
                });
            } else {
                bootbox.confirm('Are you sure you want to Update Course?', (result: boolean) => {
                    if (result) {
                        this.courseService.createCourse(SaveData).subscribe((data: any) => {
                            if (data.Success) {
                                this.router.navigate(['/course-List']);
                            }
                        });
                    }
                    return;
                });
            }
        } else {
            const invalidFields = this.findInvalidControls1();
            const fieldNames = invalidFields.map(fieldName => this.controlFieldMapping[fieldName] || fieldName);
            const message = fieldNames.join(', ');

            bootbox.alert({
                size: "heigh",
                title: "Some required fields are not filled. Please update the value.",
                message: message,
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
        }
    }


    public findInvalidControls() {
        const invalid = [];
        const controls = this.CourseForm.controls;
        for (const name in controls) {
            if (controls[name].invalid) {
                invalid.push(name);
            }
        }
        console.log("Invalids control", invalid);
    }

    ValidatesgslsnFormControl(validate: boolean) {
        for (let control of this.CourseForm?.get("SGSLSNFormGroups")?.value) {
            if (control?.ServiceGroup === "" || control?.ServiceLine === "" || control?.ServiceNetwork === "") {
                this.IsRequiredsgslsnFormControl = true
            } else {
                this.IsRequiredsgslsnFormControl = false
            }
        }
    }

    ValidatefOSFormGroup(validate: boolean) {
        for (let control of this.CourseForm?.get("FieldOfStudyFormGroup")?.value) {
            if (control?.FieldOfStudy === "" || control?.FieldOfStudyCredit === "") {
                this.IsRequiredfOSFormGroup = true
            } else {
                this.IsRequiredfOSFormGroup = false
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


    getDeploymentFiscalYear() {
        const firstDeliveryDate = this.CourseForm?.get('FirstDeliveryDate')?.value;
        if (firstDeliveryDate) {
            const date = new Date(firstDeliveryDate);
            const year = date.getFullYear();
            const month = date.getMonth() + 1;
            const isOctoberOrLater = month >= 10;

            if (isOctoberOrLater) {
                const nextYear = year + 1;
                const lastTwoDigits = nextYear % 100;
                return `FY${lastTwoDigits}`;
            } else {
                const lastTwoDigits = year % 100;
                return `FY${lastTwoDigits}`;
            }
        }
        return '';
    }


}
