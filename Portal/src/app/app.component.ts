import { Component } from '@angular/core';
import { UserService } from './service/userservice';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    title = 'kpmg-advisory-database-2023';


    constructor(private userService: UserService,
        private router: Router) {
    }
    ngOnInit() {
        this.userService.WindowAuthentication().subscribe(
            data => {
                if (data) {
                    localStorage.setItem('UserData', JSON.stringify(data));
                    alert('User is authorized. UserData: ' + JSON.stringify(data));
                } else {
                    this.router.navigate(['PageNotFoundComponent']);
                }
            },
            error => {
                alert('An error occurred. Please try again later.');
            }
        );
    }

}
