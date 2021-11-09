import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  toggleRegister = false;
  
  constructor() { }

  ngOnInit(): void {
  }

  onToggle(): void{
    this.toggleRegister = !this.toggleRegister;
  }

}
