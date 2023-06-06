import { Component, OnInit, ViewChild } from '@angular/core';
import { saveAs } from 'file-saver';
import * as XLSX from 'xlsx';
import { environment } from 'src/environments/environment';


import { HttpClient } from '@angular/common/http';


import { CourseService } from 'src/app/service/service/course.service';


@Component({
    selector: 'app-course-management',
    templateUrl: './course-management.component.html',
    styleUrls: ['./course-management.component.scss']
})
export class CourseManagementComponent implements OnInit {

    // for download excel file
    data: any;
    datac: any;
    datad: any;
    public coursView: any[] = []


    //excel for focus
    ExcelOfFocus() {
        this.http.get<any[]>(environment.baseUrl + 'api/GetExcelForFocus/ShowDataoffocus').subscribe(data => {

            this.data = data;

        });
    }
    getHeaders() {
        const headers = Object.keys(this.data[0]).slice(0, 14);

        return headers;
    }
    downloadExceloffocus() {
        if (!this.data) {
            return;
        }
        const headers = this.getHeaders();
        const data = this.data.map((obj: any) => headers.map(key => obj[key]));
        const worksheetName = 'Data Of Focus Fields';
        const fileName = 'Excel of Focus Fields.xlsx';
        const worksheet = XLSX.utils.aoa_to_sheet([headers, ...data]);
        // Set column widths
        const columnWidths = headers.map(() => ({ width: 23 }));
        worksheet['!cols'] = columnWidths;
        const workbook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
        XLSX.writeFile(workbook, fileName);
    }

    //excel for Clarizen

    ExcelOfClarizen() {
        this.http.get<any[]>(environment.baseUrl + 'api/GETExcelForClarizenFields/ShowDataofclarizen').subscribe(data2 => {

            this.datac = data2;

        });
    }
    getHeaders2() {
        const headers = Object.keys(this.datac[0]).slice(0, 12);
        // console.log('headers:', headers);
        return headers;
    }
    downloadExcelofClarizen() {
        if (!this.datac) {
            return;
        }
        const headers = this.getHeaders2();
        const data = this.datac.map((obj: any) => headers.map(key => obj[key]));
        const worksheetName = 'Data Of Clarizen Fields';
        const fileName = 'Excel For Clarizen Fields.xlsx';
        const worksheet = XLSX.utils.aoa_to_sheet([headers, ...data]);
        // Set column widths
        const columnWidths = headers.map(() => ({ width: 20 }));
        worksheet['!cols'] = columnWidths
        const workbook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
        XLSX.writeFile(workbook, fileName);
    }

    //excel for deployment

    ExcelOfDeployment() {
        this.http.get<any[]>(environment.baseUrl + 'api/GetExcelForDeploymentReport/ShowDataofdeployment').subscribe(data3 => {

            this.datad = data3;

        });
    }

    getHeaders3() {
        const headers = Object.keys(this.datad[0]).slice(0, 19);
        // console.log('headers:', headers);
        return headers;
    }
    downloadExcelofDeployment() {
        if (!this.datad) {
            return;
        }
        const headers = this.getHeaders3();
        const data = this.datad.map((obj: any) => headers.map(key => obj[key]));
        const worksheetName = 'Data Of Deployment Field';
        const fileName = 'Excel For Deployment Fields.xlsx';

        const worksheet = XLSX.utils.aoa_to_sheet([headers, ...data]);

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
    //-----here end the excel download format-----






    // getcoursedata
    constructor(public courseservice: CourseService, public http: HttpClient) { }
    coursed: any;
    ngOnInit(): void {
        this.ExcelOfFocus();
        this.ExcelOfClarizen();
        this.ExcelOfDeployment();
        this.courseservice.getData().subscribe(res => {
            this.coursed = res;
            this.coursView = this.coursed

        });
    }





    // for delete record on screen not in db
    public deletedRecords: any[] = [];
    public deleteRecord(dataItem: any): void {
        const index = this.coursed.indexOf(dataItem);
        if (index !== -1) {
            this.coursed.splice(index, 1);
            this.deletedRecords.push(dataItem);
        }
    }



}
 // console.log('headers:', headers);line 41