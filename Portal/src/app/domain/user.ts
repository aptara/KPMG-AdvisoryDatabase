
export interface User {
    firstName?: string;
    lastName?: string;
    email?: string;
    location?: string;
}


export class CoursePermission {
    hasPermissionCreateCourse: boolean;
    hasPermissionUpdateCourse: boolean;
    hasPermissionDisableCourse: boolean;
    hasPermissionReviewCourse: boolean;
    hasPermissionEnableCourse: boolean;
    hasPermissionAddUpdateCourseID: boolean;
    hasPermissionExportCourse: boolean;
    hasPermissionDownloadCourseRDIforFocus: boolean;
    hasPermissionDownloadCourseRDIforClarizen: boolean;
    hasPermissionDownloadCourse: boolean;
    constructor() {
        this.hasPermissionCreateCourse = false
        this.hasPermissionUpdateCourse = false
        this.hasPermissionDisableCourse = false
        this.hasPermissionReviewCourse = false
        this.hasPermissionEnableCourse = false
        this.hasPermissionAddUpdateCourseID = false
        this.hasPermissionExportCourse = false
        this.hasPermissionDownloadCourseRDIforFocus = false
        this.hasPermissionDownloadCourseRDIforClarizen = false
        this.hasPermissionDownloadCourse = false
    }
}