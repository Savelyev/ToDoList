import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskListComponent } from './task-list.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
    declarations: [TaskListComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild([
            { path: '', component: TaskListComponent }
        ])
    ]
})
export class TaskModule { }