import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Table } from 'primeng/table';
import { Course } from 'src/app/domain/Course';
import { CoursePermission } from 'src/app/domain/user';
import { CourseService } from 'src/app/service/course.service';
import { DownloadExcelService } from 'src/app/service/service/download-excel.service';
import { UserService } from 'src/app/service/userservice';
import { environment } from 'src/environments/environment';
import * as XLSX from 'xlsx';

import { DatePipe } from '@angular/common';


declare var bootbox: any;

interface Column {
    field: string;
    header: string;
}
@Component({
    selector: 'app-course-list',
    templateUrl: './course-list.component.html',
    styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {
    @ViewChild('dt1') dt1!: Table;
    CourseData: any = [];
    CourseList: any = [];
    statuses: any = [];
    loading: boolean = false;
    activityValues: number[] = [0, 100];
    hasPermission: CoursePermission;
    selectedCourseIds: string[] = [];
    selectAll: boolean = false;

    constructor(
        public service: CourseService,
        private route: ActivatedRoute,
        private router: Router,
        private downloadExcelService: DownloadExcelService,

        private userservice: UserService,
        private http: HttpClient,
        private datePipe: DatePipe
    ) {
        this.hasPermission = new CoursePermission();
    }

    ngOnInit(): void {
        this.hasPermission = this.userservice.GetUserPermission();
        this.GetAllCourse()
        this.GetCourseList()
        this.ExcelOfFilter()
    }

    @Input() get selectedColumns(): any[] {
        return this._selectedColumns;
    }
    cols!: Column[];

    _selectedColumns!: Column[];
    set selectedColumns(val: any[]) {
        //restore original order
        this._selectedColumns = this.cols.filter((col) => val.includes(col));
    }

    GetCourseList() {
        this.loading = true;
        return this.downloadExcelService.getAllCourseList().subscribe((data: any) => {
            this.loading = false;
            if (data.Success) {
                this.CourseData = data.Data;
            }
        });

    }
    ExcelOfFilter() {
        this.http.get<any[]>(environment.baseUrl + 'GetCourseList/CourseList/').subscribe(data => {
            this.CourseList = data
        });
    }
    GetAllCourse() {
        this.loading = true;
        return this.service.getAllCourses().subscribe((data: any) => {
            console.log(data)
            this.loading = false;
            if (data.Success) {
                this.CourseData = data.Data;
            }
        });
    }

    clear(table: Table) {
        table.clear();
    }

    EditCourse(CourseId: any) {
        console.log("Edit ", CourseId)
        this.router.navigate(['/course-details', { id: CourseId }]);
        this.service.setSaveButtonDisabled(false);
    }

    ViewCourse(CourseId: any) {
        this.router.navigate(['/course-details', { id: CourseId }]);
        this.service.setSaveButtonDisabled(true);
    }

    DeleteCourse(CourseId: any) {
        bootbox.confirm('Are you sure you want to delete Course?', (result: boolean) => {
            if (result) {
                return this.service.deleteCourse(CourseId).subscribe((data: any) => {
                    if (data != null) {
                        bootbox.alert('Course deleted successfully');

                    } else {
                        bootbox.alert('Deletion not successful');
                    }
                    this.ngOnInit();
                });
            }
            return;
        });
    }

    AddCourse() {
        this.router.navigate(['/course-details'])
        this.service.setSaveButtonDisabled(false);
    }

    DownloadExcelForAllCourse() {
        this.downloadExcelService.getAllCoursesForDataOfDeployment().subscribe((data: any) => {
            if (data) {
                var courseData: any = data;
                const headers = Object.keys(courseData[0]).slice(0, 55);//56 col
                const columnTitles = [
                    'Course Name', 'Course ID', 'Deployment Fiscal Year', 'Competency', 'Skill', 'Industry', 'Program Knowledge Level',
                    'Status',
                    'Course Overview & Objective', 'Target Audience', 'Audience Level', 'Development Year',
                    'SG/SL/SN Values', 'FOS values', 'Estimated CPE', 'Prerequisite Course ID', 'Equivalent Course ID',
                    'Special Notice', 'Function Name', 'Audience Type', 'Course Sponsor', 'Which SG/SL/SNSponsor Learning ', 'Subject Matter Professional', 'Vendor', 'ServiceNowID', 'Descriptions', 'Is Regulatoryor Legal Requirement', 'Program Type', 'Delivery Type', 'Duration', 'First Delivery Date', 'Maximum Attendee Count', 'Minimum Attendee Count', 'Maximum Attendee Waitlist', 'Material', 'Collateral', 'Level Of Effort', 'Room Set Up Comments', 'Deployment Facilitator Consideration', 'L&D Intake Owner',
                    'Project Manager ', 'Instructional Designer ', 'Course Owner 1', ' Course Owner 2',
                    'Price', 'Currency', 'Display Call Center', 'OFFERING_TEMPLATE_NO', 'Is RecordLocked', 'Clarizen Start Date',
                    'Course Record URL', 'Focus Domain', 'Focus Retired', 'Focus Disc From', 'Focus Displayed To Learner',]


                const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
                excelData.unshift(columnTitles);
                function generateRandom(maxLimit = 100) {
                    let rand = Math.random() * maxLimit;

                    rand = Math.floor(rand);

                    return rand;
                }
                generateRandom();
                const random = (generateRandom());
                const currentDate = new Date();
                const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
                const fileName = 'All_Course_Records_' + myDate + '_' + random + '.xlsx';
                const worksheetName = 'Data All_Course_Records_ Field';
                const worksheet = XLSX.utils.aoa_to_sheet([...excelData]);

                // Set the color to blue
                const headerCellStyle = {
                    fill: { patternType: 'solid', fgColor: { theme: 8, tint: -0.25 } },
                    font: { bold: true },
                    alignment: { horizontal: 'center', wrapText: true },
                };
                Object.keys(worksheet).forEach((cell) => {
                    if (cell.startsWith('A1:') && cell.endsWith('1')) {
                        worksheet[cell].s = headerCellStyle;
                    }
                });

                // Set column widths
                const columnWidths = headers.map(() => ({ width: 35 }));
                worksheet['!cols'] = columnWidths;
                const workbook = XLSX.utils.book_new();
                XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
                XLSX.writeFile(workbook, fileName);
            }
            this.selectedCourseIds = []
            this.selectAll = false
        });
    }

    toggleCourseSelection(courseId: string) {
        if (this.isCourseSelected(courseId)) {
            this.selectedCourseIds = this.selectedCourseIds.filter(id => id !== courseId);
        } else {
            this.selectedCourseIds.push(courseId);
        }
    }

    toggleSelectAll() {
        if (this.selectAll) {

            this.selectedCourseIds = this.CourseList.map((course: { CourseMasterID: any; }) => course.CourseMasterID);
        } else {

            this.selectedCourseIds = [];
        }
    }

    isCourseSelected(courseId: string): boolean {
        return this.selectedCourseIds.includes(courseId);
    }

    cancelSelection() {
        this.selectedCourseIds = [];
        this.selectAll = false;
    }

    DownloadExcelForFocus() {
        if (this.selectedCourseIds.length !== 0) {
            if (this.selectedCourseIds.length > 450) {
                bootbox.alert({
                    size: "heigh",
                    message: "Please select a maximum of 450 records for download.",
                    closeButton: false,
                    className: 'center-alert-box',
                    centerVertical: true,
                });
                return;
            }

            this.downloadExcelService.getAllCoursesForDataOfFocus(this.selectedCourseIds).subscribe((data: any) => {
                console.log(data)
                var courseData: any = data;
                const headers1 = Object.keys(courseData[0]).slice(0, 46);
                const headers2 = Object.keys(courseData[0]).slice(0, 46);

                // Custom titles for each column
                const columnTitles1 = ['ID', 'OFFERING_TEMPLATE_NO', 'VERSION', 'TITLE', 'DOMAIN',
                    'AVAIL_FROM', 'DISC_FROM', 'CURRENCY', 'PRICE', 'DESCRIPTION', 'DISPLAY_LEARNER',
                    'DISPLAY_CALL_CENTER', ' AUDIENCE_TYPE1', 'AUDIENCE_TYPE2', 'VENDOR', 'CUSTOM0',
                    'CUSTOM1', 'CUSTOM2', 'CUSTOM3', 'CUSTOM5', ' CUSTOM8', 'OWNER1', 'Owner two',
                    'PREREQUISITE1', 'PREREQUISITE_VERSION1', 'PREREQUISITE2', 'PREREQUISITE_VERSION2',
                    'EQUIVALENT1', 'EQUIVALENT_VERSION1', 'EQUIVALENT2', 'EQUIVALENT_VERSION2', 'DELIVERY_TYPE1',
                    'DT_DURATION1', 'FIELD_OF_STUDY1', 'FOS_DEFAULT_CREDITS1', 'FIELD_OF_STUDY2',
                    'FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3', 'FOS_DEFAULT_CREDITS3', 'FIELD_OF_STUDY4',
                    'FOS_DEFAULT_CREDITS4', 'MIN_CT', 'MAX_CT', 'MAX_CT', 'FocusTemplateName'];

                const columnTitles2 = ['ID', 'OFFERING_TEMPLATE_NO', 'VERSION', 'TITLE', 'DOMAIN',
                    'AVAIL_FROM', 'DISC_FROM', 'CURRENCY', 'PRICE', 'DESCRIPTION', 'DISPLAY_LEARNER',
                    'DISPLAY_CALL_CENTER', ' AUDIENCE_TYPE1', 'AUDIENCE_TYPE2', 'VENDOR', 'CUSTOM0',
                    'CUSTOM1', 'CUSTOM2', 'CUSTOM3', 'CUSTOM5', ' CUSTOM8', 'OWNER1', 'Owner two',
                    'PREREQUISITE1', 'PREREQUISITE_VERSION1', 'PREREQUISITE2', 'PREREQUISITE_VERSION2',
                    'EQUIVALENT1', 'EQUIVALENT_VERSION1', 'EQUIVALENT2', 'EQUIVALENT_VERSION2', 'DELIVERY_TYPE1',
                    'DT_DURATION1', 'FIELD_OF_STUDY1', 'FOS_DEFAULT_CREDITS1', 'FIELD_OF_STUDY2',
                    'FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3', 'FOS_DEFAULT_CREDITS3', 'FIELD_OF_STUDY4',
                    'FOS_DEFAULT_CREDITS4', 'MIN_CT', 'MAX_CT', 'MAX_CT', 'FocusTemplateName', 'Error Message'];
                const excelDataWithErrorMessageNull = [];
                const excelDataWithErrorMessageNotNull = [];

                for (let i = 0; i < courseData.length; i++) {
                    const ErrorMessage = courseData[i]['ErrorMessage'];
                    const rowData = headers2.map((key, index) => columnTitles2[index] ? courseData[i][key] : '');

                    if (ErrorMessage === null || ErrorMessage.trim() === '') {
                        excelDataWithErrorMessageNull.push(rowData);
                    } else {
                        excelDataWithErrorMessageNotNull.push(rowData);
                    }
                }
                function generateRandom(maxLimit = 99) {
                    let rand = Math.random() * maxLimit;

                    rand = Math.floor(rand); // 99

                    return rand;
                }
                const random = (generateRandom());
                const currentDate = new Date();
                const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
                const worksheetName1 = ' Focus Field ';
                const worksheetName2 = 'Focus Field Error  ';
                const fileName1 = 'Focus_Records_' + myDate + '_' + random + '.xlsx';
                const fileName2 = 'Focus_ErrorRecords_' + myDate + '_' + random + '.xlsx';
                const worksheet1 = XLSX.utils.aoa_to_sheet([columnTitles1, ...excelDataWithErrorMessageNull]);
                const worksheet2 = XLSX.utils.aoa_to_sheet([columnTitles2, ...excelDataWithErrorMessageNotNull]);

                // Set column widths
                const columnWidths1 = headers1.map(() => ({ width: 40 }));
                const columnWidths2 = headers2.map(() => ({ width: 40 }));
                worksheet1['!cols'] = columnWidths1;
                worksheet2['!cols'] = columnWidths2;
                const confirmMessage = `<br>` +
                    `Success Records Count: ${excelDataWithErrorMessageNull.length}<br><br>` +
                    `Error Records Count: ${excelDataWithErrorMessageNotNull.length}`;

                bootbox.alert({

                    size: "heigh",
                    title: "Export RDI for Focus -  File Download is in Progress",
                    message: confirmMessage,
                    closeButton: false,
                    centerVertical: true,
                    callback: () => {
                        if (excelDataWithErrorMessageNull.length > 0) {
                            const workbook1 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook1, worksheet1, worksheetName1);
                            try {
                                XLSX.writeFile(workbook1, fileName1);
                            } catch (error) {
                                bootbox.alert({
                                    size: "heigh",
                                    message: ("Max character limit exceeds. Please select only 100 records."),
                                    closeButton: false,
                                    className: 'center-alert-box',
                                    centerVertical: true,
                                })
                                return;
                            }
                            this.selectedCourseIds = [];
                        }

                        if (excelDataWithErrorMessageNotNull.length > 0) {
                            const workbook2 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook2, worksheet2, worksheetName2);
                            try {
                                XLSX.writeFile(workbook2, fileName2);
                            } catch (error) {

                                bootbox.alert({
                                    size: "heigh",
                                    message: ("Max character limit exceeds. Please select only 100 records. "),
                                    closeButton: false,
                                    className: 'center-alert-box',
                                    centerVertical: true,
                                });
                                return;
                            }
                            this.selectedCourseIds = [];
                        }

                        this.selectedCourseIds = [];
                        this.selectAll = false;
                    }
                })
            });
        }
        else {

            bootbox.alert({
                size: "heigh",
                message: "Please Select At Least One Record.",
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
        }
    }

    DownloadExcelForClarize() {
        if (this.selectedCourseIds.length !== 0) {
            if (this.selectedCourseIds.length > 450) {
                bootbox.alert({
                    size: "heigh",
                    message: "Please select a maximum of 450 records for download.",
                    closeButton: false,
                    className: 'center-alert-box',
                    centerVertical: true,
                });
                return;
            }


            this.downloadExcelService.getAllCoursesForClarizen(this.selectedCourseIds).subscribe((data: any) => {
                console.log(data)
                var courseData: any = data;
                const headers1 = Object.keys(courseData[0]).slice(0, 19);
                const headers2 = Object.keys(courseData[0]).slice(0, 19);

                // Custom titles for each column
                const columnTitles1 = ['Name', 'L&D Intake Owner', 'Owner',
                    'Course Sponser', ' Description', 'Instructional Designer(s)', 'Lead SMP', 'Program Type',
                    'Delivery Type (Single Pick)', 'CPE Credits', 'Course #',
                    'First Delivery Date', 'Deployment Fiscal Year', 'Level Of Effort',
                    'Start Date', 'S2 URL', 'Project Type', 'FromTemplate:'];

                const columnTitles2 = ['Name', 'L&D Intake Owner', 'Owner',
                    'Course Sponser', ' Description', 'Instructional Designer(s)', 'Lead SMP', 'Program Type',
                    'Delivery Type (Single Pick)', 'CPE Credits', 'Course #',
                    'First Delivery Date', 'Deployment Fiscal Year', 'Level Of Effort', 'Start Date'
                    , 'S2 URL', 'Project Type', 'FromTemplate:', 'Error Message'];

                const excelDataWithErrorMessageNull = [];
                const excelDataWithErrorMessageNotNull = [];

                for (let i = 0; i < courseData.length; i++) {
                    const ErrorMessage = courseData[i]['ErrorMessage'];
                    const rowData = headers2.map((key, index) => columnTitles2[index] ? courseData[i][key] : '');

                    if (ErrorMessage === null || ErrorMessage.trim() === '') {
                        excelDataWithErrorMessageNull.push(rowData);
                    } else {
                        excelDataWithErrorMessageNotNull.push(rowData);
                    }
                }

                function generateRandom(maxLimit = 100) {
                    let rand = Math.random() * maxLimit;
                    rand = Math.floor(rand);
                    return rand;
                }
                const random = (generateRandom());
                const currentDate = new Date();
                const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');

                const worksheetName1 = ' Clarizen Field ';
                const worksheetName2 = 'Clarizen Field Error  ';
                const fileName1 = 'Clarizen_Records_' + myDate + '_' + random + '.xlsx';
                const fileName2 = 'Clarizen_ErrorRecords_' + myDate + '_' + random + '.xlsx';

                const worksheet1 = XLSX.utils.aoa_to_sheet([columnTitles1, ...excelDataWithErrorMessageNull]);
                const worksheet2 = XLSX.utils.aoa_to_sheet([columnTitles2, ...excelDataWithErrorMessageNotNull]);

                // Set column widths
                const columnWidths1 = headers1.map(() => ({ width: 40 }));
                const columnWidths2 = headers2.map(() => ({ width: 40 }));
                worksheet1['!cols'] = columnWidths1;
                worksheet2['!cols'] = columnWidths2;

                const confirmMessage = `<br><br>` +
                    `Success Records Count: ${excelDataWithErrorMessageNull.length}<br><br>` +
                    `Error Records Count: ${excelDataWithErrorMessageNotNull.length}`;
                bootbox.alert({
                    size: "heigh",
                    title: "Export RDI for Clarizen -  File Download is in Progress.",
                    message: confirmMessage,
                    closeButton: false,
                    className: 'center-alert-box',
                    centerVertical: true,
                    callback: () => {
                        if (excelDataWithErrorMessageNull.length > 0) {
                            const workbook1 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook1, worksheet1, worksheetName1);
                            try {
                                XLSX.writeFile(workbook1, fileName1);
                            } catch (error) {

                                bootbox.alert({
                                    size: "heigh",
                                    message: ("Max character limit exceeds. Please select only 100 records."),
                                    closeButton: false,
                                    className: 'center-alert-box',
                                    centerVertical: true,
                                })
                                return;
                            }
                            this.selectedCourseIds = [];
                        }

                        if (excelDataWithErrorMessageNotNull.length > 0) {
                            const workbook2 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook2, worksheet2, worksheetName2);
                            try {
                                XLSX.writeFile(workbook2, fileName2);
                            } catch (error) {

                                bootbox.alert({
                                    size: "heigh",
                                    message: ("Max character limit exceeds. Please select only 100 records."),
                                    closeButton: false,
                                    className: 'center-alert-box',
                                    centerVertical: true,
                                });
                                return;
                            }
                            this.selectedCourseIds = [];
                        }

                        this.selectedCourseIds = [];
                        this.selectAll = false;
                    }
                })
            });
            return;
        }
        else {

            bootbox.alert({
                size: "heigh",
                message: "Please Select At Least One Record.",
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
        }

    }

    UnlockCourse() {
        if (this.selectedCourseIds.length !== 0) {
            this.downloadExcelService.getUnlockAllCourses(this.selectedCourseIds).subscribe((data: any) => {
                bootbox.alert({
                    size: "heigh",
                    message: "Record/s are unlocked.",
                    closeButton: false,
                    className: 'center-alert-box',
                    centerVertical: true,
                });

            });
            return;
        }
        else {
            bootbox.alert({
                size: "heigh",
                message: "Please Select At Least One Record.",
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
        }

    }

    DownloadExcelForFilter() {
        const filteredData = this.dt1.filteredValue;
        if (filteredData) {
            var courseData: any = filteredData;
            const columnIndices = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21];
            const columnTitles = ['Course ID', 'Course Name', 'Target Audience', 'First Delivery Date',
                'FOS ',

                'Estimated CPE', 'Skill', 'Program Type', 'Delivery Type', 'L&D Intake Owner ', 'Program Knowledge Level',
                'Instructional Designer', 'Project Manager ', 'Competency', 'Industry', 'Course Sponsor',
                'Vendor (s)', 'Service Now ID', 'SG/SN/SL Sponsor', 'Focus Domain', 'Duration', 'Status'];
            const headers = columnIndices.map(index => columnTitles[index]);
            const excelData = courseData.map((obj: any) => columnIndices.map(index => obj[Object.keys(obj)[index]]));

            function generateRandom(maxLimit = 100) {
                let rand = Math.random() * maxLimit;
                console.log(rand);

                rand = Math.floor(rand);

                return rand;
            }
            generateRandom();
            console.log(generateRandom());
            const random = (generateRandom());
            const currentDate = new Date();
            const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
            const fileName = 'Filter_Records_' + myDate + '_' + random + '.xlsx';

            const worksheetName = 'Data Of Filter Field';
            const worksheet = XLSX.utils.aoa_to_sheet([headers, ...excelData]);

            // Set column widths
            const columnWidths = headers.map(() => ({ width: 30 }));
            worksheet['!cols'] = columnWidths;

            const workbook = XLSX.utils.book_new();
            XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
            XLSX.writeFile(workbook, fileName);
        }
        this.selectedCourseIds = []
        this.selectAll = false
        // this.clear(this.dt1);
    }
}


