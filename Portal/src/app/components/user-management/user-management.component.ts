import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../service/userservice';
import { User } from '../../domain/user';
import { process } from "@progress/kendo-data-query";
import { DataBindingDirective } from "@progress/kendo-angular-grid";
import { Router, ActivatedRoute } from '@angular/router';
import { GridDataResult } from '@progress/kendo-angular-grid';
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
        // this.userService.getData().subscribe(res => {
        //     // this.UserDAta = res;

        //     // console.log(JSON.stringify(this.UserDAta))
        // }

        //)

        this.userService.getUsers().subscribe((data: any[]) => {
            this.UserDAta = data.filter(user => user.IsActive === true);
        });
    }
    get gridData(): GridDataResult {
        return {
            data: this.users,
            total: this.users.length
        };
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
                        field: "IsActive",
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

    deleteUser(userData: any): void {
        if (confirm("Are you sure you want to delete this user?")) {
            this.userService.delData(userData).subscribe((response: any) => {
                if (response != null) {
                    alert("User Deleted successfully");
                }
                else {
                    alert("not successful")
                }
                this.ngOnInit();
            });
        }
    }


}


//to show only valid user (only status is true)
// ngOnInit() {
//     this.userService.getUsers().subscribe((data: any[]) => {
//         this.UserData = data.filter(user => user.IsActive === true);
//     });
// }

//     get gridData(): GridDataResult {
//     return {
//         data: this.users,
//         total: this.users.length
//     };
// }

//for delete user but not in db
// deleteUser(userData: any): void {
//     if(confirm("Are you sure you want to delete this user?")) {
//     this.userService.delData(userData).subscribe((response: any) => {
//         if (response != null) {
//             alert("successful");
//         }
//         else {
//             alert("not successful")
//         }
//         this.ngOnInit();
//     });
// }
//     }