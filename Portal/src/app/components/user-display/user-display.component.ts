import { Component, Input, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/userservice';

@Component({
    selector: 'app-user-display',
    templateUrl: './user-display.component.html',
    styleUrls: ['./user-display.component.scss']
})
export class UserDisplayComponent implements OnInit {

    @Input() templateType: string = 'photo';
    headerTitle: string = '';
    data: any = {};

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.headerTitle = "Advisory Database - 2023";
        this.userService.WindowAuthentication().subscribe(
            user => {
                this.data = user;
            },
            error => {
                console.error('Error retrieving user data:', error);
            }
        );
    }



}
