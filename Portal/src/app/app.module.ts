import { NgModule } from '@angular/core';
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
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
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
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
        RouterModule.forRoot
            ([
                { path: "add-user", component: AddUserComponent },
                { path: "update-user", component: UpdateUserComponent },
                { path: "user-management", component: UserManagementComponent },
                { path: "add-course", component: AddCourseComponent },
                { path: "update-course", component: UpdateCourseComponent },
                { path: "course-management", component: CourseManagementComponent },
                { path: '**', component: PageNotFoundComponent }
            ]),
    ],
    providers: [UserService],
    bootstrap: [AppComponent]
})
export class AppModule { }
