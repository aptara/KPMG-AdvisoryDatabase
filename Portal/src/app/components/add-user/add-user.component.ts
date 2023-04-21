import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-add-user',
    templateUrl: './add-user.component.html',
    styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {


    constructor() { }

    emailRegex = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

    isValidFormSubmitted = false;




    onFormSubmit(form: NgForm) {

        this.isValidFormSubmitted = false;

        if (form.invalid) {
            return;
        }

        this.isValidFormSubmitted = true;
        form.resetForm();

        alert('SUCCESS!! :-)\n\n')
    }

    ngOnInit(): void {
    }

    addUser() {

    }

}
