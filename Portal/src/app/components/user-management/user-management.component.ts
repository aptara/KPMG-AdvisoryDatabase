import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../service/userservice';
import { User } from '../../domain/user';
import { Table } from 'primeng/table';
import { saveAs } from 'file-saver';



import { Router, ActivatedRoute } from '@angular/router';
declare var bootbox: any;
@Component({
    selector: 'app-user-management',
    templateUrl: './user-management.component.html',
    styleUrls: ['./user-management.component.scss']
})

export class UserManagementComponent implements OnInit {
    @ViewChild('dt') table: Table;
    // @ViewChild(DataBindingDirective)
    // dataBinding!: DataBindingDirective;
    displayCheckBoxList = false
    users: User[] = [];
    selectedUser: User[] = [];
    loading: boolean = true;
    public colSpan: number = 5;
    Uservalue: any = [];
    user: any[] = []
    cols: any[];
    bootbox: any;
    _selectedColumns: any[];
    public showFirstNameColumn: boolean = true;
    constructor(private userService: UserService,
        private Router: Router,
        private ActivatedRoute: ActivatedRoute,

    ) {

    }

    ngOnInit() {

        this.userService.getUsers().subscribe((data: any[]) => {
            this.Uservalue = data.filter(user => user.IsActive === true);
            this.loading = false;
        });


        this.cols = [
            { field: 'firstName', header: 'firstNamee' },
            { field: 'lastName', header: 'lastName' },
            { field: 'email', header: 'email' }
        ];

        this._selectedColumns = this.cols;

    }
    get selectedColumns(): any[] {
        return this._selectedColumns;
    }

    set selectedColumns(val: any[]) {
        //restore original order
        this._selectedColumns = this.cols.filter((col) => val.includes(col));
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



    public displayCheckBoxListFunction() {

        this.displayCheckBoxList = !this.displayCheckBoxList

    }
    clear(table: Table) {
        table.clear();
    }

    AddUser() {
        this.Router.navigate(['/add-user'])
    }


    editData(SelectedUserData: any) {


        this.Router.navigate(['/update-user', SelectedUserData])

        // console.log(SelectedUserData)
    }

    deleteUser(userData: any): void {
        bootbox.confirm('Are you sure you want to delete this user?', (result: boolean) => {
            if (result) {
                this.userService.delData(userData).subscribe((response: any) => {
                    if (response != null) {
                        bootbox.alert('User deleted successfully');
                    } else {
                        bootbox.alert('Deletion not successful');
                    }
                    this.ngOnInit();
                });
            }
        });
    }
    exportCSV() {
        if (this.table && this.table.value) {
            const columnTitles = ['First Name', 'Last Name', 'NetworkID'];
            const csvData = this.table.value.map(user => [
                user.FirstName,
                user.LastName,
                user.NetworkID
            ]);

            // Prepare the CSV content
            const csvContent = columnTitles.join(",") + "\n"
                + csvData.map(row => row.join(",")).join("\n");

            // Create a Blob object and save the file
            const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8' });
            saveAs(blob, 'User_data.csv');
        }


    }

}


