import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

    selectedLinkNo: string = '1';
    constructor() { }

    ngOnInit(): void {
        this.selectedLinkNo = '1';
    }

    clickHandler(iNo: string) {
        console.log("clickHandler: ", iNo);
        this.selectedLinkNo = iNo;
    }

}
