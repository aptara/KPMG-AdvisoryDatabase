import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CourseService {



    constructor(private http: HttpClient) { }

    //for get all course data in table
    getData() {
        var req = environment.apiurl + 'api/Course/ShowData'
        return this.http.get(req);
    }

}
