import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Course } from '../domain/Course';
import { retry, catchError } from 'rxjs/operators';
import { DropdownData } from '../domain/dropdown-data';

@Injectable({
    providedIn: 'root'
})
export class DropdownDataService {

    apiURL = environment.baseUrl;

    //constant variable for API URL
    readonly getAllCourseAPI = this.apiURL + "DropdownData/GetDropdownData/";

    constructor(private http: HttpClient) {

    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };


    getAllCourses(): Observable<DropdownData> {
        return this.http
            .get<DropdownData>(this.getAllCourseAPI)
            .pipe(retry(1), catchError(this.handleError));
    }

    handleError(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Get client-side error
            errorMessage = error.error.message;
        } else {
            // Get server-side error
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        window.alert(errorMessage);
        return throwError(() => {
            return errorMessage;
        });
    }
}
