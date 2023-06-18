import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/service/userservice';

@Component({
    selector: 'app-page-not-found',
    templateUrl: './page-not-found.component.html',
    styleUrls: ['./page-not-found.component.scss']
})
export class PageNotFoundComponent implements OnInit {


    constructor(public http: HttpClient, public service: UserService) {
    }


    User =
        {
            "Email": "Pushpraj.Jagadale@ap",
        }
    ngOnInit(): void {
        localStorage.setItem('Me', JSON.stringify(this.User))



        var Userdata = JSON.parse(localStorage.getItem('Me')!)
        console.log(Userdata.FirstName)
        this.setUserToLocalStorage()
    }

    setUserToLocalStorage(): void {


        this.service.getDataByEmail(this.User.Email).subscribe(

            response => {
                console.log("hey" + JSON.stringify(response));
                localStorage.setItem('UserData', JSON.stringify(response))
            }

        );
    }

}
