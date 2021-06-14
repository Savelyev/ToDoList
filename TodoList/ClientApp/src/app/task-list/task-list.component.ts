import { Component, OnInit } from '@angular/core';
import { TaskRequest } from '../viewModel/task/taskRequest';
import { TaskViewModel } from '../viewModel/task/taskViewModel';
import { TaskService } from '../services/task.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    providers: [TaskService]
})
export class TaskListComponent implements OnInit {

    public createTaskForm: FormGroup;
    public groupTasks: any[];

    constructor(private dataService: TaskService) { }

    ngOnInit() {
        this.createTaskForm = new FormGroup({
            title: new FormControl(''),
            description: new FormControl(''),
            dueDate: new FormControl(''),
            dueTime: new FormControl(''),
            priority: new FormControl(''),
            notificationPeriod: new FormControl(''),
        });
        this.loadTasks();
    }

    loadTasks() {
        this.groupTasks = []
        this.dataService.getTasks()
            .subscribe((data: TaskViewModel[]) => {
                data.forEach((element) => {
                    if (this.groupTasks[element.dueDate]) {
                        this.groupTasks[element.dueDate].push(element);
                    } else {
                        this.groupTasks[element.dueDate] = [element]  
                    }

                })
            });
    }

    public save = (formValue) => {
        const formValues = { ...formValue };
        const task: TaskRequest = {
            description: formValues.description,
            dueDateTime: new Date(formValues.dueDate + " " + formValues.dueTime),
            priority: Number(formValues.priority),
            title: formValues.title,
            notificationPeriod: Number(formValues.notificationPeriod),
        };
        this.dataService.createTask(task)
            .subscribe(() => this.loadTasks());
    }

    delete(task: TaskViewModel) {
        this.dataService.deleteTask(task.id)
            .subscribe(data => this.loadTasks());
    }
}
