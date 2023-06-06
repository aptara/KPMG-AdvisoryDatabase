import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/service/userservice';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
declare var bootbox: any;
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

        if (this.UserAdd.valid) {
            this.UserAdd.controls.TaskMasterID.setValue(this.tmId);
            this.userService.PostUserData(this.UserAdd.value).subscribe(data => {
                if (data != null) {
                    bootbox.alert('User Added successfully!!');
                } else {
                    bootbox.alert('Failed!!');
                }
                this.router.navigate(['/user-management']);
            });
        } else {
            this.UserAdd.markAllAsTouched();
            bootbox.alert('Invalid form data. Please fill in all required fields correctly.');
        }
    }


    ngOnInit(): void {
        this.UserAdd = new FormGroup({
            'FirstName': new FormControl('', [
                Validators.required,
                Validators.pattern('[a-zA-Z]+')
            ]),
            'LastName': new FormControl('', [
                Validators.required,
                Validators.pattern('[a-zA-Z]+')
            ]),
            'Email': new FormControl('', [Validators.required, Validators.email]),
            'LocationID': new FormControl('', Validators.required),
            'TaskMasterID': new FormControl('')

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


