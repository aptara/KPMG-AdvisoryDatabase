// import { NgModule } from '@angular/core';
// import { BrowserModule } from "@angular/platform-browser";
// import { FormsModule, ReactiveFormsModule } from "@angular/forms";
// import { HttpClientModule } from "@angular/common/http";
// import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
// import { RouterModule } from "@angular/router";

// import { AppRoutingModule } from './app-routing.module';

// import { SelectButtonModule } from 'primeng/selectbutton';
// import { CalendarModule } from 'primeng/calendar';
// import { FieldsetModule } from 'primeng/fieldset';
// import { DividerModule } from 'primeng/divider';
// import { TabViewModule } from 'primeng/tabview';
// import { ButtonModule } from 'primeng/button';
// import { TableModule } from "primeng/table";
// import { TagModule } from "primeng/tag";
// import { SliderModule } from "primeng/slider";
// import { ProgressBarModule } from "primeng/progressbar";
// import { RadioButtonModule } from 'primeng/radiobutton';
// import { CheckboxModule } from 'primeng/checkbox';
// import { DropdownModule } from 'primeng/dropdown';
// import { InplaceModule } from 'primeng/inplace';
// import { InputSwitchModule } from 'primeng/inputswitch';
// import { InputTextModule } from 'primeng/inputtext';
// import { InputNumberModule } from 'primeng/inputnumber';
// import { InputTextareaModule } from 'primeng/inputtextarea';
// import { MultiSelectModule } from 'primeng/multiselect';

// import { HeaderComponent } from './components/header/header.component';
// import { UserDisplayComponent } from './components/user-display/user-display.component';
// import { UserManagementComponent } from './components/user-management/user-management.component';
// import { AppComponent } from './app.component';


// import { GridModule } from '@progress/kendo-angular-grid';
// import { IconsModule } from "@progress/kendo-angular-icons";
// import { InputsModule } from '@progress/kendo-angular-inputs';
// import { ButtonsModule } from '@progress/kendo-angular-buttons';
// import { UserService } from './service/userservice';
// import { AddCourseComponent } from './components/add-course/add-course.component';
// import { AddUserComponent } from './components/add-user/add-user.component';
// import { UpdateUserComponent } from './components/update-user/update-user.component';
// import { UpdateCourseComponent } from './components/update-course/update-course.component';
// import { CourseManagementComponent } from './components/course-management/course-management.component';
// import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
// import { MainBodyComponent } from './components/main-body/main-body.component';
// import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';



// @NgModule({
//     declarations: [
//         AppComponent,
//         HeaderComponent,
//         UserDisplayComponent,
//         UserManagementComponent,
//         AddCourseComponent,
//         AddUserComponent,
//         UpdateUserComponent,
//         UpdateCourseComponent,
//         CourseManagementComponent,
//         NavMenuComponent,
//         MainBodyComponent,
//     ],
//     imports: [
//         BrowserModule,
//         BrowserAnimationsModule,
//         HttpClientModule,
//         FormsModule,
//         RouterModule,
//         AppRoutingModule,
//         CheckboxModule,
//         DividerModule,
//         TabViewModule,
//         ButtonModule,
//         TableModule,
//         SliderModule,
//         RadioButtonModule,
//         ProgressBarModule,
//         TagModule,
//         DropdownModule,
//         InputTextModule,
//         InputNumberModule,
//         InputTextareaModule,
//         MultiSelectModule,
//         InplaceModule,
//         InputSwitchModule,
//         FieldsetModule,
//         CalendarModule,
//         SelectButtonModule,
//         GridModule,
//         IconsModule,
//         ButtonsModule,
//         InputsModule,
//         ReactiveFormsModule,

//         RouterModule.forRoot
//             ([
//                 { path: "add-user", component: AddUserComponent },
//                 { path: 'update-user/:UserMasterID', component: UpdateUserComponent },
//                 { path: "user-management", component: UserManagementComponent },
//                 { path: "add-course", component: AddCourseComponent },
//                 { path: "update-course", component: UpdateCourseComponent },
//                 { path: "course-management", component: CourseManagementComponent },
//                 { path: '**', component: PageNotFoundComponent }
//             ]),
//         InputsModule,
//     ],
//     providers: [UserService],
//     bootstrap: [AppComponent]
// })
// export class AppModule { }



import { NgModule } from '@angular/core';
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { RouterModule } from "@angular/router";

import { AppRoutingModule } from './app-routing.module';

import { SelectButtonModule } from 'primeng/selectbutton';
import { CalendarModule } from 'primeng/calendar';
import { FieldsetModule } from 'primeng/fieldset';
import { DividerModule } from 'primeng/divider';
import { TabViewModule } from 'primeng/tabview';
import { ButtonModule } from 'primeng/button';
import { TableModule } from "primeng/table";
import { TagModule } from "primeng/tag";
import { SliderModule } from "primeng/slider";
import { ProgressBarModule } from "primeng/progressbar";
import { RadioButtonModule } from 'primeng/radiobutton';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';
import { InplaceModule } from 'primeng/inplace';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { MultiSelectModule } from 'primeng/multiselect';

import { HeaderComponent } from './components/header/header.component';
import { UserDisplayComponent } from './components/user-display/user-display.component';
import { UserManagementComponent } from './components/user-management/user-management.component';
import { AppComponent } from './app.component';
import { UserService } from './service/userservice';
import { AddCourseComponent } from './components/add-course/add-course.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { UpdateUserComponent } from './components/update-user/update-user.component';
import { UpdateCourseComponent } from './components/update-course/update-course.component';
import { CourseManagementComponent } from './components/course-management/course-management.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { MainBodyComponent } from './components/main-body/main-body.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { IconModule } from '@progress/kendo-angular-icons';
import { DropDownButtonModule } from '@progress/kendo-angular-buttons';
import { DropDownListModule } from '@progress/kendo-angular-dropdowns';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from "@progress/kendo-angular-dropdowns";
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseComponent } from './components/course/course.component';
import { CourseService } from './service/course.service';
import { GridModule } from '@progress/kendo-angular-grid';
import { ConfirmationService, MessageService } from 'primeng/api';
import { SharedModule } from 'primeng/api';
import { MessagesModule } from "primeng/messages";
import { MessageModule } from "primeng/message";

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        UserDisplayComponent,
        UserManagementComponent,
        AddCourseComponent,
        AddUserComponent,
        UpdateUserComponent,
        UpdateCourseComponent,
        CourseManagementComponent,
        NavMenuComponent,
        MainBodyComponent,
        CourseListComponent,
        CourseComponent,
    ],
    imports: [
        BrowserModule,
        ButtonsModule,
        ReactiveFormsModule,
        DropDownsModule,
        InputsModule,
        IconModule,
        DropDownButtonModule,
        DropDownListModule,
        LabelModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        AppRoutingModule,
        CheckboxModule,
        DividerModule,
        TabViewModule,
        ButtonModule,
        TableModule,
        SliderModule,
        RadioButtonModule,
        ProgressBarModule,
        TagModule,
        DropdownModule,
        InputTextModule,
        InputNumberModule,
        InputTextareaModule,
        MultiSelectModule,
        InplaceModule,
        InputSwitchModule,
        FieldsetModule,
        CalendarModule,
        SelectButtonModule,
        SharedModule,
        DropdownModule,
        InputTextModule,
        InputTextareaModule,
        ButtonModule,
        FormsModule,
        MessagesModule,
        MessageModule,
        RouterModule.forRoot
            ([
                { path: "add-user", component: AddUserComponent },
                { path: "update-user/:UserMasterID", component: UpdateUserComponent },
                { path: "user-management", component: UserManagementComponent },
                { path: "add-course", component: AddCourseComponent },
                { path: "update-course", component: UpdateCourseComponent },
                { path: "course-management", component: CourseManagementComponent },
                { path: "course-List", component: CourseListComponent },
                { path: "course-details", component: CourseComponent },
                { path: '**', component: PageNotFoundComponent }
            ]),
        DateInputsModule,
        GridModule,
    ],
    providers: [
        UserService,
        CourseService,
        ConfirmationService,
        MessageService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
