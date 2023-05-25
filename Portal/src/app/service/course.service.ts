import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Course } from '../domain/Course';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class CourseService {
    apiURL = environment.baseUrl;

    //constant variable for API URL
    readonly getAllCourseAPI = this.apiURL + "Course/GetAllCourse/";
    readonly getCourseAPI = this.apiURL + "Course/GetAllCourse/";
    readonly addCourseAPI = this.apiURL + "Course/GetAllCourse/";
    readonly updateCourseAPI = this.apiURL + "Course/GetAllCourse/";
    readonly deleteCourseAPI = this.apiURL + "Course/DeleteCourse/";

    constructor(private http: HttpClient) {

    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };


    getAllCourses(): Observable<Course> {
        return this.http
            .get<Course>(this.getAllCourseAPI)
            .pipe(retry(1), catchError(this.handleError));
    }


    getCourse(id: any): Observable<Course> {
        return this.http
            .get<Course>(this.getCourseAPI + id)
            .pipe(retry(1), catchError(this.handleError));
    }

    createCourse(Course: any): Observable<Course> {
        return this.http
            .post<Course>(
                this.addCourseAPI,
                JSON.stringify(Course),
                this.httpOptions
            )
            .pipe(retry(1), catchError(this.handleError));
    }

    updateCourse(id: any, Course: any): Observable<Course> {
        return this.http
            .put<Course>(
                this.updateCourse + id,
                JSON.stringify(Course),
                this.httpOptions
            )
            .pipe(retry(1), catchError(this.handleError));
    }

    deleteCourse(id: any) {
        return this.http
            .delete<Course>(this.deleteCourseAPI + id, this.httpOptions)
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
