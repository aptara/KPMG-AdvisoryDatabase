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
    LevelOfEffortMasterData: any = [];
    SpecialNoticeMasterData: any = [];
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
    IsSubmit: boolean = false;
    IsRequiredsgslsnFormControl: boolean = false;
    IsRequiredfOSFormGroup: boolean = false;

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
            ServiceGroup: [''],
            ServiceLine: [''],
            ServiceNetwork: [''],
        })
    }

    GetFieldOfStudyFormGroup() {
        return this.formBuilder.group({
            FieldOfStudy: [''],
            FieldOfStudyCredit: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetPrerequisiteCourseIDFormGroup() {
        return this.formBuilder.group({
            PrerequisiteCourseID: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetEquivalentCourseIDFormGroup() {
        return this.formBuilder.group({
            EquivalentCourseID: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetAudienceTypeFormGroup() {
        return this.formBuilder.group({
            AudienceType: ['', [Validators.pattern(/^[ A-Za-z0-9_@./#&+-]*$/)]],
        });
    }

    GetFOCUSCourseOwnerFormGroup() {
        return this.formBuilder.group({
            CourseOwner: [''],
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

    ngOnInit() {
        this.getDropdownData();
    }

    bindFormData() {
        this.CourseForm.patchValue({
            CourseName: this.CourseData?.CourseName,
            CourseID: this.CourseData?.CourseID,
            DeploymentFiscalYear: this.CourseData?.DeploymentFiscalYear,
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
            FirstDeliveryDate: this.datePipe.transform(this.CourseData?.FirstDeliveryDate, 'yyyy-MM-dd'),
            MaximumAttendeeCount: this.CourseData?.MaximumAttendeeCount,
            MinimumAttendeeCount: this.CourseData?.MinimumAttendeeCount,
            MaximumAttendeeWaitlist: this.CourseData?.MaximumAttendeeWaitlist,
            Collateral: this.CourseData?.Collateral,
            RoomSetUpComments: this.CourseData?.RoomSetUpComments,
            DeploymentFacilitatorConsideration: this.CourseData?.DeploymentFacilitatorConsideration,
            LDIntakeOwner: this.CourseData?.LDIntakeOwner,
            ProjectManagerContact: this.CourseData?.ProjectManagerContact,
            InstructionalDesigner: this.CourseData?.InstructionalDesigner,
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

        });
        if (this.FieldOfStudyFormGroup.length == 1 && this.CourseData.FieldOfStudyFormGroup.length) {
            this.FieldOfStudyFormGroup.clear();
        }

        for (let item of this.CourseData?.FieldOfStudyFormGroup) {
            this.FieldOfStudyFormGroup.push(this.formBuilder.group(item));
        }

        if (this.SGSLSNFormGroups.length == 1 && this.CourseData.SGSLSNFormGroups.length) {
            this.SGSLSNFormGroups.clear();
        }
        for (let item of this.CourseData?.SGSLSNFormGroups) {
            this.SGSLSNFormGroups.push(this.formBuilder.group(item));
        }

        if (this.PrerequisiteCourseIDFormGroup.length == 1 && this.CourseData.PrerequisiteCourseIDFormGroup.length) {
            this.PrerequisiteCourseIDFormGroup.clear();
        }
        for (let item of this.CourseData?.PrerequisiteCourseIDFormGroup) {
            this.PrerequisiteCourseIDFormGroup.push(this.formBuilder.group(item));
        }

        if (this.EquivalentCourseIDFormGroup.length == 1 && this.CourseData.EquivalentCourseIDFormGroup.length) {
            this.EquivalentCourseIDFormGroup.clear();
        }
        for (let item of this.CourseData?.EquivalentCourseIDFormGroup) {
            this.EquivalentCourseIDFormGroup.push(this.formBuilder.group(item));
        }

        if (this.AudienceTypeFormGroup.length == 1 && this.CourseData.AudienceTypeFormGroup.length) {
            this.AudienceTypeFormGroup.clear();
        }
        for (let item of this.CourseData?.AudienceTypeFormGroup) {
            this.AudienceTypeFormGroup.push(this.formBuilder.group(item));
        }

        if (this.FOCUSCourseOwnerFormGroup.length == 1 && this.CourseData.FOCUSCourseOwnerFormGroup.length) {
            this.FOCUSCourseOwnerFormGroup.clear();
        }
        for (let item of this.CourseData?.FOCUSCourseOwnerFormGroup) {
            this.FOCUSCourseOwnerFormGroup.push(this.formBuilder.group(this.formBuilder.group({
                CourseOwner: [item],
            })));
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
                debugger
            }
            this.getCourseDataForEdit();
        });
    }

    BindCourseDataForSaveEdit() {
        var CourseData: any = this.CourseForm.value;
        let saveCourse: any = {};
        saveCourse.CourseMasterID = this.URLParamCourseId;
        saveCourse.CompetencyMasterID = this.GetSingleDropdownDataForSave(CourseData.CompetencyMasterID);
        saveCourse.LevelofEffortMasterId = this.GetSingleDropdownDataForSave(CourseData.LevelofEffortMasterId);
        saveCourse.ProgramKnowledgeLevelMasterID = this.GetSingleDropdownDataForSave(CourseData.ProgramKnowledgeLevelMasterID);
        saveCourse.IsRegulatoryOrLegalRequirement = this.GetSingleDropdownDataForSave(CourseData.IsRegulatoryOrLegalRequirement);
        saveCourse.MaterialMasterID = this.GetSingleDropdownDataForSave(CourseData.MaterialMasterID);
        saveCourse.ProgramTypeID = this.GetSingleDropdownDataForSave(CourseData.ProgramTypeID);
        saveCourse.DeliveryTypeID = this.GetSingleDropdownDataForSave(CourseData.DeliveryTypeID);


        saveCourse.SkillMasterIDs = CourseData.SkillMasterIDs;
        saveCourse.Industries = CourseData.Industries;
        saveCourse.AudienceLevels = CourseData.AudienceLevels;
        saveCourse.FunctionMasterIDs = CourseData.FunctionMasterIDs;
        saveCourse.FieldOfStudyFormGroup = CourseData.FieldOfStudyFormGroup;
        saveCourse.SGSLSNFormGroups = CourseData.SGSLSNFormGroups;
        saveCourse.PrerequisiteCourseIDFormGroup = CourseData.PrerequisiteCourseIDFormGroup
        saveCourse.EquivalentCourseIDFormGroup = CourseData.EquivalentCourseIDFormGroup
        saveCourse.AudienceTypeFormGroup = CourseData.AudienceTypeFormGroup
        saveCourse.FOCUSCourseOwnerFormGroup = CourseData.FOCUSCourseOwnerFormGroup

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
        return value?.Id
    }

    GetAlphaNumaricDataForSave(value: any) {
        let arrayList: any = [];
        value.forEach((x: any) => {
            arrayList.push(x.FOCUSCourseOwner);
        });
        return arrayList;
    }

    GetMultiSelectDropdownDataForSave(value: any) {
        let ValueIds = [];
        if (Array.isArray(value)) {

        }
    }


    onSubmitCourse() {
        this.IsSubmit = true;
        var SaveData = this.BindCourseDataForSaveEdit();
        if (!this.CourseForm.invalid) {
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

    ValidatesgslsnFormControl(validate: boolean) {
        debugger
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

}
