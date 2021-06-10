var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Task } from './task';
let AppComponent = class AppComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.task = new Task();
        this.tableMode = true;
    }
    ngOnInit() {
        this.loadTasks();
    }
    loadTasks() {
        this.dataService.getTasks()
            .subscribe((data) => this.tasks = data);
    }
    save() {
        if (this.task.id == null) {
            this.dataService.createTask(this.task)
                .subscribe((data) => this.tasks.push(data));
        }
        else {
            this.dataService.updateTask(this.task)
                .subscribe(data => this.loadTasks());
        }
        this.cancel();
    }
    editTask(task) {
        this.task = task;
    }
    cancel() {
        this.task = new Task();
        this.tableMode = true;
    }
    delete(task) {
        this.dataService.deleteTask(task.id)
            .subscribe(data => this.loadTasks());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        providers: [DataService]
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map