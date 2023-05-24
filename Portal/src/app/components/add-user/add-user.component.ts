import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/service/userservice';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-add-user',
    templateUrl: './add-user.component.html',
    styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {
    Location: any[] = [];
    Tasks: any[] = [];
    UserAdd: FormGroup | any
    checkbox: any[] = []
    Userdata: any;
    tmId: any = ""

    constructor(private userService: UserService) { }








    onFormSubmit() {

        this.UserAdd.controls.TaskMasterID.setValue(this.tmId)
        this.userService.PostUserData(this.UserAdd.value).subscribe(data => {
            if (data != null) {
                alert('User Added succesfully!!');


            }

            else {
                alert('not successful')
            }
            window.location.href = '/user-management';
        });
        // console.log(JSON.stringify(this.UserAdd.value))
        // console.log(this.checkbox)
        // console.log(JSON.stringify(this.Tasks))
        console.log(this.UserAdd)


    }


    ngOnInit(): void {
        this.UserAdd = new FormGroup({
            'FirstName': new FormControl(),
            'LastName': new FormControl(),
            'Email': new FormControl(),
            'LocationID': new FormControl(),
            'TaskMasterID': new FormControl()

        });


        // this.Tasks.forEach(task => {
        //     this.checkbox = this.Tasks.filter(x => x.checked == true)

        //     // this.checkbox = task.TaskMasterID
        // })
        // console.log(this.checkbox)


        this.SetLocationDropDown()
        this.SetTasksTable()


    }

    //Set Location dropdown
    SetLocationDropDown() {
        this.userService.GetLocationData().subscribe(loc => {
            this.Location = Object.values(loc)

        })
    }

    // set TaskTable
    SetTasksTable() {
        this.userService.GetTasks().subscribe(task => {
            this.Tasks = Object.values(task)
        })
    }

    //for Task change check

    onCheckboxChange(task: any, e: any) {

        var Ids: any = []

        if (e.target.checked) {
            this.checkbox.push(task)
            // console.log(task
        }
        else {
            this.checkbox.forEach((value, index) => {
                if (value == task)
                    this.checkbox.splice(index, 1)

            })


        }

        this.checkbox.forEach(taskName => {
            Ids.push(taskName.TaskMasterID)
            this.tmId = Ids.join(",")
        })
        console.log(this.tmId)


    }
}


