import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DownloadExcelService {
    apiURL = environment.baseUrl;

    readonly getAllShowDataofclarizenAPI = this.apiURL + "GETExcelForClarizenFields/GetShowDataForClarizan/";
    readonly getAllShowDataoffocusAPI = this.apiURL + "GetExcelForFocus/GetShowDataoffocus/";
    readonly getAllShowDataofdeploymentAPI = this.apiURL + "GetExcelForDeploymentReport/ShowDataofdeployment/";
    readonly getAllShowDataofUnlockAPI = this.apiURL + "UnlockCourse/UnlockCourse/";
    readonly getAllShowDataofCourseList = this.apiURL + "GetCourseList/CourseList/";

    constructor(private http: HttpClient) {

    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };


    getUnlockAllCourses(courseId: any): Observable<any> {
        const url = this.getAllShowDataofUnlockAPI + "?courseId=" + courseId;
        console.log(url)
        return this.http
            .get<any>(url)
            .pipe(retry(1), catchError(this.handleError));
    }
    getAllCoursesForClarizen(courseId: any): Observable<any> {
        const url = this.getAllShowDataofclarizenAPI + "?courseId=" + courseId;
        console.log(url)
        return this.http
            .get<any>(url)
            .pipe(retry(1), catchError(this.handleError));
    }

    getAllCoursesForDataOfFocus(courseId: any): Observable<any> {
        const url = this.getAllShowDataoffocusAPI + "?courseId=" + courseId;
        console.log(url)
        return this.http
            .get<any>(url)
            .pipe(retry(1), catchError(this.handleError));
    }


    getAllCoursesForDataOfDeployment(): Observable<any> {
        return this.http
            .get<any>(this.getAllShowDataofdeploymentAPI)
            .pipe(retry(1), catchError(this.handleError));
    }

    getAllCourseList(): Observable<any> {
        return this.http
            .get<any>(this.getAllShowDataofCourseList)
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
