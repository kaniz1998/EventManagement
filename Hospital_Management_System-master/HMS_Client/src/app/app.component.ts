import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HMS_Client';
  public loaderMessage: string = "loading test";

  public hideNav: boolean = false;
  constructor(private router: Router) {
    // router.events.subscribe((url:any) =>{
    //      if(router.url=='/sign-in' || router.url=='/sign-up'){
    //       this.hideNav=true;
    //      }

    //     });
  }
}
