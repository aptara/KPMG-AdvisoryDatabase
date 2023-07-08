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
import { filter } from 'rxjs';
import { DatePipe } from '@angular/common';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { table } from 'console';


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
        this.ExcelOfClarizen()
        //this.ExcelOfFocus()
        //this.ExcelOfDeployment()
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
        this.http.get<any[]>(environment.baseUrl + 'GetCourseList/CourseList/').subscribe(data2 => {

            //this.datac = [];
            this.CourseList = data2
            console.log(this.datac)
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
                        //this.GetAllCourse();
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
                const headers = Object.keys(courseData[0]).slice(0, 56);//78 final


                const columnTitles = [
                    'Course Name', 'Course ID', 'Deployment Fiscal Year', 'Competency', 'Skill', 'Industry', 'Program Knowledge Level',
                    'Status',
                    'Course Overview & Objective', 'Target Audience', 'Audience Level', 'Development Year',
                    'SG/SL/SN Values', 'FOS values', 'Estimated CPE', 'Prerequisite Course ID', 'Equivalent Course ID',
                    'Special Notice', 'Function Name', 'AudienceType',

                    'Course Sponsor', 'Which SG/SL/SNSponsor Learning ', 'Subject Matter Professional', 'Vendor',
                    'ServiceNowID', 'Descriptions',
                    'Is Regulatoryor Legal Requirement', 'Program Type', 'Delivery Type', 'Duration',
                    'First Delivery Date', 'Maximum Attendee Count',
                    'Minimum Attendee Count', 'Maximum Attendee Waitlist', 'Material', 'Collateral',
                    'Level Of Effort', 'Room Set Up Comments', 'Deployment Facilitator Consideration', 'L&D Intake Owner',
                    'Project Manager ', 'Instructional Designer ', 'Course Owner 1', ' Course Owner 2',
                    , 'Price', 'Currency', 'Display Call Center',

                    'OFFERING_TEMPLATE_NO', 'Is RecordLocked', 'Clarizen Start Date', 'Course Record URL',
                    'Focus Domain', 'Focus Retired', 'Focus Disc From', 'Focus Displayed To Learner',

                ]




                const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
                excelData.unshift(columnTitles);
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
                const fileName = 'All_Course_Records_' + myDate + '_' + random + '.xlsx';

                const worksheetName = 'Data All_Course_Records_ Field';

                const worksheet = XLSX.utils.aoa_to_sheet([...excelData]);
                //const worksheet = XLSX.utils.aoa_to_sheet([headers, ...excelData]);

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
            this.selectedCourseIds = this.CourseList.map((course: { CourseMasterID: any; }) => course.CourseMasterID);
        } else {
            // Clear the selectedCourseIds array to unselect all checkboxes
            this.selectedCourseIds = [];
        }
    }


    isCourseSelected(courseId: string): boolean {
        return this.selectedCourseIds.includes(courseId);
    }

    cancelSelection() {
        // if (this.selectedCourseIds.length == 0) {
        //     //Show for no select
        //     bootbox.alert({
        //         size: "heigh",
        //         //title: "Export RDI for Clarizen -  File Download is in progress.",
        //         message: "Please Select At Least One Record.",
        //         closeButton: false,
        //         className: 'center-alert-box',
        //         centerVertical: true,
        //     });


        // }
        this.selectedCourseIds = []; // Clear the selectedCourseIds array to unselect all checkboxes
        this.selectAll = false; // Uncheck the "Select All" checkbox


    }

    downloadExceloffocusN() {
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
                const headers1 = Object.keys(courseData[0]).slice(0, 45); // First 10 columns
                const headers2 = Object.keys(courseData[0]).slice(0, 45); // First 15 columns

                // Custom titles for each column
                const columnTitles1 = ['ID', 'OFFERING_TEMPLATE_NO',
                    'VERSION', 'TITLE',
                    'DOMAIN',
                    'AVAIL_FROM', 'DISC_FROM', 'CURRENCY', 'PRICE', 'DESCRIPTION',

                    'DISPLAY_LEARNER', 'DISPLAY_CALL_CENTER', ' AUDIENCE_TYPE1', 'AUDIENCE_TYPE2', 'VENDOR', 'CUSTOM0', 'CUSTOM1', 'CUSTOM2',

                    'CUSTOM3', 'CUSTOM5', ' CUSTOM8', 'OWNER1', 'Owner two	', 'PREREQUISITE1', 'PREREQUISITE_VERSION1', 'PREREQUISITE2',
                    'PREREQUISITE_VERSION2', 'EQUIVALENT1', 'EQUIVALENT_VERSION1', 'EQUIVALENT2', 'EQUIVALENT_VERSION2',
                    'DELIVERY_TYPE1', 'DT_DURATION1',

                    'FIELD_OF_STUDY1', 'FOS_DEFAULT_CREDITS1', 'FIELD_OF_STUDY2',

                    'FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3', 'FOS_DEFAULT_CREDITS3', 'FIELD_OF_STUDY4',
                    'FOS_DEFAULT_CREDITS4', 'MIN_CT', 'MAX_CT', 'MAX_CT'];

                const columnTitles2 = ['ID', 'OFFERING_TEMPLATE_NO',
                    'VERSION', 'TITLE',
                    'DOMAIN',
                    'AVAIL_FROM', 'DISC_FROM', 'CURRENCY', 'PRICE', 'DESCRIPTION',

                    'DISPLAY_LEARNER', 'DISPLAY_CALL_CENTER', ' AUDIENCE_TYPE1', 'AUDIENCE_TYPE2', 'VENDOR', 'CUSTOM0', 'CUSTOM1', 'CUSTOM2',

                    'CUSTOM3', 'CUSTOM5', ' CUSTOM8', 'OWNER1', 'Owner two	', 'PREREQUISITE1', 'PREREQUISITE_VERSION1', 'PREREQUISITE2',
                    'PREREQUISITE_VERSION2', 'EQUIVALENT1', 'EQUIVALENT_VERSION1', 'EQUIVALENT2', 'EQUIVALENT_VERSION2',
                    'DELIVERY_TYPE1', 'DT_DURATION1',

                    'FIELD_OF_STUDY1', 'FOS_DEFAULT_CREDITS1', 'FIELD_OF_STUDY2',

                    'FOS_DEFAULT_CREDITS2', 'FIELD_OF_STUDY3', 'FOS_DEFAULT_CREDITS3', 'FIELD_OF_STUDY4',
                    'FOS_DEFAULT_CREDITS4', 'MIN_CT', 'MAX_CT', 'MAX_CT', 'Error Message'];

                // ID	OFFERING_TEMPLATE_NO	VERSION	TITLE	DOMAIN	AVAIL_FROM	DISC_FROM	CURRENCY	PRICE	DESCRIPTION	DISPLAY_LEARNER	DISPLAY_CALL_CENTER

                // AUDIENCE_TYPE1	AUDIENCE_TYPE2	VENDOR	CUSTOM0	CUSTOM1	CUSTOM2	CUSTOM3	CUSTOM5	CUSTOM8	OWNER1	Owner two	PREREQUISITE1	EQUIVALENT1

                // DELIVERY_TYPE1	DT_DURATION1	FIELD_OF_STUDY1	FOS_DEFAULT_CREDITS1	FIELD_OF_STUDY2	FOS_DEFAULT_CREDITS2	MIN_CT	MAX_CT	MAX_CT

                //   const excelData1 = courseData.map((obj: any) => headers1.map((key, index) => columnTitles1[index] ? obj[key] : ''));
                //const excelData2 = courseData.map((obj: any) => headers2.map((key, index) => columnTitles2[index] ? obj[key] : ''));




                // let ErrorMessage = " ";
                // let result = ErrorMessage.trim();


                // const filteredData1 = excelData1.filter((obj: any) => obj[35] == null);

                // const filteredData2 = excelData2.filter((obj: any) => obj[35] !== null);

                // let filteredData1 = excelData1.filter((row: string[]) => row[34].trim() === "");
                // let filteredData2 = excelData2.filter((row: string[]) => row[34].trim() !== "");


                // let filteredData1 = excelData1.filter((row: string[]) => {
                //     const value = row[34]?.trim(); // Access column number 35 and trim the value
                //     return value === "" || value === null; // Filter empty string values and null values
                // });

                // let filteredData2 = excelData2.filter((row: string[]) => {
                //     const value = row[34]?.trim(); // Access column number 35 and trim the value
                //     return value !== "" && value !== null; // Filter non-empty string values and non-null values
                // });


                //2
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

                    // callback: () => {
                    //     if (excelDataWithErrorMessageNull.length > 0) {
                    //         const workbook1 = XLSX.utils.book_new();
                    //         XLSX.utils.book_append_sheet(workbook1, worksheet1, worksheetName1);
                    //         XLSX.writeFile(workbook1, fileName1);
                    //     }
                    //     if (excelDataWithErrorMessageNotNull.length > 0) {
                    //         const workbook2 = XLSX.utils.book_new();
                    //         XLSX.utils.book_append_sheet(workbook2, worksheet2, worksheetName2);
                    //         XLSX.writeFile(workbook2, fileName2);
                    //     }
                    //     this.selectedCourseIds = []

                    // }
                    callback: () => {
                        if (excelDataWithErrorMessageNull.length > 0) {
                            const workbook1 = XLSX.utils.book_new();
                            XLSX.utils.book_append_sheet(workbook1, worksheet1, worksheetName1);
                            try {
                                XLSX.writeFile(workbook1, fileName1);
                            } catch (error) {
                                //bootbox.alert("Clarizen success can not be download due to " + error);
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
                                });// bootbox.alert("Clarizen Error Records file can not be download due to  " + error);
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
                //title: "Export RDI for Clarizen -  File Download is in progress.",
                message: "Please Select At Least One Record.",
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
        }



    }


    downloadExcelofClarizeN() {
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

            // No checkboxes are selected, do not proceed with the download
            this.downloadExcelService.getAllCoursesForClarizen(this.selectedCourseIds).subscribe((data: any) => {
                console.log(data)
                var courseData: any = data;
                const headers1 = Object.keys(courseData[0]).slice(0, 18); // First 18 columns
                const headers2 = Object.keys(courseData[0]).slice(0, 19); // First 19 columns

                // Custom titles for each column
                const columnTitles1 = ['Name', 'Business Relationship Director', 'Owner',
                    'Course Sponser', ' Description', 'InstructionalDesigner(s)', 'Lead SMP', 'ProgramType',
                    'Delivery  Type(Single Pick)', 'CPE creadits', 'Course #',
                    'First Delivery Date', 'Deployment Fiscal Year', 'Level of Effort',
                    'Start Date', 'S2URl', 'FocusTemplateName '];

                const columnTitles2 = ['Name', 'Business Relationship Director', 'Owner',
                    'Course Sponser', ' Description', 'InstructionalDesigner', 'Lead SMP', 'ProgramType',
                    'Delivery  Type(Single Pick)', 'CPE creadits', 'Course #',
                    'First Delivery Date', 'Deployment Fiscal Year', 'Level of Effort', 'Start Date'
                    , 'S2URl', 'FocusTemplateName', 'ErrorMessage'];


                //   const excelData1 = courseData.map((obj: any) => headers1.map((key, index) => columnTitles1[index] ? obj[key] : ''));
                // const excelData2 = courseData.map((obj: any) => headers2.map((key, index) => columnTitles2[index] ? obj[key] : ''));

                //const filteredData1 = excelData1.filter((obj: any) => obj[17] === null);
                // const filteredData2 = excelData2.filter((obj: any) => obj[17] !== null);

                // let filteredData1 = excelData1.filter((row: string[]) => row[17].trim() === "");
                // let filteredData2 = excelData2.filter((row: string[]) => row[17].trim() !== "");



                // let filteredData1 = excelData1.filter((row: any[]) => {
                //     const value = row[17]?.trim();
                //     return value === "" || value == null; // Filter empty string values and null values
                // });

                // let filteredData2 = excelData2.filter((row: any[]) => {
                //     const value = row[17]?.trim();
                //     return value !== "" || value !== null; // Filter non-empty string values and non-null values
                // });

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
                                //bootbox.alert("Clarizen success can not be download due to " + error);
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
                                });// bootbox.alert("Clarizen Error Records file can not be download due to  " + error);
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
                //title: "Export RDI for Clarizen -  File Download is in progress.",
                message: "Please Select At Least One Record.",
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
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
        else {

            bootbox.alert({
                size: "heigh",
                //title: "Export RDI for Clarizen -  File Download is in progress.",
                message: "Please Select At Least One Record.",
                closeButton: false,
                className: 'center-alert-box',
                centerVertical: true,
            });
        }

    }

    downloadExcelofFilter() {
        const filteredData = this.dt1.filteredValue;
        if (filteredData) {
            var courseData: any = filteredData;
            console.log(courseData)



            // const columnTitles = [
            //     'Course ID',
            //     'Course Name',
            //     'Target Audience', 'First Delivery Date', 'FOS1','FOS2','FOS3','FOS4',
            //     'Estimated CPE', 'Skill', 'Program Type', 'Delivery Type',
            //     'L&D Intake Owner', 'Program Knowledge Level', 'Instructional Designer',
            //     'Project Manager Contact', 'Competency ',  'Course Sponsor',
            //     'Vendor'

            // ];
            // const headers = columnTitles.slice(1, 24); // Limiting to 64 columns, change as needed

            // const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
            /////-------////----

            const columnIndices = [1, 2, 3, 4, 5, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21];
            const columnTitles = ['Course ID', 'Course Name', 'Target Audience', 'First Delivery Date',
                'FOS ',

                'Estimated CPE', 'Skill', 'Program Type', 'Delivery Type', 'L&D Intake Owner ', 'Program Knowledge Level',
                'Instructional Designer', 'Project Manager ', 'Competency', 'Industry', 'Course Sponsor',
                'Vendor (s)', 'Service Now ID', 'SG/SN/SL Sponsor', 'Focus Domain', 'Duration', 'Status'];
            const headers = columnIndices.map(index => columnTitles[index]);
            const excelData = courseData.map((obj: any) => columnIndices.map(index => obj[Object.keys(obj)[index]]));

            //-----method 2----
            // const columnIndices = [2, 1, 10, 27, 63, 12, 6, 58, 24, 25, 55, 8, 37, 56, 5, 7, 17, 20, 21, 62, 26, 43, 57
            // ]; // Array of column indices to include
            // const headers = columnIndices.map(index => Object.keys(courseData[0])[index]);
            // const excelData = courseData.map((obj: any) => columnIndices.map(index => obj[Object.keys(obj)[index]]));


            // method 1 ---
            // var courseData: any = filteredData;
            // const headers = Object.keys(courseData[0]).slice(1, 39); //39
            // const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
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


