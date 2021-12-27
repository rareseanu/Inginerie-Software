import { Component, Injectable, Input, OnInit } from '@angular/core';
import { Toast } from '../toast.model';
import { ToastService } from '../toast.service';


@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css']
})

export class ToastComponent implements OnInit {

  constructor(public toastService: ToastService) { 
  }

  ngOnInit(): void {
  }

  onClick(object: Toast): void {
    this.toastService.delete(object);
  }
}
