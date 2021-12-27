import { Injectable } from "@angular/core";
import { Toast } from "./toast.model";

@Injectable({ providedIn: 'root' })
export class ToastService {
    toasts: Toast[];

    constructor() {
        this.toasts = [];
    }

    addToast(title: string, message: string): void {
        var toast = new Toast(title, message);
        this.toasts.push(toast);
        setTimeout(() => {
            this.delete(toast);
        }, 5000);
    }

    delete(object: Toast): void {
        this.toasts = this.toasts.filter(p => p != object);
    }
}