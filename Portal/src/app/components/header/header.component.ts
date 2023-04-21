import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit {

    headerTitle: string = '';
    constructor() { }

    ngOnInit(): void {
        this.headerTitle = "Advisory Database - 2023";
    }

}
