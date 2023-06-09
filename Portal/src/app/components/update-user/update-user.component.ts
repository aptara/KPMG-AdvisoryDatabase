import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/service/userservice';
declare var bootbox: any;
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
    tmId: any = ""
    submitted = false;
    emailInvalid: boolean = false;
    constructor(private userService: UserService, private Router: Router, private ActivatedRoute: ActivatedRoute) {

    }

    onFormSubmit() {
        this.UserUpdate.controls.TaskMasterID.setValue(this.tmId);
        if (this.UserUpdate.valid) {

            this.userService.EditUserData(this.UserUpdate.value).subscribe(data => {
                if (data != null) {
                    bootbox.alert('User Updated successfully!!');
                } else {
                    bootbox.alert('Failed!!');
                }
                this.Router.navigate(['/user-management']);
            });
        } else {
            this.UserUpdate.markAllAsTouched();
            bootbox.alert('Invalid form data. Please fill in all required fields correctly.');
        }
    }





    ngOnInit(): void {
        this.UserUpdate = new FormGroup({
            'UserMasterID': new FormControl(this.UserID),
            'FirstName': new FormControl('', [
                Validators.required,
                //Validators.pattern('[a-zA-Z]+')
            ]),
            'LastName': new FormControl('', [
                Validators.required,
                //Validators.pattern('[a-zA-Z]+')
            ]),
            'Email': new FormControl('', [Validators.required, Validators.email]),

            'TaskMasterID': new FormControl(''),
            'NetworkID': new FormControl('', Validators.required)
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
            this.UserUpdate.controls.NetworkID.setValue(this.data.NetworkID)

        })






        this.SelectLocation()
        this.SetTasksTable()

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



    clearForm() {
        this.UserUpdate.reset();
        this.submitted = false;
    }


    onCancel() {

        this.clearForm();
    }
    validateEmail() {
        const emailInput = this.UserUpdate.get('Email');
        if (emailInput?.invalid && emailInput?.dirty) {
            const emailRegex = /^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$/;
            this.emailInvalid = !emailRegex.test(emailInput.value);
        }
    }
}
