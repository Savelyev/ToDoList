import { Component, OnInit } from '@angular/core';
import { Task } from '../viewModel/task';
import { TaskService } from '../services/task.service';
import { FormControl, FormGroup} from '@angular/forms';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    providers: [TaskService]
})
export class TaskListComponent implements OnInit {

    public createTaskForm: FormGroup;
    task: Task = new Task();
    tasks: Task[];
    tableMode: boolean = true;

    constructor(private dataService: TaskService) { }

    ngOnInit() {
        this.createTaskForm = new FormGroup({
            title: new FormControl(''),
            description: new FormControl(''),
            dueDateTime: new FormControl(''),
            priority: new FormControl(''),
        });
        this.loadTasks();
    }

    loadTasks() {
        this.dataService.getTasks()
            .subscribe((data: Task[]) => this.tasks = data);
    }

    sav2e() {
        if (this.task.id == null) {
            this.dataService.createTask(this.task)
                .subscribe((data: Task) => this.tasks.push(data));
        } else {
            this.dataService.updateTask(this.task)
                .subscribe(data => this.loadTasks());
        }
        this.cancel();
    }

    public save = (formValue) => {
        const formValues = { ...formValue };
        const task: Task = {
            description: formValues.description,
            dueDateTime: formValues.dueDateTime,
            priority: Number(formValues.priority),
            title: formValues.title,
        };
        if (this.task.id == null) {
            this.dataService.createTask(task)
                .subscribe((data: Task) => this.tasks.push(data));
        } else {
            this.dataService.updateTask(task)
                .subscribe(data => this.loadTasks());
        }
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
