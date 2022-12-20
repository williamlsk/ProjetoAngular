import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;

  constructor(private route: Router) { }

  ngOnInit() {

  }

  showMenu(): boolean {
    return this.route.url !== '/user/login';
  }

}
