import { Component, OnInit } from '@angular/core';
import { Task } from '../viewModel/task';
import { TaskService } from '../services/task.service';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    providers: [TaskService]
})
export class TaskListComponent implements OnInit {

    task: Task = new Task();
    tasks: Task[];
    tableMode: boolean = true;

    constructor(private dataService: TaskService) { }

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
