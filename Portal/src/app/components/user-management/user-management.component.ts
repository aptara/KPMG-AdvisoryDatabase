import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/userservice';
import { User } from '../../domain/user';


@Component({
    selector: 'app-user-management',
    templateUrl: './user-management.component.html',
    styleUrls: ['./user-management.component.scss']
})

export class UserManagementComponent implements OnInit {

    users: User[] = [];
    selectedUser: User[] = [];
    loading: boolean = true;

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.userService.getUsersData().then((users) => {
            this.users = users;
            this.loading = false;
        });
    }
}
