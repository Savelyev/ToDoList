import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from '../viewModel/task';

@Injectable()
export class TaskService {

    private url = "/api/tasks";

    constructor(private http: HttpClient) {
    }

    getTasks() {
        return this.http.get(this.url);
    }

    getTask(id: string) {
        return this.http.get(this.url + '/' + id);
    }

    createTask(task: Task) {
        return this.http.post(this.url, task);
    }
    updateTask(task: Task) {

        return this.http.put(this.url, task);
    }
    deleteTask(id: string) {
        return this.http.delete(this.url + '/' + id);
    }
}