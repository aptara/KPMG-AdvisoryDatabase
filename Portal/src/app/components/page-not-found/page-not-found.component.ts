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

    ngOnInit(): void {
    }
}
