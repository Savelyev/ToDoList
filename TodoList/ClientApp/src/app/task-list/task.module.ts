import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskListComponent } from './task-list.component';
import { RouterModule } from '@angular/router';



@NgModule({
    declarations: [TaskListComponent],
    imports: [
        CommonModule,
        RouterModule.forChild([
            { path: '', component: TaskListComponent }
        ])
    ]
})
export class TaskModule { }