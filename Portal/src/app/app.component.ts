import { Component } from '@angular/core';
import { UserService } from './service/userservice';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    title = 'kpmg-advisory-database-2023';
   
    constructor(private userService: UserService) {
    }
}
