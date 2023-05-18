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
    constructor(private userService: UserService) { }








    onFormSubmit() {

        alert(JSON.stringify(this.UserAdd.value))

        // this.userService.PostUserData(this.UserAdd.value).subscribe(data => {
        //     this.Userdata = data;
        //     console.log(this.Userdata)
        // });

    }


    ngOnInit(): void {
        this.UserAdd = new FormGroup({
            'FirstName': new FormControl(),
            'LastName': new FormControl(),
            'Email': new FormControl(),
            'LocationID': new FormControl(),
            'TaskName': new FormControl([])
        });





        this.checkbox.forEach(task => {
            this.checkbox = this.Tasks.filter(x => x.checked == true)
            this.checkbox = task.TaskMasterID
        })


        this.SetLocationDropDown()
        this.SetTasksTable()
        this.onCheckboxChange()

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
    onCheckboxChange() {

    }
}


