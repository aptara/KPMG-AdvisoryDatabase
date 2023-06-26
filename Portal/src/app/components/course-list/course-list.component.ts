import { Component, OnInit, ViewChild } from '@angular/core';
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
import { filter } from 'rxjs';
import { DatePipe } from '@angular/common';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';


declare var bootbox: any;

declare var bootbox: any;
@Component({
    selector: 'app-course-list',
    templateUrl: './course-list.component.html',
    styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {
    CourseData: any = [];
    statuses: any = [];
    loading: boolean = false;
    activityValues: number[] = [0, 100];
    hasPermission: CoursePermission;

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

        this.ExcelOfClarizen()
        //this.ExcelOfFocus()
        //this.ExcelOfDeployment()
    }

    GetAllCourse() {
        this.loading = true;
        return this.service.getAllCourses().subscribe((data: any) => {
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
    }

    ViewCourse(CourseId: any) {
        this.router.navigate(['/course-details', { id: CourseId }]);
    }

    DeleteCourse(CourseId: any) {


        bootbox.confirm('Are you sure you want to delete Course?', (result: boolean) => {
            if (result) {
                return this.service.deleteCourse(CourseId).subscribe((data: any) => {
                    if (data != null) {
                        bootbox.alert('Course deleted successfully');
                        this.GetAllCourse();
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
    }



    downloadExcelofDeployment() {
        this.downloadExcelService.getAllCoursesForDataOfDeployment().subscribe((data: any) => {
            if (data) {
                var courseData: any = data;
                const headers = Object.keys(courseData[0]).slice(1, 21);
                const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
                function generateRandom(maxLimit = 100) {
                    let rand = Math.random() * maxLimit;
                    console.log(rand); // say 99.81321410836433

                    rand = Math.floor(rand); // 99

                    return rand;
                }
                generateRandom(); // 43
                //generateRandom(500); // 165

                console.log(generateRandom());
                const random = (generateRandom());
                const currentDate = new Date();
                const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
                const fileName = 'Deployment_Records_' + myDate + '_' + random + '.xlsx';

                const worksheetName = 'Data Of Deployment Field';
                //const fileName = 'Excel For Deployment Fields.xlsx';

                const worksheet = XLSX.utils.aoa_to_sheet([headers, ...excelData]);

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
                const columnWidths = headers.map(() => ({ width: 24 }));
                worksheet['!cols'] = columnWidths;


                const workbook = XLSX.utils.book_new();
                XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
                XLSX.writeFile(workbook, fileName);
            }
            this.selectedCourseIds = []
            this.selectAll = false
        });
    }

    dataf: any;
    datac: any;
    selectedCourseIds: string[] = [];


    //excel for focus
    // ExcelOfFocus() {
    //     this.http.get<any[]>(environment.baseUrl + 'GetExcelForFocus/ShowDataoffocus').subscribe(data => {

    //         this.dataf = data;

    //     });
    // }
    getHeaders() {
        const headers = Object.keys(this.dataf[0]).slice(1, 34); //1,28

        return headers;
    }
    downloadExceloffocus() {
        if (!this.dataf || this.selectedCourseIds.length === 0) {
            return;
        }
        const selectedData = this.dataf.filter((obj: any) => this.selectedCourseIds.includes(obj['CourseMasterID']));


        // use for filter data on status base

        //const filteredData = this.data.filter((obj: { Status: string; }) => obj.Status === 'Project Initiated' || obj.Status === 'Course Updated');

        // const filteredData = selectedData.filter((obj: { Status: string; }) => obj.Status === 'Project Initiated' || obj.Status === 'Course Updated');

        // const invalidStatusData = selectedData.filter((obj: any) => !filteredData.includes(obj));
        // const invalidStatusCourseIds = invalidStatusData.map((obj: any) => `${obj.CourseName}`);

        // if (invalidStatusCourseIds.length > 0) {
        //     const errorMessage = 'Invalid status for the following Course:- ' + invalidStatusCourseIds.join(', ');
        //     bootbox.alert(errorMessage);
        //     return;
        // }

        const headers = this.getHeaders();


        //  For not accpect any null values for all columns in selected records

        // const nullFieldCourses = selectedData
        //     .filter((obj: any) => headers.some(key => obj[key] === null))
        //     .map((obj: any) => obj.CourseName);

        // if (nullFieldCourses.length > 0) {
        //     const errorMessage = 'The following courses have null fields:- ' + nullFieldCourses.join(', ');
        //     bootbox.alert(errorMessage);
        //     return;
        // }

        // For not accpect any null values but ignore below list of columns which is null
        // const columnTitle = ['DESCRIPTION'];

        // const nullFieldCourses = selectedData
        //     .filter((obj: any) => headers.some(key => obj[key] === null && columnTitle.includes(key)))
        //     .map((obj: any) => obj.CourseName);

        // if (nullFieldCourses.length > 0) {
        //     const errorMessage = 'The following courses have null fields: ' + nullFieldCourses.join(', ');
        //     bootbox.alert(errorMessage);
        //     return;
        // }


        const columnTitles = ['Title', 'FIELD_OF_STUDY1/FOS_DEFAULT_CREDITS1',
            'FIELD_OF_STUDY2/FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3/FOS_DEFAULT_CREDITS3',
            'FIELD_OF_STUDY4/FOS_DEFAULT_CREDITS4',
            'PREREQUISITE1', 'PREREQUISITE2', 'EQUIVALENT1', 'EQUIVALENT2', 'DELIVERY_TYPE1',
            'CUSTOM3', 'OFFERING_TEMPLATE_NO', ' DESCRIPTION', 'MAX_CT', 'MIN_CT', 'WAITLIST_MAX', 'Ower1', 'Ower2',
            'AVAIL_FORM', 'DT_DURATION1', ' Domain', 'DISC_FORM', 'DISPLAY_LEARNER', 'CUSTOM0', 'CUSTOM1', 'PRICE', 'CURRENCY',
            'DISPLAY_CALL_CENTER', 'AUDIENCE_TYPE1', 'AUDIENCE_TYPE2',

            'CUSTOM2', 'CUSTOM5', 'CUSTOM8'];

        // const data = this.data.map((obj: any) => headers.map(key => obj[key]));
        // const data = filteredData.map((obj: any) => headers.map((key, index) => {
        const data = selectedData.map((obj: any) => headers.map((key, index) => {
            //const data = this.data.map((obj: any) => headers.map((key, index) => {
            const columnTitle = columnTitles[index] || key;
            return { columnTitle, value: obj[key] };
        }));
        const worksheetName = 'Data Of Focus Fields';
        const fileName = 'Excel of Focus Fields.xlsx';
        const worksheetData = [columnTitles, ...data.map((obj: any[]) => obj.map(item => item.value))];
        const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
        //const worksheet = XLSX.utils.aoa_to_sheet([headers, ...data]);

        // Set column widths
        const columnWidths = headers.map(() => ({ width: 23 }));
        worksheet['!cols'] = columnWidths;
        const workbook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
        XLSX.writeFile(workbook, fileName);


        // to uncheck box
        try {
            XLSX.writeFile(workbook, fileName);
            this.selectedCourseIds = []; // Uncheck all checkboxes on successful download
        } catch (error) {
            console.error('Error downloading the file:', error);
            this.selectedCourseIds = []; // Uncheck all checkboxes on error
        }
    }


    //excel for Clarizen

    ExcelOfClarizen() {
        this.http.get<any[]>(environment.baseUrl + 'GETExcelForClarizenFields/ShowDataofclarizen').subscribe(data2 => {

            //this.datac = [];
            this.datac = data2

        });
    }
    getHeaders2() {
        const headers = Object.keys(this.datac[0]).slice(1, 17);
        // console.log('headers:', headers);
        return headers;
    }
    downloadExcelofClarizen() {
        if (!this.datac || this.selectedCourseIds.length === 0) {
            return;
        }

        const selectedData = this.datac.filter((obj: any) => this.selectedCourseIds.includes(obj['CourseMasterID']));

        // const filteredData = selectedData.filter((obj: { Status: string; }) => obj.Status === 'Focus Course Created' || obj.Status === 'Course Updated');

        // const invalidStatusData = selectedData.filter((obj: any) => !filteredData.includes(obj));
        // const invalidStatusCourseIds = invalidStatusData.map((obj: any) => `${obj.CourseName}`);

        // if (invalidStatusCourseIds.length > 0) {
        //     const errorMessage = 'Invalid status for the following Course:- ' + invalidStatusCourseIds.join(', ');
        //     bootbox.alert(errorMessage);
        //     return;
        // }

        const headers = this.getHeaders2();

        // For not accpect null values with show coursename
        // const nullFieldCourses = filteredData
        //     .filter((obj: any) => headers.some(key => obj[key] === null))
        //     .map((obj: any) => obj.CourseName);

        // if (nullFieldCourses.length > 0) {
        //     const errorMessage = 'The following courses have null fields:- ' + nullFieldCourses.join(', ');
        //     bootbox.alert(errorMessage);
        //     return;
        // }


        // for set title
        const columnTitles = ['Name', 'Business Relationship Director', 'Owner',
            'Course Sponser', ' Description', 'InstructionalDesigner', 'Lead SMP', 'ProgramType',
            'Delivery  Type(Single Pick)', 'CPE creadits', 'Course #',
            'First Delivery Date', 'Deployment Fiscal Year', 'Level of Effort', 'Course Duration?', 'Start Date'];


        const Datam = selectedData.map((obj: any) => headers.map((key, index) => {
            const columnTitle = columnTitles[index] || key;
            return { columnTitle, value: obj[key] };
        }));
        const worksheetData = [columnTitles, ...Datam.map((obj: any[]) => obj.map(item => item.value))];


        //here end


        const worksheetName = 'Data Of Clarizen Fields';
        const fileName = 'Excel For Clarizen Fields.xlsx';
        //  const worksheet = XLSX.utils.aoa_to_sheet([headers, ...data]);
        const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
        const columnWidths = headers.map(() => ({ width: 26 }));
        worksheet['!cols'] = columnWidths;
        const workbook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
        XLSX.writeFile(workbook, fileName);

        // to uncheck box
        try {
            XLSX.writeFile(workbook, fileName);
            this.selectedCourseIds = []; // Uncheck all checkboxes on successful download
        } catch (error) {
            console.error('Error downloading the file:', error);
            this.selectedCourseIds = []; // Uncheck all checkboxes on error
        }

    }


    selectAll: boolean = false;

    toggleCourseSelection(courseId: string) {
        if (this.isCourseSelected(courseId)) {
            this.selectedCourseIds = this.selectedCourseIds.filter(id => id !== courseId);
        } else {
            this.selectedCourseIds.push(courseId);
        }
    }
    toggleSelectAll() {
        if (this.selectAll) {
            // Add all course IDs to the selectedCourseIds array
            this.selectedCourseIds = this.CourseData.map((course: { CourseMasterID: any; }) => course.CourseMasterID);
        } else {
            // Clear the selectedCourseIds array to unselect all checkboxes
            this.selectedCourseIds = [];
        }
    }


    isCourseSelected(courseId: string): boolean {
        return this.selectedCourseIds.includes(courseId);
    }

    cancelSelection() {
        this.selectedCourseIds = []; // Clear the selectedCourseIds array to unselect all checkboxes
        this.selectAll = false; // Uncheck the "Select All" checkbox
    }
    downloadExceloffocusN() {
        if (this.selectedCourseIds.length !== 0) {
            this.downloadExcelService.getAllCoursesForDataOfFocus(this.selectedCourseIds).subscribe((data: any) => {
                console.log(data)
                var courseData: any = data;
                const headers1 = Object.keys(courseData[0]).slice(0, 35); // First 10 columns
                const headers2 = Object.keys(courseData[0]).slice(0, 36); // First 15 columns

                // Custom titles for each column
                const columnTitles1 = ['Title', 'FIELD_OF_STUDY1/FOS_DEFAULT_CREDITS1',
                    'FIELD_OF_STUDY2/FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3/FOS_DEFAULT_CREDITS3',
                    'FIELD_OF_STUDY4/FOS_DEFAULT_CREDITS4',
                    'PREREQUISITE1', 'PREREQUISITE2', 'EQUIVALENT1', 'EQUIVALENT2', 'DELIVERY_TYPE1',
                    'CUSTOM3', 'OFFERING_TEMPLATE_NO', ' DESCRIPTION', 'MAX_CT', 'MIN_CT', 'WAITLIST_MAX', 'Ower1', 'Ower2',
                    'AVAIL_FORM', 'DT_DURATION1', ' Domain', 'DISC_FORM', 'DISPLAY_LEARNER', 'CUSTOM0', 'CUSTOM1', 'PRICE', 'CURRENCY',
                    'DISPLAY_CALL_CENTER', 'AUDIENCE_TYPE1', 'AUDIENCE_TYPE2',

                    'CUSTOM2', 'CUSTOM5', 'CUSTOM8', 'Focus Template Name '];

                const columnTitles2 = ['Title', 'FIELD_OF_STUDY1/FOS_DEFAULT_CREDITS1',
                    'FIELD_OF_STUDY2/FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3/FOS_DEFAULT_CREDITS3',
                    'FIELD_OF_STUDY4/FOS_DEFAULT_CREDITS4',
                    'PREREQUISITE1', 'PREREQUISITE2', 'EQUIVALENT1', 'EQUIVALENT2', 'DELIVERY_TYPE1',
                    'CUSTOM3', 'OFFERING_TEMPLATE_NO', ' DESCRIPTION', 'MAX_CT', 'MIN_CT', 'WAITLIST_MAX', 'Ower1', 'Ower2',
                    'AVAIL_FORM', 'DT_DURATION1', ' Domain', 'DISC_FORM', 'DISPLAY_LEARNER', 'CUSTOM0', 'CUSTOM1', 'PRICE', 'CURRENCY',
                    'DISPLAY_CALL_CENTER', 'AUDIENCE_TYPE1', 'AUDIENCE_TYPE2',

                    'CUSTOM2', 'CUSTOM5', 'CUSTOM8', 'Focus Template Name', 'Error Message'];


                const excelData1 = courseData.map((obj: any) => headers1.map((key, index) => columnTitles1[index] ? obj[key] : ''));
                const excelData2 = courseData.map((obj: any) => headers2.map((key, index) => columnTitles2[index] ? obj[key] : ''));


                const filteredData1 = excelData1.filter((obj: any) => obj[34] == null);
                const filteredData2 = excelData2.filter((obj: any) => obj[34] !== null);


                function generateRandom(maxLimit = 99) {
                    let rand = Math.random() * maxLimit;
                    //console.log(rand); // say 99.81321410836433

                    rand = Math.floor(rand); // 99

                    return rand;
                }
                // generateRandom(); // 43
                //generateRandom(500); // 165

                //console.log(generateRandom());
                const random = (generateRandom());

                const currentDate = new Date();
                const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');

                const worksheetName1 = ' Focus Field ';
                const worksheetName2 = 'Focus Field Error  ';
                const fileName1 = 'Focus_Records_' + myDate + '_' + random + '.xlsx';
                const fileName2 = 'Focus_ErrorRecords_' + myDate + '_' + random + '.xlsx';

                const worksheet1 = XLSX.utils.aoa_to_sheet([columnTitles1, ...filteredData1]);
                const worksheet2 = XLSX.utils.aoa_to_sheet([columnTitles2, ...filteredData2]);

                // Set column widths
                const columnWidths1 = headers1.map(() => ({ width: 40 }));
                const columnWidths2 = headers2.map(() => ({ width: 40 }));
                worksheet1['!cols'] = columnWidths1;
                worksheet2['!cols'] = columnWidths2;


                const confirmMessage = `<br>` +
                    `Success Records Count: ${filteredData1.length}<br><br>` +
                    `Error Records Count: ${filteredData2.length}`;

                bootbox.alert({

                    size: "heigh",
                    title: "Export RDI for Focus -  File Download is in Progress",
                    message: confirmMessage,
                    closeButton: false,
                    centerVertical: true,

                    callback: () => {
                        if (filteredData1.length > 0) {
                            const workbook1 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook1, worksheet1, worksheetName1);
                            XLSX.writeFile(workbook1, fileName1);
                        }
                        if (filteredData2.length > 0) {
                            const workbook2 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook2, worksheet2, worksheetName2);
                            XLSX.writeFile(workbook2, fileName2);
                        }
                        this.selectedCourseIds = []
                        this.selectAll = false
                    }


                })


            });
        }




    }


    downloadExcelofClarizeN() {
        if (this.selectedCourseIds.length !== 0) {
            // No checkboxes are selected, do not proceed with the download
            this.downloadExcelService.getAllCoursesForClarizen(this.selectedCourseIds).subscribe((data: any) => {
                console.log(data)
                var courseData: any = data;
                const headers1 = Object.keys(courseData[0]).slice(0, 20); // First 16 columns
                const headers2 = Object.keys(courseData[0]).slice(0, 19); // First 17 columns

                // Custom titles for each column
                const columnTitles1 = ['Name', 'Business Relationship Director', 'Owner',
                    'Course Sponser', ' Description', 'InstructionalDesigner', 'Lead SMP', 'ProgramType',
                    'Delivery  Type(Single Pick)', 'CPE creadits', 'Course #',
                    'First Delivery Date', 'Deployment Fiscal Year', 'Level of Effort', 'Course Duration?', 'Start Date'];

                const columnTitles2 = ['Name', 'Business Relationship Director', 'Owner',
                    'Course Sponser', ' Description', 'InstructionalDesigner', 'Lead SMP', 'ProgramType',
                    'Delivery  Type(Single Pick)', 'CPE creadits', 'Course #',
                    'First Delivery Date', 'Deployment Fiscal Year', 'Level of Effort', 'Course Duration?', 'Start Date'
                    , 'ErrorMessage'];

                const excelData1 = courseData.map((obj: any) => headers1.map((key, index) => columnTitles1[index] ? obj[key] : ''));
                const excelData2 = courseData.map((obj: any) => headers2.map((key, index) => columnTitles2[index] ? obj[key] : ''));

                const filteredData1 = excelData1.filter((obj: any) => obj[19] == null);
                const filteredData2 = excelData2.filter((obj: any) => obj[19] !== null);


                function generateRandom(maxLimit = 100) {
                    let rand = Math.random() * maxLimit;
                    //console.log(rand); // say 99.81321410836433

                    rand = Math.floor(rand); // 99

                    return rand;
                }
                // generateRandom();

                // console.log(generateRandom());
                const random = (generateRandom());

                const currentDate = new Date();
                const myDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');

                const worksheetName1 = ' Clarizen Field ';
                const worksheetName2 = 'Clarizen Field Error  ';
                const fileName1 = 'Clarizen_Records_' + myDate + '_' + random + '.xlsx';
                const fileName2 = 'Clarizen_ErrorRecords_' + myDate + '_' + random + '.xlsx';


                const worksheet1 = XLSX.utils.aoa_to_sheet([columnTitles1, ...filteredData1]);
                const worksheet2 = XLSX.utils.aoa_to_sheet([columnTitles2, ...filteredData2]);

                // Set column widths
                const columnWidths1 = headers1.map(() => ({ width: 40 }));
                const columnWidths2 = headers2.map(() => ({ width: 40 }));
                worksheet1['!cols'] = columnWidths1;
                worksheet2['!cols'] = columnWidths2;

                const confirmMessage = `<br><br>` +
                    `Success Records Count: ${filteredData1.length}<br><br>` +
                    `Error Records Count: ${filteredData2.length}`;
                bootbox.alert({
                    size: "heigh",
                    title: "Export RDI for Clarizen -  File Download is in Progress.",
                    message: confirmMessage,
                    closeButton: false,
                    className: 'center-alert-box',
                    centerVertical: true,

                    callback: () => {
                        if (filteredData1.length > 0) {
                            const workbook1 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook1, worksheet1, worksheetName1);
                            XLSX.writeFile(workbook1, fileName1);
                        }
                        if (filteredData2.length > 0) {
                            const workbook2 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook2, worksheet2, worksheetName2);
                            XLSX.writeFile(workbook2, fileName2);
                        }
                        this.selectedCourseIds = []
                        this.selectAll = false
                    }
                })


            });
            return;
        }

    }

    UnlockCourse() {
        if (this.selectedCourseIds.length !== 0) {
            // No checkboxes are selected, do not proceed with the download
            this.downloadExcelService.getUnlockAllCourses(this.selectedCourseIds).subscribe((data: any) => {
                console.log(data)


                bootbox.alert({
                    size: "heigh",
                    //title: "Export RDI for Clarizen -  File Download is in progress.",
                    message: "Record/s are unlocked.",
                    closeButton: false,
                    className: 'center-alert-box',
                    centerVertical: true,
                });

            });
            return;
        }

    }
}


