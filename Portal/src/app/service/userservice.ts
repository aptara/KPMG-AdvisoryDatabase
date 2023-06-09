import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CoursePermission, User } from '../domain/user';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {
    gridData: User[] = []
    userData: [] = []
    headers = new HttpHeaders()
        .set('content-type', 'application/json')
    constructor(private http: HttpClient) {
        // this.setUserToLocalStorage();
    }

    getUsersData() {
        console.log(this.userData)
        return Promise.resolve(this.userData);
    }

    public url = environment.baseUrl + 'WebUser/GetUserData'
    getData() {
        var req = this.url;
        return this.http.get(req);
    }

    public GetDataByUrl = environment.baseUrl + 'WebUser/GetDataByUserId'
    getUData(UserID: any) {
        var req = this.GetDataByUrl + "/" + UserID;
        return this.http.get(req, UserID)
    }

    // setUserToLocalStorage(): void {

    //     if (!localStorage.getItem("UserData")) {

    //         this.WindowAuthentication().subscribe(user => {
    //             localStorage.setItem('UserData', JSON.stringify(user))
    //             alert('UserData' + JSON.stringify(user))
    //         });
    //     }
    // }





    GetUserPermission() {
        let userPermission = new CoursePermission();
        let UserData = this.ReadUserData();
        if (UserData) {
            let permissions = UserData?.TaskMasterID?.split(",")
            userPermission.hasPermissionCreateCourse = permissions.some((x: any) => x?.trim() === "1")
            userPermission.hasPermissionUpdateCourse = permissions.some((x: any) => x?.trim() === "2");
            userPermission.hasPermissionDisableCourse = permissions.some((x: any) => x?.trim() === "3");
            userPermission.hasPermissionReviewCourse = permissions.some((x: any) => x?.trim() === "8");
            userPermission.hasPermissionEnableCourse = permissions.some((x: any) => x?.trim() === "13");
            userPermission.hasPermissionAddUpdateCourseID = permissions.some((x: any) => x?.trim() === "15");
            userPermission.hasPermissionExportCourse = permissions.some((x: any) => x?.trim() === "4");
            userPermission.hasPermissionDownloadCourseRDIforFocus = permissions.some((x: any) => x?.trim() === "5");
            userPermission.hasPermissionDownloadCourseRDIforClarizen = permissions.some((x: any) => x?.trim() === "6");
            userPermission.hasPermissionDownloadCourse = permissions.some((x: any) => x?.trim() === "7");
        }
        return userPermission;
    }

    ReadUserData(): any {
        let userData: any = localStorage.getItem('UserData');
        return JSON.parse(userData);
    }

    public LocationUrl = environment.baseUrl + 'TaskLocationMaster/LocationAction'
    GetLocationData() {
        var LocationData = this.LocationUrl;
        return this.http.get(LocationData);
    }

    public TaskUrl = environment.baseUrl + 'TaskLocationMaster/GetTask'
    GetTasks() {
        return this.http.get(this.TaskUrl)
    }

    public postData = environment.baseUrl + 'WebUser/PostUserData'
    PostUserData(User: any) {
        var req = this.postData;
        return this.http.post(req, User, { headers: this.headers })
    }


    public EditData = environment.baseUrl + 'WebUser/UpdateUser'
    EditUserData(UserData: any) {
        var req = this.EditData;
        return this.http.post(req, UserData)
    }


    //for all delete data but show on screen

    public deleteData = environment.baseUrl + 'WebUser/DelData'
    delData(empData: any) {
        var req = this.deleteData;
        return this.http.post(req, empData);
    }

    //to show only true value data
    getUsers(): Observable<any[]> {
        var req = environment.baseUrl + 'WebUser/GetUserData'
        return this.http.get<any[]>(req);
    }



    public GetAuthUser = environment.baseUrl + "WebUser/GetAutherizedUser";

    WindowAuthentication() {
        return this.http.get(this.GetAuthUser)

    }



}

