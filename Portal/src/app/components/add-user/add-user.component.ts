import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/service/userservice';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

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
    emailInvalid: boolean = false;
    submitted = false;


    constructor(private userService: UserService, ActivatedRoute: ActivatedRoute, private router: Router,) { }




    onFormSubmit() {

        this.UserAdd.controls.TaskMasterID.setValue(this.tmId)
        this.userService.PostUserData(this.UserAdd.value).subscribe(data => {
            if (data != null) {
                alert('User Added succesfully!!');
            }

            else {
                alert('Failed!!')
            }
            this.router.navigate(['/user-management']);
        });
        if (this.UserAdd.valid) {

        } else {

            this.UserAdd.markAllAsTouched();
        }
    }


    ngOnInit(): void {
        this.UserAdd = new FormGroup({
            'FirstName': new FormControl('', Validators.required),
            'LastName': new FormControl('', Validators.required),
            'Email': new FormControl('', [Validators.required]),
            'LocationID': new FormControl('', Validators.required),
            'TaskMasterID': new FormControl('', Validators.required)

        });





        this.SetLocationDropDown()
        this.SetTasksTable()

        this.clearForm();

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



    }


    validateEmail() {
        const emailInput = this.UserAdd.get('Email');
        if (emailInput?.invalid && emailInput?.dirty) {
            const emailRegex = /^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$/;
            this.emailInvalid = !emailRegex.test(emailInput.value);
        }
    }

    clearForm() {
        this.UserAdd.reset();
        this.submitted = false;
    }


    onCancel() {
        // Clear the form
        this.clearForm();
    }



}


