import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Table } from 'primeng/table';
import { Course } from 'src/app/domain/Course';
import { CourseService } from 'src/app/service/course.service';
import { DownloadExcelService } from 'src/app/service/service/download-excel.service';

import * as XLSX from 'xlsx';

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

    constructor(
        public service: CourseService,
        private route: ActivatedRoute,
        private router: Router,
        private downloadExcelService: DownloadExcelService
    ) { }

    ngOnInit(): void {
        this.GetAllCourse()
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

    DeleteCourse(CourseId: any) {

        // this.confirmationService.confirm({
        //     message: 'Do you want to delete this record?',
        //     header: 'Delete Confirmation',
        //     accept: () => {
        return this.service.deleteCourse(CourseId).subscribe((data: any) => {
            this.GetAllCourse();
        });
        //     },
        //     reject: (type: any) => {
        //         switch (type) {
        //             case ConfirmEventType.REJECT:
        //                 this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
        //                 break;
        //             case ConfirmEventType.CANCEL:
        //                 this.messageService.add({ severity: 'warn', summary: 'Cancelled', detail: 'You have cancelled' });
        //                 break;
        //         }
        //     }
        // });


    }

    AddCourse() {
        this.router.navigate(['/course-details'])
    }

    downloadExceloffocus() {

        this.downloadExcelService.getAllCoursesForDataOfFocus().subscribe((data: any) => {
            if (data) {
                var courseData: any = data;
                const headers = Object.keys(courseData[0]).slice(0, 14);
                const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
                const worksheetName = 'Data Of Focus Fields';
                const fileName = 'Excel of Focus Fields.xlsx';
                const worksheet = XLSX.utils.aoa_to_sheet([headers, ...excelData]);
                // Set column widths
                const columnWidths = headers.map(() => ({ width: 23 }));
                worksheet['!cols'] = columnWidths;
                const workbook = XLSX.utils.book_new();

                XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
                XLSX.writeFile(workbook, fileName);
            }
        });
    }

    downloadExcelofClarizen() {
        this.downloadExcelService.getAllCoursesForClarizen().subscribe((data: any) => {
            if (data) {
                var courseData: any = data;
                const headers = Object.keys(courseData[0]).slice(0, 12);;
                const excelData = courseData.map((obj: any) => headers.map(key => obj[key]));
                const worksheetName = 'Data Of Clarizen Fields';
                const fileName = 'Excel For Clarizen Fields.xlsx';
                const worksheet = XLSX.utils.aoa_to_sheet([headers, ...excelData]);
                // Set column widths
                const columnWidths = headers.map(() => ({ width: 20 }));
                worksheet['!cols'] = columnWidths
                const workbook = XLSX.utils.book_new();
                XLSX.utils.book_append_sheet(workbook, worksheet, worksheetName);
                XLSX.writeFile(workbook, fileName);
            }
        });
    }

    downloadExcelofDeployment() {

        this.downloadExcelService.getAllCoursesForDataOfDeployment().subscribe((data: any) => {
            if (data) {
                var courseData: any = data;
                const headers = Object.keys(courseData[0]).slice(0, 19);
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

    // public onFilter(inputValue: string): void {
    //     this.CourseData = process(this.CourseData, {
    //         filter: {
    //             logic: "or",
    //             filters: [
    //                 {

    //                     field: "CourseID",
    //                     operator: "contains",
    //                     value: inputValue,
    //                 },
    //                 {
    //                     field: "CourseName",
    //                     operator: "contains",
    //                     value: inputValue,
    //                 },
    //                 {
    //                     field: "LDIntakeOwner",
    //                     operator: "contains",
    //                     value: inputValue,
    //                 },
    //                 {
    //                     field: "ProjectManagerContact",
    //                     operator: "contains",
    //                     value: inputValue,
    //                 },
    //                 {
    //                     field: " BusinessSponsor",
    //                     operator: "contains",
    //                     value: inputValue,
    //                 },
    //                 {
    //                     field: "ProjectStatusID",
    //                     operator: "contains",
    //                     value: inputValue,
    //                 },
    //             ],
    //         },
    //     }).data;

    //     this.dataBinding.skip = 0;
    // }

}
