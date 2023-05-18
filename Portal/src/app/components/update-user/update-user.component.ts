import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/service/userservice';
@Component({
    selector: 'app-update-user',
    templateUrl: './update-user.component.html',
    styleUrls: ['./update-user.component.scss']
})
export class UpdateUserComponent implements OnInit {

    emailRegex = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
    isValidFormSubmitted = false;
    UserUpdate: FormGroup | any;
    router: any;
    UserID: any;
    data: any;
    Resp: any[] = [];
    Location: any[] = [];
    Tasks: any[] = [];
    checkbox: any[] = []
    checked: any;
    User: any;
    checkedTask: any;
    constructor(private userService: UserService, private Router: Router, private ActivatedRoute: ActivatedRoute) {

    }

    onFormSubmit() {

        this.checkbox = this.Tasks.filter(x => x.checked == true)
        this.checkbox.forEach(task => {
            console.log(task.TaskMasterID)
        })

        this.userService.EditUserData(this.UserUpdate.value).subscribe(response => {
            console.log(response)
            if (response != null) {
                alert('successful');

            }
            else {
                alert('not successful')
            }

        });


    }






    ngOnInit(): void {
        this.UserUpdate = new FormGroup({
            'UserMasterID': new FormControl(this.UserID),
            'FirstName': new FormControl(),
            'LastName': new FormControl(),
            'Email': new FormControl(),
            'LocationID': new FormControl(),
            'TaskName': new FormControl()
        })

        this.UserID = this.ActivatedRoute.snapshot.params['UserMasterID'];
        console.log(this.UserID)
        this.userService.getUData(this.UserID).subscribe(res => {
            this.data = res
            // this.Resp = Object.values(this.data[0])
            // console.log(this.Resp)
            this.UserUpdate.controls.UserMasterID.setValue(this.data.UserMasterID)
            this.UserUpdate.controls.FirstName.setValue(this.data.FirstName)
            this.UserUpdate.controls.LastName.setValue(this.data.LastName)
            this.UserUpdate.controls.Email.setValue(this.data.Email)
            this.UserUpdate.controls.LocationID.setValue(this.data.LocationID)
            this.UserUpdate.controls.TaskName.setValue(this.checkbox)
        })






        this.SelectLocation()
        this.SetTasksTable()
        this.onCheckboxChange()
    }
    SelectLocation() {
        this.userService.GetLocationData().subscribe(loc => {
            this.Location = Object.values(loc)

        })
    }


    SetTasksTable() {
        this.userService.GetTasks().subscribe(task => {
            this.Tasks = Object.values(task)
        })
    }


    onCheckboxChange() {

    }


    // UpdateUser() {
    //     this.userService.EditUserData(this.UpdateUser).subscribe(response => {
    //         if (response != null) {
    //             alert('successful');

    //         }
    //         else {
    //             alert('not successful')
    //         }

    //     });

    // }


}
