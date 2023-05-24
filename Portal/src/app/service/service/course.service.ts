import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CourseService {

    public url = ' http://localhost:62220//api/Course/ShowData'



    constructor(private http: HttpClient) { }

    //for get all course data in table
    getData() {
        var req = this.url;
        return this.http.get(req);
    }

}
