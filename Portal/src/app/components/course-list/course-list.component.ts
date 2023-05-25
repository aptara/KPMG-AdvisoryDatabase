import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService, ConfirmEventType, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Course } from 'src/app/domain/Course';
import { CourseService } from 'src/app/service/course.service';

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
        private confirmationService: ConfirmationService,
        private messageService: MessageService
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
        debugger
        // this.confirmationService.confirm({
        //     message: 'Do you want to delete this record?',
        //     header: 'Delete Confirmation',
        //     accept: () => {
        return this.service.deleteCourse(CourseId).subscribe((data: any) => {
            this.GetAllCourse();
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
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

}
