import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../service/userservice';
import { User } from '../../domain/user';
import { process } from "@progress/kendo-data-query";
import { DataBindingDirective } from "@progress/kendo-angular-grid";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-user-management',
    templateUrl: './user-management.component.html',
    styleUrls: ['./user-management.component.scss']
})

export class UserManagementComponent implements OnInit {

    @ViewChild(DataBindingDirective)
    dataBinding!: DataBindingDirective;
    displayCheckBoxList = false
    users: User[] = [];
    selectedUser: User[] = [];
    loading: boolean = true;
    public colSpan: number = 5;
    public gridView: any[] = [];
    UserDAta: any;

    constructor(private userService: UserService, private Router: Router, private ActivatedRoute: ActivatedRoute) {

    }

    ngOnInit() {
        // this.gridView = this.gridData;
        this.userService.getData().subscribe(res => {
            this.UserDAta = res;
            this.UserDAta.IsActive = true;
            console.log(JSON.stringify(this.UserDAta))
        }

        )
    }




    public columns: string[] = ["Action", "UserMasterID", "First Name", "Last Name", "Email", "Location"];

    public hiddenColumns: string[] = [];

    public isHidden(columnName: string): boolean {
        return this.hiddenColumns.indexOf(columnName) > -1;
    }




    public isDisabled(columnName: string): boolean {
        return (
            this.columns.length - this.hiddenColumns.length === 1 &&
            !this.isHidden(columnName)
        );
    }



    public hideColumn(columnName: string): void {
        const hiddenColumns = this.hiddenColumns;

        if (!this.isHidden(columnName)) {
            hiddenColumns.push(columnName);
        } else {
            hiddenColumns.splice(hiddenColumns.indexOf(columnName), 1);
        }
    }

    public onFilter(inputValue: string): void {
        this.gridView = process(this.UserDAta, {
            filter: {
                logic: "or",
                filters: [
                    {
                        field: "UserMasterID",
                        operator: "contains",
                        value: inputValue,
                    },
                    {
                        field: "firstName",
                        operator: "contains",
                        value: inputValue,
                    },
                    {
                        field: "lastName",
                        operator: "contains",
                        value: inputValue,
                    },
                    {
                        field: "email",
                        operator: "contains",
                        value: inputValue,
                    },
                    {
                        field: "location",
                        operator: "contains",
                        value: inputValue,
                    },
                ],
            },
        }).data;

        this.dataBinding.skip = 0;
    }

    public displayCheckBoxListFunction() {

        this.displayCheckBoxList = !this.displayCheckBoxList

    }

    public deletedRecords: any[] = [];
    public deleteRecord(dataItem: any): void {
        const index = this.gridView.indexOf(dataItem);
        if (index !== -1) {
            this.gridView.splice(index, 1);
            this.deletedRecords.push(dataItem);
        }
    }

    editData(SelectedUserData: any) {


        this.Router.navigate(['/update-user', SelectedUserData])

        // console.log(SelectedUserData)




    }


}
