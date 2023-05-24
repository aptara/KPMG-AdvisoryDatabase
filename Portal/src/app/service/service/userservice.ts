// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';

// @Injectable()
// export class UserService {

//     userData: [] = []
//     constructor(private http: HttpClient) {
//         this.getJSON().subscribe(data => {
//             this.userData = data;
//         });
//     }

//     getJSON(): Observable<any> {
//         return this.http.get("../../assets/data/userData.json");
//     }


//     getUsersData() {
//         return Promise.resolve(this.userData);
//     }

//     getData_1() {
//         return [
//             {
//                 id: 1,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 2,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 3,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 4,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 5,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 6,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 7,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 8,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 9,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 10,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 11,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 12,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 13,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 14,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 15,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 16,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 17,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 18,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 19,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 20,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 21,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 22,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 23,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 24,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 25,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 26,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 27,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 28,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 29,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             },
//             {
//                 id: 30,
//                 firstName: 'First Name',
//                 lastName: 'Last Name',
//                 emailId: 'Email.Id@gmail.com',
//                 location: 'Location'
//             }
//         ];
//     }

//     getUsersData_1() {
//         return Promise.resolve(this.getData_1());
//     }


// }
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course, User } from '../domain/user';

@Injectable()
export class UserService {

    public url = ' http://localhost:62220//api/Course/ShowData'
    coursedata: Course[] = []
    gridData: User[] = []
    userData: [] = []
    constructor(private http: HttpClient) {

        this.getJSON().subscribe(data => {

            this.userData = data;


            console.log("data" + this.userData)
        });
    }

    getJSON(): Observable<any> {
        return this.http.get("../../assets/data/userData.json");
    }




    // for udate userinfo
    // updateData(userData: any) {
    //     var req = this.url;
    //     return this.http.put(req, userData);
    // }


    //for id call one page  for next comp
    getuserid(UserMasterID: any) {
        //return this.httpClient.get<User>(this.url, +UserMasterID);
        var req = this.url + "?UserMasterID=" + UserMasterID;
        return this.http.get(req);
    }

    //to show all info on table
    getallinfo() {
        return this.http.get(this.url);
    }


    // for udate course info
    // updatecourse(usercourse: any) {
    //     var req = this.url;
    //     return this.http.put(req, usercourse);
    // }




    getGridData() {
        return this.gridData = [

            {
                "firstName": "James",
                "lastName": "Butt",
                "email": "jbutt@gmail.com",
                "location": "New Orleans"


            }, {
                "firstName": "Josephine",
                "lastName": "Darakjy",
                "email": "josephine_darakjy@darakjy.org",
                "location": "Brighton"
            }, {
                "firstName": "Art",
                "lastName": "Venere",
                "email": "art@venere.org",
                "location": "Bridgeport"
            }, {
                "firstName": "Lenna",
                "lastName": "Paprocki",
                "email": "lpaprocki@hotmail.com",
                "location": "Anchorage"
            }, {
                "firstName": "Donette",
                "lastName": "Foller",
                "email": "donette.foller@cox.net",
                "location": "Hamilton"
            },
            {
                "firstName": "Simona",
                "lastName": "Morasca",
                "email": "simona@morasca.com",
                "location": "Ashland"
            }
        ]
    }

    getcoursedata() {
        return this.coursedata = []

    }
}