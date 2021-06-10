import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Task } from './task';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    task: Task = new Task();   
    tasks: Task[];
    tableMode: boolean = true;     

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadTasks();
    }

    loadTasks() {
        this.dataService.getTasks()
            .subscribe((data: Task[]) => this.tasks = data);
    }

    save() {
        if (this.task.id == null) {
            this.dataService.createTask(this.task)
                .subscribe((data: Task) => this.tasks.push(data));
        } else {
            this.dataService.updateTask(this.task)
                .subscribe(data => this.loadTasks());
        }
        this.cancel();
    }

    editTask(task: Task) {
        this.task = task;
    }

    cancel() {
        this.task = new Task();
        this.tableMode = true;
    }

    delete(task: Task) {
        this.dataService.deleteTask(task.id)
            .subscribe(data => this.loadTasks());
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}