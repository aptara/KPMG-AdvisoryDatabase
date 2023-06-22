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
        private http: HttpClient
    ) {
        this.hasPermission = new CoursePermission();
    }


    ngOnInit(): void {
        this.hasPermission = this.userservice.GetUserPermission();
        this.GetAllCourse()

        this.ExcelOfClarizen()
        this.ExcelOfFocus()
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


        bootbox.confirm('Are you sure you want to delete this user?', (result: boolean) => {
            if (result) {
                return this.service.deleteCourse(CourseId).subscribe((data: any) => {
                    if (data != null) {
                        bootbox.alert('User deleted successfully');
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
                const worksheetName = 'Data Of Deployment Field';
                const fileName = 'Excel For Deployment Fields.xlsx';

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
        });
    }


    // User =
    //     {
    //         "Email": "sdemotest34@gmail.com",
    //     }
    // setUserToLocalStorage(): void {


    //     this.userservice.getDataByEmail(this.User.Email).subscribe(

    //         response => {
    //             console.log("hey" + JSON.stringify(response));
    //             localStorage.setItem('UserData', JSON.stringify(response))
    //         }

    //     );
    // }











    dataf: any;
    datac: any;
    selectedCourseIds: string[] = [];


    //excel for focus
    ExcelOfFocus() {
        this.http.get<any[]>(environment.baseUrl + 'GetExcelForFocus/ShowDataoffocus').subscribe(data => {

            this.dataf = data;

        });
    }
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



}
