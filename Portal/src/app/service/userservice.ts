import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../domain/user';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {
    gridData: User[] = []
    userData: [] = []
    headers = new HttpHeaders()
        .set('content-type', 'application/json')
    constructor(private http: HttpClient) {


    }


    getUsersData() {
        console.log(this.userData)
        return Promise.resolve(this.userData);
    }


    public url = environment.baseUrl + 'api/WebUser/ShowData'
    getData() {
        var req = this.url;
        return this.http.get(req);
    }

    public GetDataByUrl = environment.baseUrl + 'api/WebUser/GetDataByUserId'
    getUData(UserID: any) {
        var req = this.GetDataByUrl + "/" + UserID;
        return this.http.get(req, UserID)
    }



    public LocationUrl = environment.baseUrl + 'api/TaskLocationMaster/LocationAction'
    GetLocationData() {
        var LocationData = this.LocationUrl;
        return this.http.get(LocationData);
    }

    public TaskUrl = environment.baseUrl + 'api/TaskLocationMaster/TaskAction'
    GetTasks() {
        return this.http.get(this.TaskUrl)
    }

    public postData = environment.baseUrl + 'api/WebUser/PostData'
    PostUserData(User: any) {
        var req = this.postData;
        return this.http.post(req, User, { headers: this.headers })
    }


    public EditData = environment.baseUrl + 'api/WebUser/UpdateData'
    EditUserData(UserData: any) {
        var req = this.EditData;
        return this.http.post(req, UserData)
    }


    //for all delete data but show on screen

    public deleteData = environment.baseUrl + 'api/WebUser/DelData'
    delData(empData: any) {
        var req = this.deleteData;
        return this.http.post(req, empData);
    }

    //to show only true value data
    getUsers(): Observable<any[]> {
        var req = environment.baseUrl + 'api/WebUser/ShowData'
        return this.http.get<any[]>(req);
    }
}